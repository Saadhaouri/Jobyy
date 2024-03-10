import axios from "../Auth/axiosConfig";
import UserData from "../../types/Interfaces/UserData";

const getUserDetails = async (userId: string, token: string) => {
  const response = await axios.get(`/User/${userId}`, {
    headers: {
      Authorization: `Bearer ${token}`,
      "Content-Type": "application/json",
    },
  });

  return response.data;
};
const updateUserDetails = async (userId: string, userData: UserData) => {
  const response = await axios.put(`/User/${userId}`, userData);

  return response.data;
};

export { updateUserDetails };

export { getUserDetails };
