import {
  Card,
  Avatar,
  Button,
  CardActions,
  CardContent,
  CardHeader,
  CardMedia,
  Typography,
} from "@mui/material";
import { Post as PostInterface } from "../../models/post.ts";
import { choosePostMediaImage } from "../../helper/imagepicker";
// import ThumbUpOffAltOutlinedIcon from "@mui/icons-material/ThumbUpOffAltOutlined";
import { Link } from "react-router-dom";
import { postAnswerText } from "../../helper/postanswers.ts";

interface Props {
  post: PostInterface;
}

const Post: React.FC<Props> = (props: Props) => {
  const { post } = props;

  return (
    <Card>
      <CardHeader
        avatar={
          <Avatar sx={{ bgcolor: "primary.light" }}>
            {post.category.charAt(0).toUpperCase()}
          </Avatar>
        }
        title={post.title}
        titleTypographyProps={{
          sx: { fontWeight: "bold", color: "primary.dark", fontSize: "1rem" },
        }}
      />
      <CardMedia
        component="img"
        alt="post category image"
        sx={{
          height: 140,
          backgroundSize: "contain",
          width: 300,
          objectFit: "contain",
          mx: 0,
        }}
        image={choosePostMediaImage(post.category)}
        title={post.title}
      />
      <CardContent>
        <Typography variant="h6" color="grey.700" fontWeight="bold">
          {post.description}
        </Typography>
        <Typography gutterBottom variant="caption" color="grey.800">
          Uploaded By {post.postOwner.firstName} {post.postOwner.lastName}
        </Typography>
      </CardContent>
      <CardActions>
        <Typography variant="h6" sx={{mr: 2}}>{post.postAnswers.length} {postAnswerText(post.postAnswers.length)}</Typography>
        {/* <ThumbUpOffAltOutlinedIcon
          fill="outlined"
          onClick={() => console.log("Post Liked")}
          fontSize="large"
          sx={{ mr: 5, cursor: "pointer" }}
        /> */}
        <Button
          component={Link}
          to={`/posts/${post.id}`}
          size="large"
          variant="contained"
        >
          View Post
        </Button>
      </CardActions>
    </Card>
  );
};

export default Post;
