using API.Entities;
using API.Models;

namespace API.Data
{
    public static class DbInitalizer
    {
        public static void Initialize(SocialTechContext context)
        {

            // if (context.Users.Any()) return;
            if (context.Posts.Any()) return;
            //if (context.Categories.Any()) return;

            //     List<Category> categories = new() {
            //     new Category {CategoryEnum = CategoryEnum.REACT},

            //     new Category {CategoryEnum = CategoryEnum.MVC},
            //     new Category {CategoryEnum = CategoryEnum.C},
            //     new Category {CategoryEnum = CategoryEnum.PYTHON},
            //     new Category {CategoryEnum = CategoryEnum.LINQ},
            //     new Category {CategoryEnum = CategoryEnum.R},
            //     new Category {CategoryEnum = CategoryEnum.ANGULAR},
            //     new Category {CategoryEnum = CategoryEnum.API},
            //     new Category {CategoryEnum = CategoryEnum.XML},
            //     new Category {CategoryEnum = CategoryEnum.TYPESCRIPT},
            //     new Category {CategoryEnum = CategoryEnum.SOAP},
            //     new Category {CategoryEnum = CategoryEnum.REST},
            //     new Category {CategoryEnum = CategoryEnum.NEXT},
            //     new Category {CategoryEnum = CategoryEnum.LISP},
            //     new Category {CategoryEnum = CategoryEnum.CSV},
            //     new Category {CategoryEnum = CategoryEnum.CSHARP},
            //     new Category {CategoryEnum = CategoryEnum.DOTNET},
            //     new Category {CategoryEnum = CategoryEnum.GO},
            //     new Category {CategoryEnum = CategoryEnum.JAVASCRIPT},
            //     new Category {CategoryEnum = CategoryEnum.JSON},
            // };
            // List<User> users = new() {
            //     new User{ FirstName = "Scott", LastName="Mctaggart",
            //     Email="scott@hotmail.com"},
            //     new User { FirstName="Ali", LastName="Mohammed",
            //     Email="ali@hotmail.com"},
            //     new User{ FirstName="Andy", LastName="Messer", Email="andy@hotmail.com"},
            //     new User{FirstName="Ibrahim", LastName="Abdullah", Email="ibrahim@hotmail.com"},
            //     new User{FirstName="David", LastName="Messer", Email="david@gmail.com"},
            // };
            List<Post> posts = new() {
                new Post
                {Category = CategoryEnum.REACT,
                    Title = "How to use useState in React.Js",
                    Description = "I'm getting confused on how useState generics work, can anyone please explain to me how it works",
                    Likes = 3,
                    UserId = 1,
                },
                new Post
                { Category = CategoryEnum.TYPESCRIPT,
                    Title = "Typescript Interface Error",
                    Description = "I'm receiving this error in typescript 'interface error in file demo.ts'",
                    Likes = 5,
                    UserId = 1,
                },
                new Post
                {Category = CategoryEnum.PYTHON,
                    Title = "Python classes syntax",
                    Description = "Can anyone give me a good course on python syntax, I'm getting conused with the classes syntax",
                    Likes = 3,
                    UserId = 2,
                },
                new Post
                {Category = CategoryEnum.LINQ,
                    Title = "Linq SQL Injection Vulnerability",
                    Description = "Were using LINQ in one of our .net projects and I'm receiving a SQL Injection vulnerability.",
                    Likes = 3,
                    UserId = 2,
                },
                new Post
                {Category = CategoryEnum.FLUTTER,
                    Title = "App wide state in Flutter",
                    Description = "Is app wide state like redux in flutter? Can anyone point me in the right direction.",
                    Likes = 3,
                    UserId = 3,
                },
                new Post
                {Category = CategoryEnum.GO,
                    Title = "Is Go still being used",
                    Description = "Is Go still being used in the industry, should I even learn it for a career?",
                    Likes = 3,
                    UserId = 4,
                },
                new Post
                {Category = CategoryEnum.REACT,
                    Title = "Using useEffect in React",
                    Description = "When does useEffect() run in React, is it before the component mounts or after?",
                    Likes = 3,
                    UserId = 4,
                },
                new Post
                {Category = CategoryEnum.XML,
                    Title = "XML Output incorrect",
                    Description = "How do I conditionally render XML tags? ",
                    Likes = 3,
                    UserId = 5,
                },
                new Post
                {Category = CategoryEnum.REACT,
                    Title = "How to use useState in React.Js",
                    Description = "I'm getting confused on how useState generics work, can anyone please explain to me how it works",
                    Likes = 3,
                    UserId = 5,
                },
                new Post
                {Category = CategoryEnum.REACT,
                    Title = "How to use useState in React.Js",
                    Description = "I'm getting confused on how useState generics work, can anyone please explain to me how it works",
                    Likes = 3,
                    UserId = 5,
                },
            };

            //context.Users.AddRange(users);
            context.Posts.AddRange(posts);
            //context.Categories.AddRange(categories);
            // context.Categories.Add();
            context.SaveChanges();

        }
    }
}