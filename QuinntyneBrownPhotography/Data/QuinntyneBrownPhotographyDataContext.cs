using QuinntyneBrownPhotography.Data.Models;
using System.Data.Entity;

namespace QuinntyneBrownPhotography.Data
{
    public interface IQuinntyneBrownPhotographyDataContext
    {
        DbSet<Article> Articles { get; set; }
        DbSet<Customer> Customers { get; set; }
        DbSet<DigitalAsset> DigitalAssets { get; set; }
        DbSet<Contact> Contacts { get; set; }
        DbSet<ContactMessage> ContactMessages { get; set; }
    }

    public class QuinntyneBrownPhotographyDataContext: DbContext, IQuinntyneBrownPhotographyDataContext
    {
        public QuinntyneBrownPhotographyDataContext()
            : base(nameOrConnectionString: "QuinntyneBrownPhotographyDataContext")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            Configuration.AutoDetectChangesEnabled = true;
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<DigitalAsset> DigitalAssets { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactMessage> ContactMessages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        } 
    }
}
