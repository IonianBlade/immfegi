namespace immfegi.Models;

public class UserArticle
{
    public int Id { get; set; }
    public string ApplicationUserId { get; set; }
    public ApplicationUser ApplicationUser { get; set; }

    public int ArticleFormId { get; set; }
    public ArticleForm ArticleForm { get; set; }
}