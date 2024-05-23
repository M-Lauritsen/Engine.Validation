using System.ComponentModel.DataAnnotations;

namespace Engine.Validation.ValidationAttributes;

public class ShouldBeNullAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        return value is null;
    }
}
