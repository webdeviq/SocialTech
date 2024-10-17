using API.Entities;
using API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
  public class SocialTechContext(DbContextOptions options) : IdentityDbContext(options)
  {
    // Test change.
    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //   modelBuilder.Entity<Category>().HasData(
    //           new Category { Id = 1, CategoryName = "React" },
    //             new Category { Id = 2, CategoryName = "MVC" },
    //             new Category { Id = 3, CategoryName = "C" },
    //             new Category { Id = 4, CategoryName = "PYTHON" },
    //             new Category { Id = 5, CategoryName = "LINQ" },
    //             new Category { Id = 6, CategoryName = "R" },
    //             new Category { Id = 7, CategoryName = "ANGULAR" },
    //             new Category { Id = 8, CategoryName = "API" },
    //             new Category { Id = 9, CategoryName = "XML" },
    //             new Category { Id = 10, CategoryName = "TYPESCRIPT" },
    //             new Category { Id = 11, CategoryName = "SOAP" },
    //             new Category { Id = 12, CategoryName = "REST" },
    //             new Category { Id = 13, CategoryName = "NEXT" },
    //             new Category { Id = 14, CategoryName = "LISP" },
    //             new Category { Id = 15, CategoryName = "CSV" },
    //             new Category { Id = 16, CategoryName = "CSHARP" },
    //             new Category { Id = 17, CategoryName = "DOTNET" },
    //             new Category { Id = 18, CategoryName = "GO" },
    //             new Category { Id = 19, CategoryName = "JAVASCRIPT" },
    //             new Category { Id = 20, CategoryName = "JSON" },
    //             new Category { Id = 21, CategoryName = "FLUTTER" }
    //   );
    // }

    public DbSet<Post> Posts { get; set; }
    public DbSet<PostAnswer> PostAnswers { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);
      builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Member", NormalizedName = "MEMBER" },
      new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" });
    }
  }
}