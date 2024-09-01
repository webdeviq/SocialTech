import { Grid, Typography } from "@mui/material";

import { Post as PostInterface } from "../../models/post.ts";
import Post from "./Post.tsx";
import { useEffect, useState } from "react";
import agent from "../../agent/agent.ts";
import LoadingSpinner from "../loadingspinner/LoadingSpinner.tsx";

const PostList = () => {
  const [posts, setPosts] = useState<PostInterface[]>([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    agent.Post.postlist()
      .then((response) => setPosts(response))
      .catch((error) => console.log(error))
      .finally(() => setLoading(false));
  }, []);
  console.log(loading);
  if (loading) return <LoadingSpinner message="Loading posts..." />;

  if (posts.length <= 0) {
    return <Typography variant="h4">No Posts To Show Yet....</Typography>;
  }

  return (
    <Grid container spacing={5}>
      {posts.map((post) => (
        <Grid item xs={12} key={post.id}>
          <Post post={post} />
        </Grid>
      ))}
    </Grid>
  );
};

export default PostList;
