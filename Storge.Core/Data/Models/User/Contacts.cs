using System.ComponentModel.DataAnnotations;

namespace Storge.Core.Data.Models.User
{
    public class Contacts : Entity
    {
        [Key]
        public override required string ID { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public long TelegramID { get; set; }
    }
}
