using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace API.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public ICollection<Post> Posts { get; set; } = [];

        // User Cookie
        // public string Cookie { get; set; } = string.Empty;


    }
}