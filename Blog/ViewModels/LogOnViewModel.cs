using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public class LogOnViewModel
    {
        [Required(ErrorMessage = "Поле не может быть пустым")]
        [Display(Name = "Логин:")]
        [RegularExpression(@"[A-Za-z0-9._%+-]*", ErrorMessage = "Некорректный логин")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Пароль")]
        [Display(Name = "Пароль:")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Запомнить меня")]
        public bool RememberMe { get; set; }
    }
}