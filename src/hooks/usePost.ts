import { useQuery, useMutation } from "react-query";
// import axios from "../Services/Auth/axiosConfig";l
import {
  getPosts,
  getPostByUserId,
  getPostById,
  addPost as apiAddPost,
  updatePost as apiUpdatePost,
  deletePost as apiDeletePost,
} from "../Services/Api/PostApi";
// import postData from "../types/Interfaces/PostData";
import { jwtDecode } from "jwt-decode";

interface DecodedToken {
  // Define your PostWithCommentsViewModel interface here
  "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier": string;
}

const usePost = () => {
  const {
    data: posts,
    isLoading: isPostsLoading,
    isError: isPostsError,
  } = useQuery("posts", getPosts);

  const {
    data: userPosts,
    isLoading: isUserPostsLoading,
    isError: isUserPostsError,
  } = useQuery("userPosts", async () => {
    const token = localStorage.getItem("token");

    if (!token) {
      throw new Error("Token not found");
    }

    const decodedToken: DecodedToken = jwtDecode(token);
    const userId =
      decodedToken[
        "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"
      ];

    return getPostByUserId(userId);
  });

  const { mutate: addNewPost } = useMutation(apiAddPost);

  const { mutate: updateExistingPost } = useMutation(apiUpdatePost);

  const { mutate: removePost } = useMutation(apiDeletePost);

  return {
    posts,
    isPostsLoading,
    isPostsError,
    userPosts,
    isUserPostsLoading,
    isUserPostsError,
    addNewPost,
    updateExistingPost,
    removePost,
  };
};

export default usePost;
