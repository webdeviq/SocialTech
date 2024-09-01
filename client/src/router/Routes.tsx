import { createBrowserRouter, Navigate } from "react-router-dom";

import App from "../App";
import HomePage from "../pages/HomePage";
import SignupPage from "../pages/SignupPage";
import LoginPage from "../pages/LoginPage";
import PostDetailPage from "../pages/PostDetailPage";
import NotFound from "../pages/NotFound";
import TestErrorPage from "../pages/TestErrorPage";
import ServerError from "../pages/ServerError";
import PostsPage from "../pages/PostsPage";

const router = createBrowserRouter([
  {
    path: "/",
    element: <App />,
    children: [
      { path: "", element: <HomePage /> },
      { path: "posts", element: <PostsPage /> },
      { path: "posts/:id", element: <PostDetailPage /> },
      { path: "register", element: <SignupPage /> },
      { path: "login", element: <LoginPage /> },
      { path: "not-found", element: <NotFound /> },
      { path: "test-error", element: <TestErrorPage /> },
      { path: "server-error", element: <ServerError /> },
      { path: "*", element: <Navigate replace to="/not-found" /> },
    ],
  },
]);

export default router;
