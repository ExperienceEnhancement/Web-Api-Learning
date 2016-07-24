using System.Linq;

namespace Bookstore.Web.Models.DataTransferObjects
{
    using System;
    using System.Linq.Expressions;
    using System.Collections.Generic;

    using Bookstore.Models;

    public class BookDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Summary { get; set; }

        public ICollection<ReviewDto> Reviews { get; set; }

        public static Expression<Func<Book, BookDto>> Dto
        {
            get
            {
                return e => new BookDto()
                {
                    Id = e.Id,
                    Title = e.Title,
                    Summary = e.Summary,
                    Author = e.Author,
                    Reviews = e.Reviews.Select(x => new ReviewDto()
                    {
                        UserId = x.UserId,
                        UserName = x.User.UserName,
                        Comment = x.Comment,
                        Rate = x.Rate
                    }).ToList()
                };
            }
        }
    }
}