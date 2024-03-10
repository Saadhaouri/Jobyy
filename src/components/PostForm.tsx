import React from "react";
import { MdArticle, MdPermMedia, MdWork } from "react-icons/md";

interface PostFormProps {
  user: {
    profileImage: string;
  };
}

const PostForm: React.FC<PostFormProps> = ({ user }) => {
  return (
    <div className="max-w-2xl mx-auto bg-white rounded-md">
      {/* Post Content */}
      <div className="posttext flex items-center justify-around">
        <img
          src={user?.profileImage}
          alt=""
          className="w-14 h-14 rounded-full shadow-lg"
        />
        <input
          type="text"
          className="w-full ml-1 border-gray-200 border-2 focus:outline-none p-4 rounded-full"
          placeholder="Share your ideas"
        />
      </div>
      <hr className="m-4" />
      {/* Actions */}
      <div className="flex justify-around items-center">
        {/* Add more actions or buttons as needed */}
        {[
          {
            icon: <MdPermMedia className="text-[28px] text-blueColor" />,
            text: "Photo / Video",
          },
          {
            icon: <MdWork className="text-[28px] text-violet-700" />,
            text: "Opportunity",
          },
          {
            icon: <MdArticle className="text-[28px] text-orange-500" />,
            text: "Article",
          },
        ].map((action, index) => (
          <div
            key={index}
            className="action flex items-center flex-col hover:bg-slate-100 rounded-md p-4 cursor-pointer"
          >
            {action.icon}
            <span>{action.text}</span>
          </div>
        ))}
      </div>
    </div>
  );
};

export default PostForm;
