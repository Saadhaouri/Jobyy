import { IoInformationCircleOutline } from "react-icons/io5";
import useUser from "../../../hooks/useUser";

const DetailsCard = () => {
  const { userAuth, loading, error } = useUser();

  return (
    <>
      <div className="mb-2 bg-white h-60 p-2 shadow-lg rounded-lg">
        <div className="hde flex items-center justify-between ">
          <h2 className="text-xl font-bold mb-2 flex items-center">
            <IoInformationCircleOutline className="text-blue-500 text-[2rem] mr-2" />
            Information:
          </h2>
        </div>
        <div className="bg-gray-100 p-4 rounded-lg shadow-md">
          <p className="text-lg font-bold mb-2">Information:</p>
          <p className="mb-2 text-[13px]">
            {" "}
            {userAuth.contact.city} {userAuth.contact.country}
          </p>
          <p className="mb-2 text-[13px]">{userAuth.contact.phone}</p>
        </div>
      </div>
    </>
  );
};

export default DetailsCard;
