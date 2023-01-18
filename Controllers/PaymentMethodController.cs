using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using yourhotel.Dtos.PaymentMethod;
using YourHotel.Dtos.Client;
using YourHotel.Services;

namespace YourHotel.Controllers;

[ApiController]
[Authorize]
[Route("payment")]
public class PaymentMethodController : ControllerBase
{
    private PaymentMethodService _paymentMethodService;
    public PaymentMethodController([FromServices] PaymentMethodService service)
    {
        _paymentMethodService = service;
    }

    [HttpPost]
    public ActionResult<PaymentResponseDTO> PostPaymentMethod([FromBody] PaymentRequestDTO paymentRequestDTO)
    {
        try
        {
            var paymentResponse = _paymentMethodService.PostPaymentMethod(paymentRequestDTO);
            return StatusCode(201, paymentResponse);
        }
        catch (Exception e)
        {
            return StatusCode(400, "Payment Method could not have been created!" + e);
        }
    }

    [HttpGet]
    public ActionResult<List<PaymentResponseDTO>> GetPaymentMethods()
    {
        try
        {
            var paymentResponse = _paymentMethodService.GetPaymentMethods();
            return StatusCode(200, paymentResponse);
        }
        catch (Exception e)
        {
            return StatusCode(400, "Payment Methods have not been found!" + e);
        }
    }

    [HttpGet("{id:int}")]
    public ActionResult<ClientResponse> GetPaymentMethod([FromRoute] int id)
    {
        try
        {
            var paymentResponse = _paymentMethodService.GetPaymentMethod(id);
            return StatusCode(200, paymentResponse);
        }
        catch (Exception e)
        {
            return StatusCode(400, "Payment Method have not been found !" + e);
        }
    }

    [HttpDelete("{id:int}")]
    public ActionResult DeletePaymentMethod([FromRoute] int id)
    {
        try
        {
            _paymentMethodService.DeletePaymentMethod(id);
            return StatusCode(204);
        }
        catch (Exception e)
        {
            return StatusCode(400, "Payment Method have not been found !" + e);
        }
    }

    [HttpPut("{id:int}")]
    public ActionResult<PaymentResponseDTO> PutPaymentMethod([FromRoute] int id, [FromBody] PaymentRequestDTO paymentRequestDTO)
    {
        try
        {
            var paymentResponse = _paymentMethodService.PutPaymentMethod(id, paymentRequestDTO);
            return StatusCode(200, paymentResponse);
        }
        catch (Exception e)
        {
            return StatusCode(400, "Payment Method have not been found!" + e);
        }
    }
}

