using System.ComponentModel.DataAnnotations;

namespace Storge.Core.Data.Models;

/// <summary>
/// Represents user data in database.
/// </summary>
internal class User
{
    /// <summary>
    /// User's unique identifier.
    /// </summary>
    [Key]
    [Required]
    internal int UserID { get; set; }

    /// <summary>
    /// User's first name.
    /// </summary>
    [Required]
    internal string FirstName { get; set; }

    /// <summary>
    /// User's unique identifier in the Telegram.
    /// </summary>
    [Required]
    internal long TelegramID { get; set; }
}