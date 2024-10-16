import axios, { AxiosError, AxiosResponse } from "axios";
import { toast } from "react-toastify";
import router from "../router/Routes";
import { AcceptPostAnswer } from "../models/acceptpostanswer";
import { PaginatedResponse } from "../models/pagination";

const sleep = () => new Promise((resolve) => setTimeout(resolve, 2000));
axios.defaults.baseURL = "http://localhost:5001/api/";

const responseBody = (axiosResponse: AxiosResponse) => axiosResponse.data;

axios.interceptors.response.use(
  async (response) => {
    await sleep();
    const pagination = response.headers["pagination"];
    if (pagination) {
      response.data = new PaginatedResponse(
        response.data,
        JSON.parse(pagination),
      )
    }
    return response;
  },
  (error: AxiosError) => {
    const { data, status } = error.response as AxiosResponse;
    switch (status) {
      case 400:
        if (data.errors) {
          const modelStateErrors: string[] = [];
          for (const key in data.errors) {
            if (data.errors[key]) {
              modelStateErrors.push(data.errors[key]);
            }
          }
          throw modelStateErrors.flat();
        }
        toast.error(data.title);
        break;
      case 401:
        toast.error(data.title);
        break;
      case 500:
        router.navigate("/server-error", { state: { error: data } });
        break;
      default:
        break;
    }
  }
);

const requests = {
  get: (url: string, params? : URLSearchParams) => axios.get(url, {params}).then(responseBody),
  post: (url: string, body: object) => axios.post(url, body).then(responseBody),
  put: (url: string, body: object) => axios.put(url, body).then(responseBody),
  delete: (url: string, body: object) =>
    axios.delete(url, body).then(responseBody),
};

const Post = {
  getallposts: (params: URLSearchParams) => requests.get("posts",params), 
  getonepost: (postid: number) => requests.get(`posts/${postid}`), 
  getfilters: () => requests.get("posts/filters"),
};
const UserPost = {
  acceptanswer: (data: AcceptPostAnswer) => requests.put("posts", data),
}

const TestError = {
  get400Error: () => requests.get("buggy/bad-request"),
  get401Error: () => requests.get("buggy/unauthorised"),
  get404Error: () => requests.get("buggy/not-found"),
  get500Error: () => requests.get("buggy/server-error"),
  getValidationError: () => requests.get("buggy/validation-error"),
};

const agent = {
  Post,
  TestError,
  UserPost,
};

export default agent;
