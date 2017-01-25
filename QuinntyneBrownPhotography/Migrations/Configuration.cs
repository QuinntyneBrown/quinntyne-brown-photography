namespace QuinntyneBrownPhotography.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<QuinntyneBrownPhotography.Data.QuinntyneBrownPhotographyDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(QuinntyneBrownPhotography.Data.QuinntyneBrownPhotographyDataContext context)
        {

        }
    }
}
