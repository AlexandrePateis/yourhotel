namespace YourHotel.Dtos.Room;

public class RoomRequestDTO
{
    public bool Reserved { get; set; }
    public decimal Price { get; set; }
    public int RoomTypeId { get; set; }
}
