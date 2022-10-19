namespace YourHotel.Dtos.Client;

public class ClientCreateUpdateRequest
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Cpf { get; set; }
    public DateTime BirthDate { get; set; }
}
