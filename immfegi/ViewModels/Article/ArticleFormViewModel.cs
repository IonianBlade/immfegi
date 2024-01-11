using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using immfegi.Data;

namespace immfegi.ViewModels.Article;

public class ArticleFormViewModel
{
        [DisplayName("Имя")]
        [Required(ErrorMessage = "Введите имя")]
        public string SpeakerName { get; set; }

        [DisplayName("Фамилия")]
        [Required(ErrorMessage = "Введите фамилию")]
        public string SpeakerSurname { get; set; }

        [DisplayName("Отчество")]
        public string? SpeakerPatronymic { get; set; }
        
        [DisplayName("Полное название образовательного учреждения")]
        [Required(ErrorMessage = "Введите полное название образовательного учреждения")]
        public string FullEducationInstitutionName { get; set; }
        
        [DisplayName("Занимаемая должность")]
        [Required(ErrorMessage = "Введите занимаемую должность")]
        public string SpeakerPost { get; set; }
        
        [DisplayName("Курс обучения")]
        [Required(ErrorMessage = "Введите курс обучения")]
        public string Course { get; set; }
        
        [DisplayName("Научное звание, научная степень")]
        public string? ScientificTitle { get; set; }
        
        [DisplayName("Группа")]
        public string? Group { get; set; }

        [DisplayName("Название статьи на русском")]
        [Required(ErrorMessage = "Введите название статьи на русском")]
        public string ArticleNameOnRussian { get; set; }

        [DisplayName("Название статьи на английском")]
        [Required(ErrorMessage = "Введите название статьи на английском")]
        public string ArticleNameOnEnglish { get; set; }
        
        [DisplayName("Докладчик")]
        [Required(ErrorMessage = "Выберите статус")]
        public IntendedParticipation IntendedParticipation { get; set; }

        [DisplayName("Секция")]
        [Required(ErrorMessage = "Выберите секцию")]
        public string Section { get; set; }

        [DisplayName("Телефон")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Введите телефон")]
        public string SpeakerPhoneNumber { get; set; }

        [DisplayName("Электронная почта")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Введите адрес электронной почты")]
        public string SpeakerEmail { get; set; }
        
        [DisplayName("Статус")]
        [Required(ErrorMessage = "Выберите статус")]
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
        
        [DisplayName("Файл со статьей")]
        [Required(ErrorMessage = "Прикрепите файл со статьей")]
        public IFormFile Article { get; set; }
        

        public string ApplicationUserId { get; set; }
        public DateTime UploadDateTime { get; set; }
        public  ArticleFormStatus ArticleFormStatus { get; set; }
}