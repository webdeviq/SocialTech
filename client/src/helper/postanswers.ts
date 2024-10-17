import { PostAnswer } from "../models/post";

export const postAnswerText = (input: PostAnswer[]) => {
  switch (input.length) {
    case 0:
      return "No Answers";
    case 1:
      return `${input.length} Answer`;
    default:
      return `${input.length} Answers`;
  }
};
