import {
  AppBar,
  Toolbar,
  Typography,
  Switch,
  Box,
  List,
  ListItem,
  InputBase,
  Paper,
  IconButton,
} from "@mui/material";
import SearchIcon from "@mui/icons-material/Search";
import React from "react";
import { NavLink } from "react-router-dom";

const navStyles = {
  color: "inherit",
  textDecoration: "none",
  typography: "h6",
  "&:hover": {
    color: "grey.500",
  },
  "&:active": {
    color: "text.secondary",
  },
};

// const midLinks = [{ path: "/posts", text: "all posts" }];

const rightLinks = [
  { path: "/register", text: "register" },
  { path: "/login", text: "login" },
];

interface Props {
  darkMode: boolean;
  onHandleThemeChange: () => void;
}
const Header: React.FC<Props> = (props: Props) => {
  const { onHandleThemeChange, darkMode } = props;

  return (
    <AppBar position="static" sx={{ mb: 4 }}>
      <Toolbar sx={{ display: "flex", justifyContent: "space-between" }}>
        <Box sx={{ display: "flex", alignItems: "center" }}>
          <Typography component={NavLink} to="/" variant="h6" sx={navStyles}>
            SocialTech
          </Typography>
          <Switch checked={darkMode} onChange={onHandleThemeChange} />
        </Box>
        {/* <List sx={{ display: "flex" }}>
          {midLinks.map(({ path, text }) => (
            <ListItem component={NavLink} to={path} sx={navStyles}>
              {text.toUpperCase()}
            </ListItem>
          ))} */}
        <Paper
          component="form"
          onSubmit={(event: React.FormEvent) => {
            event.preventDefault();
            console.log("Submitted Search...");
          }}
          sx={{
            height: 1,
            width: 300,
            display: "flex",
            alignItems: "center",
            justifyContent: "space-evenly",
          }}
        >
          <InputBase placeholder="Search" sx={{ height: 10, pl: "5px" }} />
          <IconButton type="submit" aria-label="search">
            <SearchIcon />
          </IconButton>
        </Paper>
        {/* </List> */}
        <Box>
          <List sx={{ display: "flex" }}>
            {rightLinks.map(({ path, text }) => (
              <ListItem component={NavLink} key={text} to={path} sx={navStyles}>
                {text.toUpperCase()}
              </ListItem>
            ))}
          </List>
        </Box>
      </Toolbar>
    </AppBar>
  );
};

export default Header;
