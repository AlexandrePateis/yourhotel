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
    public ActionResult<ClientResponse>  PostClient([FromBody] ClientCreateUpdateRequest newClient)
    {

        var clientResponse = _clientService.CreateClient(newClient);

        //Enviar para a classe serviço os dados da requisição
        return CreatedAtAction(nameof(GetClients), new{id = clientResponse.Id }, clientResponse);

    }
    
    [HttpGet]
    public ActionResult<List<ClientResponse>> GetClients()
    {
        return Ok(_clientService.ListClient());
    }

    [HttpGet("{id:int}")]
    public ActionResult<ClientResponse> GetClient([FromRoute] int id)
    {
        try
        {
            //manda para o serviçoo buscar pelo ID
            return Ok(_clientService.SearchClintById(id));
        }
        catch(Exception e)
        {
            return NotFound(e.Message);
        }
        
    }

    [HttpDelete("{id:int}")]
    public ActionResult DeleteClient([FromRoute] int id)
    {

        try
        {
            _clientService.RemoveCliente(id);

            return NoContent();

        }
        catch(Exception e)
        {
            return NotFound(e.Message);
        }

    }

    [HttpPut("{id:int}")]
    public ActionResult<ClientResponse> PutClient([FromRoute] int id, [FromBody] ClientCreateUpdateRequest clientEdited)
    {

        try
        {
            return Ok( _clientService.UpdateClient(id, clientEdited));
        }
        catch(Exception e)
        {
            return NotFound(e.Message);
        }
 
        
    }
}
