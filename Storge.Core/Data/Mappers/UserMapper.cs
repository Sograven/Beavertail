using Storge.Core.Data.Contexts;
using Storge.Core.Data.Models;

namespace Storge.Core.Data.Mappers;

/// <summary>
/// Manages user data in the database.
/// </summary>
public class UserMapper
{
    /// <summary>
    /// <inheritdoc cref="Contexts.AllUsersContext"/>
    /// </summary>
    private readonly AllUsersContext _db = new();

    /// <summary>
    /// <inheritdoc cref="Models.User.UserID"/>
    /// </summary>
    public int UserID { get; }

    /// <summary>
    /// <inheritdoc cref="Models.User.FirstName"/>
    /// </summary>
    public string FirstName
    {
        get => _db.Users!.Single(u => u.UserID == UserID).FirstName;
        set
        {
            _db.Users!.Single(u => u.UserID == UserID).FirstName = value;
            _db.SaveChanges();
        }
    }

    /// <summary>
    /// <inheritdoc cref="Models.User.TelegramID"/>
    /// </summary>
    public long TelegramID
    {
        get => _db.Users!.Single(u => u.UserID == UserID).TelegramID;
        set
        {
            _db.Users!.Single(u => u.UserID == UserID).TelegramID = value;
            _db.SaveChanges();
        }
    }

    /// <summary>
    /// Provides access to user's data by <paramref name="UserID"/>.
    /// </summary>
    /// <param name="userId">User's unique identifier.</param>
    /// <exception cref="InvalidOperationException"></exception>
    public UserMapper(int userId)
    {
        UserID = _db.Users!.Single(u => u.UserID == userId).UserID;
    }

    /// <summary>
    /// Provides access to user's data by <paramref name="TelegramID"/>.
    /// </summary>
    /// <param name="userId">User's unique identifier in the Telegram.</param>
    /// <exception cref="InvalidOperationException"></exception>
    public UserMapper(long telegramId)
    {
        UserID = _db.Users!.Single(u => u.TelegramID == telegramId).UserID;
    }

    /// <summary>
    /// Adds user to database and provides access to it's data.
    /// </summary>
    /// <param name="telegramId">User's unique identifier in the Telegram.</param>
    /// <param name="firstName">User's first name.</param>
    public UserMapper(long telegramId, string firstName)
    {
        var user = new User()
        {
            FirstName = firstName,
            TelegramID = telegramId
        };

        _db.Users!.Add(user);
        _db.SaveChanges();

        UserID = user.UserID;
    }
}