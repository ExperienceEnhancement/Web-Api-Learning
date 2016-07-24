namespace Bookstore.Data.Data
{
    using Models;
    using Repositories;

    public interface IBookstoreData
    {
        IRepository<User> Users { get; }

        IRepository<Book> Books { get; }

        IRepository<Review> Reviews { get; }

        IRepository<Publisher> Publishers { get; }

        IRepository<Availability> Availabilities { get; }

        int SaveChanges();
    }
}
