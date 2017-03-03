using System.Data.Entity.Migrations;
using System.Data.Entity;
using System.Linq;
using QuinntyneBrownPhotography.Data;
using QuinntyneBrownPhotography.Data.Models;
using System.Collections.Generic;
using QuinntyneBrownPhotography.Security;

namespace QuinntyneBrownPhotography.Migrations
{
    public class UserConfiguration
    {
        public static void Seed(QuinntyneBrownPhotographyDataContext context) {

            var systemRole = context.Roles.First(x => x.Name == "System");
            var roles = new List<Role>() { systemRole };            
            context.Users.AddOrUpdate(x => x.Username, new User()
            {
                Username = "quinntynebrown@gmail.com",
                Password = new EncryptionService().HashPassword("P@ssw0rd"),
                Roles = roles
            });
            context.SaveChanges();
        }
    }
}
