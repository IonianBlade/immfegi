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
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var article = _articleRepository.GetById(id);
            
            var changeStatusArticleViewModel = new EditArticleViewModel()
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
        [Authorize(Roles = ApplicationUserRoles.Administrator)]
        public IActionResult Edit(int id, EditArticleViewModel editArticleViewModel)
        {
             if (!ModelState.IsValid)
            {
                var userArticle = _articleRepository.GetByIdNoTracking(id);
                if (userArticle != null)
                {
                    var articleForm = new ArticleForm()
                    {
                        Id = id,
                        SpeakerName = editArticleViewModel.SpeakerName,
                        SpeakerSurname = editArticleViewModel.SpeakerSurname,
                        SpeakerPatronymic = editArticleViewModel.SpeakerPatronymic,
                        FullEducationInstitutionName = editArticleViewModel.FullEducationInstitutionName,
                        SpeakerPost = editArticleViewModel.SpeakerPost,
                        Course = editArticleViewModel.Course,
                        ScientificTitle = editArticleViewModel.ScientificTitle,
                        Group = editArticleViewModel.Group,
                        ArticleNameOnRussian = editArticleViewModel.ArticleNameOnRussian,
                        ArticleNameOnEnglish = editArticleViewModel.ArticleNameOnEnglish,
                        IntendedParticipation = editArticleViewModel.IntendedParticipation,
                        Section = editArticleViewModel.Section,
                        SpeakerPhoneNumber = editArticleViewModel.SpeakerPhoneNumber,
                        SpeakerEmail = editArticleViewModel.SpeakerEmail,
                        SpeakerRole = editArticleViewModel.SpeakerRole,
                        ScientificDirectorName = editArticleViewModel.ScientificDirectorName,
                        ScientificDirectorSurname = editArticleViewModel.ScientificDirectorSurname,
                        ScientificDirectorPatronymic = editArticleViewModel.ScientificDirectorPatronymic,
                        ScientificDirectorFullEducationInstitutionName = editArticleViewModel.ScientificDirectorFullEducationInstitutionName,
                        ScientificDirectorPost = editArticleViewModel.ScientificDirectorPost,
                        ScientificDirectorTitle = editArticleViewModel.ScientificDirectorTitle,
                        ScientificDirectorPhoneNumber = editArticleViewModel.ScientificDirectorPhoneNumber,
                        ScientificDirectorEmail = editArticleViewModel.ScientificDirectorEmail,
                        ArticlePath = editArticleViewModel.ArticlePath,
                        ArticleFormStatus = editArticleViewModel.ArticleFormStatus,
                        UploadDateTime = editArticleViewModel.UploadDateTime,
                    };
                    _articleRepository.Update(articleForm);
                    return RedirectToAction("Index");
                }
            }
            return View(editArticleViewModel);
        }

        [Authorize(Roles = ApplicationUserRoles.Administrator)]
        [HttpGet]
        public IActionResult Detail(int id)
        {
            var article = _articleRepository.GetById(id);
            
            var detailsArticleViewModel = new DetailsArticleViewModel()
            {
                Id = article.Id,
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
            return View(detailsArticleViewModel);
        }

        

        [Authorize(Roles = ApplicationUserRoles.Student)]
        [HttpGet]
        public IActionResult Upload()
        {
            var currentApplicationUserId = _httpContextAccessor.HttpContext?.User.GetUserId();
            var currentUploadDate = DateTime.UtcNow;
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
        [Authorize(Roles = ApplicationUserRoles.Student)]
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
                    ArticlePath = SaveFile(articleFormViewModel.Article),
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
            _articleRepository.DeleteArticle(id);
            
            return RedirectToAction("Index");
        }
}