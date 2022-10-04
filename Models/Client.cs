using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YourHotel.Models;

public class Client
{   
    [Required]
    public int Id { get; set; }
    [Column(TypeName = "varchar(50)")]
    [Required]
    public string Name { get; set; }
    [Column(TypeName = "varchar(80)")]
    public string? Email { get; set; }
    [Column(TypeName = "varchar(20)")]
    [Required]
    public string PhoneNumber { get; set; }
    [Column(TypeName = "varchar(20)")]
    [Required]
    public string Cpf { get; set; }
    [Required]
    public DateTime BirthDate { get; set; }

    //Propriedade de navegação
    public List<Booking> Bookings { get; set; }
}
