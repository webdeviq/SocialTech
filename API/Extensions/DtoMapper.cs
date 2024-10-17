using API.Dtos.Post;
using API.Entities;
using Microsoft.AspNetCore.Identity;

namespace API.Extensions
{
    public static class DtoMapper
    {


        /// <summary>
        /// Maps a List of A Post model to a List of PostDto
        /// </summary>
        /// <param name="posts"></param>
        /// <returns>A List<PostDto></returns>
        public static List<PostDto> MapGetAllPosts(List<Post> posts)
        {
            return posts.Select(element => new PostDto
            {
                Category = element.Category.CategoryName,
                Description = element.Description,
                Id = element.Id,
                Likes = element.Likes,
                Title = element.Title,
                UploadedOn = element.PostDate,
                PostOwner = new UserPostInfoDto
                {
                    Email = element.PostOwner.Email!,
                    FirstName = element.PostOwner.FirstName,
                    LastName = element.PostOwner.LastName,
                    Id = element.PostOwner.Id,
                },
                PostAnswers = element.Answers.Select((answer) => new PostAnswerDto
                {
                    Id = answer.Id,
                    Answer = answer.Answer,
                    AnswerAccepted = answer.AnswerAccepted,
                    AnswerDate = answer.AnswerDate,
                    AnswerAcceptedDate = answer.AnswerAcceptedDate,
                    AnsweredBy = answer.AnsweredBy.FirstName + ' ' + answer.AnsweredBy.LastName,
                    PostId = element.Id,
                }).ToList(),
            }).ToList();

        }
        public static PostDto MapGetOnePost(Post post)
        {

            return new PostDto
            {
                Category = post.Category.CategoryName,
                Description = post.Description,
                Id = post.Id,
                Likes = post.Likes,
                Title = post.Title,
                UploadedOn = post.PostDate,
                PostOwner = new UserPostInfoDto
                {
                    Id = post.PostOwner.Id,
                    Email = post.PostOwner.Email!,
                    FirstName = post.PostOwner.FirstName,
                    LastName = post.PostOwner.LastName,

                },
                PostAnswers = post.Answers.Select((answer) => new PostAnswerDto
                {
                    Id = answer.Id,
                    Answer = answer.Answer,
                    AnswerAccepted = answer.AnswerAccepted,
                    AnswerDate = answer.AnswerDate,
                    AnsweredBy = answer.AnsweredBy.FirstName + ' ' + answer.AnsweredBy.LastName,
                    PostId = post.Id,

                }).ToList(),
            };
        }
        public static Post MapCreatePostDto(CreatePostDto createPostDto, string userId)
        {
            return new Post
            {
                Title = createPostDto.Title,
                Description = createPostDto.Description,
                CategoryId = createPostDto.CategoryId,
                PostDate = createPostDto.PostDate,
                UserId = userId,
            }; // CHECK THE LIKES FOR A POST WHEN CREATED , MAYBE ADD IT TO THE DTO.
        }



    }
}