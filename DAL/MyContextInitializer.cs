using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class MyContextInitializer : CreateDatabaseIfNotExists<Context>
    {
        protected override void Seed(Context context)
        {
            var admin = context.Users.Add(new User() { FirstName = "Defailt", LastName = "Admin", Login = "1", Password = "1", IsAdmin = true });
            var user = context.Users.Add(new User() { FirstName = "Defailt", LastName = "User", Login = "user", Password = "user", IsAdmin = false });
            var admins_group = context.Groups.Add(new Group() { Name = "admins_group" });
            var first_group = context.Groups.Add(new Group() { Name = "first_group" });

            admins_group.Users.Add(admin);
            first_group.Users.Add(user);
            first_group.Users.Add(admin);

            

            context.SaveChanges();

        }
    }
}
