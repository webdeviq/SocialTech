import {
  AppBar,
  Toolbar,
  Typography,
  Switch,
  Box,
  List,
  ListItem,
} from "@mui/material";
import React from "react";
import { NavLink } from "react-router-dom";
import { getCookie } from "../../helper/getcookie";

const navStyles = {
  color: "inherit",
  
  textDecoration: "none",
  typography: "h6",

  width: "7rem",
  "&:hover": {
    color: "grey.500",
  },
  "&:active": {
    color: "text.secondary",
  },
};

const USERCOOKIE = "USERCOOKIE";
const rightLinks = [
  { path: "/myposts", text: "Posts" },
  { path: "/newpost", text: "Create" },
  { path: "/register", text: "Sign Up" },
  { path: "/login", text: "login" },
];

interface Props {
  darkMode: boolean;
  onHandleThemeChange: () => void;
}
const Header: React.FC<Props> = (props: Props) => {
  const { onHandleThemeChange, darkMode } = props;

  return (
    <AppBar position="sticky" sx={{ mb: 4 }}>
      <Toolbar sx={{ display: "flex", justifyContent: "space-between" }}>
        <Box sx={{ display: "flex", alignItems: "center" }}>
          <Typography component={NavLink} to="/" variant="h6" sx={navStyles}>
            SocialTech
          </Typography>
          <Switch checked={darkMode} onChange={onHandleThemeChange} />
        </Box>

        <Box>
          <List sx={{ display: "flex" }}>
            {rightLinks.map(({ path, text }) => {
              if (text === "Create" && !getCookie(USERCOOKIE)) return;
              if (text === "Posts" && !getCookie(USERCOOKIE)) return;  
              return (
                <ListItem

                  component={NavLink}
                  key={text}
                  to={path}
                  sx={navStyles}
                  
                >
                  {text.toUpperCase()}
                </ListItem>
              );
            })}
          </List>
        </Box>
      </Toolbar>
    </AppBar>
  );
};

export default Header;
