using Mapster;
using Microsoft.AspNetCore.Mvc;
using YouHotel.Repository;
using yourhotel.Dtos.PaymentMethod;
using YourHotel.Dtos.RoomType;
using YourHotel.Models;

namespace YourHotel.Services;

public class RoomTypeService
{
    private RoomTypeRepository _roomTypeRepository;

    public RoomTypeService([FromServices] RoomTypeRepository repository)
    {
        _roomTypeRepository = repository;
    }
    public RoomTypeResponseDTO PostRoomType(RoomTypeRequestDTO roomTypeRequestDTO)
    {
        var roomTypeModel = roomTypeRequestDTO.Adapt<RoomType>();
        var responseModel = _roomTypeRepository.PostRoomType(roomTypeModel);
        var roomTypeResponse = responseModel.Adapt<RoomTypeResponseDTO>();
        return roomTypeResponse;
    }

    public List<RoomTypeResponseDTO> GetRoomTypes()
    {
        List<RoomType> roomTypes = _roomTypeRepository.GetRoomTypes();
        var roomTypeResponse = roomTypes.Adapt<List<RoomTypeResponseDTO>>();
        return roomTypeResponse;
    }

    public RoomTypeResponseDTO GetRoomType(int id)
    {
        var responseModel = _roomTypeRepository.GetRoomType(id, false);
        return responseModel.Adapt<RoomTypeResponseDTO>();
    }

    public bool DeleteRoomType(int id)
    {
        try
        {
            var roomType = GetRoomTypeById(id);
            _roomTypeRepository.DeleteRoomType(roomType);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public RoomTypeResponseDTO PutRoomType(int id, RoomTypeRequestDTO roomTypeRequestDTO)
    {
        var roomType = GetRoomTypeById(id);

        if (roomType is null)
        {
            return null;
        }
        roomTypeRequestDTO.Adapt(roomType);
        _roomTypeRepository.PutRoomType();
        return roomType.Adapt<RoomTypeResponseDTO>();

    }

    //Methods
    private RoomType GetRoomTypeById(int id, bool tracking = true)
    {
        var roomType = _roomTypeRepository.GetRoomType(id, tracking);
        if (roomType is null)
        {
            throw new Exception();
        }
        return roomType;
    }
}
