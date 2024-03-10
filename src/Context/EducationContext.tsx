// EducationContext.tsx
import {
  createContext,
  useContext,
  useState,
  ReactNode,
  Dispatch,
  SetStateAction,
} from "react";
import EducationData from "../types/Interfaces/EducationData";

interface EducationContextType {
  educationData: EducationData | null;
  setEducationData: Dispatch<SetStateAction<EducationData | null>>;
}

const EducationContext = createContext<EducationContextType | undefined>(
  undefined
);

export const EducationProvider: React.FC<{ children: ReactNode }> = ({
  children,
}) => {
  const [educationData, setEducationData] = useState<EducationData | null>(
    null
  );

  return (
    <EducationContext.Provider value={{ educationData, setEducationData }}>
      {children}
    </EducationContext.Provider>
  );
};

export const useEducationContext = () => {
  const context = useContext(EducationContext);
  if (!context) {
    throw new Error(
      "useEducationContext must be used within an EducationProvider"
    );
  }
  return context;
};
