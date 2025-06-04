namespace Beavertail.Telegram.Bot;

internal static class Config
{
    internal static string Token { get; } = File.ReadAllText(GetFilePath("Beavertail_Telegram_Bot", "bot.txt"));

    private static string GetFilePath(string variableName, string fileName)
    {
        if (Environment.GetEnvironmentVariable(variableName) is null)
            SetFilePath(variableName, fileName);

        return Environment.GetEnvironmentVariable(variableName)!;
    }

    private static void SetFilePath(string variableName, string fileName)
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var folderPath = Environment.GetFolderPath(folder);

        var path = Path.Combine(folderPath, fileName);
        Environment.SetEnvironmentVariable(variableName, path);
    }
}