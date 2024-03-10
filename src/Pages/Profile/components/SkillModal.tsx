import React, { useState } from "react";
import { Button, Modal } from "antd";
import SkillsData from "../../../types/Interfaces/SkillsData";

interface SkillModalProps {
  isOpen: boolean;
  onClose: () => void;
  onSave: (data: SkillsData) => void;
  skill?: SkillsData; // For editing existing skill
}

const SkillModal: React.FC<SkillModalProps> = ({
  isOpen,
  onClose,
  onSave,
  skill,
}) => {
  const [formData, setFormData] = useState<SkillsData>(
    skill || {
      name: "",
      description: "",
    }
  );

  const handleChange = (
    e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>
  ) => {
    const { name, value } = e.target;
    setFormData((prevData: SkillsData) => ({ ...prevData, [name]: value }));
  };

  const handleSave = () => {
    onSave(formData);
    onClose();
  };

  return (
    <Modal
      title="Add new skill"
      centered
      open={isOpen}
      onCancel={onClose}
      footer={[
        <Button key="back" onClick={onClose}>
          Return
        </Button>,
        <Button className="bg-blue-500" type="primary" onClick={handleSave}>
          Submit
        </Button>,
      ]}
    >
      <form>
        <label htmlFor="name">Name:</label>
        <input
          type="text"
          id="name"
          name="name"
          value={formData.name}
          onChange={handleChange}
          className="mt-1 p-2 border border-gray-300 outlined-blueColor rounded-md w-full"
        />

        <label htmlFor="description">Description:</label>
        <textarea
          id="description"
          name="description"
          value={formData.description}
          onChange={handleChange}
          className="mt-1 p-2 border border-gray-300 outlined-blueColor rounded-md w-full"
          placeholder="Enter some data here"
        />
      </form>
    </Modal>
  );
};

export default SkillModal;
