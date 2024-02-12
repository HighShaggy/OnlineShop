using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class ProductViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите название продукта")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите описание продукта")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Введите стоимость продукта")]
        
        [Range(0.01, double.MaxValue, ErrorMessage = "Введите положительное число")]
        public decimal Cost { get; set; }

        public string ImagePath { get; set; }

        

        public override string ToString()
        {
            return $"{Id}\n{Name}\n{Cost}\n";
        }
    }
}
