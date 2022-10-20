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
    public void CreateClient(ClientCreateUpdateRequest newClient)
    {
        //Copiar os dados da req para o modelo
        var client = new Client();
        client.Name = newClient.Name;
        client.Email = newClient.Email;
        client.Cpf = newClient.Cpf;
        client.BirthDate = newClient.BirthDate;
        client.PhoneNumber = newClient.PhoneNumber;

        //Regras de négocio para criação de cliente

        //Enviar os dados para o BD
        _clientRepository.CreateClient(client);

    }
}
