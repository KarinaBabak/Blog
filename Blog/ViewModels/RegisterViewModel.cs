using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public class RegisterViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Name = "Введите Ваш логин:")]
        [Required(ErrorMessage = "Поле логина не может быть пустым")]
        [RegularExpression(@"[A-Za-z0-9._%+-]*", ErrorMessage = "Некорректный логин")]
        public string Login { get; set; }

        [Display(Name = "Введите Ваш e-mail:")]
        [Required(ErrorMessage = "Поле e-mail не может быть пустым")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный e-mail.")]
        public string Email { get; set; }

        [Display(Name = "Введите Ваш пароль:")]
        [Required(ErrorMessage = "Введите Ваш пароль")]
        [StringLength(50, ErrorMessage = "Пароль должен содердать минимум {2} символов", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Введите пароль еще раз")]
        [Display(Name = "Повторите пароль:")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Введите Ваше имя:")]
        [Required(ErrorMessage = "Введите Ваше имя")]
        public string Name { get; set; }
        [Display(Name = "Введите Вашу фамилию:")]
        [Required(ErrorMessage = "Введите Вашу фамилию")]
        public string Surname { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateRegistration { get; set; }
    }
}