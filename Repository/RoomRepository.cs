using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YourHotel.Data;
using YourHotel.Models;
namespace YouHotel.Repository;

public class RoomRepository
{
    private ContextBD _context;

    public RoomRepository([FromServices] ContextBD contexto)
    {
        _context = contexto;
    }
    public Room PostRoom(Room roomModel)
    {
        _context.Rooms.Add(roomModel);
        _context.SaveChanges();
        return roomModel;
    }

    // public List<RoomType> GetRoomTypes()
    // {
    //     return _context.RoomType.AsNoTracking().ToList();
    // }

    // public RoomType GetRoomType(int id, bool tracking = true)
    // {
    //     if (tracking)
    //     {
    //         return _context.RoomType.FirstOrDefault(item => item.Id == id);
    //     }
    //     else
    //     {
    //         return _context.RoomType.AsNoTracking().FirstOrDefault(item => item.Id == id);
    //     }
    // }

    // public bool DeleteRoomType(RoomType roomType)
    // {
    //     _context.RoomType.Remove(roomType);
    //     _context.SaveChanges();
    //     return true;
    // }

    // public void PutRoomType()
    // {
    //     _context.SaveChanges();
    // }
}
