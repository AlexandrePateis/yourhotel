using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YourHotel.Data;
using YourHotel.Models;

namespace YourHotel.Repository;

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

    public List<Booking> GetBookings()
    {
        return _context.Bookings.AsNoTracking().ToList();
    }

    public Booking GetBooking(int id, bool tracking = true)
    {
        if (tracking)
        {
            return _context.Bookings.FirstOrDefault(booking => booking.Id == id);
        }
        else
        {
            return _context.Bookings.AsNoTracking().FirstOrDefault(booking => booking.Id == id);
        }
    }

    public bool DeleteBooking(Booking booking)
    {
        _context.Bookings.Remove(booking);
        _context.SaveChanges();
        return true;
    }

    public void PutBooking()
    {
        _context.SaveChanges();

    }
}
