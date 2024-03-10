using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using immfegi.Data;

namespace immfegi.ViewModels.NewViewModels.Articles;

public class EditArticleViewModel
{
    public int Id { get; set; }
    
    [DisplayName("Название статьи на русском")]
    [Required(ErrorMessage = "Введите название статьи на русском")]
    public string ArticleNameOnRussian { get; set; } = string.Empty;
    
    [DisplayName("Название статьи на английском")]
    [Required(ErrorMessage = "Введите название статьи на английском")]
    public string ArticleNameOnEnglish { get; set; } = string.Empty;
    
    [DisplayName("Секция")]
    [Required(ErrorMessage = "Выберите секцию")]
    public string Section { get; set; } = string.Empty;
    
    [DisplayName("Имя")]
    [Required(ErrorMessage = "Введите имя")]
    public string Name { get; set; } = string.Empty;
    
    [DisplayName("Фамилия")]
    [Required(ErrorMessage = "Введите фамилию")]
    public string Surname { get; set; } = string.Empty;
    
    [DisplayName("Отчество")]
    public string? Patronymic { get; set; } = string.Empty;
    
    [DisplayName("Телефон")]
    [Required(ErrorMessage = "Введите номер телефона")]
    public string PhoneNumber { get; set; } = string.Empty;
    
    [DisplayName("Электронная почта")]
    [Required(ErrorMessage = "Введите электронную почту")]
    public string Email { get; set; } = string.Empty;
        
    public string ArticlePath { get; set; }
    public string RequestPath { get; set; }

    public string ApplicationUserId { get; set; }
    public DateTime UploadDateTime { get; set; }
    
    [DisplayName("Статус заявки")]
    public  ArticleFormStatus ArticleFormStatus { get; set; }
}