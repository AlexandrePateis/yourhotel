namespace yourhotel.Dtos.Booking;

public class BookingRequestDTO
{
    public DateTime ReservationDate { get; set; }
    public DateTime? CheckInDate { get; set; }
    public DateTime? CheckOutDate { get; set; }
    public DateTime PaymentDate { get; set; }
    public int ClientId { get; set; }
    public int PaymentMethodId { get; set; }
}
