import { Grid } from "@mui/material";

import { Post as PostInterface } from "../../models/Post.ts";
import Post from "./Post.tsx";
import { useEffect, useState } from "react";

const PostList = () => {
  const [posts, setPosts] = useState<PostInterface[]>([]);

  useEffect(() => {
    fetch("http://localhost:5001/api/posts")
      .then((result) => result.json())
      .then((posts) => setPosts(posts));
  }, []);
  return (
    <Grid container spacing={4}>
      {posts.map((post) => (
        <Grid item xs={12} key={post.id}>
          <Post post={post} />
        </Grid>
      ))}
    </Grid>
  );
};

export default PostList;
