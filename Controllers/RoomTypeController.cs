using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YourHotel.Dtos.RoomType;
using YourHotel.Services;
namespace YourHotel.Controllers;

[ApiController]
[Route("roomtype")]
[Authorize]
public class RoomTypeController : ControllerBase
{
    private RoomTypeService _roomTypeService;
    public RoomTypeController([FromServices] RoomTypeService service)
    {
        _roomTypeService = service;
    }

    [HttpPost]
    public ActionResult<RoomTypeResponseDTO> PostRoomType([FromBody] RoomTypeRequestDTO roomTypeRequestDTO)
    {
        try
        {
            var roomTypeResponse = _roomTypeService.PostRoomType(roomTypeRequestDTO);
            return StatusCode(201, roomTypeResponse);
        }
        catch (Exception e)
        {
            return StatusCode(400, "Room Type could not have been created!" + e);
        }
    }

    [HttpGet]
    public ActionResult<List<RoomTypeResponseDTO>> GetRoomTypes()
    {
        try
        {
            var roomTypeResponse = _roomTypeService.GetRoomTypes();
            return StatusCode(200, roomTypeResponse);
        }
        catch (Exception e)
        {
            return StatusCode(400, "Room Types have not been found!" + e);
        }
    }

    [HttpGet("{id:int}")]
    public ActionResult<RoomTypeResponseDTO> GetRoomType([FromRoute] int id)
    {
        try
        {
            var roomTypeResponse = _roomTypeService.GetRoomType(id);
            return StatusCode(200, roomTypeResponse);
        }
        catch (Exception e)
        {
            return StatusCode(400, "Room Type have not been found !" + e);
        }
    }

    [HttpDelete("{id:int}")]
    public ActionResult DeleteRoomType([FromRoute] int id)
    {
        try
        {
            _roomTypeService.DeleteRoomType(id);
            return StatusCode(204);
        }
        catch (Exception e)
        {
            return StatusCode(400, "Payment Method have not been found !" + e);
        }
    }

    [HttpPut("{id:int}")]
    public ActionResult<RoomTypeResponseDTO> PutRoomType([FromRoute] int id, [FromBody] RoomTypeRequestDTO RoomTypeRequestDTO)
    {
        try
        {
            var roomTypeResponse = _roomTypeService.PutRoomType(id, RoomTypeRequestDTO);
            return StatusCode(200, roomTypeResponse);
        }
        catch (Exception e)
        {
            return StatusCode(400, "Payment Method have not been found!" + e);
        }
    }
}

