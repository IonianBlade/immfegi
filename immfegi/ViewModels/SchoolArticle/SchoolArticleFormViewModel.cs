using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using immfegi.Data;

namespace immfegi.ViewModels.SchoolArticle;

public class SchoolArticleFormViewModel
{
    [DisplayName("Фамилия участника")]
    [Required(ErrorMessage = "Введите фамилию участника")]
    public string SchoolBoySurname { get; set; }
    
    [DisplayName("Имя участника")]
    [Required(ErrorMessage = "Введите имя участника")]
    public string SchoolBoyName { get; set; }
    
    [DisplayName("Отчество участника")]
    public string? SchoolBoyPatronymic { get; set; }
    
    [DisplayName("Тема работы")]
    [Required(ErrorMessage = "Введите тему работы")]
    public string ArticleName { get; set; }
    
    [DisplayName("Направление")]
    [Required(ErrorMessage = "Выберите направление")]
    public ArticleActivities ArticleActivities { get; set; }
    
    [DisplayName("Дата рождения")]
    [Required(ErrorMessage = "Введите дату рождения")]
    public DateTime BirthDate { get; set; }
    
    [DisplayName("Класс")]
    [Required(ErrorMessage = "Введите класс")]
    public string SchoolBoyClass { get; set; }
    
    [DisplayName("Полное название образовательного учреждения")]
    [Required(ErrorMessage = "Введите полное название образовательного учреждения")]
    public string FullEducationInstitutionName { get; set; }
    
    [DisplayName("Сокращенное название образовательного учреждения")]
    [Required(ErrorMessage = "Введите сокращенное название образовательного учреждения")]
    public string AbbreviatedEducationInstitutionName { get; set; }
    
    [DisplayName("Город")]
    [Required(ErrorMessage = "Введите город")]
    public string City { get; set; }
    
    [DisplayName("Муниципальный район")]
    [Required(ErrorMessage = "Введите муниципальный район")]
    public string MunicipalDistrict { get; set; }
    
    [DisplayName("Городской округ")]
    [Required(ErrorMessage = "Введите городской округ")]
    public string UrbanDistrict { get; set; }
    
    [DisplayName("Телефон участника")]
    [DataType(DataType.PhoneNumber)]
    [Required(ErrorMessage = "Введите телефон участника")]
    public string SchoolBoyPhoneNumber { get; set; }
    
    [DisplayName("Электронная почта участника")]
    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "Введите электронную почту")]
    public string SchoolBoyEmail { get; set; }
    
    [DisplayName("Фамилия научного руководителя")]
    [Required(ErrorMessage = "Введите фамилию научного руководителя")]
    public string ScientificDirectorSurname { get; set; }
    
    [DisplayName("Имя научного руководителя")]
    [Required(ErrorMessage = "Введите имя научного руководителя")]
    public string ScientificDirectorName { get; set; }
    
    [DisplayName("Отчество научного руководителя")]
    public string ScientificDirectorPatronymic { get; set; }
    
    [DisplayName("Звание научного руководителя")]
    [Required(ErrorMessage = "Введите звание научного руководителя")]
    public string ScientificDirectorTitle { get; set; }
    
    [DisplayName("Должность научного руководителя")]
    [Required(ErrorMessage = "Введите должность научного руководителя")]
    public string ScientificDirectorPost{ get; set; }
    
    [DisplayName("Телефон научного руководителя")]
    [DataType(DataType.PhoneNumber)]
    public string? ScientificDirectorPhoneNumber { get; set; }
    
    [DisplayName("Электронная почта научного руководителя")]
    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "Введите электронную почту научного руководителя")]
    public string ScientificDirectorEmail { get; set; }
    
    [DisplayName("Файл с работой")]
    [Required(ErrorMessage = "Прикрепите файл с работой")]
    public IFormFile Article { get; set; }
    
    public DateTime UploadDateTime { get; set; }
    public ArticleFormStatus ArticleFormStatus { get; set; }
    public string ApplicationUserId { get; set; }
    public string Section { get; set; }
}