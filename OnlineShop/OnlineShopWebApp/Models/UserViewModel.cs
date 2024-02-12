using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите логин.")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Login должен быть от 3 до 30 символов.")]

        public string Name { get; set; }

        [Required(ErrorMessage = "Введите пароль.")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Password должен быть от 5 до 30 символов.")]
        public string Password { get; set; }

    }
}
