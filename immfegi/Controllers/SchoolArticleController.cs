using immfegi.Data;
using immfegi.External;
using immfegi.Models;
using immfegi.Repositories.SchoolArticle;
using immfegi.ViewModels.SchoolArticle;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace immfegi.Controllers;

public class SchoolArticleController : Controller
{
    private readonly ISchoolArticleRepository _schoolArticleRepository;
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public SchoolArticleController(ISchoolArticleRepository schoolArticleRepository,
        IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor)
    {
        _schoolArticleRepository = schoolArticleRepository;
        _webHostEnvironment = webHostEnvironment;
        _httpContextAccessor = httpContextAccessor;
    }

    [Authorize(Roles = ApplicationUserRoles.Administrator)]
    public IActionResult Index()
    {
        var schoolArticles = _schoolArticleRepository.GetAll();
        return View(schoolArticles);
    }

    [Authorize(Roles = ApplicationUserRoles.Administrator)]
    public IActionResult Detail(int id)
    {
        var schoolArticle = _schoolArticleRepository.GetById(id);

        var detailsArticleViewModel = new DetailsSchoolArticleViewModel()
        {
            Id = schoolArticle.Id,
            SchoolBoySurname = schoolArticle.SchoolBoySurname,
            SchoolBoyName = schoolArticle.SchoolBoyName,
            SchoolBoyPatronymic = schoolArticle.SchoolBoyPatronymic,
            ArticleName = schoolArticle.ArticleName,
            ArticleActivities = schoolArticle.ArticleActivities,
            BirthDate = schoolArticle.BirthDate,
            SchoolBoyClass = schoolArticle.SchoolBoyClass,
            FullEducationInstitutionName = schoolArticle.FullEducationInstitutionName,
            AbbreviatedEducationInstitutionName = schoolArticle.AbbreviatedEducationInstitutionName,
            City = schoolArticle.City,
            MunicipalDistrict = schoolArticle.MunicipalDistrict,
            UrbanDistrict = schoolArticle.UrbanDistrict,
            SchoolBoyPhoneNumber = schoolArticle.SchoolBoyPhoneNumber,
            SchoolBoyEmail = schoolArticle.SchoolBoyEmail,
            ScientificDirectorName = schoolArticle.ScientificDirectorName,
            ScientificDirectorSurname = schoolArticle.ScientificDirectorSurname,
            ScientificDirectorPatronymic = schoolArticle.ScientificDirectorPatronymic,
            ScientificDirectorTitle = schoolArticle.ScientificDirectorTitle,
            ScientificDirectorPost = schoolArticle.ScientificDirectorPost,
            ScientificDirectorPhoneNumber = schoolArticle.ScientificDirectorPhoneNumber,
            ScientificDirectorEmail = schoolArticle.ScientificDirectorEmail,
            UploadDateTime = schoolArticle.UploadDateTime,
            Section = schoolArticle.Section,
            ArticleFormStatus = schoolArticle.ArticleFormStatus,
        };
        return View(detailsArticleViewModel);
    }
    
    [Authorize(Roles = ApplicationUserRoles.Administrator)]
    public IActionResult Edit(int id)
    {
        var article = _schoolArticleRepository.GetById(id);

        var changeStatusArticleViewModel = new EditSchoolArticleViewModel()
        {
                ArticlePath = article.ArticlePath,
                SchoolBoySurname = article.SchoolBoySurname,
                SchoolBoyName = article.SchoolBoyName,
                SchoolBoyPatronymic = article.SchoolBoyPatronymic,
                ArticleName = article.ArticleName,
                ArticleActivities = article.ArticleActivities,
                BirthDate = article.BirthDate,
                SchoolBoyClass = article.SchoolBoyClass,
                FullEducationInstitutionName = article.FullEducationInstitutionName,
                AbbreviatedEducationInstitutionName = article.AbbreviatedEducationInstitutionName,
                City = article.City,
                MunicipalDistrict = article.MunicipalDistrict,
                UrbanDistrict = article.UrbanDistrict,
                SchoolBoyPhoneNumber = article.SchoolBoyPhoneNumber,
                SchoolBoyEmail = article.SchoolBoyEmail,
                ScientificDirectorName = article.ScientificDirectorName,
                ScientificDirectorSurname = article.ScientificDirectorSurname,
                ScientificDirectorPatronymic = article.ScientificDirectorPatronymic,
                ScientificDirectorTitle = article.ScientificDirectorTitle,
                ScientificDirectorPost = article.ScientificDirectorPost,
                ScientificDirectorPhoneNumber = article.ScientificDirectorPhoneNumber,
                ScientificDirectorEmail = article.ScientificDirectorEmail,
                UploadDateTime = article.UploadDateTime,
                Section = article.Section,
                ArticleFormStatus = article.ArticleFormStatus,
        };
        return View(changeStatusArticleViewModel);
    }

    [HttpPost]
    [Authorize(Roles = ApplicationUserRoles.Administrator)]
    public IActionResult Edit(int id, EditSchoolArticleViewModel editSchoolArticleViewModel)
    {
        if (!ModelState.IsValid)
        {
            var userArticle = _schoolArticleRepository.GetByIdNoTracking(id);
            if (userArticle != null)
            {
                var articleForm = new SchoolArticleForm()
                {
                    Id = id,
                    SchoolBoySurname = editSchoolArticleViewModel.SchoolBoySurname,
                    SchoolBoyName = editSchoolArticleViewModel.SchoolBoyName,
                    SchoolBoyPatronymic = editSchoolArticleViewModel.SchoolBoyPatronymic,
                    ArticleName = editSchoolArticleViewModel.ArticleName,
                    ArticleActivities = editSchoolArticleViewModel.ArticleActivities,
                    BirthDate = editSchoolArticleViewModel.BirthDate,
                    SchoolBoyClass = editSchoolArticleViewModel.SchoolBoyClass,
                    FullEducationInstitutionName = editSchoolArticleViewModel.FullEducationInstitutionName,
                    AbbreviatedEducationInstitutionName = editSchoolArticleViewModel.AbbreviatedEducationInstitutionName,
                    City = editSchoolArticleViewModel.City,
                    MunicipalDistrict = editSchoolArticleViewModel.MunicipalDistrict,
                    UrbanDistrict = editSchoolArticleViewModel.UrbanDistrict,
                    SchoolBoyPhoneNumber = editSchoolArticleViewModel.SchoolBoyPhoneNumber,
                    SchoolBoyEmail = editSchoolArticleViewModel.SchoolBoyEmail,
                    ScientificDirectorName = editSchoolArticleViewModel.ScientificDirectorName,
                    ScientificDirectorSurname = editSchoolArticleViewModel.ScientificDirectorSurname,
                    ScientificDirectorPatronymic = editSchoolArticleViewModel.ScientificDirectorPatronymic,
                    ScientificDirectorTitle = editSchoolArticleViewModel.ScientificDirectorTitle,
                    ScientificDirectorPost = editSchoolArticleViewModel.ScientificDirectorPost,
                    ScientificDirectorPhoneNumber = editSchoolArticleViewModel.ScientificDirectorPhoneNumber,
                    ScientificDirectorEmail = editSchoolArticleViewModel.ScientificDirectorEmail,
                    UploadDateTime = editSchoolArticleViewModel.UploadDateTime,
                    Section = editSchoolArticleViewModel.Section,
                    ArticleFormStatus = editSchoolArticleViewModel.ArticleFormStatus,
                    ArticlePath = editSchoolArticleViewModel.ArticlePath,
                };
                _schoolArticleRepository.Update(articleForm);
                return RedirectToAction("Index");
            }
        }
        return View(editSchoolArticleViewModel);
    }

    [Authorize(Roles = ApplicationUserRoles.Student)]
    [HttpGet]
    public IActionResult Upload()
    {
        var currentApplicationUserId = _httpContextAccessor.HttpContext?.User.GetUserId();
        var currentDate = DateTime.UtcNow;
        var notVerifiedStatus = ArticleFormStatus.NotVerified;

        var registrationFormViewModel = new SchoolArticleFormViewModel()
        {
            ApplicationUserId = currentApplicationUserId,
            UploadDateTime = currentDate,
            ArticleFormStatus = notVerifiedStatus,
            BirthDate = currentDate
        };

        return View(registrationFormViewModel);
    }

    [HttpPost]
    [Authorize(Roles = ApplicationUserRoles.Student)]
    public IActionResult Upload(SchoolArticleFormViewModel schoolArticleFormViewModel)
    {
        if (ModelState.IsValid)
        {
            var schoolArticleForm = new SchoolArticleForm()
            {
                SchoolBoySurname = schoolArticleFormViewModel.SchoolBoySurname,
                SchoolBoyName = schoolArticleFormViewModel.SchoolBoyName,
                SchoolBoyPatronymic = schoolArticleFormViewModel.SchoolBoyPatronymic,
                ArticleName = schoolArticleFormViewModel.ArticleName,
                ArticleActivities = schoolArticleFormViewModel.ArticleActivities,
                BirthDate = schoolArticleFormViewModel.BirthDate,
                SchoolBoyClass = schoolArticleFormViewModel.SchoolBoyClass,
                FullEducationInstitutionName = schoolArticleFormViewModel.FullEducationInstitutionName,
                AbbreviatedEducationInstitutionName = schoolArticleFormViewModel.AbbreviatedEducationInstitutionName,
                City = schoolArticleFormViewModel.City,
                MunicipalDistrict = schoolArticleFormViewModel.MunicipalDistrict,
                UrbanDistrict = schoolArticleFormViewModel.UrbanDistrict,
                SchoolBoyPhoneNumber = schoolArticleFormViewModel.SchoolBoyPhoneNumber,
                SchoolBoyEmail = schoolArticleFormViewModel.SchoolBoyEmail,
                ScientificDirectorName = schoolArticleFormViewModel.ScientificDirectorName,
                ScientificDirectorSurname = schoolArticleFormViewModel.ScientificDirectorSurname,
                ScientificDirectorPatronymic = schoolArticleFormViewModel.ScientificDirectorPatronymic,
                ScientificDirectorTitle = schoolArticleFormViewModel.ScientificDirectorTitle,
                ScientificDirectorPost = schoolArticleFormViewModel.ScientificDirectorPost,
                ScientificDirectorPhoneNumber = schoolArticleFormViewModel.ScientificDirectorPhoneNumber,
                ScientificDirectorEmail = schoolArticleFormViewModel.ScientificDirectorEmail,
                UploadDateTime = schoolArticleFormViewModel.UploadDateTime,
                Section = schoolArticleFormViewModel.Section,
                ArticleFormStatus = schoolArticleFormViewModel.ArticleFormStatus,
                ArticlePath = SaveFile(schoolArticleFormViewModel.Article),
                UserSchoolArticles = new List<UserSchoolArticle>
                {
                    new() { ApplicationUserId = schoolArticleFormViewModel.ApplicationUserId }
                }
            };  
            
            _schoolArticleRepository.Add(schoolArticleForm);
            TempData["Success"] = "Ваша статья подана!";
            return RedirectToAction("Upload", "SchoolArticle");
        }
        return View(schoolArticleFormViewModel);
    }
    
    [Authorize(Roles = ApplicationUserRoles.Administrator)]
    public IActionResult OpenArticle(int id)
    {
        var article = _schoolArticleRepository.GetById(id);

        if (article == null)
        {
            return NotFound();
        }

        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", article.ArticlePath);

        return File(filePath, "application/msword", Path.GetFileName(filePath));
    }

    [Authorize(Roles = ApplicationUserRoles.Administrator)]
    private string SaveFile(IFormFile file)
    {
        if (file != null)
        {
            var uploadsRoot = Path.Combine(_webHostEnvironment.WebRootPath, "files");

            var immfegiPath = Path.Combine(uploadsRoot, "ИММФЭГИ");
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

            return "/files/ИММФЭГИ/" + uniqueFileName;
        }
        return null;
    }
    [Authorize(Roles = ApplicationUserRoles.Administrator)]
    [HttpPost]
    public IActionResult Delete(int id)
    {
        _schoolArticleRepository.DeleteArticle(id);
            
        return RedirectToAction("Index");
    }
}