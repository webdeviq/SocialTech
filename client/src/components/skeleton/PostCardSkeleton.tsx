import {
  Card,
  CardActions,
  CardContent,
  CardHeader,
  Skeleton,
} from "@mui/material";

import { Grid } from "@mui/material";

const PostCardSkeleton = () => {
  return (
    <Grid component={Card} sx={{ width: "60rem", ml: 8 }}>
      <CardHeader
        avatar={
          <Skeleton
            animation="wave"
            variant="circular"
            width={40}
            height={40}
          />
        }
        title={
          <Skeleton
            animation="wave"
            height={10}
            width="40%"
            style={{ marginBottom: 6 }}
          />
        }
      />
      <Skeleton sx={{ height: 190 }} animation="wave" variant="rectangular" />
      <CardContent>
        <>
          <Skeleton animation="wave" height={10} style={{ marginBottom: 6 }} />
          <Skeleton animation="wave" height={10} width="40%" />
        </>
      </CardContent>
      <CardActions>
        <Skeleton animation="wave" height={10} width="40%" />
        <Skeleton animation="wave" height={10} width="20%" />
      </CardActions>
    </Grid>
  );
};

export default PostCardSkeleton;
