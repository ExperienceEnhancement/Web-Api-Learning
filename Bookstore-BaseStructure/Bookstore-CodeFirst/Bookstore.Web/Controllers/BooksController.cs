using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Bookstore.Web.DbContext;
using Bookstore.Web.Models;
using Newtonsoft.Json;

namespace Bookstore.Web.Controllers
{
    public class BooksController : ApiController
    {
        // GET
        // api/Books
        [HttpGet]
        public IHttpActionResult Get()
        {
            var context = new BookstoreDbContext();

            var books = context.Books
                .Select(x => new BookDTO()
                {
                    Id = x.Id,
                    Author = x.Author,
                    Summary = x.Summary,
                    Title = x.Title
                }).ToList();

            return this.Ok(books);
        }
    }
}