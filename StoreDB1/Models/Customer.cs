using System.ComponentModel.DataAnnotations;

namespace StoreDB1.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Address { get; set; }


        public virtual ICollection<Sales> Sales { get; set; }

    }
}
