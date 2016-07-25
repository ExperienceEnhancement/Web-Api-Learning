namespace Bookstore.Data.DbContext
{
    using System.Data.Entity;

    using Microsoft.AspNet.Identity.EntityFramework;

    using Models;
    
    public class BookstoreDbContext : IdentityDbContext<User>, IBookstoreDbContext
    {
        public BookstoreDbContext()
            : base("BookstoreDbConnection", throwIfV1Schema: false)
        {
        }

        public static BookstoreDbContext Create()
        {
            return new BookstoreDbContext();
        }

        public IDbSet<Book> Books { get; set; }

        public IDbSet<Review> Reviews { get; set; }

        public IDbSet<Publisher> Publishers { get; set; }

        public IDbSet<Availability> Availabilities { get; set; }
    }
}
