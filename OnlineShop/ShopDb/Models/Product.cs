using System.Collections.Generic;

namespace ShopDb.Models
{
    public class Product
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }


        public decimal Cost { get; set; }
        public string ImagePath { get; set; }

        public List<CartItem> CartItems { get; set; }

        public Product(string name, string description, decimal cost, string imagePath)
        {
            Name = name;
            Description = description;
            Cost = cost;
            ImagePath = imagePath;
        }
        public Product(int id, string name, string description, decimal cost, string imagePath)
        {
            Id = id;
            Name = name;
            Description = description;
            Cost = cost;
            ImagePath = imagePath;
        }
        public Product()
        {

        }
    }
}
