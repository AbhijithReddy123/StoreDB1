using System.ComponentModel.DataAnnotations;

namespace StoreDB1.Models
{
    public class Store
    {
        public int StoreId { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Address { get; set; }

        public virtual ICollection<Sales> Sales { get; set; }
    }
}
