
using System.ComponentModel.DataAnnotations;
using API.Models;

namespace API.Entities
{
    public class Category
    {
        public int Id { get; set; }
        [MaxLength(100, ErrorMessage = "Category length is too long")]
        public string CategoryName { get; set; } = string.Empty;

    }
}