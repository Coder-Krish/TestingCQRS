using System.ComponentModel.DataAnnotations;

namespace TestingLibrary.Models;

public class Person
{
    [Key]
    public Guid PersonId { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public List<PersonDetails> PersonDetails { get; set; } = new List<PersonDetails>();

}