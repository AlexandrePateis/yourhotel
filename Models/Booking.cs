using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YourHotel.Models;

public class Booking
{
    [Required]
    public int Id { get; set; }
    [Required]
    [Column(TypeName = "decimal(13,2)")]
    public decimal Discount { get; set; }
    [Required]
    public DateTime ReservationDate { get; set; }
    [Required]
    public DateTime ReservationFinalDate { get; set; }
    [Required]
    [Column(TypeName = "decimal(13,2)")]
    public decimal ReservationValue { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    [Required]
    public DateTime PaymentDate { get; set; }

    //Propriedades de navegações
    public List<Client> Clients { get; set; }
    public List<PaymentMethod> PaymentMethods { get; set; }
    public List<Room> Rooms { get; set; }

    //Chave Estrangeira
    public int ClientsId { get; set; }
    public int PaymentMethodsId { get; set; }
 
}