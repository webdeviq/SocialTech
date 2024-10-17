

using API.Entities;
using Microsoft.AspNetCore.Identity;

namespace API.Extensions
{
    public class UserHelper
    {
        private readonly UserManager<User> _userManager;
        
        public UserHelper(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        /// <summary>
        /// return the user based on the username.
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<User> ReturnUserByUsername(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
            {
                throw new Exception($"No user matches the specified username {userName}");
            }
            return user;
        }
        /// <summary>
        /// Return the user based on the User Id.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<User> ReturnUserByUserId(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new Exception($"No user matches the specified user id {userId}");
            }
            return user;
        }

    }
}