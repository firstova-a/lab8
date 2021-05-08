using lab8.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace lab8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikeController : ControllerBase
    {
        private UserContext context = new UserContext();
        [HttpGet]
        public async Task<string> GetAsync(string username)
        {
            if (string.IsNullOrEmpty(username))
                return "Введите имя пользователя";
            UserInfo likedUser = context.Users.SingleOrDefault(usr => usr.Username == username);
            if (likedUser != null)
            {
                likedUser.Likes++;
                await context.SaveChangesAsync();
                return $"Вы поставили лайк пользователю {username}";
            }
            else return "Такой пользователь еще не зарегистрирован";
                
           

        }

    }
}