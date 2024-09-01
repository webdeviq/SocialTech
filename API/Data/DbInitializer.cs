using API.Entities;
using API.Models;

namespace API.Data
{
    public static class DbInitalizer
    {
        public static void Initialize(SocialTechContext context)
        {

            if (context.Users.Any()) return;
            if (context.Categories.Any()) return;
            if (context.Posts.Any()) return;

#pragma warning disable IDE0028 // Simplify collection initialization
            List<Category> categories = new() {
                 new Category {CategoryEnum = CategoryEnum.REACT},
                new Category {CategoryEnum = CategoryEnum.MVC},
                new Category {CategoryEnum = CategoryEnum.C},
                new Category {CategoryEnum = CategoryEnum.PYTHON},
                new Category {CategoryEnum = CategoryEnum.LINQ},
                new Category {CategoryEnum = CategoryEnum.R},
                new Category {CategoryEnum = CategoryEnum.ANGULAR},
                new Category {CategoryEnum = CategoryEnum.API},
                new Category {CategoryEnum = CategoryEnum.XML},
                new Category {CategoryEnum = CategoryEnum.TYPESCRIPT},
                new Category {CategoryEnum = CategoryEnum.SOAP},
                new Category {CategoryEnum = CategoryEnum.REST},
                new Category {CategoryEnum = CategoryEnum.NEXT},
                new Category {CategoryEnum = CategoryEnum.LISP},
                new Category {CategoryEnum = CategoryEnum.CSV},
                new Category {CategoryEnum = CategoryEnum.CSHARP},
                new Category {CategoryEnum = CategoryEnum.DOTNET},
                new Category {CategoryEnum = CategoryEnum.GO},
                new Category {CategoryEnum = CategoryEnum.JAVASCRIPT},
                new Category {CategoryEnum = CategoryEnum.JSON},
                new Category {CategoryEnum = CategoryEnum.FLUTTER },

            };
#pragma warning restore IDE0028 // Simplify collection initialization
#pragma warning disable IDE0028 // Simplify collection initialization
            List<User> users = new() {
                new User{ FirstName = "Scott", LastName="Mctaggart",
                Email="scott@hotmail.com"},
                new User { FirstName="Trevor", LastName="Davidson",
                Email="trevor@hotmail.com"},
                new User{ FirstName="Andy", LastName="Messer", Email="andy@hotmail.com"},
                new User{FirstName="Ibrahim", LastName="Abdullah", Email="ibrahim@hotmail.com"},
                new User{FirstName="David", LastName="Messer", Email="david@gmail.com"},
            };
#pragma warning restore IDE0028 // Simplify collection initialization
#pragma warning disable IDE0028 // Simplify collection initialization
            List<Post> posts = new() {
                new Post
                {CategoryId = 1,
                    Title = "How to use useState in React.Js",
                    Description = "I'm getting confused on how useState generics work, can anyone please explain to me how it works.",
                    Likes = 3,
                    UserId = 1,
                    PostDate = new DateTime(2024, 2, 20, 7, 30, 0),
                    Answers = new List<PostAnswer>() {new() {Answer="It's a hook that is used for state in a component' lifetime.", AnswerAccepted=false,
                    AnswerDate = new DateTime(2024, 2, 22, 5, 30, 0), UserId = 1} , new() {
                                                                Answer="useSate generics go between the angle brackets, and act as the type for the piece of state you set.",
                                                                AnswerAccepted=true,
                                                    AnswerDate = new DateTime(2024, 2, 26, 5, 30, 0),AnswerAcceptedDate =new DateTime(2024, 2, 28, 8, 30, 0) , UserId = 1}

                    } },
                new Post
                {
                    CategoryId = 10,
                    Title = "Typescript Interface Error",
                    Description = "I'm receiving this error in typescript 'interface error in file demo.ts'",
                    Likes = 5,
                    UserId = 1,
                    PostDate = new DateTime(2024, 2, 20, 7, 30, 0),
                    Answers = new List<PostAnswer>() {new() {Answer="Typescript comes with a packages.ts file, you can check the error there.", AnswerAccepted=false,
                    AnswerDate = new DateTime(2024, 2, 22, 5, 30, 0), UserId = 2} }
                },
                new Post
                {
                    CategoryId = 4,
                    Title = "Python classes syntax",
                    Description = "Can anyone give me a good course on python syntax, I'm getting conused with the classes syntax.",
                    Likes = 3,
                    UserId = 2,
                    PostDate = new DateTime(2024, 2, 20, 7, 30, 0),
                    Answers = new List<PostAnswer>() {new() {Answer="The python.org website is a really good website that has plenty of documentation.", AnswerAccepted=false,
                    AnswerDate = new DateTime(2024, 2, 22, 5, 30, 0), UserId=3} }
                },
                new Post
                {
                    CategoryId= 5,
                    Title = "Linq SQL Injection Vulnerability",
                    Description = "Were using LINQ in one of our .net projects and I'm receiving a SQL Injection vulnerability.",
                    Likes = 3,
                    UserId = 2,
                    PostDate = new DateTime(2024, 2, 20, 7, 30, 0),
                    Answers = new List<PostAnswer>() {new() {Answer="Just update all of your nuget packages and all will be ok.", AnswerAccepted=false,
                    AnswerDate = new DateTime(2024, 2, 22, 5, 30, 0), UserId=5} }
                },
                new Post
                {
                    CategoryId= 21,
                    Title = "App wide state in Flutter",
                    Description = "Is app wide state like redux in flutter? Can anyone point me in the right direction.",
                    Likes = 3,
                    UserId = 3,
                    PostDate = new DateTime(2024, 2, 20, 7, 30, 0),
                    Answers = new List<PostAnswer>() {new() {Answer="It's very similiar to React.JS , it's usually the same with these frameworks.", AnswerAccepted=false,
                    AnswerDate = new DateTime(2024, 2, 22, 5, 30, 0), UserId=4} }
                },
                new Post
                {
                    CategoryId= 18,
                    Title = "Is Go still being used",
                    Description = "Is Go still being used in the industry, should I even learn it for a career?",
                    Likes = 3,
                    UserId = 4,
                    PostDate = new DateTime(2024, 2, 20, 7, 30, 0),
                    Answers = new List<PostAnswer>() {new() {Answer="It's very well being used in the industry, plenty of apps are using it.", AnswerAccepted=false,
                    AnswerDate = new DateTime(2024, 2, 22, 5, 30, 0), UserId=3} }
                },
                new Post
                {
                    CategoryId= 1,
                    Title = "Using useEffect in React",
                    Description = "When does useEffect() run in React, is it before the component mounts or after?",
                    Likes = 3,
                    UserId = 4,
                    PostDate = new DateTime(2024, 2, 20, 7, 30, 0),
                    Answers = new List<PostAnswer>() {new() {Answer="useEffec() is run after the component runs and if any dependencies are changed.", AnswerAccepted=false,
                    AnswerDate = new DateTime(2024, 2, 22, 5, 30, 0), UserId=3} }
                },
                new Post
                {
                    CategoryId= 9,
                    Title = "XML Output incorrect",
                    Description = "How do I conditionally render XML tags? ",
                    Likes = 3,
                    UserId = 5,
                    PostDate = new DateTime(2024, 2, 20, 7, 30, 0),
                    Answers = new List<PostAnswer>() {new() {Answer="Use the ternary operator, it's very similiar to Javascript.", AnswerAccepted=false,
                    AnswerDate = new DateTime(2024, 2, 22, 5, 30, 0), UserId=5} }
                },
                new Post
                {
                    CategoryId= 1,
                    Title = "Infinite loop in useEffect() hook, please help.",
                    Description = "I'm getting an infinite loop with the useEffect hook in React.Js, I've tried to remove the <StrictMode> tags, but still no luck. Any help is greatly appreciated.",
                    Likes = 3,
                    UserId = 5,
                    PostDate = new DateTime(2024, 2, 20, 7, 30, 0),
                    Answers = new List<PostAnswer>() {new() {Answer="It sounds like you need to add and empty set of brackets as the dependency paramater and make sure to include any dependencies that you are using within the hook itself.",  AnswerAccepted=true,
                    AnswerDate = new DateTime(2024, 2, 22, 5, 30, 0),AnswerAcceptedDate = new DateTime(2024, 2, 25, 10, 30, 0), UserId=3} ,
                    new() { Answer="You need the empty brackets as the second argument to tell React run this hook once.",  AnswerAccepted=true,
                    AnswerDate = new DateTime(2024, 2, 22, 5, 30, 0),AnswerAcceptedDate = new DateTime(2024, 2, 28, 10, 30, 0), UserId=4} }
                },
                new Post
                {
                    CategoryId= 1,
                    Title = "How to use useState in React.Js",
                    Description = "I'm getting confused on how useState generics work, can anyone please explain to me how it works",
                    Likes = 3,
                    UserId = 5,
                    PostDate = new DateTime(2024, 2, 20, 7, 30, 0),
                    Answers = new List<PostAnswer>() {new() {Answer="It's a hook that is used for state in a component' lifetime", AnswerAccepted=false,
                    AnswerDate = new DateTime(2024, 2, 22, 5, 30, 0), UserId=3} }
                },
            };
#pragma warning restore IDE0028 // Simplify collection initialization

            //  context.Users.AddRange(users);
            // context.Categories.AddRange(categories);
            // context.Posts.AddRange(posts);


            context.SaveChanges();

        }
    }
}