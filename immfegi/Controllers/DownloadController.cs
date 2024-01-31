using immfegi.Data;
using immfegi.Repositories.Article;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace immfegi.Controllers;

public class DownloadController : Controller
{
    private readonly IArticleRepository _articleRepository;

    public DownloadController(IArticleRepository articleRepository)
    {
        _articleRepository = articleRepository;
    }
    
    [Authorize(Roles = ApplicationUserRoles.Administrator)]
    public IActionResult DownloadArticle(int id)
    {
        var article = _articleRepository.GetById(id);

        if (article == null)
        {
            return NotFound();
        }

        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", article.ArticlePath);

        return File(filePath, "application/msword", Path.GetFileName(filePath));
    }
}