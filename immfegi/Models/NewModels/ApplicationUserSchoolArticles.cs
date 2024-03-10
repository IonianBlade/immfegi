namespace immfegi.Models.NewModels;

public class ApplicationUserSchoolArticles
{
    public int Id { get; set; }
    public string ApplicationUserId { get; set; }
    public virtual ApplicationUser ApplicationUser { get; set; }

    public int SchoolArticleId { get; set; }
    public virtual SchoolArticle SchoolArticle { get; set; }
}