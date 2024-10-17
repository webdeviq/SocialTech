import { createBrowserRouter, Navigate } from "react-router-dom";

import App from "../App";


import NotFound from "../pages/NotFound";
import TestErrorPage from "../pages/TestErrorPage";
import ServerError from "../pages/ServerError";
import CreatePostPage from "../pages/CreatePostPage";
import Signup from "../components/auth/Signup";
import Login from "../components/auth/Login";
import PostDetail from "../components/post/PostDetail";
import HomePage from "../pages/HomePage";

const router = createBrowserRouter([
  {
    path: "/",
    element: <App />,
    children: [
      { path: "", element: <HomePage/> },
      { path: "posts/:id", element: <PostDetail/> },
      {path: "myposts" , element: <h1>User Posts</h1>},
      { path: "register", element: <Signup /> },
      { path: "login", element: <Login /> },
      { path: "create-post", element: <CreatePostPage /> },
      { path: "not-found", element: <NotFound /> },
      { path: "test-error", element: <TestErrorPage /> },
      { path: "server-error", element: <ServerError /> },
      { path: "*", element: <Navigate replace to="/not-found" /> },
    ],
  },
]);

export default router;
