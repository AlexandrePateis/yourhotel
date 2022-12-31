using Mapster;
using Microsoft.AspNetCore.Mvc;
using YouHotel.Repository;
using YourHotel.Dtos.Room;
using YourHotel.Models;

namespace YourHotel.Services;

public class RoomService
{
    private RoomRepository _roomRepository;

    public RoomService([FromServices] RoomRepository repository)
    {
        _roomRepository = repository;
    }
    public RoomResponseDTO PostRoom(RoomRequestDTO roomRequestDTO)
    {
        var roomModel = roomRequestDTO.Adapt<Room>();
        var responseModel = _roomRepository.PostRoom(roomModel);
        var roomResponseDTO = responseModel.Adapt<RoomResponseDTO>();
        return roomResponseDTO;
    }

    public List<RoomResponseDTO> GetRooms()
    {
        List<Room> roomList = _roomRepository.GetRooms();
        var roomListResponse = roomList.Adapt<List<RoomResponseDTO>>();
        return roomListResponse;
    }

    public RoomResponseDTO GetRoom(int id)
    {
        var responseModel = _roomRepository.GetRoom(id, false);
        if (responseModel == null)
        {
            throw new Exception("Room not found in the database!");
        }
        return responseModel.Adapt<RoomResponseDTO>();
    }

    public bool DeleteRoom(int id)
    {
        try
        {
            var room = GetRoomById(id);
            if (room == null)
            {
                throw new Exception("Room not found in the database!");
            }
            _roomRepository.DeleteRoom(room);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public RoomResponseDTO PutRoom(int id, RoomRequestDTO roomRequestDTO)
    {
        var roomType = GetRoomById(id);

        if (roomType is null)
        {
            return null;
        }
        roomRequestDTO.Adapt(roomType);
        _roomRepository.PutRoom();
        return roomType.Adapt<RoomResponseDTO>();
    }

    //Methods
    private Room GetRoomById(int id, bool tracking = true)
    {
        var room = _roomRepository.GetRoom(id, tracking);
        if (room is null)
        {
            throw new Exception();
        }
        return room;
    }
}

