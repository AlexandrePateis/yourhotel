using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YourHotel.Services;
using YourHotel.Dtos.Room;
using Microsoft.AspNetCore.Authorization;

namespace YourHotel.Controllers;

[ApiController]
[Route("room")]
[Authorize]
public class RoomController : ControllerBase
{
    private RoomService _roomService;
    public RoomController([FromServices] RoomService service)
    {
        _roomService = service;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(RoomResponseDTO))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    public ActionResult<RoomResponseDTO> PostRoomType([FromBody] RoomRequestDTO roomRequestDTO)
    {
        try
        {
            var roomResponse = _roomService.PostRoom(roomRequestDTO);
            return StatusCode(201, roomResponse);
        }
        catch (DbUpdateException e)
        {
            return StatusCode(400, $"Room Type could not have been created. Repository error! {e.Message}");
        }
        catch (Exception e)
        {
            return StatusCode(500, $"Internal error! {e.Message}");
        }
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<RoomResponseDTO>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    public ActionResult<List<RoomResponseDTO>> GetRooms()
    {
        try
        {
            var roomResponse = _roomService.GetRooms();
            return StatusCode(200, roomResponse);
        }
        catch (Exception e)
        {
            return StatusCode(400, "Room Types have not been found!" + e);
        }
    }


    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RoomResponseDTO))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
    public ActionResult<RoomResponseDTO> GetRoom([FromRoute] int id)
    {
        try
        {
            var roomResponse = _roomService.GetRoom(id);
            return StatusCode(200, roomResponse);
        }
        catch (Exception e)
        {
            return StatusCode(404, $"Room Type have not been found {e.Message}");
        }
    }

    [HttpDelete("{id:int}")]
    public ActionResult DeleteRoomType([FromRoute] int id)
    {
        try
        {
            _roomService.DeleteRoom(id);
            return StatusCode(204);
        }
        catch (Exception e)
        {
            return StatusCode(404, "Payment Method have not been found !" + e);
        }
    }

    [HttpPut("{id:int}")]
    public ActionResult<RoomResponseDTO> PutRoom([FromRoute] int id, [FromBody] RoomRequestDTO RoomRequestDTO)
    {
        try
        {
            var roomResponse = _roomService.PutRoom(id, RoomRequestDTO);
            return StatusCode(200, roomResponse);
        }
        catch (Exception e)
        {
            return StatusCode(400, "Payment Method have not been found!" + e);
        }
    }
}

