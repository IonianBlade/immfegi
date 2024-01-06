using immfegi.Models;

namespace immfegi.Repositories.Article;

public interface IArticleRepository
{
    bool Add(ArticleForm articleForm);
    List<ArticleForm?> GetAll();
    ArticleForm GetById(int id);
    bool Update(ArticleForm articleForm);
    ArticleForm GetByIdNoTracking(int id);
    bool Save();
}