using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YourHotel.Models;

public class Room
{
    [Required]
    public int Id { get; set; }
    [Required]
    public bool Reserved { get; set; }
    [Required]
    [Column(TypeName = "decimal(13,2)")]
    public decimal Price { get; set; }

    // Chave de Navegação
    public RoomType RoomType { get; set; }
    public List<Booking> Bookings { get; set; }

    //Chave Estrangeira

    public int RoomTypeId { get; set; }
}
