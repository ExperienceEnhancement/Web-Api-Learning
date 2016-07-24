using System.Data.Entity;
using Bookstore.Web.Migrations;

namespace Bookstore.Web.DbContext
{
    using Bookstore.Models;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class BookstoreDbContext : IdentityDbContext<User>
    {
        public BookstoreDbContext()
            : base("BookstoreDbConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<BookstoreDbContext, BookstoreDbMigrationConfiguration>());
        }

        public static BookstoreDbContext Create()
        {
            return new BookstoreDbContext();
        }

        public IDbSet<Book> Books { get; set; }

        public IDbSet<Publisher> Publishers { get; set; }

        public IDbSet<Availability> Availabilities { get; set; }

        public IDbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Publisher>()
                .HasMany(x => x.Availabilities)
                .WithRequired(x => x.Publisher)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Book>()
                .HasMany(x => x.Reviews)
                .WithRequired(x => x.Book)
                .WillCascadeOnDelete(true);
        }
    }
}