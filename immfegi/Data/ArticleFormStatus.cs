using System.ComponentModel.DataAnnotations;

namespace immfegi.Data;

public enum ArticleFormStatus
{
    [Display(Name = "Не проверена")]
    NotVerified,
    
    [Display(Name = "На проверке")]
    UnderReview,
    
    [Display(Name = "Отправлена модераторам")]
    SentToModerators,
    
    [Display(Name = "Антиплагиат")]
    AntiPlagiarism,
    
    [Display(Name = "Завершена")]
    Completed,
    
    [Display(Name = "Отклонена")]
    Rejected,
    
    
    
}