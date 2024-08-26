import { AppBar, Toolbar, Typography, Switch } from "@mui/material";
import React from "react";

interface Props {
  darkMode: boolean;
  onHandleThemeChange: () => void;
}
const Header: React.FC<Props> = (props: Props) => {
  const { onHandleThemeChange, darkMode } = props;
  return (
    <AppBar position="static" sx={{ mb: 4 }}>
      <Toolbar>
        <Typography variant="h6">SocialTech</Typography>
        <Switch checked={darkMode} onChange={onHandleThemeChange} />
      </Toolbar>
    </AppBar>
  );
};

export default Header;
