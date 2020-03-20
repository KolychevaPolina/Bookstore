using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BookStore.ViewModels
{
    public class LoginModel
    {
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        [Required]
        public string Email { get; set; }
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Длина пароля должна быть от 3 до 15 символов")]
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
    }
}