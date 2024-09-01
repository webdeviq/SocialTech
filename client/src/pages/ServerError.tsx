import { Button, Container, Divider, Paper, Typography } from "@mui/material";
import { useLocation, useNavigate } from "react-router-dom";

const ServerError = () => {
  const { state } = useLocation();
  const navigate = useNavigate();

  return (
    <Container component={Paper}>
      {state.error ? (
        <>
          <Typography variant="h3" gutterBottom color="secondary">
            {state.error.title}
          </Typography>
          <Divider />
          <Typography variant="body1">
            {state.error.detail || "Internal server error..."}
          </Typography>
        </>
      ) : (
        <Typography variant="h5" gutterBottom>
          Server Error
        </Typography>
      )}
      <Button onClick={() => navigate("/posts")}>Go Back</Button>
    </Container>
  );
};

export default ServerError;
