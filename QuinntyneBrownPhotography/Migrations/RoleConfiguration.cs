using System.Data.Entity.Migrations;
using QuinntyneBrownPhotography.Data;

namespace QuinntyneBrownPhotography.Migrations
{
    public class RoleConfiguration
    {
        public static void Seed(QuinntyneBrownPhotographyDataContext context) {

            context.SaveChanges();
        }
    }
}
