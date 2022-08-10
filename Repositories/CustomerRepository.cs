using Dapper;
using DependencyRoomBooking.Models;
using DependencyRoomBooking.Repositories.Contracts;
using Microsoft.Data.SqlClient;

namespace DependencyRoomBooking.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly SqlConnection _context;
    public CustomerRepository(SqlConnection _context)
    {
        _context = _context;
    }

    public async Task<Customer?> GetCustomerByEmailAsync(string email)
    {
        var customer = await _context
            .QueryFirstOrDefaultAsync<Customer?>("SELECT * FROM [Customer] WHERE [Email]=@email", email);

        return customer;
    }
}
