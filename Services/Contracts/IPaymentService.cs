using DependencyRoomBooking.Models;

namespace DependencyRoomBooking.Services.Contracts;

public interface IPaymentService
{
    public Task<PaymentResponse?> MakePayment(string email, CreditCard creditCard);
}
