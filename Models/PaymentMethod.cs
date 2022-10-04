using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YourHotel.Models;

public class PaymentMethod
{
    [Required]
    public int Id { get; set; }
    [Column(TypeName = "varchar(50)")]
    [Required]
    public string Name { get; set; }

    //Porpriedade de navegação

    public List<Booking> Bookings { get; set; }
}
