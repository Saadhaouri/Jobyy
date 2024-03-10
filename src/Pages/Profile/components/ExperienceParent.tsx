// ExperienceParent.jsx
import { Button, DatePicker, Form, Input, Modal } from "antd";
import dayjs from "dayjs";
import { useState } from "react";
import { Controller, SubmitHandler, useForm } from "react-hook-form";
import { BsBuildings } from "react-icons/bs";
import { FcAddDatabase, FcDataBackup, FcDeleteDatabase } from "react-icons/fc";
import { LiaGraduationCapSolid } from "react-icons/lia";
import { toast } from "react-toastify";
import { updateUserDetails } from "../../../Services/Api/userApi";
import useUser from "../../../hooks/useUser";
import ExperienceData from "../../../types/Interfaces/JobExperience";

const ExperienceParent = () => {
  const { userAuth } = useUser();
  const [isEditModalVisible, setEditModalVisible] = useState(false);
  const [currentIndex, setCurrentIndex] = useState<number | null>(null);
  const [isAddModalVisible, setAddModalVisible] = useState(false);
  // Delete tools method
  const [isDeleteModalVisible, setDeleteModalVisible] = useState(false);
  const [deleteIndex, setDeleteIndex] = useState<number | null>(null);

  const { control, handleSubmit, setValue, reset } = useForm<ExperienceData>();

  const handleEditClick = (index: number) => {
    setCurrentIndex(index);
    setEditModalVisible(true);
  };

  const handleCancel = () => {
    setEditModalVisible(false);
  };

  const openAddExperienceModal = () => {
    setAddModalVisible(true);
  };

  const handleAddCancel = () => {
    setAddModalVisible(false);
  };

  const onSubmit: SubmitHandler<ExperienceData> = async (data) => {
    if (userAuth && data) {
      const existingExperienceIndex = currentIndex;

      if (existingExperienceIndex !== undefined) {
        userAuth.experiences[existingExperienceIndex] = data;
        console.log("Experience Updated");
      }

      await updateUserDetails(userAuth.id, userAuth);
      toast.success("Experience Updated Successfully", {
        position: "bottom-left",
      });
      setEditModalVisible(false);
    }
  };

  const onAddSubmit: SubmitHandler<ExperienceData> = async (data) => {
    console.log("New Experience Data:", data);
    if (userAuth && data) {
      userAuth.experiences.push(data);
      console.log("Experience Added");

      await updateUserDetails(userAuth.id, userAuth);
      toast.success("Experience Added Successfully", {
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
      userAuth.experiences.splice(deleteIndex, 1);
      updateUserDetails(userAuth.id, userAuth);

      toast.success("Experience Deleted Successfully", {
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
            Experience:
          </h2>
          <FcAddDatabase
            className=" mr-2 text-[28px] font-bold mb-2 cursor-pointer"
            onClick={openAddExperienceModal}
          />
        </div>

        <div className="">
          {userAuth?.experiences.map((exp: ExperienceData, index: number) => (
            <div
              key={index}
              className="mb-4 flex items-center justify-between p-4 bg-white shadow-md rounded-lg"
            >
              <div>
                <h5 className="text-md font-bold mb-2">{exp.title}</h5>
                <p className=" flex items-center ">
                  <BsBuildings className=" text-xl mr-2" />
                  {exp.company}
                </p>
                {/* <p>
                  {exp.startDate} - {exp.endDate}
                </p> */}
                {/* <p className=" flex items-center ">
                  <PiTextAaLight className=" mr-2 text-xl" />
                  {exp.description}
                </p> */}
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

      {/* Edit Experience Modal */}
      <Modal
        title="Edit Experience"
        open={isEditModalVisible}
        onCancel={handleCancel}
        footer={[
          <Button key="back" onClick={handleCancel}>
            Cancel
          </Button>,
          <Button
            key="submit"
            type="primary"
            className="bg-red-500 text-white"
            onClick={() => handleSubmit(onSubmit)()}
          >
            Save
          </Button>,
        ]}
      ></Modal>

      {/* Add Experience Modal */}
      <Modal
        title="Add Experience"
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
            label="Title"
            name="title"
            rules={[{ required: true, message: "Please enter the title!" }]}
          >
            <Controller
              name="title"
              control={control}
              render={({ field }) => (
                <Input {...field} placeholder="Enter the title" />
              )}
            />
          </Form.Item>
          <Form.Item
            label="Company"
            name="company"
            rules={[{ required: true, message: "Please enter the company!" }]}
          >
            <Controller
              name="company"
              control={control}
              render={({ field }) => (
                <Input {...field} placeholder="Enter the company" />
              )}
            />
          </Form.Item>
          <Form.Item
            label="Start Date"
            name="startDate"
            rules={[
              { required: true, message: "Please select the start date!" },
            ]}
          >
            <Controller
              name="startDate"
              control={control}
              render={({ field }) => (
                <DatePicker
                  onChange={(date) => setValue("startDate", date)}
                  showTime
                  value={field.value ? dayjs(field.value) : null}
                />
              )}
            />
          </Form.Item>
          <Form.Item
            label="End Date"
            name="endDate"
            rules={[{ required: true, message: "Please select the end date!" }]}
          >
            <Controller
              name="endDate"
              control={control}
              render={({ field }) => (
                <DatePicker
                  onChange={(date) => setValue("endDate", date)}
                  showTime
                  value={field.value ? dayjs(field.value) : null}
                />
              )}
            />
          </Form.Item>
          <Form.Item
            label="Description"
            name="description"
            rules={[
              { required: true, message: "Please enter the description!" },
            ]}
          >
            <Controller
              name="description"
              control={control}
              render={({ field }) => (
                <Input.TextArea
                  {...field}
                  placeholder="Enter the description"
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
        <p>Are you sure you want to delete this experience entry?</p>
      </Modal>
    </div>
  );
};

export default ExperienceParent;
