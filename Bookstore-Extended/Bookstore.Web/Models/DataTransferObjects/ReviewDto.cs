namespace Bookstore.Web.Models.DataTransferObjects
{
    using System;
    using System.Linq.Expressions;

    using Bookstore.Models;

    public class ReviewDto
    {
        public string UserId { get; set; }

        public string UserName { get; set; }

        public string Comment { get; set; }

        public int Rate { get; set; }

        public static Expression<Func<Review, ReviewDto>> Dto
        {
            get
            {
                return e => new ReviewDto()
                {
                    UserId = e.UserId,
                    UserName = e.User.UserName,
                    Comment = e.Comment,
                    Rate = e.Rate
                };
            }
        }
    }
}