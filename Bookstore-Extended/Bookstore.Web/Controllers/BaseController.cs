namespace Bookstore.Web.Controllers
{
    using System.Web.Http;

    using Data.Data;

    public class BaseController : ApiController
    {
        public BaseController(IBookstoreData data)
        {
            this.Data = data;
        }

        protected IBookstoreData Data { get; private set; }
    }
}