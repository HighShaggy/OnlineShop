using System.ComponentModel.DataAnnotations;

namespace ShopDb.Models
{
    public class Role
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Введите название роли.")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Длина должна быть от 3 до 30 символов.")]
        public string Name { get; set; }
    }
}

