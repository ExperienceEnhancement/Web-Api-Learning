namespace Bookstore.Web.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using System.Data.Entity;

    using Microsoft.Ajax.Utilities;

    using Models.BindingModels;
    using Bookstore.Models;
    using Models.DataTransferObjects;

    public class BooksController : BaseController
    {
        // GET
        // api/books
        [HttpGet]
        [Route("api/books/search")]
        public IHttpActionResult SearchBooks([FromUri]BookSearchBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var books = base.dbContext.Books
                .Include(x => x.Reviews)
                .Select(BookDto.Dto)
                .AsQueryable();

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
            var book = base.dbContext.Books
                .Select(BookDto.Dto)
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

            base.dbContext.Books.Add(book);
            base.dbContext.SaveChanges();

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
            var book = base.dbContext.Books.FirstOrDefault(x => x.Id == id);

            if (book == null)
            {
                return this.NotFound();
            }

            base.dbContext.Books.Remove(book);
            base.dbContext.SaveChanges();

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

            var book = base.dbContext.Books.FirstOrDefault(x => x.Id == id);
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

            var entry = base.dbContext.Entry(book);

            entry.State = EntityState.Modified;
            base.dbContext.SaveChanges();

            return this.Ok(
                new
                {
                    Message = $"Book {book.Title} updated"
                }
            );
        }
    }
}