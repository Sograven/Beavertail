using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Storge.Core.Data.Models;

/// <summary>
/// Represents order position.
/// </summary>
[Owned]
public class Position
{
    /// <summary>
    /// <inheritdoc cref="Models.Item.ID"/>
    /// </summary>
    [Required]
    public int Article { get; set; }

    /// <summary>
    /// Amount of items.
    /// </summary>
    [Required]
    public int Amount { get; set; }

    /// <summary>
    /// Cost of one item.
    /// </summary>
    [Required]
    public int Price { get; set; }
}