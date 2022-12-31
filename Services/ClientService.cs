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
        //Copiar os dados da req para o modelo
        var client = newClient.Adapt<Client>();

        //Regras de négocio para criação de cliente

        //Enviar os dados para o BD
        _clientRepository.CreateClient(client);

        //copiar os dados do modelo para a resposta
        var clientResponse = client.Adapt<ClientResponse>();

        return clientResponse;

    }

    public List<ClientResponse> ListClient()
    {
        //Busca os clietes no repositório
        var clients = _clientRepository.ListClient();


        var clientResponses = clients.Adapt<List<ClientResponse>>();


        return clientResponses;
    }

    public ClientResponse SearchClintById(int id)
    {
        //Buscar do repositorio pelo Id
        var client = ShareForId(id, false);

        //Copiar do modelo para a resposta
        return client.Adapt<ClientResponse>();
    }

    public void RemoveCliente(int id)
    {
        //buscar pelo id
        var client = ShareForId(id);

        //Mandar o repositorio remover
        _clientRepository.RomeveClient(client);
    }

    public ClientResponse UpdateClient(int id, ClientCreateUpdateRequest clientEdited)
    {
        //Buscar o procedimento pelo Id

        var client = _clientRepository.SearchById(id);

        if (client is null)
        {
            return null;
        }

        //Copiar os dados da req para o modelo
        //ConvertReqToModel(clientEdited, client);
        clientEdited.Adapt(client);

        //mandando o repositorio atualizar
        _clientRepository.UpdateClient();

        //retornando resposta/
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
