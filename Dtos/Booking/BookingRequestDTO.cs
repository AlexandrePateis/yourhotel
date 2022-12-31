namespace yourhotel.Dtos.Booking;

public class BookingRequestDTO
{
    public DateTime InitialBookingDate { get; set; }
    public DateTime FinalBookingDate { get; set; }
    public DateTime? CheckInDate { get; set; }
    public DateTime? CheckOutDate { get; set; }
    public string PaymentForm { get; set; }
}
