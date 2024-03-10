import SkillData from "../../types/Interfaces/SkillsData";
import axios from "../Auth/axiosConfig";

const getSkills = async () => {
  const response = await axios.get("/Skill");
  return response.data;
};

const getSkillById = async (skillId: string) => {
  const response = await axios.get(`/Skill/${skillId}`);
  return response.data;
};

const addSkill = async (skill: SkillData) => {
  const response = await axios.post("/Skill", skill);
  return response.data;
};

const updateSkill = async (skillId: string, skill: SkillData) => {
  const response = await axios.put(`/Skill/${skillId}`, skill);
  return response.data;
};

const deleteSkill = async (skillId: string) => {
  const response = await axios.delete(`/Skill/${skillId}`);
  return response.data;
};

export { getSkills, getSkillById, addSkill, updateSkill, deleteSkill };
