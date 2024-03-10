using immfegi.External;
using immfegi.Models;
using NPOI.XWPF.UserModel;

namespace immfegi.Services;

public static class SchoolArticleExportService
{
    public static byte[] ExportToWord(SchoolArticleForm article)
    {
        using (var stream = new MemoryStream())
        {
            using (var document = new XWPFDocument())
            {
                AddTableToWordDocument(document, "Заявка участника", new Dictionary<string, string>
                {
                    { "Фамилия, Имя, Отчество", GetFullName(article.SchoolBoySurname, article.SchoolBoyName, article.SchoolBoyPatronymic) },
                    { "Название работы", article.ArticleName },
                    { "Секция", article.Section },
                    { "Направление", article.ArticleActivities.GetDisplayName() },
                    { "Дата рождения", article.BirthDate.ToString("dd.MM.yyyy") },
                    { "Класс", article.SchoolBoyClass },
                    { "Полное название образовательного учреждения", article.FullEducationInstitutionName },
                    { "Сокращенное название образовательного учреждения", article.AbbreviatedEducationInstitutionName },
                    { "Город", article.City },
                    { "Муниципальный район", article.MunicipalDistrict },
                    { "Городской округ", article.UrbanDistrict },
                    { "Телефон", article.SchoolBoyPhoneNumber },
                    { "Электронная почта", article.SchoolBoyEmail },
                });
                
                AddTableToWordDocument(document, "Сведения о научном руководителе (для студентов)", new Dictionary<string, string>
                {
                    { "Фамилия, Имя, Отчество", GetFullName(article.ScientificDirectorSurname, article.ScientificDirectorName, article.ScientificDirectorPatronymic) },
                    { "Научное звание", article.ScientificDirectorTitle },
                    { "Занимаемая должность", article.ScientificDirectorPost },
                    { "Телефон", article.ScientificDirectorPhoneNumber },
                    { "Email", article.ScientificDirectorEmail }
                });
                
                document.Write(stream);
            }

            return stream.ToArray();
        }
    }

    private static string GetFullName(string surname, string name, string patronymic)
    {
        return $"{surname} {name} {patronymic}".Trim();
    }

    private static void AddTableToWordDocument(XWPFDocument document, string tableName, Dictionary<string, string> data)
    {
        var paragraph = document.CreateParagraph();
        var run = paragraph.CreateRun();
        run.IsBold = true;
        run.SetText(tableName);
        
        var table = document.CreateTable(data.Count, 2);
        
        table.Width = 5000;

        var rowIndex = 0;
        foreach (var entry in data)
        {
            table.GetRow(rowIndex).GetCell(0).SetText(entry.Key);
            table.GetRow(rowIndex).GetCell(1).SetText(entry.Value);
            rowIndex++;
        }
        
        document.CreateParagraph();
    }
}