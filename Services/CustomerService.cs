using DependencyRoomBooking.Models;
using DependencyRoomBooking.Repositories.Contracts;
using DependencyRoomBooking.Services.Contracts;

namespace DependencyRoomBooking.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<Customer?> GetCustomerByEmailAsync(string email)
    {
        return await _customerRepository.GetCustomerByEmailAsync(email);
    }
}
