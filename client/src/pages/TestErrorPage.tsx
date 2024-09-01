import {
  Alert,
  AlertTitle,
  Button,
  ButtonGroup,
  Container,
  List,
  ListItem,
  ListItemText,
  Typography,
} from "@mui/material";

import { useState } from "react";
import agent from "../agent/agent";

const TestErrorPage = () => {
  const [validationErrors, setValidationErrors] = useState<string[]>([]);
  const getValidationError = () => {
    agent.TestError.getValidationError()
      .then(() => console.log("Should not see this message..."))
      .catch((error) => setValidationErrors(error));
  };
  return (
    <Container>
      <Typography gutterBottom variant="h2">
        Errors for testing purposes
        <ButtonGroup fullWidth>
          <Button
            variant="contained"
            onClick={() =>
              agent.TestError.get400Error().catch((error) => console.log(error))
            }
          >
            Test 400 Error
          </Button>
          <Button
            variant="contained"
            onClick={() =>
              agent.TestError.get401Error().catch((error) => console.log(error))
            }
          >
            Test 401 Error
          </Button>
          <Button
            variant="contained"
            onClick={() =>
              agent.TestError.get404Error().catch((error) => console.log(error))
            }
          >
            Test 404 Error
          </Button>
          <Button
            variant="contained"
            onClick={() =>
              agent.TestError.get500Error().catch((error) => console.log(error))
            }
          >
            Test 500 Error
          </Button>
          <Button variant="contained" onClick={getValidationError}>
            Test Validation Error
          </Button>
        </ButtonGroup>
        {validationErrors.length > 0 && (
          <Alert severity="error">
            <AlertTitle>Validation Errors</AlertTitle>
            <List>
              {validationErrors.map((error) => (
                <ListItem key={error}>
                  <ListItemText>{error}</ListItemText>
                </ListItem>
              ))}
            </List>
          </Alert>
        )}
      </Typography>
    </Container>
  );
};

export default TestErrorPage;
