using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Storge.Core.Data.Models;

/// <summary>
/// Represents item data in the database.
/// </summary>
[Index(nameof(ID), IsUnique = true)]
internal class Item
{
    /// <summary>
    /// Item's unique identifier (article).
    /// </summary>
    [Required]
    internal int ID { get; set; }

    /// <summary>
    /// Item's name.
    /// </summary>
    [Required]
    internal string Name { get; set; }

    /// <summary>
    /// Item's description.
    /// </summary>
    internal string? Description { get; set; }

    /// <summary>
    /// Path to item's image file.
    /// </summary>
    internal string? ImagePath { get; set; }

    /// <summary>
    /// Item's color.
    /// </summary>
    [Required]
    internal string Color { get; set; }

    /// <summary>
    /// Item's size.
    /// </summary>
    [Required]
    internal string Size { get; set; }

    /// <summary>
    /// Item's category.
    /// </summary>
    [Required]
    internal string Category { get; set; }
}
