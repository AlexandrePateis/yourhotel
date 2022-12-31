using Microsoft.AspNetCore.Mvc;
using Mapster;
using yourhotel.Dtos.Booking;
using yourhotel.Repository;
using YourHotel.Models;

namespace YourHotel.Services;

public class BookingService
{
    private BookingRepository _bookingRepository;

    public BookingService([FromServices] BookingRepository repository)
    {
        _bookingRepository = repository;
    }
    public BookingResponseDTO PostBooking(BookingRequestDTO bookingRequestDTO)
    {
        Booking bookingModel = bookingRequestDTO.Adapt<Booking>();

        //regras de negocio

        var responseModel = _bookingRepository.PostBooking(bookingModel);
        BookingResponseDTO bookingResponseDTO = responseModel.Adapt<BookingResponseDTO>();
        return bookingResponseDTO;
    }
}
