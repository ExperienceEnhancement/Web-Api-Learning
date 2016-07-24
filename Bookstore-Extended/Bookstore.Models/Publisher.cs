namespace Bookstore.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Publisher
    {
        private ICollection<Availability> availabilities;

        public Publisher()
        {
            this.availabilities = new HashSet<Availability>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Availability> Availabilities
        {
            get { return this.availabilities; }
            set { this.availabilities = value; }
        }
    }
}
