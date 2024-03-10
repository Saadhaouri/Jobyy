// ProtectedRoute.tsx
import React from "react";
import { Route, Navigate, RouteProps, Routes } from "react-router-dom";
import { useAuth } from "./Context/AuthContext";

interface ProtectedRouteProps extends RouteProps {
  element: React.ReactNode;
  path: string;
}

const ProtectedRoute: React.FC<ProtectedRouteProps> = ({
  element,
  ...rest
}) => {
  const { isAuthenticated } = useAuth();

  return isAuthenticated ? (
    <Routes>
      <Route {...rest} element={element} />
    </Routes>
  ) : (
    <Navigate to="/login" replace={true} />
  );
};

export default ProtectedRoute;
