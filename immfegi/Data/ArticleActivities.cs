using System.ComponentModel.DataAnnotations;

namespace immfegi.Data;

public enum ArticleActivities
{
    [Display(Name = "Информатика")]
    Informatics,
    
    [Display(Name = "Математика")]
    Mathematics,
    
    [Display(Name = "Физика")]
    Physics
}