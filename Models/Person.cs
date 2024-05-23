using Engine.Validation.ValidationAttributes;

namespace Engine.Validation.Models;

public class Person
{
    [ShouldBeNull(ErrorMessage = "Age should be null")]
    public int? Age { get; set; }

    [NotNull(ErrorMessage = "Name must not be null")]
    [NameInList(typeof(CodeList), nameof(CodeList.L1PersonNames))]
    public string Name { get; set; }
}
