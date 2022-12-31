namespace yourhotel.Dtos.Booking;

public class BookingResponseDTO
{
    public int Id { get; set; }
    public decimal Discount { get; set; }
    public DateTime ReservationDate { get; set; }
    public decimal ReservationValue { get; set; }
    public DateTime PaymentDate { get; set; }

    public int ClientId { get; set; }
    public int PaymentMethodId { get; set; }

}
