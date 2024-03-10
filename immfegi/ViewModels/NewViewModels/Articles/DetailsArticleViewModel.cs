using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using immfegi.Data;

namespace immfegi.ViewModels.NewViewModels.Articles;

public class DetailsArticleViewModel
{
    public int Id { get; set; }
    
    [DisplayName("Название статьи на русском")]
    public string ArticleNameOnRussian { get; set; } = string.Empty;
    
    [DisplayName("Название статьи на английском")]
    public string ArticleNameOnEnglish { get; set; } = string.Empty;
    
    [DisplayName("Секция")]
    [Required(ErrorMessage = "Выберите секцию")]
    public string Section { get; set; } = string.Empty;
    
    [DisplayName("Имя")]
    [Required(ErrorMessage = "Введите имя")]
    public string Name { get; set; } = string.Empty;
    
    [DisplayName("Фамилия")]
    public string Surname { get; set; } = string.Empty;
    
    [DisplayName("Отчество")]
    public string? Patronymic { get; set; } = string.Empty;
    
    [DisplayName("Телефон")]
    public string PhoneNumber { get; set; } = string.Empty;
    
    [DisplayName("Электронная почта")]
    public string Email { get; set; } = string.Empty;

    [DisplayName("Статус заявки")]
    public  ArticleFormStatus ArticleFormStatus { get; set; }
    
    [DisplayName("Дата и время загрузки статьи")]
    public DateTime UploadDateTime { get; set; }
    
    public string ApplicationUserId { get; set; }
    
}