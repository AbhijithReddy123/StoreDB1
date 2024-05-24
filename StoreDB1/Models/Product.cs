using System.ComponentModel.DataAnnotations;

namespace StoreDB1.Models
{
    public class Product
    {
        
            public int ProductId { get; set; }


            [Required]
            [StringLength(250)]
            public string Name { get; set; }

            public int Price { get; set; }

            public virtual ICollection<Sales> Sales { get; set; }
        }
    
}
