using Microsoft.AspNetCore.Identity;

namespace immfegi.Models;

public class ApplicationUser : IdentityUser
{
    public ICollection<UserArticle> UserArticles { get; set; }
}