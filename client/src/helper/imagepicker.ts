import { PostCategory } from "../models/post";

/**
 * @param category
 * accepts a category of a post and returns the image url for the category.
 */

export const choosePostMediaImage = (category: PostCategory): string => {
  switch (category) {
    case "React":
      return "images/react.jpg";
    case "JAVASCRIPT":
      return "/images/javascript.jpg";
    case "TYPESCRIPT":
      return "/images/typescript.jpg";
    case "CSHARP":
      return "/images/csharp.jpg";
    case "C":
      return "/images/c.jpg";
    case "GO":
      return "/images/go.jpg";
    case "R":
      return "/images/r.jpg";
    case "PYTHON":
      return "/images/python.jpg";
    case "LISP":
      return "/images/lisp.jpg";
    case "LINQ":
      return "/images/linq.jpg";
    case "ANGULAR":
      return "/images/angular.jpg";
    case "NEXT":
      return "/images/next.jpg";
    case "DOTNET":
      return "/images/dotnet.jpg";
    case "MVC":
      return "/images/mvc.jpg";
    case "API":
      return "/images/api.jpg";
    case "REST":
      return "/images/rest.jpg";
    case "SOAP":
      return "/images/soap.png";
    case "XML":
      return "/images/xml.jpg";
    case "JSON":
      return "/images/json.jpg";
    case "CSV":
      return "/images/csv.jpg";
    case "FLUTTER":
      return "/images/flutter.jpg";
    default:
      return "";
  }
};
