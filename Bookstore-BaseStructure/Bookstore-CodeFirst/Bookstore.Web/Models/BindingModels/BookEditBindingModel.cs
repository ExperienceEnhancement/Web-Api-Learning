namespace Bookstore.Web.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class BookEditBindingModel
    {
        public string Title { get; set; }

        public string Author { get; set; }

        [MinLength(10, ErrorMessage = "Summary should be at least {1} symbols long")]
        public string Summary { get; set; }
    }
}