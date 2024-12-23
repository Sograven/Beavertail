using System.ComponentModel.DataAnnotations;

namespace Storge.Core.Data.Models;

/// <summary>
/// Represents user data in database.
/// </summary>
internal class User
{
    /// <summary>
    /// Unique identifier of the user.
    /// </summary>
    [Key]
    [Required]
    internal int UserID { get; set; }

    /// <summary>
    /// First name of the user.
    /// </summary>
    [Required]
    internal string FirstName { get; set; }

    /// <summary>
    /// Unique identifier of the user in Telegram.
    /// </summary>
    internal long TelegramID { get; set; }
}