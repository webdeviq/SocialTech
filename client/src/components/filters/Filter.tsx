import { Box, Paper } from "@mui/material";
import CheckBoxButton from "../checkboxbutton/CheckBoxButton";
import PostSearch from "../post/PostSearch";
import { setPostParams } from "../post/postSlice";
import RadioButtonGroup from "../radiobutton/RadioButtonGroup";
import { useAppDispatch, useAppSelector } from "../../store/store";
import React from "react";

const sortOptions = [
  { value: "name", label: "Alphabetical" },
  { value: "datePosted", label: "Oldest To New" },
  { value: "datePostedDescending", label: "Newest To Old" },
];

const Filter = () => {
  const dispatch = useAppDispatch();
  const { postParams, categories } = useAppSelector((state) => state.post);
  return (
    <React.Fragment>
      <Box
        sx={{
          position: "fixed",
          pb: 1,
          scrollBehavior: "smooth",
          width: "15rem",
        }}
      >
        <Paper sx={{ mb: 1 }}>
          <PostSearch />
        </Paper>
        <Paper sx={{ mb: 1, p: 1 }}>
          <RadioButtonGroup
            onChange={(e) =>
              dispatch(setPostParams({ orderBy: e.target.value }))
            }
            options={sortOptions}
            selectedValue={postParams.orderBy}
          />
        </Paper>
        <Paper sx={{ mb: 1, p: 1 }}>
          <CheckBoxButton
            items={categories}
            checked={postParams.categories}
            onChange={(items: string[]) =>
              dispatch(setPostParams({ categories: items }))
            }
          />
        </Paper>
      </Box>
    </React.Fragment>
  );
};

export default Filter;
