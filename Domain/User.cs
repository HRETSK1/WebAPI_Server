using System.ComponentModel.DataAnnotations;

namespace WebAPI_Server.Domain
{
    public class User
    {
        public int Id { get; set; }

        [Required (ErrorMessage = "Введите имя")]
        [RegularExpression(@"^[a-z ,.'-]+$", ErrorMessage ="Неверное имя пользователя")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Имя должно вмещать от 3 до 50 символов")]
        public string Name { get; set; }

        [Required (ErrorMessage = "Введите email")]
        [EmailAddress(ErrorMessage ="Некорректный email")]
        public string Email { get; set; }
    }
}
