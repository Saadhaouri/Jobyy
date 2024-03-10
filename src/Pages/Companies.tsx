import { useState } from "react";

const Companies = () => {
  const [Case, setCase] = useState("");

  const handleShow = () => {
    setCase(Case !== "" ? "" : "Hello saad im here!!");
  };

  return (
    <div>
      <h1>{Case}</h1>
      <button onClick={handleShow} className="bg-red-300 p-4 text-white">
        Click me
      </button>
    </div>
  );
};

export default Companies;
