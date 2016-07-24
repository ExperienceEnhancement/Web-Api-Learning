using System.ComponentModel.DataAnnotations;

namespace Bookstore.Web.Models.BindingModels
{
    public class BookSearchBindingModel
    {
        public string Title { get; set; }

        [MinLength(3, ErrorMessage = "Summary filter should be at least {1} symbols long")]
        public string Summary { get; set; }
    }
}