import React from "react";
import { AiOutlineLike } from "react-icons/ai";
import { BsThreeDots } from "react-icons/bs";
import { FaComment, FaRegComments, FaShare, FaThumbsUp } from "react-icons/fa6";
import { GiEarthAfricaEurope, GiRapidshareArrow } from "react-icons/gi";
import { IoClose } from "react-icons/io5";
import CommentData from "../../types/Interfaces/CommentData";

interface PostProps {
  avatar: string;
  userName: string;
  privacy: string;
  postTitle: string;
  postImage: string;
  likes: number;
  comments: CommentData;
  biography: string;
}

const Post: React.FC<PostProps> = ({
  avatar,
  userName,
  privacy,
  postTitle,
  postImage,
  likes,
  comments,
}) => {
  return (
    <div className="relative bg-white p-4 md:p-6 lg:p-8 my-4 rounded-md shadow-md">
      <div className="post-header flex justify-between ">
        <div className="flex items-center mb-4">
          <img
            src={avatar}
            alt={userName}
            className="w-12 h-12 md:w-16 md:h-16 rounded-full mr-2"
          />
          <div className="info">
            <span className="font-semibold text-lg md:text-xl hover:underline cursor-pointer">
              {userName}
            </span>
            <span className="text-gray-400 flex items-center text-sm md:text-base">
              <GiEarthAfricaEurope />
              {privacy}
            </span>
          </div>
        </div>
        <div className="options flex font-bold text-xl md:text-2xl text-gray-400">
          <BsThreeDots />
          <IoClose />
        </div>
      </div>

      {/* User Information Tooltip */}

      {/* Post Content */}
      <p className="mb-4 text-base md:text-lg">{postTitle}</p>

      {/* Post Image */}
      <img
        src={postImage}
        alt="Post"
        className="w-full mb-4 rounded-md object-cover"
      />

      {/* Post Footer */}
      <div className="flex justify-between">
        <div className="flex items-center space-x-2 md:space-x-4">
          <button className="flex items-center space-x-1 md:space-x-2">
            <FaThumbsUp className="text-xl md:text-2xl  text-blue-700" />
            <span className="text-sm md:text-base">{likes} Likes</span>
          </button>
          <button className="flex items-center space-x-1 md:space-x-2">
            <FaComment className="text-xl md:text-2xl text-green-300 " />
            <span className="text-sm md:text-base">
              {comments.comment} Comments
            </span>
          </button>
        </div>
        <button className="flex items-center space-x-1 md:space-x-2">
          <FaShare className="text-xl md:text-2xl text-orange-200" />
          <span className="text-sm md:text-base"> 7 Shares</span>
        </button>
      </div>
      <hr className="mt-2" />
      <div className="action flex justify-around pt-2 md:pt-4">
        <button className="flex items-center justify-between text-base md:text-lg pb-2 pt-2 pl-2 pr-2 md:pl-4 md:pr-4 rounded-xl hover:bg-slate-200">
          <AiOutlineLike className="text-xl md:text-2xl" />
          Like
        </button>
        <button className="flex items-center justify-between text-base md:text-lg pb-2 pt-2 pl-2 pr-2 md:pl-4 md:pr-4 rounded-xl hover:bg-slate-200">
          <FaRegComments className="text-xl md:text-2xl mr-1" />
          Comment
        </button>
        <button className="flex items-center justify-between text-base md:text-lg pb-2 pt-2 pl-2 pr-2 md:pl-4 md:pr-4 rounded-xl hover:bg-slate-200">
          <GiRapidshareArrow className="text-xl md:text-2xl" />
          Share
        </button>
      </div>
    </div>
  );
};

export default Post;
