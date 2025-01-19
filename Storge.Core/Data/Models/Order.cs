using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Storge.Core.Data.Models;

[Index(nameof(Id), IsUnique = true)]
public class Order
{
    /// <summary>
    /// Order's unique identifier.
    /// </summary>
    [Key]
    [Required]
    public int Id { get; set; }

    /// <summary>
    /// <inheritdoc cref="Models.User.UserID"/>
    /// </summary>
    [Required]
    public int UserId { get; set; }

    /// <summary>
    /// List of positions in the order.
    /// </summary>
    [Required]
    public List<Position> Positions { get; set; }

    /// <summary>
    /// Final cost of the order.
    /// </summary>
    [Required]
    public int Sum
    {
        get
        {
            int sum = 0;
            foreach (var p in Positions)
                sum += p.Amount * p.Price;

            return sum;
        }
    }

    /// <summary>
    /// Address for delivery.
    /// </summary>
    [Required]
    public string Address { get; set; }
}
