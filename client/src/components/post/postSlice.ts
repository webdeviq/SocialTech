import {
  createAsyncThunk,
  createEntityAdapter,
  createSlice,
} from "@reduxjs/toolkit";
import { Post, PostParams } from "../../models/post";
import agent from "../../agent/agent";
import { RootState } from "../../store/store";
import { MetaData } from "../../models/pagination";

const postsAdapter = createEntityAdapter<Post>();

const getAxiosParams = (postParams: PostParams) => {
  const params = new URLSearchParams();
  params.append("pageNumber", postParams.pageNumber.toString());
  params.append("pageSize", postParams.pageSize.toString());
  params.append("orderBy", postParams.orderBy);
  if (postParams.searchTerm) {
    params.append("searchTerm", postParams.searchTerm);
  }
  if (postParams.categories.length > 0) {
    params.append("categories", postParams.categories.toString());
  }
  return params;
};

interface PostState {
  postsLoaded: boolean;
  filtersLoaded: boolean;
  status: string;
  categories: string[];
  postParams: PostParams;
  metaData: MetaData | null;
}

const initParams = (): PostParams => {
  return {
    pageNumber: 1,
    pageSize: 6,
    orderBy: "name",
    categories: [],
  };
};
export const fetchFiltersAsync = createAsyncThunk(
  "posts/fetchFilters",
  async (_, thunkApi) => {
    try {
      return await agent.Post.getfilters();
    } catch (error: any) {
      return thunkApi.rejectWithValue({ error: error.data });
    }
  }
);
export const getAllPostsAsync = createAsyncThunk<
  Post[],
  void,
  { state: RootState }
>("posts/getAllPostsAsync", async (_, thunkApi) => {
  const params = getAxiosParams(thunkApi.getState().post.postParams);
  try {

    const response = await agent.Post.getallposts(params);

    thunkApi.dispatch(setMetaData(response.metaData));
    return response.items;
  } catch (error: any) {
    return thunkApi.rejectWithValue({ error: error.data });
  }
});

export const getOnePostAsync = createAsyncThunk<Post, number>(
  "posts/getOnePostAsync",
  async (postId: number, thunkApi) => {
    try {
      return await agent.Post.getonepost(postId);
    } catch (error: any) {
      
      return thunkApi.rejectWithValue({ error: error.data });
    }
  }
);

export const postSlice = createSlice({
  name: "postSlice",
  initialState: postsAdapter.getInitialState<PostState>({
    postsLoaded: false,
    status: "idle",
    filtersLoaded: false,
    categories: [],
    postParams: initParams(),
    metaData: null,
  }),
  reducers: {
    setMetaData: (state, action) => {
      state.metaData = action.payload;
    },
    resetPostParams: (state) => {
      state.postParams = initParams();
    },
    setPostParams: (state, action) => {
      state.postsLoaded = false;
      state.postParams = {
        ...state.postParams,
        ...action.payload,
        pageNumber: 1,
      };
    },
    setPageNumber: (state, action) => {
      state.postsLoaded = false;
      state.postParams = {
        ...state.postParams,
        ...action.payload,
      };
    },
  },
  extraReducers: (builder) => {
    builder.addCase(getAllPostsAsync.pending, (state) => {
      state.status = "pendingFetchAllPosts";
    });

    builder.addCase(getAllPostsAsync.fulfilled, (state, action) => {
      console.log(action.payload);
      postsAdapter.setAll(state, action.payload);
      state.status = "idle";
      state.postsLoaded = true;
    });
    builder.addCase(getAllPostsAsync.rejected, (state, action) => {
      console.log(action.payload);
      state.status = "idle";
    });
    builder.addCase(getOnePostAsync.pending, (state) => {
      state.status = "pendingFetchOnePost";
    });
    builder.addCase(getOnePostAsync.fulfilled, (state, action) => {
      postsAdapter.upsertOne(state, action.payload);
      state.status = "idle";
    });
    builder.addCase(getOnePostAsync.rejected, (state, action) => {
      console.log(action.payload);
      
      state.status = "idle";
    });
    builder.addCase(fetchFiltersAsync.pending, (state) => {
      state.status = "idle";
    });
    builder.addCase(fetchFiltersAsync.fulfilled, (state, action) => {
      state.filtersLoaded = true;
      state.categories = action.payload.categories;
      state.status = "idle";
    });
    builder.addCase(fetchFiltersAsync.rejected, (state, action) => {
      console.log(action.payload);
      state.status = "idle";
    });
  },
});

export const postsSelectors = postsAdapter.getSelectors(
  (state: RootState) => state.post
);

export const { setMetaData, setPageNumber, setPostParams, resetPostParams } =
  postSlice.actions;
