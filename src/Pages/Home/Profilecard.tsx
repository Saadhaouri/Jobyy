import React from "react";
import { Link } from "react-router-dom";

interface User {
  profileImage: string;
  firstName?: string;
  lastName?: string;
  biography?: string;
}

interface ProfileCardProps {
  user: User;
}

const ProfileCard: React.FC<ProfileCardProps> = ({ user }) => {
  return (
    <div className="bg-white shadow-md rounded-md p-4 sm:p-6 md:p-8 mx-auto sm:max-w-md md:max-w-lg lg:max-w-xl xl:max-w-2xl">
      <img
        src={user?.profileImage}
        alt="Profile Picture"
        className="w-24 h-24 sm:w-32 sm:h-32 md:w-40 md:h-40 rounded-full mx-auto mb-4"
      />
      <h2 className="text-xl font-bold text-center mb-2">
        {`${user?.firstName} ${user?.lastName}`}
      </h2>
      <p className="text-gray-600 text-center mb-4">{user?.biography}</p>
      <div className="flex justify-center mb-4">
        <Link to="/profile" className="text-blue-500 hover:underline">
          View Profile
        </Link>
      </div>
      <div className="border-t pt-4">
        <p className="text-sm text-gray-600">
          <span className="font-bold">Location:</span> New York, USA
        </p>
        <p className="text-sm text-gray-600">
          <span className="font-bold">Connections:</span> 500+
        </p>
        <p className="text-sm text-gray-600">
          <span className="font-bold">Skills:</span> JavaScript, React, Node.js
        </p>
      </div>
    </div>
  );
};

export default ProfileCard;
