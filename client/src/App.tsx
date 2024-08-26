import { useState } from "react";
import PostList from "./components/post/PostList";

import Header from "./components/header/Header";
import {
  Container,
  createTheme,
  CssBaseline,
  ThemeProvider,
} from "@mui/material";

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
      <CssBaseline />
      <Header darkMode={darkMode} onHandleThemeChange={onHandleThemeChange} />
      <Container>
        <PostList />
      </Container>
    </ThemeProvider>
  );
};

export default App;
