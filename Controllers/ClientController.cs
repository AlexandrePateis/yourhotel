using Microsoft.AspNetCore.Mvc;
using YourHotel.Dtos.Client;
using YourHotel.Services;

namespace YourHotel.Controllers;

[ApiController]
[Route("client")]
public class ClientController : ControllerBase
{
    //Campo injetado no construtor
    private ClientService _clientService;

    //injetando o serviço no construtor
    public ClientController([FromServices] ClientService service)
    {
        _clientService = service;
    }

    [HttpPost]
    public ClientResponse PostClient([FromBody] ClientCreateUpdateRequest newClient)
    {
        //Enviar para a classe serviço os dados da requisição
        return _clientService.CreateClient(newClient);

    }
    
    [HttpGet]
    public List<ClientResponse> GetClients()
    {
        return _clientService.ListClient();
    }

    [HttpGet("{id:int}")]
    public ClientResponse GetClient([FromRoute] int id)
    {
        //manda para o serviçoo buscar pelo ID
        return _clientService.SearchClintById(id);
    }

    [HttpDelete("{id:int}")]
    public void DeleteClient([FromRoute] int id)
    {
        _clientService.RemoveCliente(id);
    }

    [HttpPut("{id:int}")]
    public ClientResponse PutClient([FromRoute] int id, [FromBody] ClientCreateUpdateRequest clientEdited)
    {
        return _clientService.UpdateClient(id, clientEdited);
    }
}
