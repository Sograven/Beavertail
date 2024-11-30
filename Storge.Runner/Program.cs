using Storge.Bot;
using Storge.Core;
using Storge.Core.Data;
using Storge.Core.Data.Models;

// await Client.StartHandlingAsync();
var user = new Account() { Id = 1488, Group = AccountGroups.User };
Core.AddUser(user);
Console.WriteLine(Core.GetUser(user.Id).Group);