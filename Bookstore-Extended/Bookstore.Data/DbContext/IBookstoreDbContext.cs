namespace Bookstore.Data.DbContext
{
    using System.Data.Entity;

    using Models;

    public interface IBookstoreDbContext
    {
        IDbSet<User> Users { get; }

        IDbSet<Book> Books { get; }

        IDbSet<Review> Reviews { get; }

        IDbSet<Publisher> Publishers { get; } 

        IDbSet<Availability> Availabilities { get; }

        int SaveChanges();
    }
}
