import { Backdrop, Box, CircularProgress, Typography } from "@mui/material";
import React from "react";

interface Props {
  message: string;
}

const LoadingSpinner: React.FC<Props> = (props: Props) => {
  const { message } = props;
  return (
    <Backdrop invisible={true} open={true}>
      <Box
        sx={{
          display: "flex",
          justifyContent: "center",
          alignItems: "center",
          height: "100vh",
        }}
      >
        <CircularProgress size={100} color="secondary" />
        <Typography
          variant="h4"
          sx={{ justifyContent: "center", position: "fixed", top: "60%" }}
        >
          {message}
        </Typography>
      </Box>
    </Backdrop>
  );
};

export default LoadingSpinner;
