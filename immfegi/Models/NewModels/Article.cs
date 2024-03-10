using immfegi.Data;

namespace immfegi.Models.NewModels;

public class Article
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string? Patronymic { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string ArticleNameOnRussian { get; set; } = string.Empty;
    public string ArticleNameOnEnglish { get; set; } = string.Empty;
    public string Section { get; set; } = string.Empty;
    public string ArticlePath { get; set; } = string.Empty;
    public string RequestPath { get; set; } = string.Empty;
    
    public DateTime UploadDateTime { get; set; }
    public ArticleFormStatus ArticleFormStatus { get; set; }
    public virtual ICollection<ApplicationUserArticles> ApplicationUserArticlesCollection { get; set; }
}