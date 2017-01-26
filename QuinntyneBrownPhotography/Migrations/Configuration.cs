namespace QuinntyneBrownPhotography.Migrations
{
    using Data;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<QuinntyneBrownPhotographyDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(QuinntyneBrownPhotographyDataContext context)
        {
            UserConfiguration.Seed(context);
            RoleConfiguration.Seed(context);
        }
    }
}
