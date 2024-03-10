// src/components/Register.tsx
import React, { useState, ChangeEvent, FormEvent } from "react";
import axios from "../Services/Auth/axiosConfig";
import { Link } from "react-router-dom";

interface FormData {
  firstName: string;
  lastName: string;
  email: string;
  password: string;
  confirmPassword: string;
}

const Register: React.FC = () => {
  const [formData, setFormData] = useState<FormData>({
    firstName: "",
    lastName: "",
    email: "",
    password: "",
    confirmPassword: "",
  });

  const handleChange = (e: ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    setFormData((prevData) => ({
      ...prevData,
      [name]: value,
    }));
  };

  const handleRegister = async (e: FormEvent) => {
    e.preventDefault();
    try {
      const response = await axios.post("/Account/signup", formData);
      console.log("Registration successful!", response.data);
    } catch (error) {
      console.error("Registration failed:", error);
    }
  };

  return (
    <div className="2xl:container h-screen m-auto">
      <div hidden className="fixed inset-0 w-7/12 lg:block">
        <span className="absolute left-6 bottom-6 text-sm">
          <a href="https://www.pexels.com/" target="_blank" title="Pexels">
            Pexels
          </a>
        </span>
        <img
          className="w-full h-full object-cover"
          src="https://f.hubspotusercontent30.net/hubfs/8110437/Blog%20Content/cv-job-hunting-wide.jpg"
          alt=""
        />
      </div>
      <div
        hidden
        role="hidden"
        className="fixed inset-0 w-6/12 ml-auto bg-white bg-opacity-70 backdrop-blur-xl lg:block"
      ></div>
      <div className="relative h-full ml-auto lg:w-6/12">
        <div className="m-auto py-12 px-6 sm:p-20 xl:w-10/12">
          <div className="space-y-4">
            <div className="logoDiv">
              <Link to="/">
                <h1 className="logo text-[45px] text-blueColor  text-center ">
                  <strong className="">Joby</strong>
                </h1>
              </Link>
            </div>

            <p className="font-medium text-lg text-gray-600  w-full  ">
              Create Your Account and Unlock Endless Opportunities!{" "}
            </p>
          </div>

          <form onSubmit={handleRegister} className="space-y-6 py-6">
            <div className="flex grid-cols-2 gap-4">
              <div>
                <input
                  type="text"
                  name="firstName"
                  placeholder="First Name"
                  value={formData.firstName}
                  onChange={handleChange}
                  className="w-full py-3 px-6 ring-1 ring-gray-300 rounded-xl placeholder-gray-600 bg-transparent transition disabled:ring-gray-200 disabled:bg-gray-100 disabled:placeholder-gray-400 invalid:ring-red-400 focus:invalid:outline-none"
                />
                {/* <p className=" text-red-500">{errors.firstname?.message}</p> */}
              </div>

              <div>
                <input
                  type="text"
                  name="lastName"
                  placeholder="Last Name"
                  value={formData.lastName}
                  onChange={handleChange}
                  className="w-full py-3 px-6 ring-1 ring-gray-300 rounded-xl placeholder-gray-600 bg-transparent transition disabled:ring-gray-200 disabled:bg-gray-100 disabled:placeholder-gray-400 invalid:ring-red-400 focus:invalid:outline-none"
                />
                {/* <p className=" text-red-500">{errors.lastname?.message}</p> */}
              </div>
            </div>

            <div>
              <input
                type="email"
                name="email"
                placeholder="Email or username "
                value={formData.email}
                onChange={handleChange}
                className="w-full py-3 px-6 ring-1 ring-gray-300 rounded-xl placeholder-gray-600 bg-transparent transition disabled:ring-gray-200 disabled:bg-gray-100 disabled:placeholder-gray-400 invalid:ring-red-400 focus:invalid:outline-none"
              />
              {/* <p className=" text-red-500">{errors.email?.message}</p> */}
            </div>

            <div>
              <input
                type="password"
                placeholder=" password "
                name="password"
                value={formData.password}
                onChange={handleChange}
                className="w-full py-3 px-6 ring-1 ring-gray-300 rounded-xl placeholder-gray-600 bg-transparent transition disabled:ring-gray-200 disabled:bg-gray-100 disabled:placeholder-gray-400 invalid:ring-red-400 focus:invalid:outline-none"
              />
              {/* <p className=" text-red-500">{errors.password?.message}</p> */}
            </div>

            <div>
              <input
                type="password"
                placeholder="Confirme Password"
                name="confirmPassword"
                value={formData.confirmPassword}
                onChange={handleChange}
                className="w-full py-3 px-6 ring-1 ring-gray-300 rounded-xl placeholder-gray-600 bg-transparent transition disabled:ring-gray-200 disabled:bg-gray-100 disabled:placeholder-gray-400 invalid:ring-red-400 focus:invalid:outline-none"
              />
              {/* <p className=" text-red-500">
                {errors.passwordConfirmation?.message}
              </p> */}
            </div>

            <div>
              <button
                type="submit"
                className="w-full px-6 py-3 rounded-xl bg-blueColor transition hover:bg-sky-600 focus:bg-sky-600 active:bg-sky-800"
              >
                <span className="font-semibold text-white text-lg">
                  Register
                </span>
              </button>
              <Link to="/login" className="w-max p-3 -ml-3">
                <span className="text-sm tracking-wide text-blue-600">
                  Already have an account? Login
                </span>
              </Link>
            </div>
          </form>
          <div className="border-t pt-12">
            <div className="space-y-2 text-center">
              <img src="" className="w-40 m-auto grayscale" alt="" />
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Register;
