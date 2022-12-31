using Microsoft.AspNetCore.Mvc;
using YourHotel.Data;
using YourHotel.Models;

namespace yourhotel.Repository;

public class BookingRepository
{
    private ContextBD _context;

    public BookingRepository([FromServices] ContextBD contexto)
    {
        _context = contexto;
    }
    public Booking PostBooking(Booking booking)
    {
        _context.Bookings.Add(booking);
        _context.SaveChanges();
        return booking;
    }
}
