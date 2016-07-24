using Bookstore.Data.Data;

namespace Bookstore.Web.Controllers
{
    using System.Web.Http;

    public class BaseController : ApiController
    {
        public BaseController(IBookstoreData data)
        {
            this.Data = data;
        }

        protected IBookstoreData Data { get; private set; }
    }
}