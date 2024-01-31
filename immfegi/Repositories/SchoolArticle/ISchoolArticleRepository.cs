using immfegi.Models;

namespace immfegi.Repositories.SchoolArticle;

public interface ISchoolArticleRepository
{
    bool Add(SchoolArticleForm schoolArticleForm);
    List<SchoolArticleForm?> GetAll();
    void DeleteArticle(int id);
    SchoolArticleForm GetById(int id);
    bool Update(SchoolArticleForm schoolArticleForm);
    SchoolArticleForm GetByIdNoTracking(int id);
    bool Save();
}