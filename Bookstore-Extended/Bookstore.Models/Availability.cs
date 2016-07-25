namespace Bookstore.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Availability
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime Published { get; set; }

        [Required]
        public int PagesCount { get; set; }

        [Required]
        public string CoverType { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public int BookId { get; set; }

        [ForeignKey("BookId")]
        public virtual Book Book { get; set; }

        public int PublisherId { get; set; }

        [ForeignKey("PublisherId")]
        public virtual Publisher Publisher { get; set; }
    }
}
