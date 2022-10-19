using Microsoft.AspNetCore.Mvc;
using YourHotel.Dtos.Client;
using YourHotel.Services;

namespace YourHotel.Controllers;

[ApiController]
[Route("client")]
public class ClientController : ControllerBase
{
    private ClientService _clientService;

    //injetando o serviço no construtor
    public ClientController([FromServices] ClientService service)
    {
        _clientService = service;
    }

    [HttpPost]
    public void PostClient([FromBody] ClientCreateUpdateRequest newClient)
    {
        //Enviar para a classe serviço os dados da requisição
        _clientService.CreateClient(newClient);

    }
}
