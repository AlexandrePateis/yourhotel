using Microsoft.AspNetCore.Mvc;
using Mapster;
using yourhotel.Dtos.Booking;
using YourHotel.Models;
using YourHotel.Repository;

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
        bookingModel.Discount = 0;
        bookingModel.ReservationDate = DateTime.Now;
        bookingModel.ReservationValue = 900.00m;
        if (bookingModel.CheckInDate != null)
        {
            bookingModel.CheckInDate = bookingRequestDTO.CheckInDate;
        }
        if (bookingModel.CheckOutDate != null)
        {
            bookingModel.CheckOutDate = bookingRequestDTO.CheckOutDate;
        }
        bookingModel.PaymentDate = bookingRequestDTO.PaymentDate;
        bookingModel.ClientId = bookingRequestDTO.ClientId;
        bookingModel.PaymentMethodId = bookingRequestDTO.PaymentMethodId;

        var responseModel = _bookingRepository.PostBooking(bookingModel);
        BookingResponseDTO bookingResponseDTO = responseModel.Adapt<BookingResponseDTO>();
        return bookingResponseDTO;
    }

    public List<BookingResponseDTO> GetBookings()
    {
        var bookingList = _bookingRepository.GetBookings();
        var bookingResponseDTO = bookingList.Adapt<List<BookingResponseDTO>>();
        return bookingResponseDTO;
    }

    public BookingResponseDTO GetBooking(int id)
    {
        try
        {
            var responseModel = _bookingRepository.GetBooking(id, false);
            if (responseModel is null)
            {
                return null;
            }
            return responseModel.Adapt<BookingResponseDTO>();
        }
        catch (Exception)
        {
            return null;
        }

    }


    public bool DeleteBooking(int id)
    {
        try
        {
            var booking = GetBookingById(id);
            _bookingRepository.DeleteBooking(booking);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public BookingResponseDTO PutBooking(int id, BookingRequestDTO bookingRequestDTO)
    {
        var booking = GetBookingById(id);
        if (booking is null)
        {
            return null;
        }
        bookingRequestDTO.Adapt(booking);
        _bookingRepository.PutBooking();
        return booking.Adapt<BookingResponseDTO>();
    }

    private Booking GetBookingById(int id, bool tracking = true)
    {
        var booking = _bookingRepository.GetBooking(id, tracking);
        if (booking is null)
        {
            throw new Exception("booking not found");
        }
        return booking;
    }
}
