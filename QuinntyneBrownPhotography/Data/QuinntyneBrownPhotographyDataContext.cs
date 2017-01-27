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
        public DbSet<Author> Authors { get; set; }
        public DbSet<Avatar> Avatars { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactMessage> ContactMessages { get; set; }
        public DbSet<Contest> Contests { get; set; }
        public DbSet<ContestEntry> ContestEntries { get; set; }        
        public DbSet<Customer> Customers { get; set; }
        public DbSet<DigitalAsset> DigitalAssets { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Poll> Polls { get; set; }
        public DbSet<PollAnswer> PollAnswers { get; set; }
        public DbSet<PollQuestion> PollQuestions { get; set; }
        public DbSet<PollQuestionOption> PollQuestionOptions { get; set; }
        public DbSet<PollRespondent> PollRespondents { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        } 
    }
}
