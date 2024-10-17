import {
    Box,
    Button,
    Divider,
    FormControl,
    Input,
    InputLabel,
    Typography,
  } from "@mui/material";
  import { Grid } from "@mui/material";
  import QuestionAnswerIcon from "@mui/icons-material/QuestionAnswer";
  import LightbulbIcon from "@mui/icons-material/Lightbulb";
  
  const FORMCONTROLSTYLES = { width: 200 };
  
  const Signup = () => {
    return (
      <>
        <Divider />
        <Grid
          container
          spacing={3}
          sx={{
            width: 500,
  
            mt: "10vh",
            position: "fixed",
          }}
        >
          <Grid item xs={12}>
            <Box
              sx={{
                display: "flex",
                alignItems: "center",
                justifyContent: "flex-start",
              }}
            >
              <img
                src="/images/young-man-programmer.jpg"
                alt="social tech logo"
                style={{ maxWidth: "8rem" }}
              />
              <Typography variant="h5" sx={{ ml: 2 }}>
                SocialTech
              </Typography>
            </Box>
          </Grid>
          <Grid item xs={12}>
            <Box
              sx={{
                display: "flex",
                alignContent: "center",
                justifyContent: "flex-start",
              }}
            >
              <QuestionAnswerIcon />
              <Typography variant="caption" sx={{ ml: 1, fontSize: "0.9rem" }}>
                Ask questions about the most popular technologies!
              </Typography>
            </Box>
          </Grid>
          <Grid item xs={12}>
            <Box
              sx={{
                display: "flex",
                alignContent: "center",
                justifyContent: "flex-start",
              }}
            >
              <LightbulbIcon />
              <Typography variant="caption" sx={{ ml: 1, fontSize: "0.9rem" }}>
                Learn by answering questions and engaging in discussions.
              </Typography>
            </Box>
          </Grid>
        </Grid>
        <Grid
          container
          spacing={2}
          sx={{
            border: "2px solid transparent",
            borderRadius: "5px",
            pb: "40px",
            boxShadow: 3,
            width: 500,
            ml: "45%",
            mt: "10vh",
          }}
        >
          <Grid item xs={12}>
            <Box>
              <Typography variant="h5" sx={{ fontWeight: "500" }}>
                Create your account
              </Typography>
            </Box>
          </Grid>
          <Grid item xs={6}>
            <FormControl sx={FORMCONTROLSTYLES}>
              <InputLabel htmlFor="firstname">First Name</InputLabel>
              <Input id="firstname" error={true} />
            </FormControl>
          </Grid>
          <Grid item xs={6}>
            <FormControl sx={FORMCONTROLSTYLES}>
              <InputLabel htmlFor="lastname">Last Name</InputLabel>
              <Input id="lastname" />
            </FormControl>
          </Grid>
          <Grid item xs={6}>
            <FormControl sx={FORMCONTROLSTYLES}>
              <InputLabel htmlFor="username">User Name</InputLabel>
              <Input id="username" />
            </FormControl>
          </Grid>
          <Grid item xs={6}>
            <FormControl sx={FORMCONTROLSTYLES}>
              <InputLabel htmlFor="username">Email</InputLabel>
              <Input id="username" />
            </FormControl>
          </Grid>
          <Grid item xs={6}>
            <FormControl sx={FORMCONTROLSTYLES}>
              <InputLabel htmlFor="username">Password</InputLabel>
              <Input id="username" />
            </FormControl>
          </Grid>
          <Grid item xs={6}>
            <Button
              variant="contained"
              disabled={true}
              sx={{ mt: "15px", width: "200px" }}
            >
              SIGN UP
            </Button>
          </Grid>
        </Grid>
      </>
    );
  };
  
  export default Signup;
  