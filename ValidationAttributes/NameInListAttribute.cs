using Engine.Validation.Models;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Engine.Validation.ValidationAttributes;

public class NameInListAttribute : ValidationAttribute
{
    private readonly List<string> _allowedNames;

    public NameInListAttribute(Type listType, string listName)
    {
        if (listType == null)
        {
            throw new ArgumentNullException(nameof(listType), "The list type cannot be null.");
        }

        _allowedNames = GetAllowedNames(listType, listName);
        if (_allowedNames == null)
        {
            throw new ArgumentException($"The list '{listName}' does not exist or is not of type List<string>.", nameof(listName));
        }
    }

    private List<string> GetAllowedNames(Type listType, string listName)
    {
        if (listType == typeof(CodeList))
        {
            switch (listName)
            {
                case nameof(CodeList.L1PersonNames):
                    return CodeList.L1PersonNames;
                case nameof(CodeList.L2AnimalNames):
                    return CodeList.L2AnimalNames;
                default:
                    return null;
            }
        }
        return null;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value == null) return ValidationResult.Success; // Allow NotNull attribute to handle null values

        if (value is string name)
        {
            if (!_allowedNames.Contains(name))
            {
                var errorMessage = $"The value '{name}' of property '{validationContext.MemberName}' is not in the allowed list.";
                return new ValidationResult(errorMessage);
            }
            return ValidationResult.Success;
        }

        return new ValidationResult($"Invalid type for '{validationContext.MemberName}'");
    }
}
