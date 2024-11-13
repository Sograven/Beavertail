namespace Storge.Bot;

public static class Config
{
    public static string Token
    {
        get
        {
            if (Environment.GetEnvironmentVariable("STORGEBOT_TOKEN") is not null)
                return Environment.GetEnvironmentVariable("STORGEBOT_TOKEN")!;
            
            Console.Write("System variable STORGEBOT_TOKEN doesn't set.\n" +
                          "Please, enter your 'Telegram Bot API' token: ");
            var token = Console.ReadLine();
            Environment.SetEnvironmentVariable("STORGEBOT_TOKEN", token, EnvironmentVariableTarget.User);

            return Environment.GetEnvironmentVariable("STORGEBOT_TOKEN")!;
        }
    }
}