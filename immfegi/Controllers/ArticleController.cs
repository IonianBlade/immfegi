using immfegi.Data;
using immfegi.External;
using immfegi.Models;
using immfegi.Repositories.Article;
using immfegi.ViewModels.Article;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace immfegi.Controllers;

public class ArticleController : Controller
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ArticleController(IArticleRepository articleRepository, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor)
        {
            _articleRepository = articleRepository;
            _webHostEnvironment = webHostEnvironment;
            _httpContextAccessor = httpContextAccessor;
        }

        [Authorize(Roles = ApplicationUserRoles.Administrator)]
        public IActionResult Index()
        {
            var articles = _articleRepository.GetAll();
            return View(articles);
        }
        
        [Authorize(Roles = ApplicationUserRoles.Administrator)]
        public IActionResult Detail(int id)
        {
            var article = _articleRepository.GetById(id);
            
            var changeStatusArticleViewModel = new ChangeStatusArticleViewModel()
            {
                SpeakerName = article.SpeakerName,
                SpeakerSurname = article.SpeakerSurname,
                SpeakerPatronymic = article.SpeakerPatronymic,
                FullEducationInstitutionName = article.FullEducationInstitutionName,
                SpeakerPost = article.SpeakerPost,
                Course = article.Course,
                ScientificTitle = article.ScientificTitle,
                Group = article.Group,
                ArticleNameOnRussian = article.ArticleNameOnRussian,
                ArticleNameOnEnglish = article.ArticleNameOnEnglish,
                IntendedParticipation = article.IntendedParticipation,
                Section = article.Section,
                SpeakerPhoneNumber = article.SpeakerPhoneNumber,
                SpeakerEmail = article.SpeakerEmail,
                SpeakerRole = article.SpeakerRole,
                ScientificDirectorName = article.ScientificDirectorName,
                ScientificDirectorSurname = article.ScientificDirectorSurname,
                ScientificDirectorPatronymic = article.ScientificDirectorPatronymic,
                ScientificDirectorFullEducationInstitutionName = article.ScientificDirectorFullEducationInstitutionName,
                ScientificDirectorPost = article.ScientificDirectorPost,
                ScientificDirectorTitle = article.ScientificDirectorTitle,
                ScientificDirectorPhoneNumber = article.ScientificDirectorPhoneNumber,
                ScientificDirectorEmail = article.ScientificDirectorEmail,
                ArticlePath = article.ArticlePath,
                ArticleFormStatus = article.ArticleFormStatus,
                UploadDateTime = article.UploadDateTime,
            };

            return View(changeStatusArticleViewModel);
        }

        [HttpPost]
        public IActionResult Detail(int id, ChangeStatusArticleViewModel changeStatusArticleViewModel)
        {
            if (!ModelState.IsValid)
            {
                var userArticle = _articleRepository.GetByIdNoTracking(id);
                if (userArticle != null)
                {
                    var articleForm = new ArticleForm()
                    {
                        Id = id,
                        SpeakerName = changeStatusArticleViewModel.SpeakerName,
                        SpeakerSurname = changeStatusArticleViewModel.SpeakerSurname,
                        SpeakerPatronymic = changeStatusArticleViewModel.SpeakerPatronymic,
                        FullEducationInstitutionName = changeStatusArticleViewModel.FullEducationInstitutionName,
                        SpeakerPost = changeStatusArticleViewModel.SpeakerPost,
                        Course = changeStatusArticleViewModel.Course,
                        ScientificTitle = changeStatusArticleViewModel.ScientificTitle,
                        Group = changeStatusArticleViewModel.Group,
                        ArticleNameOnRussian = changeStatusArticleViewModel.ArticleNameOnRussian,
                        ArticleNameOnEnglish = changeStatusArticleViewModel.ArticleNameOnEnglish,
                        IntendedParticipation = changeStatusArticleViewModel.IntendedParticipation,
                        Section = changeStatusArticleViewModel.Section,
                        SpeakerPhoneNumber = changeStatusArticleViewModel.SpeakerPhoneNumber,
                        SpeakerEmail = changeStatusArticleViewModel.SpeakerEmail,
                        SpeakerRole = changeStatusArticleViewModel.SpeakerRole,
                        ScientificDirectorName = changeStatusArticleViewModel.ScientificDirectorName,
                        ScientificDirectorSurname = changeStatusArticleViewModel.ScientificDirectorSurname,
                        ScientificDirectorPatronymic = changeStatusArticleViewModel.ScientificDirectorPatronymic,
                        ScientificDirectorFullEducationInstitutionName = changeStatusArticleViewModel.ScientificDirectorFullEducationInstitutionName,
                        ScientificDirectorPost = changeStatusArticleViewModel.ScientificDirectorPost,
                        ScientificDirectorTitle = changeStatusArticleViewModel.ScientificDirectorTitle,
                        ScientificDirectorPhoneNumber = changeStatusArticleViewModel.ScientificDirectorPhoneNumber,
                        ScientificDirectorEmail = changeStatusArticleViewModel.ScientificDirectorEmail,
                        ArticlePath = changeStatusArticleViewModel.ArticlePath,
                        ArticleFormStatus = changeStatusArticleViewModel.ArticleFormStatus,
                        UploadDateTime = changeStatusArticleViewModel.UploadDateTime,
                    };
                    _articleRepository.Update(articleForm);
                    return RedirectToAction("Index");
                }
            }
            return View(changeStatusArticleViewModel);
        }
        public IActionResult OpenArticle(int id)
        {
            var article = _articleRepository.GetById(id);

            if (article == null)
            {
                return NotFound();
            }

            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", article.ArticlePath);

            return File(filePath, "application/msword", Path.GetFileNameWithoutExtension(filePath));
        }
        

        [Authorize(Roles = ApplicationUserRoles.Student)]
        [HttpGet]
        public IActionResult Upload()
        {
            var currentApplicationUserId = _httpContextAccessor.HttpContext?.User.GetUserId();
            var currentUploadDate = DateTime.Now;
            var notVerifiedStatus = ArticleFormStatus.NotVerified;
            
            var registrationFormViewModel = new ArticleFormViewModel
            {
                ApplicationUserId = currentApplicationUserId,
                UploadDateTime = currentUploadDate,
                ArticleFormStatus = notVerifiedStatus,
            };

            return View(registrationFormViewModel);
        }

        [HttpPost]
        public IActionResult Upload(ArticleFormViewModel articleFormViewModel)
        {
            if (ModelState.IsValid)
            {
                var articleForm = new ArticleForm
                {
                    SpeakerName = articleFormViewModel.SpeakerName,
                    SpeakerSurname = articleFormViewModel.SpeakerSurname,
                    SpeakerPatronymic = articleFormViewModel.SpeakerPatronymic,
                    FullEducationInstitutionName = articleFormViewModel.FullEducationInstitutionName,
                    SpeakerPost = articleFormViewModel.SpeakerPost,
                    Course = articleFormViewModel.Course,
                    ScientificTitle = articleFormViewModel.ScientificTitle,
                    Group = articleFormViewModel.Group,
                    ArticleNameOnRussian = articleFormViewModel.ArticleNameOnRussian,
                    ArticleNameOnEnglish = articleFormViewModel.ArticleNameOnEnglish,
                    IntendedParticipation = articleFormViewModel.IntendedParticipation,
                    Section = articleFormViewModel.Section,
                    SpeakerPhoneNumber = articleFormViewModel.SpeakerPhoneNumber,
                    SpeakerEmail= articleFormViewModel.SpeakerEmail,
                    SpeakerRole = articleFormViewModel.SpeakerRole,
                    ScientificDirectorName = articleFormViewModel.ScientificDirectorName,
                    ScientificDirectorSurname = articleFormViewModel.ScientificDirectorSurname,
                    ScientificDirectorPatronymic = articleFormViewModel.ScientificDirectorPatronymic,
                    ScientificDirectorFullEducationInstitutionName = articleFormViewModel.ScientificDirectorFullEducationInstitutionName,
                    ScientificDirectorPost = articleFormViewModel.ScientificDirectorPost,
                    ScientificDirectorTitle = articleFormViewModel.ScientificDirectorTitle,
                    ScientificDirectorPhoneNumber = articleFormViewModel.ScientificDirectorPhoneNumber,
                    ScientificDirectorEmail = articleFormViewModel.ScientificDirectorEmail,
                    ArticlePath = SaveFile(articleFormViewModel.Article, articleFormViewModel.Section, articleFormViewModel.SpeakerSurname, articleFormViewModel.SpeakerName, articleFormViewModel.SpeakerPatronymic),
                    ArticleFormStatus = articleFormViewModel.ArticleFormStatus,
                    UploadDateTime = articleFormViewModel.UploadDateTime,
                    UserArticles = new List<UserArticle>
                    {
                        new() { ApplicationUserId = articleFormViewModel.ApplicationUserId }
                    }
                };

                _articleRepository.Add(articleForm);
                TempData["Success"] = "Ваша статья подана!";
                return RedirectToAction("Upload", "Article");
            }
            return View(articleFormViewModel);
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