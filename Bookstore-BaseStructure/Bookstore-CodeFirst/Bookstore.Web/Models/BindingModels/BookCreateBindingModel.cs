namespace Bookstore.Web.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class BookCreateBindingModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        public string Summary { get; set; }
    }
}