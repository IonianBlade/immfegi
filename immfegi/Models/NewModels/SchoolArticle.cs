using immfegi.Data;

namespace immfegi.Models.NewModels;

public class SchoolArticle
{
    public int Id { get; set; }
    public string Surname { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? Patronymic { get; set; } = string.Empty;
    public string ArticleName { get; set; } = string.Empty;
    public string Section { get; set; } = string.Empty;
    public ArticleActivities ArticleActivities { get; set; }
    public string PhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string ArticlePath { get; set; } = string.Empty;
    public string RequestPath { get; set; } = string.Empty;
    public DateTime UploadDateTime { get; set; }
    public ArticleFormStatus ArticleFormStatus { get; set; }
    public virtual ICollection<ApplicationUserSchoolArticles> ApplicationUserSchoolArticlesCollection { get; set; }
}