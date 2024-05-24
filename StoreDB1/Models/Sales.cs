namespace StoreDB1.Models
{
    public class Sales
    {
        public int SalesId { get; set; }
        public int ProductId { get; set; }

        public int CustomerId { get; set; }

        public int StoreId { get; set; }

        public DateTime DateSold { get; set; }

        public virtual Customer customer { get; set; }

        public virtual Store Store { get; set; }

        public virtual Product Product { get; set; }
    }
}
