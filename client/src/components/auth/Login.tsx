import {
    Box,
    Button,
    Divider,
    FormControl,
    Input,
    InputLabel,
  } from "@mui/material";
  import { Grid } from "@mui/material";
  
  const FORMCONTROLSTYLES = { width: 250 };
  
  const Login = () => {
    return (
      <>
        <Divider />
        <Grid
          container
          spacing={3}
          sx={{
            border: "2px solid transparent",
            borderRadius: "5px",
            pb: "40px",
            boxShadow: 3,
            width: 300,
            display: "flex",
            flexDirection: "column",
            alignItems: "flex-start",
            justifyContent: "center",
            ml: "auto",
            mr: "auto",
            mt: "10vh",
          }}
        >
          <Grid item xs={12}>
            <Box
              sx={{
                boxShadow: 2,
                ml: "4rem",
                
                mb: 1,
                
              }}
            >
              <img
                src="/images/young-man-programmer.jpg"
                style={{ maxWidth: "7rem" }}
              />
            </Box>
          </Grid>
          <Grid item xs={12}>
            <FormControl sx={FORMCONTROLSTYLES}>
              <InputLabel htmlFor="username">User name</InputLabel>
              <Input id="username" error={true} />
            </FormControl>
          </Grid>
          <Grid item xs={12}>
            <FormControl sx={FORMCONTROLSTYLES}>
              <InputLabel htmlFor="password">Password</InputLabel>
              <Input id="password" type="password" />
            </FormControl>
          </Grid>
          <Grid item xs={12}>
            <Box
              sx={{
                display: "flex",
                alignItems: "center",
                justifyContent: "center",
                width: "250px",
              }}
            >
              <Button
                variant="contained"
                disabled={true}
                sx={{ mt: "15px", mb: "10px", width: "100%" }}
                onClick={() => console.log("Logging in...")}
              >
                Log in
              </Button>
            </Box>
            <Divider />
          </Grid>
        </Grid>
      </>
    );
  };
  
  export default Login;
  