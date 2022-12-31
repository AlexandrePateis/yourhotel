using Mapster;
using Microsoft.AspNetCore.Mvc;
using yourhotel.Dtos.PaymentMethod;
using yourhotel.Repository;
using YourHotel.Models;

namespace YourHotel.Services;

public class PaymentMethodService
{
    private PaymentMethodRepository _paymentMethodRepository;

    public PaymentMethodService([FromServices] PaymentMethodRepository repository)
    {
        _paymentMethodRepository = repository;
    }
    public PaymentResponseDTO PostPaymentMethod(PaymentRequestDTO paymentRequestDTO)
    {
        var paymentMethodModel = paymentRequestDTO.Adapt<PaymentMethod>();
        var responseModel = _paymentMethodRepository.PostPaymentMethod(paymentMethodModel);
        var paymentMethodResponse = responseModel.Adapt<PaymentResponseDTO>();
        return paymentMethodResponse;
    }

    public List<PaymentResponseDTO> GetPaymentMethods()
    {
        List<PaymentMethod> paymentMethods = _paymentMethodRepository.GetPaymentMethods();
        var paymentResponseDTOs = paymentMethods.Adapt<List<PaymentResponseDTO>>();
        return paymentResponseDTOs;
    }

    public PaymentResponseDTO GetPaymentMethod(int id)
    {
        var responseModel = _paymentMethodRepository.GetPaymentMethod(id, false);
        return responseModel.Adapt<PaymentResponseDTO>();
    }

    public bool DeletePaymentMethod(int id)
    {
        try
        {
            var paymentMethod = GetPaymentMethodById(id);
            _paymentMethodRepository.DeletePaymentMethod(paymentMethod);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public PaymentResponseDTO PutPaymentMethod(int id, PaymentRequestDTO paymentRequestDTO)
    {
        var paymentMethod = GetPaymentMethodById(id);

        if (paymentMethod is null)
        {
            return null;
        }
        paymentRequestDTO.Adapt(paymentMethod);
        _paymentMethodRepository.PutPaymentMethod();
        return paymentMethod.Adapt<PaymentResponseDTO>();

    }

    //Methods
    private PaymentMethod GetPaymentMethodById(int id, bool tracking = true)
    {
        var paymentMethod = _paymentMethodRepository.GetPaymentMethod(id, tracking);
        if (paymentMethod is null)
        {
            throw new Exception();
        }
        return paymentMethod;
    }
}
