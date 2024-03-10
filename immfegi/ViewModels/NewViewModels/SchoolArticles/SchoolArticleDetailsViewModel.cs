using System.ComponentModel;
using immfegi.Data;

namespace immfegi.ViewModels.NewViewModels.SchoolArticles;

public class SchoolArticleDetailsViewModel
{
    public int Id { get; set; }
    
    [DisplayName("Фамилия")]
    public string Surname { get; set; }
    
    [DisplayName("Имя")]
    public string Name { get; set; }
    
    [DisplayName("Отчество")]
    public string? Patronymic { get; set; }
    
    [DisplayName("Тема работы")]
    public string ArticleName { get; set; }
    
    [DisplayName("Направление")]
    public ArticleActivities ArticleActivities { get; set; }
    
    [DisplayName("Телефон")]
    public string PhoneNumber { get; set; }
    
    [DisplayName("Электронная почта")]
    public string Email { get; set; }
    
    [DisplayName("Дата и время загрузки работы")]
    public DateTime UploadDateTime { get; set; }
    
    [DisplayName("Статус заявки")]
    public ArticleFormStatus ArticleFormStatus { get; set; }
    
    [DisplayName("Секция")]
    public string Section { get; set; }
}