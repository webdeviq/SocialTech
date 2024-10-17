import React, { useEffect } from "react";
import Filter from "../components/filters/Filter";
import AppPagination from "../components/pagination/AppPagination";
import {
  fetchFiltersAsync,
  getAllPostsAsync,
  postsSelectors,
  setPageNumber,
} from "../components/post/postSlice";
import LoadingSpinner from "../components/loadingspinner/LoadingSpinner";
import { useAppDispatch, useAppSelector } from "../store/store";
import PostList from "../components/post/PostList";

const HomePage = () => {
  const dispatch = useAppDispatch();
  const posts = useAppSelector(postsSelectors.selectAll);
  const { metaData, postsLoaded, filtersLoaded } = useAppSelector(
    (state) => state.post
    );
    console.log("Filters is " + filtersLoaded);

  useEffect(() => {
    if (!postsLoaded) {
      dispatch(getAllPostsAsync());
    }
  }, [dispatch, postsLoaded]);

  useEffect(() => {
    if (!filtersLoaded) {
      dispatch(fetchFiltersAsync());
    }
  }, [dispatch, filtersLoaded]);

  if (!filtersLoaded) {
    return <LoadingSpinner message="Loading Posts..." />;
  }
  console.log("Fitlers loaded is " + filtersLoaded);
  return (
    <React.Fragment>
      <Filter />
      <PostList posts={posts} />
      {metaData && (
        <AppPagination
          metaData={metaData}
          onPageChange={(page: number) => {
            dispatch(setPageNumber({ pageNumber: page }));
          }}
        />
      )}
    </React.Fragment>
  );
};

export default HomePage;
