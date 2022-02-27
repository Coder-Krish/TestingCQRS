using System.ComponentModel.DataAnnotations;

namespace TestingLibrary.Models;

public class PersonDetails
{
    [Key]
    public Guid PersonDetailsId { get; set; }
    public string Address { get; set; }
}