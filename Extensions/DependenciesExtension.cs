using DependencyRoomBooking.Repositories;
using DependencyRoomBooking.Repositories.Contracts;
using DependencyRoomBooking.Services;
using DependencyRoomBooking.Services.Contracts;
using Microsoft.Data.SqlClient;

namespace DependencyRoomBooking.Extensions;

public static class DependenciesExtension
{
    public static void AddSqlConnection(
        this IServiceCollection services,
        string connectString)
    {
        services.AddScoped(x
            => new SqlConnection(connectString));
    }

    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<ICustomerRepository, CustomerRepository>();
    }

    public static void AddServices(this IServiceCollection services)
    {
        services.AddTransient<ICustomerService, CustomerService>();
    }
}
