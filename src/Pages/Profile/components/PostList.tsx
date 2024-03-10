import usePost from "../../../hooks/usePost";
import postData from "../../../types/Interfaces/PostData";
import { GiEarthAfricaEurope, GiRapidshareArrow } from "react-icons/gi";
import { FaComment, FaRegComments, FaShare, FaThumbsUp } from "react-icons/fa6";
import { AiOutlineLike } from "react-icons/ai";
import useUser from "../../../hooks/useUser";
import { BsThreeDots } from "react-icons/bs";
import { IoClose } from "react-icons/io5";

const PostList = () => {
  const { userPosts } = usePost();
  const { userAuth } = useUser();

  if (!userPosts) {
    return <div>Loading...</div>;
  }

  if (userPosts.length === 0) {
    return <div>No posts found.</div>;
  }

  return (
    <div>
      {userPosts.map((post: postData) => (
        <div key={post.id} className="mb-4 bg-white shadow-lg rounded-lg">
          <div className="relative bg-white p-4 md:p-6 lg:p-8 my-4 rounded-md shadow-md">
            <div className="post-header flex justify-between ">
              <div className="flex items-center mb-4">
                <img
                  src={userAuth.profileImage}
                  alt={userAuth.username}
                  className="w-12 h-12 md:w-16 md:h-16 rounded-full mr-2"
                />
                <div className="info">
                  <span className="font-semibold text-lg md:text-xl hover:underline cursor-pointer">
                    {userAuth.firstName}
                    {userAuth.lastName}
                  </span>
                  <span className="text-gray-400 flex items-center text-sm md:text-base">
                    <GiEarthAfricaEurope />
                    {post.privacy}
                  </span>
                </div>
              </div>
              <div className="options flex font-bold text-xl md:text-2xl text-gray-400">
                <BsThreeDots />
                <IoClose />
              </div>
            </div>

            <p className="mb-4 text-base md:text-lg">{post.content}</p>

            <img
              src={post.imageUrl}
              alt="Post"
              className="w-full mb-4 rounded-md object-cover"
            />

            <div className="flex justify-between">
              <div className="flex items-center space-x-2 md:space-x-4">
                <button className="flex items-center space-x-1 md:space-x-2">
                  <FaThumbsUp className="text-xl md:text-2xl  text-blue-700" />
                  <span className="text-sm md:text-base">23 Likes</span>
                </button>
                <button className="flex items-center space-x-1 md:space-x-2">
                  <FaComment className="text-xl md:text-2xl text-green-300 " />
                  <span className="text-sm md:text-base">2 Comments</span>
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
        </div>
      ))}
    </div>
  );
};

export default PostList;
