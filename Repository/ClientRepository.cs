using YourHotel.Data;
using Microsoft.AspNetCore.Mvc;
using YourHotel.Models;
namespace YourHotel.Repository;
using Microsoft.EntityFrameworkCore;

public class ClientRepository
{
    private ContextBD _context;

    public ClientRepository([FromServices] ContextBD contexto)
    {
        _context = contexto;
    }
    public Client CreateClient(Client client)
    {
        //Recebe do serviço e salva no banco de dados
        _context.Clients.Add(client);
        _context.SaveChanges();

        //retorna o modelo
        return client;
    }

    public List<Client> ListClient()
    {
        return _context.Clients.AsNoTracking().ToList();
    }

    public Client SearchById(int id, bool tracking = true)
    {
        if(tracking)
        {
            //Busca o client por id especifico
            return _context.Clients.FirstOrDefault(client => client.Id == id);
        }
        else
        {
            //Busca o client por id especifico
            return _context.Clients.AsNoTracking().FirstOrDefault(client => client.Id == id);
        }
        
    }

    public void RomeveClient(Client client)
    {
        _context.Remove(client);
        _context.SaveChanges();
    }

    public void UpdateClient()
    {
        _context.SaveChanges();
    }
}
