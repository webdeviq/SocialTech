using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class SocialTechContext : DbContext
    {
      public SocialTechContext(DbContextOptions options) : base(options) {

      } 

      public DbSet<User> Users { get; set; }
      public DbSet<Post> Posts { get; set; }
         
    }
}