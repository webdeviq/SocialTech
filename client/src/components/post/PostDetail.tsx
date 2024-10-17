import { useParams } from "react-router-dom";
import {
  Box,
  Button,
  Card,
  CardActions,
  CardContent,
  CardHeader,
  Divider,
  Grid,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableRow,
  Typography,
} from "@mui/material";
import DoneOutlineSharpIcon from "@mui/icons-material/DoneOutlineSharp";

import { useEffect } from "react";


import NotFound from "../../pages/NotFound";
import LoadingSpinner from "../loadingspinner/LoadingSpinner";

import { getOnePostAsync, postsSelectors } from "./postSlice";
import { useAppDispatch, useAppSelector } from "../../store/store";
import { dateParser } from "../../helper/date";

const PostDetail = () => {
  const dispatch = useAppDispatch();
  const { status } = useAppSelector((state) => state.post);
  const { id } = useParams<{ id: string }>();
  const post = useAppSelector((state) =>
    postsSelectors.selectById(state, parseInt(id!))
  );

  useEffect(() => {
    if (!post) {
      dispatch(getOnePostAsync(parseInt(id!)));
    }
  }, [post, dispatch, id]);

  if (status.includes("pending"))
    return <LoadingSpinner message="Loading post..." />;
  if (!post) return <NotFound />;

  return (
    <Grid container spacing={4} sx={{ marginTop: 3 }}>
      <Grid item xs={12}>
        <Typography variant="h5" sx={{ mb: 1 }}>
          {post.title}
        </Typography>
        <Divider sx={{ mb: 2 }} />
        <TableContainer>
          <Table>
            <TableBody>
              <TableRow>
                <TableCell>
                  <Typography variant="h6">Language</Typography>
                </TableCell>

                <TableCell>{post.category}</TableCell>
              </TableRow>
              <TableRow>
                <TableCell sx={{ width: "1%" }}>
                  <Typography variant="h6">Description</Typography>
                </TableCell>
                <TableCell>{post.description}</TableCell>
              </TableRow>
              <TableRow>
                <TableCell>
                  <Typography variant="h6">Posted By</Typography>
                </TableCell>
                <TableCell>
                  {post.postOwner.firstName + " " + post.postOwner.lastName}{" "}
                </TableCell>
              </TableRow>
              <TableRow>
                <TableCell>
                  <Typography variant="h6">Date</Typography>
                </TableCell>
                <TableCell>{dateParser(post.uploadedOn)}</TableCell>
              </TableRow>
              <TableRow>
                <TableCell>
                  <Typography variant="h6" sx={{ width: "150%" }}>
                    Answers
                  </Typography>
                </TableCell>
              </TableRow>
            </TableBody>
          </Table>
        </TableContainer>
        {post.postAnswers.map((answer) => (
          <Card key={answer.id} sx={{ mb: 3 }}>
            <CardHeader
              title={`Answered on ${dateParser(answer.answerDate)} by ${
                answer.answeredBy
              }`}
              titleTypographyProps={{
                sx: { fontSize: "1rem", fontWeight: "light" },
              }}
            />
            <CardContent>
              <Typography>{answer.answer}</Typography>
            </CardContent>
            <Box
              sx={{
                display: "flex",
                alignItems: "center",

                ml: 1,
                gap: 3,
                py: 1,
                px: 1,
              }}
            >
              {answer.answerAccepted ? (
                <DoneOutlineSharpIcon
                  sx={{ color: "green" }}
                  fontSize="large"
                />
              ) : null}
              {answer.answerAccepted ? (
                <Typography>Accepted On {dateParser("2024-01-20")}</Typography>
              ) : null}
              <CardActions>
                {!answer.answerAccepted ? (
                  <Button
                    onClick={() => console.log("Answer Accepted")}
                    variant="contained"
                  >
                    Accept
                  </Button>
                ) : null}
              </CardActions>
            </Box>
          </Card>
        ))}
      </Grid>
    </Grid>
  );
};

export default PostDetail;
