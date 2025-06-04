namespace Beavertail.Data;

internal static class Config
{
    internal static string UsersFilePath { get; } = GetFilePath("Beavertail_Data_Accounts", "accounts.db");

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
