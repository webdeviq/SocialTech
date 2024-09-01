using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
  public class SocialTechContext : DbContext
  {
#pragma warning disable IDE0290 // Use primary constructor
    public SocialTechContext(DbContextOptions options) : base(options)
#pragma warning restore IDE0290 // Use primary constructor
    {

    }

    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<PostAnswer> PostAnswers { get; set; }
    public DbSet<Category> Categories { get; set; }

  }
}