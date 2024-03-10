using immfegi.Data;
using immfegi.External;
using immfegi.Models.NewModels;
using immfegi.ViewModels.NewViewModels.Articles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DetailsArticleViewModel = immfegi.ViewModels.NewViewModels.Articles.DetailsArticleViewModel;

namespace immfegi.Controllers;

public class ArticlesController : Controller
{
    private readonly DataContext _context;
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ArticlesController(DataContext context, IWebHostEnvironment webHostEnvironment,
        IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _webHostEnvironment = webHostEnvironment;
        _httpContextAccessor = httpContextAccessor;
    }

    [HttpGet]
    [Authorize(Roles = ApplicationUserRoles.Administrator)]
    public IActionResult Edit(int id)
    {
        var article = _context.Articles.FirstOrDefault(i => i.Id == id);

        var changeStatusArticleViewModel = new EditArticleViewModel()
        {
            ArticleNameOnRussian = article.ArticleNameOnRussian,
            ArticleNameOnEnglish = article.ArticleNameOnEnglish,
            Section = article.Section,
            Name = article.Name,
            Surname = article.Surname,
            Patronymic = article.Patronymic,
            PhoneNumber = article.PhoneNumber,
            Email = article.Email,
            ArticlePath = article.ArticlePath,
            RequestPath = article.RequestPath,
            ArticleFormStatus = article.ArticleFormStatus,
            UploadDateTime = article.UploadDateTime,
        };

        return View(changeStatusArticleViewModel);
    }

    [HttpPost]
    [Authorize(Roles = ApplicationUserRoles.Administrator)]
    public IActionResult Edit(int id, EditArticleViewModel editArticleViewModel)
    {
        if (!ModelState.IsValid)
        {
            var userArticle = _context.Articles.AsNoTracking().FirstOrDefault(i => i.Id == id);
            if (userArticle != null)
            {
                var articleForm = new Article()
                {
                    Id = id,
                    ArticleNameOnRussian = editArticleViewModel.ArticleNameOnRussian,
                    ArticleNameOnEnglish = editArticleViewModel.ArticleNameOnEnglish,
                    Section = editArticleViewModel.Section,
                    Name = editArticleViewModel.Name,
                    Surname = editArticleViewModel.Surname,
                    Patronymic = editArticleViewModel.Patronymic,
                    PhoneNumber = editArticleViewModel.PhoneNumber,
                    Email = editArticleViewModel.Email,
                    ArticlePath = editArticleViewModel.ArticlePath,
                    RequestPath = editArticleViewModel.RequestPath,
                    ArticleFormStatus = editArticleViewModel.ArticleFormStatus,
                    UploadDateTime = editArticleViewModel.UploadDateTime,
                };
                _context.Update(articleForm);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        return View(editArticleViewModel);
    }
    
    [HttpGet]
    [Authorize(Roles = ApplicationUserRoles.Administrator)]
    public IActionResult Detail(int id)
    {
        var article = _context.Articles.FirstOrDefault(i => i.Id == id);

        var detailsArticleViewModel = new DetailsArticleViewModel()
        {
            Id = article.Id,
            ArticleNameOnRussian = article.ArticleNameOnRussian,
            ArticleNameOnEnglish = article.ArticleNameOnEnglish,
            Section = article.Section,
            Name = article.Name,
            Surname = article.Surname,
            Patronymic = article.Patronymic,
            PhoneNumber = article.PhoneNumber,
            Email = article.Email,
            ArticleFormStatus = article.ArticleFormStatus,
            UploadDateTime = article.UploadDateTime,
        };
        return View(detailsArticleViewModel);
    }

    [HttpGet]
    [Authorize(Roles = ApplicationUserRoles.Administrator)]
    public IActionResult Index()
    {
        return View(_context.Articles.ToList());
    }

    [HttpGet]
    [Authorize(Roles = ApplicationUserRoles.Student)]
    public IActionResult Create()
    {
        var currentApplicationUserId = _httpContextAccessor.HttpContext?.User.GetUserId();
        var notVerifiedStatus = ArticleFormStatus.NotVerified;

        var articleViewModel = new ArticleViewModel()
        {
            ApplicationUserId = currentApplicationUserId,
            ArticleFormStatus = notVerifiedStatus,
        };

        return View(articleViewModel);
    }

    [HttpPost]
    [Authorize(Roles = ApplicationUserRoles.Student)]
    public IActionResult Create(ArticleViewModel articleViewModel)
    {
        if (ModelState.IsValid)
        {
            var article = new Article
            {
                Name = articleViewModel.Name,
                Surname = articleViewModel.Surname,
                Patronymic = articleViewModel.Patronymic,
                PhoneNumber = articleViewModel.PhoneNumber,
                Email = articleViewModel.Email,
                Section = articleViewModel.Section,
                ArticleNameOnRussian = articleViewModel.ArticleNameOnRussian,
                ArticleNameOnEnglish = articleViewModel.ArticleNameOnEnglish,
                ArticlePath = SaveFile(articleViewModel.Article),
                RequestPath = SaveFile(articleViewModel.Request),
                ArticleFormStatus = articleViewModel.ArticleFormStatus,
                UploadDateTime = DateTime.Now,
                ApplicationUserArticlesCollection = new List<ApplicationUserArticles>
                {
                    new() { ApplicationUserId = articleViewModel.ApplicationUserId }
                }
            };

            _context.Add(article);
            _context.SaveChanges();

            TempData["Success"] = "Ваша статья подана!";
            return RedirectToAction("Create", "Articles");
        }

        return View(articleViewModel);
    }

    [Authorize(Roles = ApplicationUserRoles.Administrator)]
    public IActionResult DownloadArticle(int id)
    {
        var article = _context.Articles.FirstOrDefault(i => i.Id == id);

        if (article == null)
        {
            return NotFound();
        }

        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", article.ArticlePath);

        return File(filePath, "application/msword", Path.GetFileName(filePath));
    }

    [Authorize(Roles = ApplicationUserRoles.Administrator)]
    public IActionResult DownloadRequest(int id)
    {
        var article = _context.Articles.FirstOrDefault(i => i.Id == id);
        ;

        if (article == null)
        {
            return NotFound();
        }

        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", article.RequestPath);

        return File(filePath, "application/msword", Path.GetFileName(filePath));
    }

    [Authorize(Roles = ApplicationUserRoles.Administrator)]
    [HttpPost]
    public IActionResult Delete(int id)
    {
        var article = _context.Articles.FirstOrDefault(i => i.Id == id);

        if (article != null)
            _context.Articles.Remove(article);

        _context.SaveChanges();

        return RedirectToAction("Index");
    }


    [Authorize(Roles = ApplicationUserRoles.Administrator)]
    private string SaveFile(IFormFile file)
    {
        if (file != null)
        {
            var uploadsRoot = Path.Combine(_webHostEnvironment.WebRootPath, "files");

            var immfegiPath = Path.Combine(uploadsRoot, "immfegi");

            if (!Directory.Exists(immfegiPath))
            {
                Directory.CreateDirectory(immfegiPath);
            }

            var fileName = Path.GetFileNameWithoutExtension(file.FileName);
            var extension = Path.GetExtension(file.FileName);
            var uniqueFileName = UniqueFileName.GetUniqueFileName(fileName, extension, immfegiPath);

            var filePath = Path.Combine(immfegiPath, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            return "/files/immfegi/" + uniqueFileName;
        }

        return null;
    }
}