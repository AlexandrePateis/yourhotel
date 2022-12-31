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

    public List<Room> GetRooms()
    {
        return _context.Rooms.AsNoTracking().ToList();
    }

    public Room GetRoom(int id, bool tracking = true)
    {
        if (tracking)
        {
            return _context.Rooms.FirstOrDefault(item => item.Id == id);
        }
        else
        {
            return _context.Rooms.AsNoTracking().FirstOrDefault(item => item.Id == id);
        }
    }

    public bool DeleteRoom(Room room)
    {
        _context.Rooms.Remove(room);
        _context.SaveChanges();
        return true;
    }

    public void PutRoom()
    {
        _context.SaveChanges();
    }
}
