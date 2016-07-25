using Bookstore.Models.Ads.Models;

namespace Bookstore.Data.Data
{
    using System;
    using System.Collections.Generic;

    using Models;
    using Repositories;
    using DbContext;

    public class BookstoreData : IBookstoreData
    {
        private IBookstoreDbContext dbContext;

        private readonly IDictionary<Type, object> repositories;

        public BookstoreData(IBookstoreDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<User> Users
        {
            get { return this.GetRepository<User>(); }
        }

        public IRepository<Book> Books
        {
            get { return this.GetRepository<Book>(); }
        }

        public IRepository<Review> Reviews
        {
            get { return this.GetRepository<Review>(); }
        }

        public IRepository<Publisher> Publishers
        {
            get { return this.GetRepository<Publisher>(); }
        }

        public IRepository<Availability> Availabilities
        {
            get { return this.GetRepository<Availability>();  }
        }

        public IRepository<UserSession> UserSessions
        {
            get { return this.GetRepository<UserSession>(); }
        }

        public int SaveChanges()
        {
            return this.dbContext.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var modelType = typeof (T);
            if (!this.repositories.ContainsKey(modelType))
            {
                var repositoryType = typeof(Repository<T>);
                this.repositories.Add(modelType,
                    Activator.CreateInstance(repositoryType, this.dbContext));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }
    }
}
