namespace EcommerceApp.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }

        public string SKU { get; set; }       // Stock Keeping Unit, unique code
        public decimal Price { get; set; }    // Product price
    }
}
