using Microsoft.EntityFrameworkCore;
using YourHotel.Models;
namespace YourHotel.Data;

public class ContextBD : DbContext
{
    //Construtor que vai receber configurações de acesso ao BD
    //Essas configurações virão do Program.cs
    public ContextBD(DbContextOptions<ContextBD> options) : base(options)
    {

    }

    //Tabelas do BD
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<PaymentMethod> PaymentMethods { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<RoomType> RoomType { get; set; }
}
