import { useState } from "react";

import Header from "./components/header/Header";
import {
  Container,
  createTheme,
  CssBaseline,
  ThemeProvider,
} from "@mui/material";
import { Outlet } from "react-router-dom";
import { ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";

const App = () => {
  const [darkMode, setDarkMode] = useState<boolean>(false);

  // theme object and options
  const darkorlightpalette = darkMode ? "dark" : "light";
  const theme = createTheme({
    palette: {
      mode: darkorlightpalette,
      background: {
        default: darkorlightpalette === "light" ? "#eaeaea" : "#121212",
      },
    },
  });

  const onHandleThemeChange = () => {
    setDarkMode((prevThemeState) => !prevThemeState);
  };
  return (
    <ThemeProvider theme={theme}>
      <ToastContainer position="bottom-right" hideProgressBar theme="colored" />
      <CssBaseline />
      <Header darkMode={darkMode} onHandleThemeChange={onHandleThemeChange} />
      <Container>
        <Outlet />
      </Container>
    </ThemeProvider>
  );
};

export default App;
