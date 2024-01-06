using System.ComponentModel;
using immfegi.Data;

namespace immfegi.ViewModels.Article;

public class ChangeStatusArticleViewModel
{
     [DisplayName("Имя выступающего")]
    public string SpeakerName { get; set; }
    
    [DisplayName("Фамилия выступающего")]
    public string SpeakerSurname { get; set; }
    
    [DisplayName("Отчество выступающего")]
    public string? SpeakerPatronymic { get; set; }
    
    [DisplayName("Полное название образовательного учреждения")]
    public string FullEducationInstitutionName { get; set; }
    
    [DisplayName("Занимаемая должность")]
    public string SpeakerPost { get; set; }
    
    [DisplayName("Курс обучения")]
    public string Course { get; set; }
    
    [DisplayName("Научное звание")]
    public string? ScientificTitle { get; set; }
    
    [DisplayName("Группа")]
    public string? Group { get; set; }
    
    [DisplayName("Название статьи на русском")]
    public string ArticleNameOnRussian { get; set; }
    
    [DisplayName("Название статьи на английском")]
    public string ArticleNameOnEnglish { get; set; }
    
    [DisplayName("Предполагаемое участие")]
    public IntendedParticipation IntendedParticipation { get; set; }
    
    [DisplayName("Секция")]
    public string Section { get; set; }
    
    [DisplayName("Телефон выступающего")]
    public string SpeakerPhoneNumber { get; set; }
    
    [DisplayName("Электронная почта выступающего")]
    public string SpeakerEmail { get; set; }
    
    [DisplayName("Статус выступающего")]
    public SpeakerRole SpeakerRole { get; set; }
        
    [DisplayName("Имя научного руководителя")]
    public string? ScientificDirectorName { get; set; }
        
    [DisplayName("Фамилия научного руководителя")]
    public string? ScientificDirectorSurname { get; set; }
        
    [DisplayName("Отчество научного руководителя")]
    public string? ScientificDirectorPatronymic { get; set; }
        
    [DisplayName("Полное название образовательного учреждения научного руководителя")]
    public string? ScientificDirectorFullEducationInstitutionName  { get; set; }
        
    [DisplayName("Занимаемая дожность научного руководителя")]
    public string? ScientificDirectorPost { get; set; }
        
    [DisplayName("Ученое звание научного руководителя")]
    public string? ScientificDirectorTitle { get; set; }
        
    [DisplayName("Телефон научного руководителя")]
    public string? ScientificDirectorPhoneNumber { get; set; }
        
    [DisplayName("Электронная почта научного руководителя")]
    public string? ScientificDirectorEmail { get; set; }
    public string ArticlePath { get; set; }
    
    [DisplayName("Дата и время загрузки статьи")]
    public DateTime UploadDateTime { get; set; }
    
    [DisplayName("Статус заявки")]
    public ArticleFormStatus ArticleFormStatus { get; set; }
    public string ApplicationUserId { get; set; }
}