import axios from "../Auth/axiosConfig";
import PostData from "../../types/Interfaces/PostData";

const getPosts = async () => {
  const response = await axios.get("/Post");
  return response.data;
};

const getPostByUserId = async (userId: string) => {
  const response = await axios.get(`/Post/userId?userId=${userId}`);
  return response.data;
};

const getPostById = async (postId: string) => {
  const response = await axios.get(`/Post/${postId}`);
  return response.data;
};

const addPost = async (post: PostData) => {
  const response = await axios.post("/Post", post);
  return response.data;
};

const updatePost = async (postId: string, post: PostData) => {
  const response = await axios.put(`/Post/${postId}`, post);
  return response.data;
};

const deletePost = async (postId: string) => {
  const response = await axios.delete(`/Post/${postId}`);
  return response.data;
};

export {
  getPosts,
  getPostByUserId,
  getPostById,
  addPost,
  updatePost,
  deletePost,
};
