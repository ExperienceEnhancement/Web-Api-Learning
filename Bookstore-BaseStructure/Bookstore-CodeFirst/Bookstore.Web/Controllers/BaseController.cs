namespace Bookstore.Web.Controllers
{
    using System.Web.Http;
    using DbContext;

    public class BaseController : ApiController
    {
        protected BookstoreDbContext dbContext;

        public BaseController():this(new BookstoreDbContext())
        {
        }

        public BaseController(BookstoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public BookstoreDbContext DbContext
        {
            get { return this.dbContext; }
            private set { this.dbContext = value; }
        }
    }
}