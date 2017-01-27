using System.Data.Entity.Migrations;
using QuinntyneBrownPhotography.Data;
using QuinntyneBrownPhotography.Data.Models;

namespace QuinntyneBrownPhotography.Migrations
{
    public class RoleConfiguration
    {
        public static void Seed(QuinntyneBrownPhotographyDataContext context) {

            context.Roles.AddOrUpdate(x => x.Name, new Role()
            {
                Name = "System"
            });

            context.SaveChanges();
        }
    }
}
