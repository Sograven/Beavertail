using System.ComponentModel.DataAnnotations;

namespace Storge.Core.Data.Models.User
{
    public enum AccountGroups
    {
        User,
        Worker,
        Admin
    }

    public class Account : Entity
    {
        [Key]
        public override required string ID { get; set; }
        public required AccountGroups Group { get; set; }
        public Passport? Passport { get; set; }
        public Contacts? Contacts { get; set; }
        public string? Password { get; set; }
    }
}
