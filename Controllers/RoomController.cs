using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YourHotel.Services;
using YourHotel.Dtos.Room;
namespace YourHotel.Controllers;

[ApiController]
[Route("[controller]")]
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

    // [HttpGet]
    // public ActionResult<List<RoomTypeResponseDTO>> GetRoomTypes()
    // {
    //     try
    //     {
    //         var roomTypeResponse = _roomTypeService.GetRoomTypes();
    //         return StatusCode(200, roomTypeResponse);
    //     }
    //     catch (Exception e)
    //     {
    //         return StatusCode(400, "Room Types have not been found!" + e);
    //     }
    // }

    // [HttpGet("{id:int}")]
    // public ActionResult<RoomTypeResponseDTO> GetRoomType([FromRoute] int id)
    // {
    //     try
    //     {
    //         var roomTypeResponse = _roomTypeService.GetRoomType(id);
    //         return StatusCode(200, roomTypeResponse);
    //     }
    //     catch (Exception e)
    //     {
    //         return StatusCode(400, "Room Type have not been found !" + e);
    //     }
    // }

    // [HttpDelete("{id:int}")]
    // public ActionResult DeleteRoomType([FromRoute] int id)
    // {
    //     try
    //     {
    //         _roomTypeService.DeleteRoomType(id);
    //         return StatusCode(204);
    //     }
    //     catch (Exception e)
    //     {
    //         return StatusCode(400, "Payment Method have not been found !" + e);
    //     }
    // }

    // [HttpPut("{id:int}")]
    // public ActionResult<RoomTypeResponseDTO> PutRoomType([FromRoute] int id, [FromBody] RoomTypeRequestDTO RoomTypeRequestDTO)
    // {
    //     try
    //     {
    //         var roomTypeResponse = _roomTypeService.PutRoomType(id, RoomTypeRequestDTO);
    //         return StatusCode(200, roomTypeResponse);
    //     }
    //     catch (Exception e)
    //     {
    //         return StatusCode(400, "Payment Method have not been found!" + e);
    //     }
    // }
}

