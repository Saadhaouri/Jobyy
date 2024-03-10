import { Button, DatePicker, Form, Input, Modal } from "antd";
import dayjs from "dayjs";
import { useState } from "react";
import { Controller, SubmitHandler, useForm } from "react-hook-form";
import { FcAddDatabase, FcDataBackup, FcDeleteDatabase } from "react-icons/fc";
import { LiaGraduationCapSolid } from "react-icons/lia";
import { toast } from "react-toastify";
import { updateUserDetails } from "../../../Services/Api/userApi";
import useUser from "../../../hooks/useUser";
import EducationData from "../../../types/Interfaces/EducationData";

const EducationParent = () => {
  const { userAuth } = useUser();
  const [isEditModalVisible, setEditModalVisible] = useState(false);
  const [currentIndex, setCurrentIndex] = useState<number | null>(null);
  const [isAddModalVisible, setAddModalVisible] = useState(false);
  // Delete tools methode
  const [isDeleteModalVisible, setDeleteModalVisible] = useState(false);
  const [deleteIndex, setDeleteIndex] = useState<number | null>(null);

  const { control, handleSubmit, setValue, reset } = useForm<EducationData>();

  const handleEditClick = (index: number) => {
    setCurrentIndex(index);
    setEditModalVisible(true);
  };

  const handleCancel = () => {
    setEditModalVisible(false);
  };

  const openAddEducationModal = () => {
    setAddModalVisible(true);
  };

  const handleAddCancel = () => {
    setAddModalVisible(false);
  };

  const onSubmit: SubmitHandler<EducationData> = async (data) => {
    // Validate and save the updated education data
    console.log("Updated Education Data:", data);
    if (userAuth && data) {
      const existingEducationIndex = currentIndex;

      if (existingEducationIndex !== undefined) {
        // Update the existing education
        userAuth.educations[existingEducationIndex] = data;
        console.log("Education Updated");
      }

      // Call the update function with the updated user data
      await updateUserDetails(userAuth.id, userAuth);
      toast.success("Education Updated Success", {
        position: "bottom-left",
      });
    }

    // Close the education modal after updating
    setEditModalVisible(false);
  };

  const onAddSubmit: SubmitHandler<EducationData> = async (data) => {
    // Validate and save the new education data
    console.log("New Education Data:", data);
    if (userAuth && data) {
      // Add the new education to the existing array
      userAuth.educations.push(data);
      console.log("Education Added");

      // Call the update function with the updated user data
      await updateUserDetails(userAuth.id, userAuth);
      toast.success("Education Added Successfully", {
        position: "bottom-left",
      });
      reset();
    }

    // Close the add education modal after updating
    setAddModalVisible(false);
  };

  //  DELETE METHODE
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
      // Remove the education entry from the array
      userAuth.educations.splice(deleteIndex, 1);

      // Call the update function with the updated user data
      updateUserDetails(userAuth.id, userAuth);

      toast.success("Education Deleted Successfully", {
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
            Education:
          </h2>
          <FcAddDatabase
            className=" mr-2 text-[28px] font-bold mb-2 cursor-pointer"
            onClick={openAddEducationModal}
          />
        </div>

        <div className="">
          {userAuth?.educations.map((exp: EducationData, index: number) => (
            <div
              key={index}
              className="mb-4 flex items-center justify-between p-4 bg-white shadow-md rounded-lg"
            >
              <div>
                <h5 className="text-md font-bold mb-2">{exp.degree}</h5>
                <p>{exp.major}</p>
                <p>{exp.school}</p>
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

      {/* Edit Education Modal */}
      <Modal
        title="Edit Education"
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
      >
        <Form>
          <Form.Item label="Degree">
            <Controller
              name="degree"
              control={control}
              defaultValue={
                currentIndex !== null
                  ? userAuth.educations[currentIndex].degree
                  : ""
              }
              render={({ field }) => <Input {...field} />}
            />
          </Form.Item>
          <Form.Item label="Major">
            <Controller
              name="major"
              control={control}
              defaultValue={
                currentIndex !== null
                  ? userAuth.educations[currentIndex].major
                  : ""
              }
              render={({ field }) => <Input {...field} />}
            />
          </Form.Item>
          <Form.Item label="School">
            <Controller
              name="school"
              control={control}
              defaultValue={
                currentIndex !== null
                  ? userAuth.educations[currentIndex].school
                  : ""
              }
              render={({ field }) => <Input {...field} />}
            />
          </Form.Item>
          <Form.Item label="Graduation Date">
            <Controller
              name="graduationDate"
              control={control}
              defaultValue={
                currentIndex !== null
                  ? dayjs(
                      userAuth.educations[currentIndex].graduationDate
                    ).format("YYYY-MM-DD")
                  : null
              }
              render={({ field }) => (
                <DatePicker
                  onChange={(date) => setValue("graduationDate", date)}
                  showTime
                  value={field.value ? dayjs(field.value) : null}
                />
              )}
            />
          </Form.Item>
        </Form>
      </Modal>

      {/* Add Education Modal */}
      <Modal
        title="Add Education"
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
            label="Degree"
            name="degree"
            rules={[{ required: true, message: "Please enter your degree!" }]}
          >
            <Controller
              name="degree"
              control={control}
              render={({ field }) => (
                <Input {...field} placeholder="Enter your degree" />
              )}
            />
          </Form.Item>
          <Form.Item
            label="Major"
            name="major"
            rules={[{ required: true, message: "Please enter your major!" }]}
          >
            <Controller
              name="major"
              control={control}
              render={({ field }) => (
                <Input {...field} placeholder="Enter your major" />
              )}
            />
          </Form.Item>
          <Form.Item
            label="School"
            name="school"
            rules={[{ required: true, message: "Please enter your school!" }]}
          >
            <Controller
              name="school"
              control={control}
              render={({ field }) => (
                <Input {...field} placeholder="Enter your school" />
              )}
            />
          </Form.Item>
          <Form.Item
            label="Graduation Date"
            name="graduationDate"
            rules={[
              {
                required: true,
                message: "Please select your graduation date!",
              },
            ]}
          >
            <Controller
              name="graduationDate"
              control={control}
              render={({ field }) => (
                <DatePicker
                  onChange={(date) => setValue("graduationDate", date)}
                  showTime
                  value={field.value ? dayjs(field.value) : null}
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
        <p>Are you sure you want to delete this education entry?</p>
      </Modal>
    </div>
  );
};

export default EducationParent;
