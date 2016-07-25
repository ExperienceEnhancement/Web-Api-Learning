namespace Bookstore.Web.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterExternalBindingModel
    {
        [Required]
        [Display(Name = "Username")]
        public string Email { get; set; }
    }
}