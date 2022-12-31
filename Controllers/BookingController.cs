using Microsoft.AspNetCore.Mvc;
using yourhotel.Dtos.Booking;
using YourHotel.Services;

namespace yourhotel.Controllers.Booking;

[ApiController]
[Route("booking")]
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
        var bookingResponseDTO = _bookingService.PostBooking(bookingRequestDTO);
        //Enviar para a classe serviço os dados da requisição
        return StatusCode(201, "Booking has been successfully created!");
    }

    // [HttpGet]
    // public ActionResult<List<BookingResponseDTO>> GetBookings()
    // {
    //     var bookingResponse = _bookingService.GetBookings();
    //     return StatusCode(200, bookingResponse);
    // }

    // [HttpGet("{id:int}")]
    // public ActionResult<BookingResponseDTO> GetBooking([FromRoute] int id)
    // {
    //     try
    //     {
    //         var bookingResponse = _bookingService.GetBooking(id);
    //         return StatusCode(200, bookingResponse);
    //     }
    //     catch (Exception e)
    //     {
    //         return StatusCode(404, "Booking not found: " + e);
    //     }
    // }

    // [HttpDelete("{id:int}")]
    // public ActionResult DeleteBooking([FromRoute] int id)
    // {
    //     try
    //     {
    //         var bookingResponse = _bookingService.DeleteBooking(id);
    //         return StatusCode(204, bookingResponse);
    //     }
    //     catch (Exception e)
    //     {
    //         return StatusCode(404, "Booking not found: " + e);
    //     }
    // }

    // [HttpPut("{id:int}")]
    // public ActionResult<BookingResponseDTO> PutBooking([FromRoute] int id, [FromBody] BookingRequestDTO bookingRequestDTO)
    // {
    //     try
    //     {
    //         var bookingResponse = _bookingService.DeleteBooking(id);
    //         return StatusCode(204, bookingResponse);
    //     }
    //     catch (Exception e)
    //     {
    //         return StatusCode(404, "Booking not found: " + e);
    //     }
    // }
}
