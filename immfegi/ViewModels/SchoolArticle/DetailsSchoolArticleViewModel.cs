using System.ComponentModel;
using immfegi.Data;

namespace immfegi.ViewModels.SchoolArticle;

public class DetailsSchoolArticleViewModel
{
    public int Id { get; set; }
    
    [DisplayName("Фамилия участника")]
    public string SchoolBoySurname { get; set; }
    
    [DisplayName("Имя участника")]
    public string SchoolBoyName { get; set; }
    
    [DisplayName("Отчество участника")]
    public string? SchoolBoyPatronymic { get; set; }
    
    [DisplayName("Тема работы")]
    public string ArticleName { get; set; }
    
    [DisplayName("Направление")]
    public ArticleActivities ArticleActivities { get; set; }
    
    [DisplayName("Дата рождения")]
    public DateTime BirthDate { get; set; }
    
    [DisplayName("Класс")]
    public string SchoolBoyClass { get; set; }
    
    [DisplayName("Полное название образовательного учреждения")]
    public string FullEducationInstitutionName { get; set; }
    
    [DisplayName("Сокращенное название образовательного учреждения")]
    public string AbbreviatedEducationInstitutionName { get; set; }
    
    [DisplayName("Город")]
    public string City { get; set; }
    
    [DisplayName("Муниципальный район")]
    public string MunicipalDistrict { get; set; }
    
    [DisplayName("Городской округ")]
    public string UrbanDistrict { get; set; }
    
    [DisplayName("Телефон участника")]
    public string SchoolBoyPhoneNumber { get; set; }
    
    [DisplayName("Электронная почта участника")]
    public string SchoolBoyEmail { get; set; }
    
    [DisplayName("Фамилия научного руководителя")]
    public string ScientificDirectorSurname { get; set; }
    
    [DisplayName("Имя научного руководителя")]
    public string ScientificDirectorName { get; set; }
    
    [DisplayName("Отчество научного руководителя")]
    public string ScientificDirectorPatronymic { get; set; }
    
    [DisplayName("Звание научного руководителя")]
    public string ScientificDirectorTitle { get; set; }
    
    [DisplayName("Должность научного руководителя")]
    public string ScientificDirectorPost{ get; set; }
    
    [DisplayName("Телефон научного руководителя")]
    public string? ScientificDirectorPhoneNumber { get; set; }
    
    [DisplayName("Электронная почта научного руководителя")]
    public string ScientificDirectorEmail { get; set; }
    
    [DisplayName("Дата и время загрузки работы")]
    public DateTime UploadDateTime { get; set; }
    
    [DisplayName("Статус заявки")]
    public ArticleFormStatus ArticleFormStatus { get; set; }
    
    [DisplayName("Секция")]
    public string Section { get; set; }
}