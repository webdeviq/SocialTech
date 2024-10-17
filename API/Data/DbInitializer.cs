using API.Entities;
using Microsoft.AspNetCore.Identity;

namespace API.Data
{
    public static class DbInitalizer
    {
        public static async Task Initialize(SocialTechContext context, UserManager<User> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user1 = new User
                {
                    FirstName = "Chris",
                    LastName = "Harrison",

                    UserName = "chison",
                    Email = "chris@test.com"
                };
                await userManager.CreateAsync(user1, "Chris@3135");
                await userManager.AddToRoleAsync(user1, "Member");
                var user2 = new User
                {
                    FirstName = "Andy",
                    LastName = "Messer",
                    UserName = "amesser",

                    Email = "amesser@gmail.com",
                };
                await userManager.CreateAsync(user2, "Andy@3135");
                await userManager.AddToRoleAsync(user2, "Member");
                var user3 = new User
                {
                    FirstName = "Jennifer",
                    LastName = "Sutton",
                    Email = "jsutton@gmail.com",
                    UserName = "jstton",
                };
                await userManager.CreateAsync(user3, "Jen@3135");
                await userManager.AddToRoleAsync(user3, "Member");
                var admin = new User
                {
                    FirstName = "Ali",
                    LastName = "Dairawi",
                    UserName = "admin",
                    Email = "admin@test.com"
                };
                await userManager.CreateAsync(admin, "Admin@3135");
                await userManager.AddToRolesAsync(admin, ["Admin", "Member"]);
            }

            
            if (context.Categories.Any()) return;
            // if (context.Posts.Any()) return;


            List<Category> categories = [
                 new Category { Id = 1, CategoryName = "React" },
                new Category { Id = 2, CategoryName = "MVC" },
                new Category { Id = 3, CategoryName = "C" },
                new Category { Id = 4, CategoryName = "PYTHON" },
                new Category { Id = 5, CategoryName = "LINQ" },
                new Category { Id = 6, CategoryName = "R" },
                new Category { Id = 7, CategoryName = "ANGULAR" },
                new Category { Id = 8, CategoryName = "API" },
                new Category { Id = 9, CategoryName = "XML" },
                new Category { Id = 10, CategoryName = "TYPESCRIPT" },
                new Category { Id = 11, CategoryName = "SOAP" },
                new Category { Id = 12, CategoryName = "REST" },
                new Category { Id = 13, CategoryName = "NEXT" },
                new Category { Id = 14, CategoryName = "LISP" },
                new Category { Id = 15, CategoryName = "CSV" },
                new Category { Id = 16, CategoryName = "CSHARP" },
                new Category { Id = 17, CategoryName = "DOTNET" },
                new Category { Id = 18, CategoryName = "GO" },
                new Category { Id = 19, CategoryName = "JAVASCRIPT" },
                new Category { Id = 20, CategoryName = "JSON" },
                new Category { Id = 21, CategoryName = "FLUTTER" }
            ];



            // List<Post> posts = [
            //     new Post
            //     {CategoryId = 1,
            //         Title = "How to use useState in React.Js",
            //         Description = "I'm getting confused on how useState generics work, can anyone please explain to me how it works.",
            //         Likes = 3,
            //         UserId = 1,
            //         PostDate = new DateTime(2024, 2, 20, 7, 30, 0),
            //         Answers = new List<PostAnswer>() {new() {Answer="It's a hook that is used for state in a component' lifetime.", AnswerAccepted=false,
            //         AnswerDate = new DateTime(2024, 2, 22, 5, 30, 0), UserId = 1} , new() {
            //                                                     Answer="useSate generics go between the angle brackets, and act as the type for the piece of state you set.",
            //                                                     AnswerAccepted=true,
            //                                         AnswerDate = new DateTime(2024, 2, 26, 5, 30, 0),AnswerAcceptedDate =new DateTime(2024, 2, 28, 8, 30, 0) , UserId = 1}

            //         } },
            //     new Post
            //     {
            //         CategoryId = 10,
            //         Title = "Typescript Interface Error",
            //         Description = "I'm receiving this error in typescript 'interface error in file demo.ts'",
            //         Likes = 5,
            //         UserId = 1,
            //         PostDate = new DateTime(2024, 2, 20, 7, 30, 0),
            //         Answers = new List<PostAnswer>() {new() {Answer="Typescript comes with a packages.ts file, you can check the error there.", AnswerAccepted=false,
            //         AnswerDate = new DateTime(2024, 2, 22, 5, 30, 0), UserId = 2} }
            //     },
            //     new Post
            //     {
            //         CategoryId = 4,
            //         Title = "Python classes syntax",
            //         Description = "Can anyone give me a good course on python syntax, I'm getting conused with the classes syntax.",
            //         Likes = 3,
            //         UserId = 2,
            //         PostDate = new DateTime(2024, 2, 20, 7, 30, 0),
            //         Answers = new List<PostAnswer>() {new() {Answer="The python.org website is a really good website that has plenty of documentation.", AnswerAccepted=false,
            //         AnswerDate = new DateTime(2024, 2, 22, 5, 30, 0), UserId=3} }
            //     },
            //     new Post
            //     {
            //         CategoryId= 5,
            //         Title = "Linq SQL Injection Vulnerability",
            //         Description = "Were using LINQ in one of our .net projects and I'm receiving a SQL Injection vulnerability.",
            //         Likes = 3,
            //         UserId = 2,
            //         PostDate = new DateTime(2024, 2, 20, 7, 30, 0),
            //         Answers = new List<PostAnswer>() {new() {Answer="Just update all of your nuget packages and all will be ok.", AnswerAccepted=false,
            //         AnswerDate = new DateTime(2024, 2, 22, 5, 30, 0), UserId=5} }
            //     },
            //     new Post
            //     {
            //         CategoryId= 21,
            //         Title = "App wide state in Flutter",
            //         Description = "Is app wide state like redux in flutter? Can anyone point me in the right direction.",
            //         Likes = 3,
            //         UserId = 3,
            //         PostDate = new DateTime(2024, 2, 20, 7, 30, 0),
            //         Answers = new List<PostAnswer>() {new() {Answer="It's very similiar to React.JS , it's usually the same with these frameworks.", AnswerAccepted=false,
            //         AnswerDate = new DateTime(2024, 2, 22, 5, 30, 0), UserId=4} }
            //     },
            //     new Post
            //     {
            //         CategoryId= 18,
            //         Title = "Is Go still being used",
            //         Description = "Is Go still being used in the industry, should I even learn it for a career?",
            //         Likes = 3,
            //         UserId = 4,
            //         PostDate = new DateTime(2024, 2, 20, 7, 30, 0),
            //         Answers = new List<PostAnswer>() {new() {Answer="It's very well being used in the industry, plenty of apps are using it.", AnswerAccepted=false,
            //         AnswerDate = new DateTime(2024, 2, 22, 5, 30, 0), UserId=3} }
            //     },
            //     new Post
            //     {
            //         CategoryId= 1,
            //         Title = "Using useEffect in React",
            //         Description = "When does useEffect() run in React, is it before the component mounts or after?",
            //         Likes = 3,
            //         UserId = 4,
            //         PostDate = new DateTime(2024, 2, 20, 7, 30, 0),
            //         Answers = new List<PostAnswer>() {new() {Answer="useEffec() is run after the component runs and if any dependencies are changed.", AnswerAccepted=false,
            //         AnswerDate = new DateTime(2024, 2, 22, 5, 30, 0), UserId=3} }
            //     },
            //     new Post
            //     {
            //         CategoryId= 9,
            //         Title = "XML Output incorrect",
            //         Description = "How do I conditionally render XML tags? ",
            //         Likes = 3,
            //         UserId = 5,
            //         PostDate = new DateTime(2024, 2, 20, 7, 30, 0),
            //         Answers = new List<PostAnswer>() {new() {Answer="Use the ternary operator, it's very similiar to Javascript.", AnswerAccepted=false,
            //         AnswerDate = new DateTime(2024, 2, 22, 5, 30, 0), UserId=5} }
            //     },
            //     new Post
            //     {
            //         CategoryId= 1,
            //         Title = "Infinite loop in useEffect() hook, please help.",
            //         Description = "I'm getting an infinite loop with the useEffect hook in React.Js, I've tried to remove the <StrictMode> tags, but still no luck. Any help is greatly appreciated.",
            //         Likes = 3,
            //         UserId = 5,
            //         PostDate = new DateTime(2024, 2, 20, 7, 30, 0),
            //         Answers = new List<PostAnswer>() {new() {Answer="It sounds like you need to add and empty set of brackets as the dependency paramater and make sure to include any dependencies that you are using within the hook itself.",  AnswerAccepted=true,
            //         AnswerDate = new DateTime(2024, 2, 22, 5, 30, 0),AnswerAcceptedDate = new DateTime(2024, 2, 25, 10, 30, 0), UserId=3} ,
            //         new() { Answer="You need the empty brackets as the second argument to tell React run this hook once.",  AnswerAccepted=true,
            //         AnswerDate = new DateTime(2024, 2, 22, 5, 30, 0),AnswerAcceptedDate = new DateTime(2024, 2, 28, 10, 30, 0), UserId=4} }
            //     },
            //     new Post
            //     {
            //         CategoryId= 1,
            //         Title = "How to use useState in React.Js",
            //         Description = "I'm getting confused on how useState generics work, can anyone please explain to me how it works",
            //         Likes = 3,
            //         UserId = 5,
            //         PostDate = new DateTime(2024, 2, 20, 7, 30, 0),
            //         Answers = new List<PostAnswer>() {new() {Answer="It's a hook that is used for state in a component' lifetime", AnswerAccepted=false,
            //         AnswerDate = new DateTime(2024, 2, 22, 5, 30, 0), UserId=3} }
            //     },
            // ];

            
            context.Categories.AddRange(categories);
            // context.Posts.AddRange(posts);
            context.SaveChanges();

        }
    }
}