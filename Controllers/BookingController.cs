using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using yourhotel.Dtos.Booking;
using YourHotel.Services;

namespace yourhotel.Controllers.Booking;

[ApiController]
[Route("[controller]")]
[Authorize]
public class BookingController : ControllerBase
{
    private BookingService _bookingService;

    public BookingController([FromServices] BookingService service)
    {
        _bookingService = service;
    }

    [HttpPost]
    public ActionResult<BookingResponseDTO> PostBooking([FromBody] BookingRequestDTO bookingRequestDTO)
    {
        try
        {
            var bookingResponseDTO = _bookingService.PostBooking(bookingRequestDTO);
            return StatusCode(201, bookingResponseDTO);
        }
        catch (DbUpdateException e)
        {
            return StatusCode(500, $"There was a problem with the database {e.Message}");
        }
        catch (Exception e)
        {
            throw new Exception($"General error while creating a booking. {e.Message}");
        }
    }

    [HttpGet]
    public ActionResult<List<BookingResponseDTO>> GetBookings()
    {
        try
        {
            var bookingResponse = _bookingService.GetBookings();
            return StatusCode(200, bookingResponse);
        }
        catch (Exception e)
        {
            throw new Exception($"Bookings not found. {e.Message}");
        }

    }

    [HttpGet("{id:int}")]
    public ActionResult<BookingResponseDTO> GetBooking([FromRoute] int id)
    {
        try
        {
            var bookingResponse = _bookingService.GetBooking(id);
            return StatusCode(200, bookingResponse);
        }
        catch (Exception e)
        {
            return StatusCode(404, "Booking not found: " + e.Message);
        }
    }

    [HttpDelete("{id:int}")]
    public ActionResult DeleteBooking([FromRoute] int id)
    {
        try
        {
            var bookingResponse = _bookingService.DeleteBooking(id);
            return StatusCode(204);
        }
        catch (Exception e)
        {
            return StatusCode(404, "Booking not found: " + e.Message);
        }
    }

    [HttpPut("{id:int}")]
    public ActionResult<BookingResponseDTO> PutBooking([FromRoute] int id, [FromBody] BookingRequestDTO bookingRequestDTO)
    {
        try
        {
            var bookingResponse = _bookingService.PutBooking(id, bookingRequestDTO);
            return StatusCode(200, bookingResponse);
        }
        catch (DbUpdateException e)
        {
            throw new Exception($"Error updating booking (database related) {e.Message}");
        }
        catch (Exception e)
        {
            return StatusCode(404, e.Message);
        }
    }
}
