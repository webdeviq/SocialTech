import { Box, Grid } from "@mui/material";

import Post from "./Post.tsx";

import { useAppSelector } from "../../store/store.ts";
import React from "react";
import PostCardSkeleton from "../skeleton/PostCardSkeleton.tsx";
import { Post as PostModel } from "../../models/post.ts";

interface Props {
  posts: PostModel[];
}

const PostList: React.FC<Props> = (props: Props) => {
  const { posts } = props;
  const { postsLoaded } = useAppSelector((state) => state.post);
  
  return (
    <React.Fragment>
      <Box sx={{ ml: 25 }}>
        <Grid container>
          {posts.map((post) => (
            <Grid item xs={12} key={post.id}>
              {!postsLoaded ? <PostCardSkeleton /> : <Post post={post} />}
            </Grid>
          ))}
        </Grid>
      </Box>
    </React.Fragment>
  );
};

export default PostList;
