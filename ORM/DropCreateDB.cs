using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Web.Helpers;

using Blog.DAL.Entities;

namespace ORM
{
    public class DropCreateDB : CreateDatabaseIfNotExists<BlogModel>
    {
        protected override void Seed(BlogModel context)
        {
            base.Seed(context);

            context.Users.Add(new User()
            {
                Id = 1,
                Login = "Karina",
                Name = "Karina",
                Surname = "Babak",
                Password = Crypto.HashPassword("karina"),
                IsBlocked = false,
                Email = "karisha.babak@gmail.com"
            });

            context.Roles.Add(new Role()
            {
                Id = 1,
                Name = "admin"
            });
        }
    }
}
