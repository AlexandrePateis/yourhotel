using Microsoft.AspNetCore.Mvc;
using YourHotel.Dtos.Client;
using YourHotel.Models;
using YourHotel.Repository;

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
        var client = new Client();
        ConvertReqToModel(newClient, client);

        //Regras de négocio para criação de cliente

        //Enviar os dados para o BD
        _clientRepository.CreateClient(client);

        //copiar os dados do modelo para a resposta
        var clientResponse = ConvertModelToResponse(client);

        return clientResponse;

    }

    public List<ClientResponse> ListClient()
    {
        //Busca os clietes no repositório
        var clients = _clientRepository.ListClient();

        //Lista de clientesResponse
        List<ClientResponse> clientResponses = new();

        foreach(var client in clients )
        {
            //Copiar os dados do modelo para a resposta
            var clientResponse = ConvertModelToResponse(client);
            clientResponses.Add(clientResponse);
        }

        return clientResponses;
    }

    private ClientResponse ConvertModelToResponse(Client model)
    {
        var clientResponse = new ClientResponse();
        clientResponse.Id = model.Id;
        clientResponse.Name = model.Name;
        clientResponse.Email = model.Email;
        clientResponse.Cpf = model.Cpf;
        clientResponse.BirthDate = model.BirthDate;
        clientResponse.PhoneNumber = model.PhoneNumber;

        return clientResponse;
    }

    public ClientResponse SearchClintById(int id)
    {
        //Buscar do repositorio pelo Id
        var client = _clientRepository.SearchById(id);

        //Copiar do modelo para a resposta
        return ConvertModelToResponse(client);
    }

    public void RemoveCliente(int id)
    {
        //buscar pelo id
        var client = _clientRepository.SearchById(id);

        if(client is null)
        {
            return;
        }

        //Mandar o repositorio remover
        _clientRepository.RomeveClient(client);
    }

    public ClientResponse UpdateClient(int id, ClientCreateUpdateRequest clientEdited)
    {
        //Buscar o procedimento pelo Id

        var client = _clientRepository.SearchById(id);

        if(client is null)
        {
            return null;
        }

        //Copiar os dados da req para o modelo
        ConvertReqToModel(clientEdited, client);

        //mandando o repositorio atualizar
        _clientRepository.UpdateClient();

        //retornando resposta/
        return ConvertModelToResponse(client);

    }

    private void ConvertReqToModel(ClientCreateUpdateRequest request, Client model)
    {
        model.Name = request.Name;
        model.Email = request.Email;
        model.Cpf = request.Cpf;
        model.PhoneNumber = request.PhoneNumber;
        model.BirthDate = request.BirthDate;
    }
}
