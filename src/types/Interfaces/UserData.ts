import ContactData from "./ContactData";
import EducationData from "./EducationData";
import ExperienceData from "./JobExperience";

interface UserData {
  Id?: string;
  firstName: string;
  lastName: string;
  jobTitle: string;
  biography: string;
  profileImage: string;
  dateOfBirth: string;
  resumeUrl: string;
  contact?: ContactData;
  educations?: EducationData[];
  experiences?: ExperienceData[];
}

export default UserData;
