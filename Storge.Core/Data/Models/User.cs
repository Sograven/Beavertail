using Storge.Core.Data.Models.Enums;

namespace Storge.Core.Data.Models;

public class User(long telegramId, Passport passport, Address address) : Entity
{
    public long TelegramID { get; set; } = telegramId;
    public Passport Passport { get; set; } = passport;
    public Address Address { get; set; } = address;

    public Group Group { get; set; } = Group.Customer;
}