import { Button, Container, Divider, Paper, Typography } from "@mui/material";
import { Link } from "react-router-dom";

const NotFound = () => {
  return (
    <Container component={Paper} sx={{ height: 400 }}>
      <Typography gutterBottom variant="h3">
        The resource you're looking for cannot be found...
      </Typography>
      <Divider />
      <Button fullWidth component={Link} to="/">
        Home
      </Button>
    </Container>
  );
};

export default NotFound;
