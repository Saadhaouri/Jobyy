// src/components/Profile.tsx

import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import Loading from "../../components/Loading";
import PostForm from "../../components/PostForm";
import PostModal from "../../components/PostModal";
import useUser from "../../hooks/useUser";
import SkillsData from "../../types/Interfaces/SkillsData";
import DetailsCard from "./components/DetailsCard";
import EducationParent from "./components/EducationParent";
import ExperienceParent from "./components/ExperienceParent";
import ParentProfile from "./components/ParentProfile";
import PostList from "./components/PostList";
import SkillModal from "./components/SkillModal";
import SkillsParent from "./components/SkillParent";
interface profilProps {
  index: number;
}
const Profile: React.FC<profilProps> = () => {
  const { userAuth, loading, error } = useUser();
  const [isSkillModalOpen, setSkillModalOpen] = useState(false);
  const [isPostModalOpen, setPostModalOpen] = useState(false);

  const navigate = useNavigate();

  useEffect(() => {
    if (error) {
      console.error("Error fetching user data:", error);
      navigate("/login");
    }
  }, [error, navigate]);

  if (loading) {
    return (
      <div className=" h-[100vh] w-full flex items-center justify-center">
        <Loading />
      </div>
    );
  }

  const closeSkillModal = () => {
    setSkillModalOpen(false);
  };

  const saveSkill = (skillData: SkillsData) => {
    // Handle saving the skill data, for example, send it to a server or update state
    console.log("Saving skill data:", skillData);
  };

  // the fuctions of post Modal
  const openPostModal = () => {
    setPostModalOpen(true);
  };

  const closePostModal = () => {
    setPostModalOpen(false);
  };

  return (
    <div className="container mx-auto p-4">
      <ParentProfile />
      <div className=" flex    justify-between gap-4">
        <div className="w-1/6 ">
          <div>
            <DetailsCard />
          </div>

          <div className=" bg-white rounded-lg  shadow-md p-4">
            <SkillsParent />
          </div>
        </div>

        <div className=" w-3/6  ">
          <div
            className="mb-4 bg-white p-4 shadow-lg rounded-lg   "
            onClick={openPostModal}
          >
            <PostForm user={userAuth} />
          </div>

          <PostList />
        </div>
        <div className="w-2/6  ">
          <div className="mb-4 bg-white p-4 shadow-lg rounded-lg ">
            <EducationParent />
          </div>
          <div className=" bg-white p-4 shadow-lg rounded-lg  ">
            <ExperienceParent />
          </div>
        </div>
      </div>

      <SkillModal
        isOpen={isSkillModalOpen}
        onClose={closeSkillModal}
        onSave={saveSkill}
      />
      {/* PostModal */}
      <PostModal isOpen={isPostModalOpen} onClose={closePostModal} />
      {/* Add more sections for additional user information (e.g., bio, activity feed, etc.) */}
    </div>
  );
};

export default Profile;
