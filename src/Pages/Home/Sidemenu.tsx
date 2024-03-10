import { FaArrowRight, FaPlus } from "react-icons/fa6";
import { Link } from "react-router-dom";

interface Company {
  id: number;
  name: string;
  photo: string;
  biography: string;
}

interface CompanyListProps {
  companies: Company[];
}

const Sidemenu: React.FC<CompanyListProps> = ({ companies }) => {
  return (
    <div className=" font-poppins flex flex-col items-center   ">
      <div className="head-title  w-full text-left   ">
        <span className=" font-poppins font-semibold"> Companies : </span>{" "}
        <hr />
      </div>
      {companies.map((company) => (
        <div
          key={company.id}
          className=" w-full items-center  flex justify-between m-2  p-3 rounded-md shadow-md"
        >
          {/* Company Photo */}
          <div className="cnt flex ">
            <img
              className=" h-16 w-16 rounded-full "
              src={company.photo}
              alt={company.name}
            />

            {/* Company Name */}
            <div className=" ml-2 text-left ">
              <h3 className="text-lg font-semibold ">{company.name}</h3>
              <p className="text-gray-600">{company.biography}</p>
            </div>
          </div>

          <div>
            <button className=" bg-gray-200 text-textColor flex items-center p-1 rounded-lg justify-between hover:bg-blueColor hover:text-white transition  duration-700 ">
              <FaPlus />
              follow
            </button>
          </div>
        </div>
      ))}
      <div className="footer w-full flex items-center  pt-2 justify-center font-bold ">
        <Link to="companies" className=" flex items-center hover:underline ">
          {" "}
          more Compnies
          <FaArrowRight />{" "}
        </Link>
      </div>
    </div>
  );
};

export default Sidemenu;
