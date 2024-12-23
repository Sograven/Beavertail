using Storge.Core.Data.Contexts;

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
        get => _db.Users.Single(u => u.UserID == UserID).FirstName;
        set
        {
            _db.Users.Single(u => u.UserID == UserID).FirstName = value;
            _db.SaveChanges();
        }
    }

    /// <summary>
    /// <inheritdoc cref="Models.User.TelegramID"/>
    /// </summary>
    public long TelegramID
    {
        get => _db.Users.Single(u => u.UserID == UserID).TelegramID;
        set
        {
            _db.Users.Single(u => u.UserID == UserID).TelegramID = value;
            _db.SaveChanges();
        }
    }

    /// <summary>
    /// Provides access to user's data by <paramref name="userID"/>.
    /// </summary>
    /// <param name="userID"></param>
    /// <exception cref="InvalidOperationException"></exception>
    public UserMapper(int userID)
    {
        try
        {
            _ = _db.Users.Single(u => u.UserID == userID);
        }
        catch (InvalidOperationException)
        {
            throw new InvalidOperationException($"User with id {userID} was not found.");
        }

        UserID = userID;
    }
}