namespace Storge.Bot;

public static class Config
{
    /// <summary>
    /// Path to bot's configuration file.
    /// </summary>
    private static readonly string _path;

    /// <summary>
    /// Returns bot's token from configuration file.
    /// </summary>
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

                Console.WriteLine("Your configuration file is located at:\n" + _path);
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