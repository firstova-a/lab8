using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab8.Entities
{
    public class UserContext:DbContext
    {
		public DbSet<UserInfo> Users { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=LAPTOP-7VM5O03N\SQLEXPRESS;Database=LR8Db;Trusted_Connection=True;");
		}
		public UserContext()
        {
			Database.EnsureCreated();
        }
	}
}
