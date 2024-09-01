
import { Typography } from "@mui/material";

import PostList from "../components/post/PostList";
import React from "react";

const PostsPage = () => {
    return (
        <React.Fragment>
            <Typography variant="h4" sx={{mb: 5}}>Recent Posts</Typography>
        <PostList />
        
        </React.Fragment>
  );
};

export default PostsPage;
