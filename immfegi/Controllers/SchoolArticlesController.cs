using immfegi.Data;
using immfegi.External;
using immfegi.Models.NewModels;
using immfegi.ViewModels.NewViewModels.SchoolArticles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace immfegi.Controllers;

public class SchoolArticlesController : Controller
{
    private readonly DataContext _context;
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public SchoolArticlesController(DataContext context,
        IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _webHostEnvironment = webHostEnvironment;
        _httpContextAccessor = httpContextAccessor;
    }

    [HttpGet]
    [Authorize(Roles = ApplicationUserRoles.Administrator)]
    public IActionResult Index()
    {
        var schoolArticles = _context.SchoolArticles.ToList();
        return View(schoolArticles);
    }

    [HttpGet]
    [Authorize(Roles = ApplicationUserRoles.Administrator)]
    public IActionResult Detail(int id)
    {
        var schoolArticle = _context.SchoolArticles.FirstOrDefault(i => i.Id == id);

        var detailsArticleViewModel = new SchoolArticleDetailsViewModel()
        {
            Id = schoolArticle.Id,
            Surname = schoolArticle.Surname,
            Name = schoolArticle.Name,
            Patronymic = schoolArticle.Patronymic,
            PhoneNumber = schoolArticle.PhoneNumber,
            Email = schoolArticle.Email,
            ArticleName = schoolArticle.ArticleName,
            ArticleActivities = schoolArticle.ArticleActivities,
            UploadDateTime = schoolArticle.UploadDateTime,
            Section = schoolArticle.Section,
            ArticleFormStatus = schoolArticle.ArticleFormStatus,
        };
        return View(detailsArticleViewModel);
    }

    [HttpGet]
    [Authorize(Roles = ApplicationUserRoles.Administrator)]
    public IActionResult Edit(int id)
    {
        var article = _context.SchoolArticles.FirstOrDefault(i => i.Id == id);

        var editSchoolArticleViewModel = new EditSchoolArticleViewModel()
        {
            RequestPath = article.RequestPath,
            ArticlePath = article.ArticlePath,
            Surname = article.Surname,
            Name = article.Name,
            Patronymic = article.Patronymic,
            ArticleName = article.ArticleName,
            ArticleActivities = article.ArticleActivities,
            PhoneNumber = article.PhoneNumber,
            Email = article.Email,
            UploadDateTime = article.UploadDateTime,
            Section = article.Section,
            ArticleFormStatus = article.ArticleFormStatus,
        };
        return View(editSchoolArticleViewModel);
    }

    [HttpPost]
    [Authorize(Roles = ApplicationUserRoles.Administrator)]
    public IActionResult Edit(int id, EditSchoolArticleViewModel editSchoolArticleViewModel)
    {
        if (!ModelState.IsValid)
        {
            var userArticle = _context.SchoolArticles.AsNoTracking().FirstOrDefault(i => i.Id == id);
            if (userArticle != null)
            {
                var articleForm = new SchoolArticle()
                {
                    Id = id,
                    Surname = editSchoolArticleViewModel.Surname,
                    Name = editSchoolArticleViewModel.Name,
                    Patronymic = editSchoolArticleViewModel.Patronymic,
                    ArticleName = editSchoolArticleViewModel.ArticleName,
                    ArticleActivities = editSchoolArticleViewModel.ArticleActivities,
                    PhoneNumber = editSchoolArticleViewModel.PhoneNumber,
                    Email = editSchoolArticleViewModel.Email,
                    UploadDateTime = editSchoolArticleViewModel.UploadDateTime,
                    Section = editSchoolArticleViewModel.Section,
                    ArticleFormStatus = editSchoolArticleViewModel.ArticleFormStatus,
                    ArticlePath = editSchoolArticleViewModel.ArticlePath,
                    RequestPath = editSchoolArticleViewModel.RequestPath,
                };

                _context.Update(articleForm);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
        }
        return View(editSchoolArticleViewModel);
    }

    [Authorize(Roles = ApplicationUserRoles.Student)]
    [HttpGet]
    public IActionResult Create()
    {
        var currentApplicationUserId = _httpContextAccessor.HttpContext?.User.GetUserId();
        var currentDate = DateTime.Now;
        var notVerifiedStatus = ArticleFormStatus.NotVerified;

        var registrationFormViewModel = new SchoolArticleViewModel()
        {
            ApplicationUserId = currentApplicationUserId,
            UploadDateTime = currentDate,
            ArticleFormStatus = notVerifiedStatus,
        };

        return View(registrationFormViewModel);
    }

    [HttpPost]
    [Authorize(Roles = ApplicationUserRoles.Student)]
    public IActionResult Create(SchoolArticleViewModel schoolArticleViewModel)
    {
        if (ModelState.IsValid)
        {
            var schoolArticleForm = new SchoolArticle()
            {
                Surname = schoolArticleViewModel.Surname,
                Name = schoolArticleViewModel.Name,
                Patronymic = schoolArticleViewModel.Patronymic,
                ArticleName = schoolArticleViewModel.ArticleName,
                ArticleActivities = schoolArticleViewModel.ArticleActivities,
                PhoneNumber = schoolArticleViewModel.PhoneNumber,
                Email = schoolArticleViewModel.Email,
                UploadDateTime = schoolArticleViewModel.UploadDateTime,
                Section = schoolArticleViewModel.Section,
                ArticleFormStatus = schoolArticleViewModel.ArticleFormStatus,
                ArticlePath = SaveFile(schoolArticleViewModel.Article),
                RequestPath = SaveFile(schoolArticleViewModel.Request),
                ApplicationUserSchoolArticlesCollection = new List<ApplicationUserSchoolArticles>
                {
                    new() { ApplicationUserId = schoolArticleViewModel.ApplicationUserId }
                }
            };

            _context.Add(schoolArticleForm);
            _context.SaveChanges();

            TempData["Success"] = "Ваша статья подана!";
            return RedirectToAction("Upload", "SchoolArticle");
        }

        return View(schoolArticleViewModel);
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

    [Authorize(Roles = ApplicationUserRoles.Administrator)]
    [HttpPost]
    public IActionResult Delete(int id)
    {
        var article = _context.SchoolArticles.FirstOrDefault(i => i.Id == id);
        if (article != null)
            _context.SchoolArticles.Remove(article);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }
    
    
    [Authorize(Roles = ApplicationUserRoles.Administrator)]
    public IActionResult DownloadArticle(int id)
    {
        var article = _context.SchoolArticles.FirstOrDefault(i => i.Id == id);

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
        var article = _context.SchoolArticles.FirstOrDefault(i => i.Id == id);

        if (article == null)
        {
            return NotFound();
        }

        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", article.RequestPath);

        return File(filePath, "application/msword", Path.GetFileName(filePath));
    }
}