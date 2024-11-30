using Storge.Core.Data.Models.User;

namespace Storge.Core.Data
{
    public class ManageAccounts
    {
        public static Account AddAccount()
        {
            return new Account { ID = "", Group = AccountGroups.User };
        }

        public static Account RemoveAccount()
        {
            return new Account { ID = "", Group = AccountGroups.User };
        }
        
        public static bool IsExists()
        {
            return false;
        }
    }
}
