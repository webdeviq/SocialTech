using API.Dtos;
using API.Dtos.Post;
using API.Entities;
using API.RequestHelpers;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class PostExtensions
    {
        public static IQueryable<Post> Sort(this IQueryable<Post> query, string orderBy)
        {
            if (string.IsNullOrEmpty(orderBy))
            {
                return query.OrderBy(p => p.Category.CategoryName);
            }
            query = orderBy switch
            {
                "datePosted" => query.OrderBy(p => p.PostDate),
                "datePostedDescending" => query.OrderByDescending(p => p.PostDate),
                _ => query.OrderBy(p => p.Title).Include(p => p.PostOwner),
            };
            return query;
        }
        
        public static IQueryable<Post> Search(this IQueryable<Post> query, string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return query;
            }
            var lowerCaseSearchTerm = searchTerm.Trim().ToLower();
            return query.Where(p => p.Title.ToLower().Contains(lowerCaseSearchTerm)).Include(p => p.PostOwner);
        }
        public static IQueryable<Post> Filter(this IQueryable<Post> query, string categories)
        {
            var categoryList = new List<string>();
            if (!string.IsNullOrEmpty(categories))
            {
                categoryList.AddRange(categories.ToLower().Split(",").ToList());
            }
            query = query.Where(post => categoryList.Count == 0 || categoryList.Contains(post.Category.CategoryName.ToLower()))
            .Include(p => p.PostOwner);
            return query;
        }
        public static List<PostDto> MapGetAllPosts(this PagedList<Post> values) 
        {
            return DtoMapper.MapGetAllPosts(values);
        }
        



    }
}