using lab8.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System;


namespace Laboratory8.Controllers
{
    public class UsersStat
    {
        public string Login { get; set; }
        public int Likes { get; set; }
    }
    [Route("api/[controller]")]
    [ApiController]
    public class Stats : Controller
    {
        string statString = "Пользователь  Количество лайков\n"; 
        private UserContext context = new UserContext();
        [HttpGet]
        public string Get()
        {
            IQueryable<UserInfo> users = from user in context.Users
                                         select user;
            List<UsersStat> result = new List<UsersStat>();
            foreach (UserInfo user in users)
            {
                statString += $"{user.Username}    {user.Likes}\n";
                
            }
            return statString;
        }
    }
}