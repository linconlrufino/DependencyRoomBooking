using DependencyRoomBooking.Models;

namespace DependencyRoomBooking.Services.Contracts;

public interface ICustomerService
{
    public Task<Customer?> GetCustomerByEmailAsync(string email);
}
