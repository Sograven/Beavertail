using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Beavertail.Data.Models;

[Index(nameof(ID), IsUnique = true)]
public class Account
{
    [Key]
    [Required]
    public required int ID { get; set; }

    [Required]
    public required long TelegramID { get; set; }
}