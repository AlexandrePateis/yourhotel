using Microsoft.AspNetCore.Mvc;
using YourHotel.Dtos.Client;
using YourHotel.Models;
using YourHotel.Repository;
using Mapster;
namespace YourHotel.Services;

public class ClientService
{
    private ClientRepository _clientRepository;

    public ClientService([FromServices] ClientRepository repository)
    {
        _clientRepository = repository;
    }
    public ClientResponse CreateClient(ClientCreateUpdateRequest newClient)
    {
        var client = newClient.Adapt<Client>();
        _clientRepository.CreateClient(client);
        var clientResponse = client.Adapt<ClientResponse>();
        return clientResponse;
    }

    public List<ClientResponse> ListClient()
    {
        var clients = _clientRepository.ListClient();
        var clientResponses = clients.Adapt<List<ClientResponse>>();
        return clientResponses;
    }

    public ClientResponse SearchClintById(int id)
    {
        var client = ShareForId(id, false);
        return client.Adapt<ClientResponse>();
    }

    public void RemoveCliente(int id)
    {
        var client = ShareForId(id);
        _clientRepository.RomeveClient(client);
    }

    public ClientResponse UpdateClient(int id, ClientCreateUpdateRequest clientEdited)
    {
        var client = _clientRepository.SearchById(id);

        if (client is null)
        {
            return null;
        }
        clientEdited.Adapt(client);
        _clientRepository.UpdateClient();
        return client.Adapt<ClientResponse>();
    }



    private Client ShareForId(int id, bool tracking = true)
    {
        var client = _clientRepository.SearchById(id, tracking);

        if (client is null)
        {
            throw new Exception("Client not found");
        }
        return client;
    }
}
