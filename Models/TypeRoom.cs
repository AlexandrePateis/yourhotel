using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YourHotel.Models;

public class TypeRoom
{
    [Required]
    public int Id { get; set; }
    [Column(TypeName = "varchar(255)")]
    [Required]
    public string Description { get; set; }
    [Required]
    public int Capacity { get; set; }

    // Propriedade de navegação

    public List<Room> Rooms { get; set; }
}
