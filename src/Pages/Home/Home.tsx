import { useState } from "react";
import PostForm from "../../components/PostForm";
import Post from "./Post";
import ProfileCard from "./Profilecard";
import Sidemenu from "./Sidemenu";
import { jwtDecode } from "jwt-decode";
import axios from "../../Services/Auth/axiosConfig";

interface DecodedToken {
  "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier": string;
  // Add other necessary claims here
}
import { useEffect } from "react";
const Home = () => {
  const [userAuth, setUserAuth] = useState<any>(); // Adjust the type accordingly

  useEffect(() => {
    const fetchUserData = async () => {
      try {
        const token = localStorage.getItem("token");

        if (token) {
          const decodedToken: DecodedToken = jwtDecode(token);
          const userId =
            decodedToken[
              "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"
            ];

          const response = await axios.get(`/User/${userId}`, {
            headers: {
              Authorization: `Bearer ${token}`,
              "Content-Type": "application/json",
            },
          });

          setUserAuth(response.data);
        }
      } catch (error) {
        console.error("Error fetching user data:", error);
        // Handle error, e.g., redirect to the login page
      }
    };

    fetchUserData();
  }, []);

  const companiesData = [
    {
      id: 1,
      name: " Berus Sama  ",
      photo: "https://i1.sndcdn.com/artworks-000110170507-wr1zet-t500x500.jpg", // Replace with actual photo URL
      biography: "Lorem ipsum dolor sit amet.",
    },
    {
      id: 2,
      name: "Vegeta ",
      photo:
        "https://openseauserdata.com/files/c5fb8a2895d59faac55222c5f01f3e8d.jpg", // Replace with actual photo URL
      biography: "Sed do eiusmod tempor incididunt ..",
    },
    {
      id: 3,
      name: " Broly ",
      photo:
        "https://w0.peakpx.com/wallpaper/334/821/HD-wallpaper-saiyan-rage-broly-dbz-dragon-ball-dragon-ball-super-dragon-ball-z.jpg", // Replace with actual photo URL
      biography: "Ut enim ad minim veniam, ",
    },
  ];
  const posts = [
    {
      id: 1,
      avatar: "https://avatarfiles.alphacoders.com/218/218978.jpg",
      userName: "Trunks ",
      privacy: "public",
      postTitle: "This is a sample post!",
      postImage:
        "https://sm.ign.com/t/ign_za/feature/t/the-10-bes/the-10-best-dragon-ball-z-characters_vcm7.1200.jpg",
      likes: 10,
      comments: 5,
      shares: 3,
      biography: "Sayejins The son of vegeta ",
    },
    {
      id: 2,
      avatar:
        "https://animefanfest.com/wp-content/uploads/2022/09/1663352184_335_Dans-Dragon-Ball-Super-Whis-est-un-personnage-presque-totalement.jpg",
      userName: "Whise ",
      privacy: "public",
      postTitle: "this is my New Books about traning ",
      postImage:
        "https://goku-shop.fr/cdn/shop/articles/guide_ultime_whis_1.png?v=1610700470",
      likes: 65,
      comments: 5,
      shares: 3,
      biography: " the coach of goku and vegeta ",
    },
  ];
  return (
    <div className="grid mx-4 md:mx-8 lg:mx-16 xl:mx-32 2xl:mx-48 grid-cols-1 md:grid-cols-12 gap-4 pt-4">
      {/* Side Menu (Hidden on Phone) */}
      <div className="col-span-12 md:col-span-3 hidden md:block">
        <div className="p-4 bg-white rounded-md shadow-md">
          <p className="text-center">
            <Sidemenu companies={companiesData} />
          </p>
        </div>
      </div>

      {/* Main Content */}
      <div className="col-span-12 md:col-span-6">
        <div className="p-4 bg-white rounded-md shadow-md">
          <PostForm user={userAuth} />
        </div>

        {/* Display Posts */}
        {posts.map((post) => (
          <Post key={post.id} {...post} />
        ))}
      </div>

      {/* Profile Card (Hidden on Phone) */}
      <div className="col-span-12 md:col-span-3 hidden md:block">
        <div className="p-4 bg-white rounded-md shadow-md">
          <ProfileCard user={userAuth} />
        </div>
      </div>
    </div>
  );
};
export default Home;
