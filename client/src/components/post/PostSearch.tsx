import { debounce, TextField } from "@mui/material";
import { useAppDispatch, useAppSelector } from "../../store/store";
import { useState } from "react";
import { setPostParams } from "./postSlice";

const PostSearch = () => {
  const { postParams } = useAppSelector((state) => state.post);
  const dispatch = useAppDispatch();
  const [searchTerm, setSearchTerm] = useState(postParams.searchTerm);

  const debounceSearched = debounce((event: any) => {
    dispatch(setPostParams({ searchTerm: event.target.value }));
  }, 1000);

  return (
    <TextField
      label="Search Posts"
      variant="filled"
      fullWidth
      value={searchTerm || ""}
      onChange={(event: any) => {
        setSearchTerm(event.target.value);
        debounceSearched(event);
      }}
    />
  );
};

export default PostSearch;
