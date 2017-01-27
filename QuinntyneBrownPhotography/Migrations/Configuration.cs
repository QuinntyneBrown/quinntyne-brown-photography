namespace QuinntyneBrownPhotography.Migrations
{
    using Data;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<QuinntyneBrownPhotographyDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(QuinntyneBrownPhotographyDataContext context)
        {
            RoleConfiguration.Seed(context);
            UserConfiguration.Seed(context);            
        }
    }
}
