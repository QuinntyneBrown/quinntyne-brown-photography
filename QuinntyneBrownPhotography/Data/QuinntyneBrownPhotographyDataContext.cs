using QuinntyneBrownPhotography.Data.Models;
using System.Data.Entity;

namespace QuinntyneBrownPhotography.Data
{
    public class QuinntyneBrownPhotographyDataContext: DbContext
    {
        public QuinntyneBrownPhotographyDataContext()
            : base(nameOrConnectionString: "QuinntyneBrownPhotographyDataContext")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            Configuration.AutoDetectChangesEnabled = true;
        }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        } 
    }
}