namespace ShopDb.Models
{
    public class Favourit
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int UserId { get; set; }
    }
}
