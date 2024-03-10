// shift + alt +_ o  = delete Unused imports
import { BiSearch } from "react-icons/bi";
import { CiHome, CiUser } from "react-icons/ci";
import { HiOutlineBuildingOffice2 } from "react-icons/hi2";
import { IoIosNotificationsOutline } from "react-icons/io";
import { IoBriefcaseOutline, IoLogOut } from "react-icons/io5";
import { Link } from "react-router-dom";
import authStore from "../stores/authStore";

const NavBar = () => {
  const { isAuth, logOut } = authStore();

  if (location.pathname === "/login") {
    return (
      <div className="Nav bg-white flex-no-wrap relative flex w-full items-center shadow-md pl-4 py-2">
        <div className="Logo flex items-center">
          <span className="text-blueColor text-[38px] font-bold">Joby</span>
        </div>
      </div>
    );
  }
  const handleLogOut = () => {
    logOut();
    localStorage.removeItem("token");
  };

  return (
    <div className="Nav bg-white flex-no-wrap relative flex flex-col md:flex-row w-full items-center justify-around shadow-md pl-4 py-2">
      <div className="flex items-center">
        <div className="Logo flex items-center">
          <span className="text-blueColor text-[38px] font-bold">Joby</span>
        </div>
        <div className="search ml-4 bg-greyIsh p-2 flex items-center rounded-md ">
          <BiSearch className="text-[20px] text-slate-500" />
          <input
            type="text"
            className="bg-transparent outline-none"
            placeholder="Search for something"
          />
        </div>
      </div>
      <div className="navigation flex items-center mt-4 md:mt-0">
        <Link
          to="/"
          className="link ml-4 mr-4 flex justify-center flex-col items-center"
        >
          <CiHome className="text-[26px] text-gray-500" />
          <span className="text-gray-500">Home</span>
        </Link>
        <Link
          to="companies"
          className="link ml-4 mr-4 flex justify-center flex-col items-center"
        >
          <HiOutlineBuildingOffice2 className="text-[26px] text-gray-500" />
          <span className="text-gray-500">Companies</span>
        </Link>
        <Link
          to="opportunity"
          className="link ml-4 mr-4 flex justify-center flex-col items-center"
        >
          <IoBriefcaseOutline className="text-[26px] text-gray-500" />
          <span className="text-gray-500">Jobs</span>
        </Link>
        <Link
          to=""
          className="link ml-4 mr-4 flex justify-center flex-col items-center"
        >
          <IoIosNotificationsOutline className="text-[26px] text-gray-500" />
          <span className="text-gray-500">Notification</span>
        </Link>
        <Link
          to="profile"
          className="link ml-4 mr-4 flex justify-center flex-col items-center"
        >
          <CiUser className="text-[26px] text-gray-500" />
          <span className="text-gray-500">Profile</span>
        </Link>
        {isAuth && (
          <button
            className="link ml-4 mr-4 flex justify-center flex-col items-center"
            onClick={handleLogOut}
          >
            <IoLogOut className="text-[26px] text-gray-500" />
            <span className="text-gray-500">Logout</span>
          </button>
        )}
      </div>
    </div>
  );
};

export default NavBar;
