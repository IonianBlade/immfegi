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
        var article = _schoolArticleRepository.GetById(id);

        var changeStatusArticleViewModel = new ChangeStatusSchoolArticleViewModel()
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
    public IActionResult Detail(int id, ChangeStatusSchoolArticleViewModel changeStatusSchoolArticleViewModel)
    {
        if (!ModelState.IsValid)
        {
            var userArticle = _schoolArticleRepository.GetByIdNoTracking(id);
            if (userArticle != null)
            {
                var articleForm = new SchoolArticleForm()
                {
                    Id = id,
                    SchoolBoySurname = changeStatusSchoolArticleViewModel.SchoolBoySurname,
                    SchoolBoyName = changeStatusSchoolArticleViewModel.SchoolBoyName,
                    SchoolBoyPatronymic = changeStatusSchoolArticleViewModel.SchoolBoyPatronymic,
                    ArticleName = changeStatusSchoolArticleViewModel.ArticleName,
                    ArticleActivities = changeStatusSchoolArticleViewModel.ArticleActivities,
                    BirthDate = changeStatusSchoolArticleViewModel.BirthDate,
                    SchoolBoyClass = changeStatusSchoolArticleViewModel.SchoolBoyClass,
                    FullEducationInstitutionName = changeStatusSchoolArticleViewModel.FullEducationInstitutionName,
                    AbbreviatedEducationInstitutionName = changeStatusSchoolArticleViewModel.AbbreviatedEducationInstitutionName,
                    City = changeStatusSchoolArticleViewModel.City,
                    MunicipalDistrict = changeStatusSchoolArticleViewModel.MunicipalDistrict,
                    UrbanDistrict = changeStatusSchoolArticleViewModel.UrbanDistrict,
                    SchoolBoyPhoneNumber = changeStatusSchoolArticleViewModel.SchoolBoyPhoneNumber,
                    SchoolBoyEmail = changeStatusSchoolArticleViewModel.SchoolBoyEmail,
                    ScientificDirectorName = changeStatusSchoolArticleViewModel.ScientificDirectorName,
                    ScientificDirectorSurname = changeStatusSchoolArticleViewModel.ScientificDirectorSurname,
                    ScientificDirectorPatronymic = changeStatusSchoolArticleViewModel.ScientificDirectorPatronymic,
                    ScientificDirectorTitle = changeStatusSchoolArticleViewModel.ScientificDirectorTitle,
                    ScientificDirectorPost = changeStatusSchoolArticleViewModel.ScientificDirectorPost,
                    ScientificDirectorPhoneNumber = changeStatusSchoolArticleViewModel.ScientificDirectorPhoneNumber,
                    ScientificDirectorEmail = changeStatusSchoolArticleViewModel.ScientificDirectorEmail,
                    UploadDateTime = changeStatusSchoolArticleViewModel.UploadDateTime,
                    Section = changeStatusSchoolArticleViewModel.Section,
                    ArticleFormStatus = changeStatusSchoolArticleViewModel.ArticleFormStatus,
                    ArticlePath = changeStatusSchoolArticleViewModel.ArticlePath,
                };
                _schoolArticleRepository.Update(articleForm);
                return RedirectToAction("Index");
            }
        }
        return View(changeStatusSchoolArticleViewModel);
    }

    [Authorize(Roles = ApplicationUserRoles.Student)]
    [HttpGet]
    public IActionResult Upload()
    {
        var currentApplicationUserId = _httpContextAccessor.HttpContext?.User.GetUserId();
        var currentDate = DateTime.Now;
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
                ArticlePath = SaveFile(schoolArticleFormViewModel.Article, schoolArticleFormViewModel.Section, schoolArticleFormViewModel.SchoolBoySurname, schoolArticleFormViewModel.SchoolBoyName, schoolArticleFormViewModel.SchoolBoyPatronymic),
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

    public IActionResult OpenArticle(int id)
    {
        var article = _schoolArticleRepository.GetById(id);

        if (article == null)
        {
            return NotFound();
        }

        string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", article.ArticlePath);

        return File(filePath, "application/msword", Path.GetFileNameWithoutExtension(filePath));
    }


    private string SaveFile(IFormFile file, string section, string surname, string name, string? patronymic)
    {

        if (file != null && file.Length > 0)
        {
            string uploadsRoot = Path.Combine(_webHostEnvironment.WebRootPath, "files");

            string immfegiPath = Path.Combine(uploadsRoot, "ИММФЭГИ");
            if (!Directory.Exists(immfegiPath))
            {
                Directory.CreateDirectory(immfegiPath);
            }

            string sectionPath = Path.Combine(immfegiPath, section);
            if (!Directory.Exists(sectionPath))
            {
                Directory.CreateDirectory(sectionPath);
            }

            var fullname = CombineFullName(surname, name, patronymic);
            string participantPath = Path.Combine(sectionPath, fullname);
            if (!Directory.Exists(participantPath))
            {
                Directory.CreateDirectory(participantPath);
            }

            string fileName = Path.GetFileNameWithoutExtension(file.FileName);
            string extension = Path.GetExtension(file.FileName);
            UniqueFileName uf = new();
            string uniqueFileName = uf.GetUniqueFileName(fileName, extension, participantPath);

            string filePath = Path.Combine(participantPath, uniqueFileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            return "/files/ИММФЭГИ/" + section + "/" + fullname + "/" + uniqueFileName;
        }
        return null;
    }

    private static string CombineFullName(string surname, string name, string patronymic)
    {
        var fullName = surname + " " + name + " " + patronymic;

        return fullName;
    }
}