using System.ComponentModel.DataAnnotations;

namespace Engine.Validation.ValidationAttributes;

public class NotNullAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        return value != null;
    }
}
