using immfegi.Data;
using immfegi.Models;
using Microsoft.EntityFrameworkCore;

namespace immfegi.Repositories.SchoolArticle;

public class SchoolArticleRepository : ISchoolArticleRepository
{
    private readonly DataContext _context;

    public SchoolArticleRepository(DataContext context)
    {
        _context = context;
    }
    
    public bool Add(SchoolArticleForm schoolArticleForm)
    {
        _context.Add(schoolArticleForm);
        return Save();
    }

    public List<SchoolArticleForm?> GetAll()
    {
        return  _context.SchoolArticleForms.ToList();
    }

    public SchoolArticleForm GetById(int id)
    {
        return _context.SchoolArticleForms.FirstOrDefault(i => i.Id == id);
    }

    public bool Update(SchoolArticleForm schoolArticleForm)
    {
        _context.Update(schoolArticleForm);
        return Save();
    }

    public SchoolArticleForm GetByIdNoTracking(int id)
    {
        return _context.SchoolArticleForms.AsNoTracking().FirstOrDefault(i => i.Id == id);
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0;
    }
}