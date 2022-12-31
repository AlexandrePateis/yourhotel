using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YourHotel.Data;
using YourHotel.Models;
namespace YouHotel.Repository;

public class RoomTypeRepository
{
    private ContextBD _context;

    public RoomTypeRepository([FromServices] ContextBD contexto)
    {
        _context = contexto;
    }
    public RoomType PostRoomType(RoomType roomTypeModel)
    {
        _context.RoomType.Add(roomTypeModel);
        _context.SaveChanges();
        return roomTypeModel;
    }

    public List<RoomType> GetRoomTypes()
    {
        return _context.RoomType.AsNoTracking().ToList();
    }

    public RoomType GetRoomType(int id, bool tracking = true)
    {
        if (tracking)
        {
            return _context.RoomType.FirstOrDefault(item => item.Id == id);
        }
        else
        {
            return _context.RoomType.AsNoTracking().FirstOrDefault(item => item.Id == id);
        }
    }

    public bool DeleteRoomType(RoomType roomType)
    {
        _context.RoomType.Remove(roomType);
        _context.SaveChanges();
        return true;
    }

    public void PutRoomType()
    {
        _context.SaveChanges();
    }
}
