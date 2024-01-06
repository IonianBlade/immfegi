using System.ComponentModel.DataAnnotations;

namespace immfegi.Data;

public enum ArticleFormStatus
{
    [Display(Name = "Завершена")]
    Completed,
    
    [Display(Name = "Отклонена")]
    Rejected,
    
    [Display(Name = "В работе")]
    InProgress,
    
    [Display(Name = "Не проверена")]
    NotVerified
}