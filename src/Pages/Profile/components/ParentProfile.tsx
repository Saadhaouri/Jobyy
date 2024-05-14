import { Button, DatePicker, Form, Input, Modal } from "antd";
import dayjs from "dayjs";
import { useState } from "react";
import { Controller, useForm } from "react-hook-form";
import { IoSettingsOutline } from "react-icons/io5";
import { TbUserEdit } from "react-icons/tb";
import { updateUserDetails } from "../../../Services/Api/userApi";
import useUser from "../../../hooks/useUser";
import UserData from "../../../types/Interfaces/UserData";
import { toast } from "react-toastify";

interface ProfileProps {
  onSubmitHandler: () => void;
}

const ParentProfile: React.FC<ProfileProps> = () => {
  const { userAuth } = useUser();
  const [isEditModalVisible, setEditModalVisible] = useState(false);
  const { control, handleSubmit, setValue } = useForm();

  const handleCancel = () => {
    setEditModalVisible(false);
  };

  const onSubmitHandler = async (data: UserData) => {
    // Handle form submission
    console.log(data);

    if (userAuth && data) {
      // Update user information
      userAuth.username = data.username;
      userAuth.firstName = data.firstName;
      userAuth.lastName = data.lastName;
      userAuth.biography = data.biography;
      userAuth.dateOfBirth = data.dateOfBirth;
      userAuth.profileImage = data.profileImage;

      console.log("Information Updated");

      await updateUserDetails(userAuth.id, userAuth);
      toast.success("Information Updated Successfully", {
        position: "bottom-left",
      });

      // Close the modal after submission
      setEditModalVisible(false);
    }
  };

  return (
    <div>
      <div className="flex items-center justify-between mb-4 bg-white rounded-lg p-4 ">
        <div className="flex items-center">
          <img
            src={userAuth.profileImage}
            alt={`${userAuth.name}'s Profile`}
            className="rounded-full h-36 w-36 mr-4"
          />
          <div>
            <h1 className="text-2xl font-bold">
              {userAuth.firstName} {userAuth.lastName}
            </h1>
            <p className="text-gray-500">{userAuth.biography}</p>
          </div>
        </div>

        <div className="flex">
          <button
            onClick={() => setEditModalVisible(true)}
            className="  border border-blueColor text-blueColor hover:shadow-md hover:shadow-blue-100  px-4 py-2 mr-4 rounded-md flex items-center  "
          >
            <TbUserEdit className=" mr-1" />
            Edit
          </button>
          <button className="bg-blueColor hover:bg-blue-700 text-white px-4 py-2 rounded-md flex items-center ">
            <IoSettingsOutline className=" mr-1" />
            Settings
          </button>
        </div>
      </div>
      <Modal
        title="Edit information "
        open={isEditModalVisible}
        onCancel={handleCancel}
        footer={[
          <Button key="back" onClick={handleCancel}>
            Cancel
          </Button>,
          <Button
            key="submit"
            type="primary"
            className="bg-blueColor text-white"
            onClick={handleSubmit(onSubmitHandler)}
          >
            Save
          </Button>,
        ]}
      >
        <Form>
          <Form.Item label="First Name">
            <Controller
              name="firstName"
              control={control}
              defaultValue={userAuth.firstName || ""}
              render={({ field }) => <Input {...field} />}
            />
          </Form.Item>
          <Form.Item label="Last Name">
            <Controller
              name="lastName"
              control={control}
              defaultValue={userAuth.lastName || ""}
              render={({ field }) => <Input {...field} />}
            />
          </Form.Item>
          <Form.Item label="Biography">
            <Controller
              name="biography"
              control={control}
              defaultValue={userAuth.biography || ""}
              render={({ field }) => <Input.TextArea {...field} />}
            />
          </Form.Item>
          <Form.Item label="Date of Birth">
            <Controller
              name="dateOfBirth"
              control={control}
              defaultValue={
                userAuth.dateOfBirth
                  ? dayjs(userAuth.dateOfBirth).format("YYYY-MM-DD")
                  : null
              }
              render={({ field }) => (
                <DatePicker
                  onChange={(date) => setValue("dateOfBirth", date)}
                  value={field.value ? dayjs(field.value) : null}
                />
              )}
            />
          </Form.Item>
          <Form.Item label="Profile Image">
            <Controller
              name="profileImage"
              control={control}
              defaultValue={userAuth.profileImage || ""}
              render={({ field }) => <Input {...field} />}
            />
          </Form.Item>
          <Form.Item>
            <Button type="primary" htmlType="submit">
              Save
            </Button>
          </Form.Item>
        </Form>
      </Modal>
    </div>
  );
};

export default ParentProfile;
