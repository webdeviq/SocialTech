export type PostCategory =
  | "REACT"
  | "JAVASCRIPT"
  | "TYPESCRIPT"
  | "CSHARP"
  | "C"
  | "GO"
  | "R"
  | "PYTHON"
  | "LISP"
  | "LINQ"
  | "ANGULAR"
  | "NEXT"
  | "DOTNET"
  | "MVC"
  | "API"
  | "REST"
  | "SOAP"
  | "XML"
  | "JSON"
  | "CSV"
  | "FLUTTER";

export interface Post {
  id: number;
  title: string;
  description: string;
  postOwner: PostOwner;
  likes: number;
  category: PostCategory;
  uploadedOn: string;
  postAnswers: PostAnswer[];
}

export interface PostOwner {
  id: number;
  firstName: string;
  lastName: string;
  email: string;
}

export interface PostAnswer {
  id: number;
  answer: string;
  answerDate: string;
  answerAccepted: boolean;
  postId: number;
  answeredBy: string;
  answerAcceptedDate: string;
}
