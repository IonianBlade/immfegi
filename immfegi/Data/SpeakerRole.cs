using System.ComponentModel.DataAnnotations;

namespace immfegi.Data;

public enum SpeakerRole
{
    [Display(Name = "Студент")]
    Student,
    
    [Display(Name = "Преподаватель")]
    Teacher
}