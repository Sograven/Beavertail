using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Storge.Core.Data.Models;

[NotMapped]
public class Entity
{
    [Key]
    public int Id { get; set; }
}