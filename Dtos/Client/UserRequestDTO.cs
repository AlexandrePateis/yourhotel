using System.ComponentModel.DataAnnotations;

namespace YourHotel.Dtos.Client;

public class UserRequestDTO
{
    [Required]
    [StringLength(50)]
    public string Email { get; set; }

    [Required]
    [StringLength(60)]
    public string Password { get; set; }
}
