import { Button, Form, Input, Modal } from "antd";
import { useState } from "react";
import { Controller, SubmitHandler, useForm } from "react-hook-form";
import { FcAddDatabase, FcDataBackup, FcDeleteDatabase } from "react-icons/fc";
import { LiaGraduationCapSolid } from "react-icons/lia";
import { toast } from "react-toastify";
import { updateUserDetails } from "../../../Services/Api/userApi";
import useUser from "../../../hooks/useUser";
import SkillData from "../../../types/Interfaces/SkillsData";

const SkillsParent = () => {
  const { userAuth } = useUser();
  const [isEditModalVisible, setEditModalVisible] = useState(false);
  const [currentIndex, setCurrentIndex] = useState<number | null>(null);
  const [isAddModalVisible, setAddModalVisible] = useState(false);
  const [isDeleteModalVisible, setDeleteModalVisible] = useState(false);
  const [deleteIndex, setDeleteIndex] = useState<number | null>(null);

  const { control, handleSubmit, setValue, reset } = useForm<SkillData>();

  const handleEditClick = (index: number) => {
    setCurrentIndex(index);
    setEditModalVisible(true);
  };

  const handleCancel = () => {
    setEditModalVisible(false);
  };

  const openAddSkillModal = () => {
    setAddModalVisible(true);
  };

  const handleAddCancel = () => {
    setAddModalVisible(false);
  };

  const onSubmit: SubmitHandler<SkillData> = async (data) => {
    if (userAuth && data) {
      const existingSkillIndex = currentIndex;

      if (existingSkillIndex !== undefined) {
        userAuth.skills[existingSkillIndex] = data;
        console.log("Skill Updated");
      }

      await updateUserDetails(userAuth.id, userAuth);
      toast.success("Skill Updated Successfully", {
        position: "bottom-left",
      });
      setEditModalVisible(false);
    }
  };

  const onAddSubmit: SubmitHandler<SkillData> = (data) => {
    console.log("New Skill Data:", data);
    if (userAuth && data) {
      userAuth.skills.push(data);
      console.log("Skill Added");

      updateUserDetails(userAuth.id, userAuth);
      toast.success("Skill Added Successfully", {
        position: "bottom-left",
      });
      reset();
    }

    setAddModalVisible(false);
  };

  const handleDeleteClick = (index: number) => {
    setDeleteIndex(index);
    setDeleteModalVisible(true);
  };

  const handleDeleteCancel = () => {
    setDeleteModalVisible(false);
    setDeleteIndex(null);
  };

  const handleDeleteConfirm = () => {
    if (deleteIndex !== null) {
      userAuth.skills.splice(deleteIndex, 1);
      updateUserDetails(userAuth.id, userAuth);

      toast.success("Skill Deleted Successfully", {
        position: "bottom-left",
      });

      setDeleteIndex(null);
    }

    setDeleteModalVisible(false);
  };

  return (
    <div>
      <div className="">
        <div className="hde flex items-center justify-between ">
          <h2 className="text-xl font-bold mb-2 flex items-center">
            <LiaGraduationCapSolid className="text-blue-500 text-[2rem] mr-2" />
            Skills:
          </h2>
          <FcAddDatabase
            className=" mr-2 text-[28px] font-bold mb-2 cursor-pointer"
            onClick={openAddSkillModal}
          />
        </div>

        <div>
          {userAuth?.skills.map((skill: SkillData, index: number) => (
            <div
              key={index}
              className="mb-4 flex items-center justify-between p-2 bg-violet-300 shadow-md rounded-lg"
            >
              <div>
                <h5 className="text-md text-white font-bold">{skill.name}</h5>
                {/* <p className=" flex items-center ">{skill.description}</p> */}
              </div>
              <div className=" flex justify-center items-center  ">
                <FcDataBackup
                  className="text-[28px] text-gray-500 cursor-pointer hover:text-gray-900"
                  onClick={() => handleEditClick(index)}
                />
                <FcDeleteDatabase
                  className="text-red-500  text-[28px] font-bold  cursor-pointer"
                  onClick={() => handleDeleteClick(index)}
                />
              </div>
            </div>
          ))}
        </div>
      </div>

      {/* Edit Skill Modal */}
      <Modal
        title="Edit Skill"
        open={isEditModalVisible}
        onCancel={handleCancel}
        footer={[
          <Button key="back" onClick={handleCancel}>
            Cancel
          </Button>,
          <Button
            key="submit"
            type="primary"
            className="bg-green-500 text-white"
            onClick={() => handleSubmit(onSubmit)()}
          >
            Save
          </Button>,
        ]}
      >
        <Form>
          <Form.Item label="Skill Name">
            <Controller
              name="name"
              control={control}
              defaultValue={
                currentIndex !== null ? userAuth.skills[currentIndex].name : ""
              }
              render={({ field }) => <Input {...field} />}
            />
          </Form.Item>
          <Form.Item label="Description">
            <Controller
              name="description"
              control={control}
              defaultValue={
                currentIndex !== null
                  ? userAuth.skills[currentIndex].description
                  : ""
              }
              render={({ field }) => <Input.TextArea {...field} />}
            />
          </Form.Item>
        </Form>
      </Modal>

      {/* Add Skill Modal */}
      <Modal
        title="Add Skill"
        open={isAddModalVisible}
        onCancel={handleAddCancel}
        footer={[
          <Button key="back" onClick={handleAddCancel}>
            Cancel
          </Button>,
          <Button
            key="submit"
            type="primary"
            className="bg-green-500 text-white"
            onClick={() => handleSubmit(onAddSubmit)()}
          >
            Save
          </Button>,
        ]}
      >
        <Form>
          <Form.Item
            label="Skill Name"
            name="name"
            rules={[
              { required: true, message: "Please enter the skill name!" },
            ]}
          >
            <Controller
              name="name"
              control={control}
              render={({ field }) => (
                <Input {...field} placeholder="Enter the skill name" />
              )}
            />
          </Form.Item>
          <Form.Item
            label="Description"
            name="description"
            rules={[
              {
                required: true,
                message: "Please enter the skill description!",
              },
            ]}
          >
            <Controller
              name="description"
              control={control}
              render={({ field }) => (
                <Input.TextArea
                  {...field}
                  placeholder="Enter the skill description"
                />
              )}
            />
          </Form.Item>
        </Form>
      </Modal>

      {/* Delete Confirmation Modal */}
      <Modal
        title="Confirm Delete"
        open={isDeleteModalVisible}
        onCancel={handleDeleteCancel}
        footer={[
          <Button key="cancel" onClick={handleDeleteCancel}>
            Cancel
          </Button>,
          <Button
            key="confirm"
            type="primary"
            danger
            onClick={handleDeleteConfirm}
            className=" bg-red-600 "
          >
            Confirm Delete
          </Button>,
        ]}
      >
        <p>Are you sure you want to delete this skill entry?</p>
      </Modal>
    </div>
  );
};

export default SkillsParent;
