using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YourHotel.Data;
using YourHotel.Models;

namespace YourHotel.Repository;

public class PaymentMethodRepository
{
    private ContextBD _context;

    public PaymentMethodRepository([FromServices] ContextBD contexto)
    {
        _context = contexto;
    }
    public PaymentMethod PostPaymentMethod(PaymentMethod paymentMethod)
    {
        _context.PaymentMethods.Add(paymentMethod);
        _context.SaveChanges();
        return paymentMethod;
    }

    public List<PaymentMethod> GetPaymentMethods()
    {
        return _context.PaymentMethods.AsNoTracking().ToList();
    }

    public PaymentMethod GetPaymentMethod(int id, bool tracking = true)
    {
        if (tracking)
        {
            return _context.PaymentMethods.FirstOrDefault(item => item.Id == id);
        }
        else
        {
            return _context.PaymentMethods.AsNoTracking().FirstOrDefault(item => item.Id == id);
        }
    }

    public bool DeletePaymentMethod(PaymentMethod paymentMethod)
    {
        _context.PaymentMethods.Remove(paymentMethod);
        _context.SaveChanges();
        return true;
    }

    public void PutPaymentMethod()
    {
        _context.SaveChanges();

    }
}
