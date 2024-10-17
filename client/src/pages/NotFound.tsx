import { Button, Container, Divider, Paper, Typography } from "@mui/material";
import { Link } from "react-router-dom";

const NotFound = () => {
  return (
    <Container component={Paper} sx={{ height: 400 }}>
      <Typography gutterBottom variant="h3">
        Oops couldn't find what your looking for in this app.
      </Typography>
      <Divider />
      <Button fullWidth component={Link} to="/">
        Home
      </Button>
    </Container>
  );
};

export default NotFound;
