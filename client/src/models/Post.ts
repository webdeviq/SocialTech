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
}

export interface PostOwner {
  id: number;
  firstName: string;
  lastName: string;
}
