// src/hooks/useUser.ts

import { useQuery } from "react-query";
import axios from "../Services/Auth/axiosConfig";
import { jwtDecode } from "jwt-decode";
import { updateUserDetails } from "../Services/Api/userApi"; // Adjust the path accordingly
import UserData from "../types/Interfaces/UserData";

interface DecodedToken {
  "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier": string;
  // Add other necessary claims here
}

const fetchUserData = async (userId: string) => {
  const token = localStorage.getItem("token");

  if (!token) {
    throw new Error("Token not found");
  }

  const response = await axios.get(`/User/${userId}`, {
    headers: {
      Authorization: `Bearer ${token}`,
      "Content-Type": "application/json",
    },
  });

  return response.data;
};

const useUser = () => {
  const {
    data: userAuth,
    isLoading,
    isError,
  } = useQuery("user", async () => {
    const token = localStorage.getItem("token");

    if (!token) {
      throw new Error("Token not found");
    }

    const decodedToken: DecodedToken = jwtDecode(token);
    const userId =
      decodedToken[
        "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"
      ];

    return fetchUserData(userId);
  });

  const updateUser = async (userData: UserData) => {
    const token = localStorage.getItem("token");

    if (!token) {
      throw new Error("Token not found");
    }

    const decodedToken: DecodedToken = jwtDecode(token);
    const userId =
      decodedToken[
        "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"
      ];

    // Call the new method to update user details
    await updateUserDetails(userId, userData);
  };

  return { userAuth, loading: isLoading, error: isError, updateUser };
};

export default useUser;
