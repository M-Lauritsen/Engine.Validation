using Engine.Validation.ValidationAttributes;

namespace Engine.Validation.Models;

public class Animal
{
    [ShouldBeNull(ErrorMessage = "Age must not be null")]
    public int? Age { get; set; }

    [NotNull(ErrorMessage = "Name must not be null")]
    [NameInList(typeof(CodeList), nameof(CodeList.L2AnimalNames))]
    public string Name { get; set; }
}
