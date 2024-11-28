namespace Storge.Bot;

public static class Config
{
    private static readonly string _path;

    public static string Token
    {
        get
        {
            if (!Path.Exists(_path))
            {
                Console.Write("Config file doesn't exist. Initialization...\n" +
                                  "Please, enter bot token: ");

                var token = Console.ReadLine();
                File.WriteAllText(_path, token);
            }
            else if (File.ReadAllText(_path) is "")
            {
                Console.Write("Please, enter bot token: ");
                var token = Console.ReadLine();
                File.WriteAllText(_path, token);
            }

            return File.ReadAllText(_path);
        }
    }

    static Config()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        _path = Path.Combine(Environment.GetFolderPath(folder), "storgebot_config.txt");
    }
}