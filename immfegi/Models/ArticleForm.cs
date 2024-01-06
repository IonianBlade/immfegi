using immfegi.Data;

namespace immfegi.Models;

public class ArticleForm
{
    public int Id { get; set; }
    public string SpeakerName { get; set; }
    public string SpeakerSurname { get; set; }
    public string? SpeakerPatronymic { get; set; }
    public string FullEducationInstitutionName { get; set; }
    public string SpeakerPost { get; set; }
    public string Course { get; set; }
    public string? ScientificTitle { get; set; }
    public string? Group { get; set; }
    public string ArticleNameOnRussian { get; set; }
    public string ArticleNameOnEnglish { get; set; }
    public IntendedParticipation IntendedParticipation { get; set; }
    public string Section { get; set; }
    public string SpeakerPhoneNumber { get; set; }
    public string SpeakerEmail { get; set; }
    public SpeakerRole SpeakerRole { get; set; }
        
    public string? ScientificDirectorName { get; set; }
    public string? ScientificDirectorSurname { get; set; }
    public string? ScientificDirectorPatronymic { get; set; }
    public string? ScientificDirectorFullEducationInstitutionName  { get; set; }
    public string? ScientificDirectorPost { get; set; }
    public string? ScientificDirectorTitle { get; set; }
    public string? ScientificDirectorPhoneNumber { get; set; }
    public string? ScientificDirectorEmail { get; set; }
        
    public string ArticlePath { get; set; }
    public DateTime UploadDateTime { get; set; }
    public ArticleFormStatus ArticleFormStatus { get; set; }
    public ICollection<UserArticle> UserArticles { get; set; }
}