using Engine.Validation;
using Engine.Validation.Models;

var persons = new List<Person>
        {
            new Person { Age = null, Name = "John Doe" },
            new Person { Age = 25, Name = "Invalid Name" },
            new Person { Age = 30, Name = "Jane Doe" }
        };

var animals = new List<Animal>
        {
            new Animal { Age = 5, Name = "Rex" },
            new Animal { Age = null, Name = "Invalid Name" },
            new Animal { Age = 3, Name = "Bella" }
        };

var validator = new Validator();

var validationsToSkip = new List<string> { "NotNullAttribute" };

Console.WriteLine("Validating Persons:");
bool allPersonsValid = validator.ValidateList(persons, validationsToSkip);
Console.WriteLine(allPersonsValid ? "All persons are valid" : "Some persons are not valid");

Console.WriteLine("\nValidating Animals:");
bool allAnimalsValid = validator.ValidateList(animals, validationsToSkip);
Console.WriteLine(allAnimalsValid ? "All animals are valid" : "Some animals are not valid");

Console.ReadKey();