using immfegi.External;
using immfegi.Models;
using NPOI.XWPF.UserModel;

namespace immfegi.Services;

public static class ArticleExportService
{
    public static byte[] ExportToWord(ArticleForm article)
    {
        using (var stream = new MemoryStream())
        {
            using (var document = new XWPFDocument())
            {
                AddTableToWordDocument(document, "Заявка участника-студента", new Dictionary<string, string>
                {
                    { "Фамилия, Имя, Отчество", GetFullName(article.SpeakerSurname, article.SpeakerName, article.SpeakerPatronymic) },
                    { "Полное название образовательного учреждения", article.FullEducationInstitutionName },
                    { "Занимаемая должность", article.SpeakerPost },
                    { "Курс обучения", article.Course },
                    { "Научное звание", article.ScientificTitle },
                    { "Группа", article.Group },
                    { "Название статьи (русское)", article.ArticleNameOnRussian },
                    { "Название статьи (английское)", article.ArticleNameOnEnglish },
                    { "Предполагаемое участие", article.IntendedParticipation.GetDisplayName() },
                    { "Секция", article.Section },
                    { "Телефон", article.SpeakerPhoneNumber },
                    { "Email", article.SpeakerEmail },
                    { "Статус", article.SpeakerRole.GetDisplayName() }
                });
                
                AddTableToWordDocument(document, "Сведения о научном руководителе", new Dictionary<string, string>
                {
                    { "Фамилия, Имя, Отчество", GetFullName(article.ScientificDirectorSurname, article.ScientificDirectorName, article.ScientificDirectorPatronymic) },
                    { "Полное название образовательного учреждения", article.ScientificDirectorFullEducationInstitutionName },
                    { "Занимаемая должность", article.ScientificDirectorPost },
                    { "Научное звание", article.ScientificDirectorTitle },
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