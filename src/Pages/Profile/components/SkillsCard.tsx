// src/components/SkillsCard.tsx

import React from "react";
import SkillsDatatst from "../../../types/Interfaces/SkillsData";
import { FiEdit2 } from "react-icons/fi";

const SkillsCard: React.FC<Pick<SkillsDatatst, "name" | "description">> = ({
  name,
  // description,
}) => {
  return (
    <div className="bg-violet-400  p-4 shadow-lg mt-2 mb-2 rounded-lg">
      <div className=" flex justify-between items-center ">
        <p className="text-white  text-xs">
          <strong>{name}</strong>
        </p>
        <FiEdit2 className="text-white  hover:text-gray-400 cursor-pointer " />
        {/* <p className="text-gray-700 text-xs">
          <strong>Description:</strong> {description}
        </p> */}
      </div>
    </div>
  );
};

export default SkillsCard;
