﻿namespace Bookstore.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Review
    {
        [Key]
        [Column(Order = 1)]
        public int BookId { get; set; }

        [Key]
        [Column(Order = 2)]
        public string UserId { get; set; }

        [Required]
        [Column(TypeName = "ntext")]
        public string Comment { get; set; }

        [Required]
        public int Rate { get; set; }

        [ForeignKey("BookId")]
        public virtual Book Book { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
