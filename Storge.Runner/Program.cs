using Storge.Bot;
using Storge.Core;
using Storge.Core.Data.Models.User;

// await Client.StartHandlingAsync();
var user = new Account
{
    ID = "1488",
    Group = AccountGroups.User,
    Contacts = new Contacts
    {
        ID = "1488",
        Email = "gayporno@ya.ru",
        PhoneNumber = "+79999999999",
        TelegramID = 123491249
    },
    Passport = new Passport
    {
        ID = "1488",
        FirstName = "Gay",
        MiddleName = "Gayevich",
        LastName = "Porno",
        BirthDate = new DateOnly(2003, 10, 14)
    }
};
Core.AddUser(user);
Console.WriteLine(Core.GetUser(user.ID).Group);