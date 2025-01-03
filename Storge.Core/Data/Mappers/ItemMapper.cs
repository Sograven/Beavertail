using Storge.Core.Data.Contexts;
using Storge.Core.Data.Models;

namespace Storge.Core.Data.Mappers;

/// <summary>
/// Manages item's data in the database.
/// </summary>
public class ItemMapper
{
    /// <summary>
    /// <inheritdoc cref="Contexts.AllItemsContext"/>
    /// </summary>
    private readonly AllItemsContext _db = new();

    /// <summary>
    /// <inheritdoc cref="Models.Item.ID"/>
    /// </summary>
    public int ID { get; }

    /// <summary>
    /// <inheritdoc cref="Models.Item.Name"/>
    /// </summary>
    public string Name
    {
        get => _db.Items!.Single(u => u.ID == ID).Name;
        set
        {
            _db.Items!.Single(u => u.ID == ID).Name = value;
            _db.SaveChanges();
        }
    }

    /// <summary>
    /// <inheritdoc cref="Models.Item.Description"/>
    /// </summary>
    public string? Description
    {
        get => _db.Items!.Single(u => u.ID == ID).Description;
        set
        {
            _db.Items!.Single(u => u.ID == ID).Description = value;
            _db.SaveChanges();
        }
    }

    /// <summary>
    /// <inheritdoc cref="Models.Item.ImagePath"/>
    /// </summary>
    public string? ImagePath
    {
        get => _db.Items!.Single(u => u.ID == ID).ImagePath;
        set
        {
            _db.Items!.Single(u => u.ID == ID).ImagePath = value;
            _db.SaveChanges();
        }
    }

    /// <summary>
    /// <inheritdoc cref="Models.Item.Color"/>
    /// </summary>
    public string Color
    {
        get => _db.Items!.Single(u => u.ID == ID).Color;
        set
        {
            _db.Items!.Single(u => u.ID == ID).Color = value;
            _db.SaveChanges();
        }
    }

    /// <summary>
    /// <inheritdoc cref="Models.Item.Size"/>
    /// </summary>
    public string Size
    {
        get => _db.Items!.Single(u => u.ID == ID).Size;
        set
        {
            _db.Items!.Single(u => u.ID == ID).Size = value;
            _db.SaveChanges();
        }
    }

    /// <summary>
    /// <inheritdoc cref="Models.Item.Category"/>
    /// </summary>
    public string Category
    {
        get => _db.Items!.Single(u => u.ID == ID).Category;
        set
        {
            _db.Items!.Single(u => u.ID == ID).Category = value;
            _db.SaveChanges();
        }
    }

    /// <summary>
    /// Provides access to item's data by <paramref name="id"/>.
    /// </summary>
    /// <param name="id">Item's unique identifier (article).</param>
    public ItemMapper(int id)
    {
        ID = _db.Items!.Single(i => i.ID == id).ID;
    }

    /// <summary>
    /// Adds item to the database and provides access to it's data.
    /// </summary>
    /// <param name="id">Item's unique identifier (article).</param>
    /// <param name="name">Item's name.</param>
    /// <param name="color">Item's color.</param>
    /// <param name="size">Item's size.</param>
    /// <param name="category">Item's category.</param>
    /// <param name="description">Item's description.</param>
    /// <param name="imagePath">Path to item's image file.</param>
    public ItemMapper(int id, string name, string color, string size, string category, string? description = null, string? imagePath = null)
    {
        var item = new Item
        {
            ID = id,
            Name = name,
            Color = color,
            Size = size,
            Category = category,
            Description = description,
            ImagePath = imagePath
        };

        _db.Items!.Add(item);
        _db.SaveChanges();

        ID = item.ID;
    }
}
