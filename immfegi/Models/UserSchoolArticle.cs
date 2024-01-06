namespace immfegi.Models;

public class UserSchoolArticle
{
    public int Id { get; set; }
    public string ApplicationUserId { get; set; }
    public ApplicationUser ApplicationUser { get; set; }

    public int SchoolArticleFormId { get; set; }
    public SchoolArticleForm SchoolArticleForm { get; set; }
}