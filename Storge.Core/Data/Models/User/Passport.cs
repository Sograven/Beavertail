using System.ComponentModel.DataAnnotations;

namespace Storge.Core.Data.Models.User
{
    public class Passport : Entity
    {
        [Key]
        public override required string ID { get; set; }
        public required string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public required string LastName { get; set; }
        public int Series { get; set; }
        public int Number { get; set; }
        public DateOnly BirthDate { get; set; }
    }
}
