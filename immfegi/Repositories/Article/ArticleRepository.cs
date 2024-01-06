using immfegi.Data;
using immfegi.Models;
using Microsoft.EntityFrameworkCore;

namespace immfegi.Repositories.Article;

public class ArticleRepository : IArticleRepository
{
    private readonly DataContext _context;

    public ArticleRepository(DataContext context)
    {
        _context = context;
    }

    public bool Add(ArticleForm articleForm)
    {
        _context.Add(articleForm);
        return Save();
    }

    public List<ArticleForm?> GetAll()
    {
        return  _context.ArticleForms.ToList();
    }

    public ArticleForm GetById(int id)
    {
        return _context.ArticleForms.FirstOrDefault(i => i.Id == id);
    }

    public bool Update(ArticleForm articleForm)
    {
        _context.Update(articleForm);
        return Save();
    }

    public ArticleForm GetByIdNoTracking(int id)
    {
        return _context.ArticleForms.AsNoTracking().FirstOrDefault(i => i.Id == id);
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0;
    }
}