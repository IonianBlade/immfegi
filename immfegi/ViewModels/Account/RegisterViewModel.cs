using System.ComponentModel.DataAnnotations;

namespace immfegi.ViewModels.Account;

public class RegisterViewModel
{
    [Display(Name = "Электронная почта")]
    [Required(ErrorMessage = "Введите электронную почту")]
    public string EmailAddress { get; set; }

    [Display(Name = "Пароль")]
    [Required(ErrorMessage = "Введите пароль")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Display(Name = "Подтверждение пароля")]
    [Required(ErrorMessage = "Подтвердите пароль")]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Пароли не совпадают")]
    public string ConfirmPassword { get; set; }
}