using lab8.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;

namespace lab8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private UserContext context = new UserContext();
        [HttpGet]
        public async Task<string> GetAsync(string username)
        {
            if (string.IsNullOrEmpty(username))
                return "Введите имя пользователя";
            if (context.Users.Any(usr => usr.Username == username))
                return "Данное имя пользователя уже занято, введите другое";
            UserInfo newUser = new UserInfo()
            {
                Username = username,
                Likes = 1
            };
            await context.Users.AddAsync(newUser);
            await context.SaveChangesAsync();
            


            return $"Пользователь {username} создан";
        }
        
    }
}
