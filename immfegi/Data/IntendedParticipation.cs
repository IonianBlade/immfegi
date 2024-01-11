using System.ComponentModel.DataAnnotations;

namespace immfegi.Data;

public enum IntendedParticipation
{
    
    [Display(Name = "Очное")]
    InPerson,
    
    [Display(Name = "Дистанционное")]
    Remote,
    
    [Display(Name= "Нет")]
    No
}