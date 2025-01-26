using Storge.Core.Data.Models.Enums;

namespace Storge.Core.Data.Models;

public class Passport(string firstName, string lastName, DateTime birthDate, Gender gender, string? middleName = null)
{
    public string FirstName { get; set; } = firstName;
    public string LastName { get; set; } = lastName;
    public DateTime BirthDate { get; set; } = birthDate;
    public Gender Gender { get; set; } = gender;

    public string? MiddleName { get; set; } = middleName;
}