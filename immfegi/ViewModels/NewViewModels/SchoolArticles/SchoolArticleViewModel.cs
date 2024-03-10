using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using immfegi.Data;

namespace immfegi.ViewModels.NewViewModels.SchoolArticles;

public class SchoolArticleViewModel
{
    [DisplayName("Фамилия")]
    [Required(ErrorMessage = "Введите фамилию")]
    public string Surname { get; set; }
    
    [DisplayName("Имя")]
    [Required(ErrorMessage = "Введите имя")]
    public string Name { get; set; }
    
    [DisplayName("Отчество")]
    public string? Patronymic { get; set; }
    
    [DisplayName("Тема работы")]
    [Required(ErrorMessage = "Введите тему работы")]
    public string ArticleName { get; set; }
    
    [DisplayName("Направление")]
    [Required(ErrorMessage = "Выберите направление")]
    public ArticleActivities ArticleActivities { get; set; }
    
    [DisplayName("Телефон")]
    [DataType(DataType.PhoneNumber)]
    [Required(ErrorMessage = "Введите телефон")]
    public string PhoneNumber { get; set; }
    
    [DisplayName("Электронная почта")]
    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "Введите электронную почту")]
    public string Email { get; set; }
    
    
    [DisplayName("Файл с работой")]
    [Required(ErrorMessage = "Прикрепите файл с работой")]
    public IFormFile Article { get; set; }
    
    [DisplayName("Файл с заявкой")]
    [Required(ErrorMessage = "Прикрепите файл с заявкой")]
    public IFormFile Request { get; set; }
    
    public DateTime UploadDateTime { get; set; }
    public ArticleFormStatus ArticleFormStatus { get; set; }
    public string ApplicationUserId { get; set; }
    public string Section { get; set; }
}