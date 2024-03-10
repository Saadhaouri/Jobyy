// src/components/JobExperienceCard.tsx

import React from "react";
// import { FaBriefcase } from "react-icons/fa";
import ExperienceData from "../../../types/Interfaces/JobExperience";

const ExperienceCard: React.FC<ExperienceData> = ({
  title,
  company,
  // startDate,
  // endDate,
  // description,
}) => {
  return (
    <div className="bg-white p-4 shadow-lg rounded-lg m-2">
      <div className="mt-2">
        <strong>{title}</strong>
        <p className="text-gray-700">
          <strong>Company:</strong> {company}
        </p>
        {/* <p className="text-gray-700">
          <strong>Duration:</strong> {new Date(startDate).toLocaleDateString()}{" "}
          - {new Date(endDate).toLocaleDateString()}
        </p>
        <p className="text-gray-700">
          <strong>Description:</strong> {description}
        </p> */}
      </div>
    </div>
  );
};

export default ExperienceCard;
