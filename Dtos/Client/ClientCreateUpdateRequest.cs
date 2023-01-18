namespace YourHotel.Dtos.Client;

public class ClientCreateUpdateRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string State { get; set; }
    public string City { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    public string Cpf { get; set; }
    public DateTime BirthDate { get; set; }
}
