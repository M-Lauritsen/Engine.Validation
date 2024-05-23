using System.ComponentModel.DataAnnotations;

namespace Engine.Validation;

public class Validator
{
    public bool Validate<T>(T obj, List<string> validationsToSkip)
    {
        var context = new ValidationContext(obj);
        var results = new List<ValidationResult>();
        var properties = obj.GetType().GetProperties();

        foreach (var property in properties)
        {
            var value = property.GetValue(obj);
            var attributes = property.GetCustomAttributes(true)
                .OfType<ValidationAttribute>()
                .Where(attr => !validationsToSkip.Contains(attr.GetType().Name));

            foreach (var attribute in attributes)
            {
                var result = attribute.GetValidationResult(value, context);
                if (result != ValidationResult.Success)
                {
                    results.Add(result);
                    Console.WriteLine(result.ErrorMessage);
                }
            }
        }

        return !results.Any();
    }

    public bool ValidateList<T>(IEnumerable<T> objects, List<string> validationsToSkip)
    {
        return objects.All(obj => Validate(obj, validationsToSkip));
    }
}
