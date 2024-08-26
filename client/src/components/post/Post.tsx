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
import { Post as PostInterface } from "../../models/Post";
import { choosePostMediaImage } from "../../helper/imagepicker";
import ThumbUpOffAltOutlinedIcon from "@mui/icons-material/ThumbUpOffAltOutlined";

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
          sx: { fontWeight: "bold", color: "primary.dark", fontSize: "1.3rem" },
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
        <Typography variant="h6" color="grey.700">
          {post.description}
        </Typography>
        <Typography gutterBottom variant="caption" color="grey.800">
          Uploaded By {post.postOwner.firstName} {post.postOwner.lastName}
        </Typography>
      </CardContent>
      <CardActions>
        <ThumbUpOffAltOutlinedIcon
          onClick={() => console.log("Post Liked")}
          fontSize="large"
          sx={{ mr: 5, cursor: "pointer" }}
        />
        <Button size="large" variant="contained">
          View Post
        </Button>
      </CardActions>
    </Card>
  );
};

export default Post;
