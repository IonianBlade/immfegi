using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace immfegi.External;

public static class EnumDescriptionExtension
{
    public static string? GetDisplayName(this Enum enumValue)
    {
        return enumValue
            .GetType()
            .GetMember(enumValue.ToString())
            .First()?
            .GetCustomAttribute<DisplayAttribute>()?
            .Name;
    }
}