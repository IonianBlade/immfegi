using immfegi.Data;

namespace immfegi.Models;

public class SchoolArticleForm
{
    public int Id { get; set; }
    public string SchoolBoySurname { get; set; }
    public string SchoolBoyName { get; set; }
    public string? SchoolBoyPatronymic { get; set; }
    public string ArticleName { get; set; }
    public string Section { get; set; }
    public ArticleActivities ArticleActivities { get; set; }
    public DateTime BirthDate { get; set; }
    public string SchoolBoyClass { get; set; }
    public string AbbreviatedEducationInstitutionName { get; set; }
    public string FullEducationInstitutionName { get; set; }
    public string City { get; set; }
    public string MunicipalDistrict { get; set; }
    public string UrbanDistrict { get; set; }
    public string SchoolBoyPhoneNumber { get; set; }
    public string SchoolBoyEmail { get; set; }
    public string ScientificDirectorSurname { get; set; }
    public string ScientificDirectorName { get; set; }
    public string ScientificDirectorPatronymic { get; set; }
    public string ScientificDirectorTitle { get; set; }
    public string ScientificDirectorPost{ get; set; }
    public string? ScientificDirectorPhoneNumber { get; set; }
    public string ScientificDirectorEmail { get; set; }
    public string ArticlePath { get; set; }
    public DateTime UploadDateTime { get; set; }
    public ArticleFormStatus ArticleFormStatus { get; set; }
    public ICollection<UserSchoolArticle> UserSchoolArticles { get; set; }
}