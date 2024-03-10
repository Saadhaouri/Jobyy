import React, { useState } from "react";
import { Modal, Button, Input } from "antd";
import usePost from "../hooks/usePost";
import useUser from "../hooks/useUser";
import { PiSubtitlesFill } from "react-icons/pi";
import { ImFilePicture } from "react-icons/im";
import { IoEarth } from "react-icons/io5";

interface PostModalProps {
  isOpen: boolean;
  onClose: () => void;
  //token: string;
}

const PostModal: React.FC<PostModalProps> = ({ isOpen, onClose }) => {
  const { userAuth } = useUser();
  const [postData, setPostData] = useState({
    userId: userAuth.id,
    content: "",
    imageUrl: "",
    privacy: "",
  });

  const handleChange = (key: keyof typeof postData, value: string) => {
    setPostData((prevData) => ({
      ...prevData,
      [key]: value,
    }));
  };
  const { addNewPost } = usePost();
  const token = localStorage.getItem("token");

  const handlAddPost = () => {
    console.log(" hello ", postData);
    addNewPost(postData, token);
    // Pass your actual access token here
    onClose();
  };

  return (
    <Modal
      title="Add new post"
      centered
      open={isOpen}
      onCancel={onClose}
      footer={[
        <Button key="back" onClick={onClose}>
          Cancel
        </Button>,
        <Button className="bg-blue-500" type="primary" onClick={handlAddPost}>
          Submit
        </Button>,
      ]}
    >
      <Input
        placeholder="Content "
        value={postData.content}
        onChange={(e) => handleChange("content", e.target.value)}
        className=" mt-2"
        prefix={<PiSubtitlesFill className="  text-gray-500  text-[28px]" />}
      />
      <Input
        placeholder="Image URL"
        value={postData.imageUrl}
        onChange={(e) => handleChange("imageUrl", e.target.value)}
        className=" mt-2"
        prefix={<ImFilePicture className="   text-gray-500 text-[28px]" />}
      />
      <Input
        prefix={<IoEarth className="  text-gray-500  text-[28px]" />}
        placeholder="Privacy"
        value={postData.privacy}
        onChange={(e) => handleChange("privacy", e.target.value)}
        className=" mt-2"
      />
    </Modal>
  );
};

export default PostModal;
