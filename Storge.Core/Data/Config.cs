namespace Storge.Core.Data;

/// <summary>
/// Contains database files paths and parameters.
/// </summary>
internal static class Config
{
    /// <summary>
    /// Path to file with users data.
    /// </summary>
    internal static string UsersFilePath { get; } = GetFilePath("SCD_USERS", "users.db");

    /// <summary>
    /// Path to file with items data.
    /// </summary>
    internal static string ItemsFilePath { get; } = GetFilePath("SCD_ITEMS", "items.db");

    /// <summary>
    /// Retrieves a path to data file from environment variable.
    /// </summary>
    /// <param name="variableName">Environment variable name.</param>
    /// <param name="fileName">Name of the file.</param>
    /// <returns>Path to data file.</returns>
    private static string GetFilePath(string variableName, string fileName)
    {
        if (Environment.GetEnvironmentVariable(variableName) is null)
            SetFilePath(variableName, fileName);

        return Environment.GetEnvironmentVariable(variableName)!;
    }

    /// <summary>
    /// Creates an environment variable storing path to data file.
    /// </summary>
    /// <param name="variableName">Environment variable name.</param>
    /// <param name="fileName">Name of the file.</param>
    private static void SetFilePath(string variableName, string fileName)
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var folderPath = Environment.GetFolderPath(folder);
        
        var path = Path.Combine(folderPath, fileName);
        Environment.SetEnvironmentVariable(variableName, path);
    }
}
