using AutoMapper.QueryableExtensions;
using Bookstore.Web.Attributes;

namespace Bookstore.Web.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using Microsoft.Ajax.Utilities;

    using Bookstore.Models;
    using Data.Data;
    using Models.BindingModels;
    using Models.DataTransferObjects;
   
    public class BooksController : BaseController
    {
        public BooksController(IBookstoreData data) : base(data)
        {
        }

        // GET
        // api/books
        [HttpGet]
        [Route("api/books/search")]
        //[SessionAuthorize]
        public IHttpActionResult SearchBooks([FromUri]BookSearchBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var books = base.Data.Books.All()
                .Project().To<BookDto>();

            if (model != null && !model.Title.IsNullOrWhiteSpace())
            {
                books = books.Where(x => x.Title.Contains(model.Title));
            }

            if (model != null && !model.Summary.IsNullOrWhiteSpace())
            {
                books = books.Where(x => x.Summary.Contains(model.Summary));
            }

            var booksResult = books.ToList();

            return this.Ok(booksResult);
        }

        // GET
        // api/books/{id}
        [HttpGet]
        [Route("api/books/{id:int}", Name = "GetBookDetails")]
        public IHttpActionResult GetBookDetails(int id)
        {
            var book = base.Data.Books.All()
                .Project()
                .To<BookDto>()
                .FirstOrDefault(x => x.Id == id);

            if (book == null)
            {
                return this.NotFound();
            }

            return this.Ok(book);
        }

        // POST
        // api/books
        [HttpPost]
        public IHttpActionResult CreateBook([FromBody]BookCreateBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var book = new Book()
            {
                Title = model.Title,
                Author = model.Author,
                Summary = model.Summary.IsNullOrWhiteSpace() ? model.Summary : null
            };

            base.Data.Books.Add(book);
            base.Data.SaveChanges();

            return this.CreatedAtRoute(
                "GetBookDetails",
                new
                {
                    Id = book.Id,
                    Message = $"Book {book.Title} added",
                },
                book);
        }

        // DELETE
        // api/books/{id:int}
        [HttpDelete]
        [Route("api/books/{id:int}")]
        public IHttpActionResult DeleteBook(int id)
        {
            var book = base.Data.Books.All().FirstOrDefault(x => x.Id == id);

            if (book == null)
            {
                return this.NotFound();
            }

            base.Data.Books.Remove(book);
            base.Data.SaveChanges();

            return Ok(new
            {
                Message = $"Book {book.Title} deleted"
            });
        }

        // PATCH
        // api/books/{id}
        [HttpPatch]
        [Route("api/books/{id:int}")]
        public IHttpActionResult EditBook(int id, [FromBody]BookEditBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var book = base.Data.Books.All().FirstOrDefault(x => x.Id == id);
            if (book == null)
            {
                return this.NotFound();
            }

            if (model.Title != null)
            {
                book.Title = model.Title;
            }

            if (model.Summary != null)
            {
                book.Summary = model.Summary;
            }

            if (model.Author != null)
            {
                book.Author = model.Author;
            }

            base.Data.Books.Update(book);
            base.Data.SaveChanges();

            return this.Ok(
                new
                {
                    Message = $"Book {book.Title} updated"
                }
            );
        }
    }
}