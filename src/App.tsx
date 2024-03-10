import {
  BrowserRouter as Router,
  Routes,
  Route,
  Navigate,
} from "react-router-dom";
import Home from "./Pages/Home/Home";
import Opportonity from "./Pages/Opportonity";
import Profile from "./Pages/Profile/Profile";
import Companies from "./Pages/Companies";
import NavBar from "./components/NavBar";
import Login from "./Pages/Login";
import Register from "./Pages/Register";
import authStore from "./stores/authStore";
import { QueryClient, QueryClientProvider } from "react-query";
import { ReactQueryDevtools } from "react-query/devtools";
import { ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import { EducationProvider } from "./Context/EducationContext";

const queryClient = new QueryClient();

function App() {
  const isAuthenticated = authStore((state) => state.isAuth);

  return (
    <QueryClientProvider client={queryClient}>
      <EducationProvider>
        <div className="app font-poppins">
          <Router>
            <NavBar />
            <Routes>
              <Route
                path="/login"
                element={
                  isAuthenticated ? (
                    <Navigate to="/" replace={true} />
                  ) : (
                    <Login />
                  )
                }
              />
              <Route
                path="/register"
                element={
                  isAuthenticated ? (
                    <Navigate to="/" replace={true} />
                  ) : (
                    <Register />
                  )
                }
              />
              <Route
                path="/"
                element={isAuthenticated ? <Home /> : <Navigate to="/login" />}
              />
              <Route
                path="/profile"
                element={
                  isAuthenticated ? <Profile /> : <Navigate to="/login" />
                }
              />
              <Route
                path="/opportunity"
                element={
                  isAuthenticated ? <Opportonity /> : <Navigate to="/login" />
                }
              />
              <Route
                path="/companies"
                element={
                  isAuthenticated ? <Companies /> : <Navigate to="/login" />
                }
              />
            </Routes>
          </Router>
          <ReactQueryDevtools />
          <ToastContainer />
        </div>
      </EducationProvider>
    </QueryClientProvider>
  );
}

export default App;
