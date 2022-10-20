using YourHotel.Data;
using Microsoft.AspNetCore.Mvc;
using YourHotel.Models;
namespace YourHotel.Repository;

public class ClientRepository
{
    private ContextBD _context;

    public ClientRepository([FromServices] ContextBD contexto)
    {
        _context = contexto;
    }
    public void CreateClient(Client client)
    {
        //Recebe do serviço e salva no banco de dados
        _context.Clients.Add(client);
        _context.SaveChanges();
    }
}
