using DependencyRoomBooking.Models;

namespace DependencyRoomBooking.Repositories.Contracts;

public interface ICustomerRepository
{
    public Task<Customer?> GetCustomerByEmailAsync(string email);
}
