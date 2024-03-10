namespace immfegi.Models.NewModels;

public class ApplicationUserArticles
{
    public int Id { get; set; }
    public string ApplicationUserId { get; set; } = string.Empty;
    public virtual ApplicationUser ApplicationUser { get; set; }

    public int ArticleId { get; set; }
    public virtual Article Article { get; set; }
}