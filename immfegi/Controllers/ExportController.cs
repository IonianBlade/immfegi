using immfegi.Data;
using immfegi.External;
using immfegi.Models;
using immfegi.Repositories.Article;
using immfegi.Repositories.SchoolArticle;
using immfegi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace immfegi.Controllers;

public class ExportController : Controller
{
    private readonly IArticleRepository _articleRepository;
    private readonly ISchoolArticleRepository _schoolArticleRepository;

    public ExportController(IArticleRepository articleRepository, ISchoolArticleRepository schoolArticleRepository)
    {
        _articleRepository = articleRepository;
        _schoolArticleRepository = schoolArticleRepository;
    }

    [Authorize(Roles = ApplicationUserRoles.Administrator)]
    public IActionResult ExportArticleToExcel()
    {
        var articles = _articleRepository.GetAll();

        using (var package = new ExcelPackage())
        {
            var worksheet = package.Workbook.Worksheets.Add("Список заявок");

            var headers = new Dictionary<string, string>
            {
                { "SpeakerName", "Имя докладчика" },
                { "SpeakerSurname", "Фамилия докладчика" },
                { "SpeakerPatronymic", "Отчество докладчика" },
                { "ArticleFormStatus", "Статус заявки" },
                { "FullEducationInstitutionName", "Полное название образовательного учреждения" },
                { "SpeakerPost", "Занимаемая должность" },
                { "Course", "Курс обучения" },
                { "ScientificTitle", "Научное звание, научная степень" },
                { "Group", "Группа" },
                { "ArticleNameOnRussian", "Название статьи на русском" },
                { "ArticleNameOnEnglish", "Название статьи на английском" },
                { "IntendedParticipation", "Докладчик" },
                { "Section", "Секция" },
                { "SpeakerPhoneNumber", "Телефон выступающего" },
                { "SpeakerEmail", "Электронная почта" },
                { "SpeakerRole", "Статус" },
                { "ScientificDirectorName", "Имя научного руководителя" },
                { "ScientificDirectorSurname", "Фамилия научного руководителя" },
                { "ScientificDirectorPatronymic", "Отчество научного руководителя" },
                { "ScientificDirectorFullEducationInstitutionName", "Полное название образовательного учреждения научного руководителя" },
                { "ScientificDirectorPost", "Занимаемая дожность научного руководителя" },
                { "ScientificDirectorTitle", "Ученое звание научного руководителя" },
                { "ScientificDirectorPhoneNumber", "Телефон научного руководителя" },
                { "ScientificDirectorEmail", "Электронная почта научного руководителя" },
            };

            var col = 1;
            foreach (var header in headers)
            {
                var cell = worksheet.Cells[1, col];
                cell.Value = header.Value;
                cell.Style.WrapText = true;
                col++;
            }

            for (int i = 0; i < articles.Count; i++)
            {
                var article = articles[i];

                col = 1;
                foreach (var header in headers)
                {
                    var propName = header.Key;
                    var propValue = typeof(ArticleForm).GetProperty(propName)?.GetValue(article, null);

                    if (propValue != null && propValue.GetType().IsEnum)
                    {
                        propValue = ((Enum)propValue).GetDisplayName();
                    }

                    worksheet.Cells[i + 2, col].Value = propValue;
                    col++;
                }
            }
            worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
            worksheet.Cells[worksheet.Dimension.Address].AutoFilter = true;

            var contentBytes = package.GetAsByteArray();
            
            return new FileContentResult(contentBytes,
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
            {
                FileDownloadName = "Список заявок.xlsx"
            };
        }
    }
    
    [Authorize(Roles = ApplicationUserRoles.Administrator)]
    public IActionResult ExportSchoolArticleToExcel()
    {
        var articles = _schoolArticleRepository.GetAll();

        using (var package = new ExcelPackage())
        {
            var worksheet = package.Workbook.Worksheets.Add("Список заявок НИР");

            var headers = new Dictionary<string, string>
            {
                { "SchoolBoySurname", "Имя докладчика" },
                { "SchoolBoyName", "Фамилия докладчика" },
                { "SchoolBoyPatronymic", "Отчество докладчика" },
                { "ArticleFormStatus", "Статус заявки" },
                { "ArticleName", "Название работы" },
                { "Section", "Секция" },
                { "ArticleActivities", "Направление" },
                { "BirthDate", "Дата рождения" },
                { "SchoolBoyClass", "Класс" },
                { "FullEducationInstitutionName", "Полное название образовательного учреждения" },
                { "AbbreviatedEducationInstitutionName", "Сокращенное название образовательного учреждения" },
                { "City", "Город" },
                { "MunicipalDistrict", "Муниципальный район" },
                { "UrbanDistrict", "Городской округ" },
                { "SchoolBoyPhoneNumber", "Телефон" },
                { "SchoolBoyEmail", "Электронная почта" },
                
                { "ScientificDirectorName", "Имя научного руководителя" },
                { "ScientificDirectorSurname", "Фамилия научного руководителя" },
                { "ScientificDirectorPatronymic", "Отчество научного руководителя" },
                { "ScientificDirectorTitle", "Ученое звание научного руководителя" },
                { "ScientificDirectorPost", "Занимаемая дожность научного руководителя" },
                { "ScientificDirectorPhoneNumber", "Телефон научного руководителя" },
                { "ScientificDirectorEmail", "Электронная почта научного руководителя" },
            };

            var col = 1;
            foreach (var header in headers)
            {
                var cell = worksheet.Cells[1, col];
                cell.Value = header.Value;
                cell.Style.WrapText = true;
                col++;
            }

            for (int i = 0; i < articles.Count; i++)
            {
                var article = articles[i];

                col = 1;
                foreach (var header in headers)
                {
                    var propName = header.Key;
                    var propValue = typeof(SchoolArticleForm).GetProperty(propName)?.GetValue(article, null);

                    if (propValue != null && propValue.GetType().IsEnum)
                    {
                        propValue = ((Enum)propValue).GetDisplayName();
                    }

                    worksheet.Cells[i + 2, col].Value = propValue;
                    col++;
                }
            }
            worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
            worksheet.Cells[worksheet.Dimension.Address].AutoFilter = true;

            var contentBytes = package.GetAsByteArray();
            
            return new FileContentResult(contentBytes,
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
            {
                FileDownloadName = "Список заявок НИР.xlsx"
            };
        }
    }
    
    [Authorize(Roles = ApplicationUserRoles.Administrator)]
    public IActionResult ExportArticleToWord(int id)
    {
        var article = _articleRepository.GetById(id);
    
        if (article == null)
        {
            return NotFound();
        }
        
        var fileContent = ArticleExportService.ExportToWord(article);

        return File(fileContent, "application/msword", $"{CombineFullName(article.SpeakerSurname, article.SpeakerName, article.SpeakerPatronymic)} Заявка.docx");
    }
    
    [Authorize(Roles = ApplicationUserRoles.Administrator)]
    public IActionResult ExportSchoolArticleToWord(int id)
    {
        var article = _schoolArticleRepository.GetById(id);
    
        if (article == null)
        {
            return NotFound();
        }
        
        var fileContent = SchoolArticleExportService.ExportToWord(article);

        return File(fileContent, "application/msword", $"{CombineFullName(article.SchoolBoySurname, article.SchoolBoyName, article.SchoolBoyPatronymic)} Заявка НИР.docx");
    }

    private static string CombineFullName(string surname, string name, string? patronymic)
    {
        return $"{surname} {name} {patronymic}";
    }
}