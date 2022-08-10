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

    }

    public static void AddServices(this IServiceCollection services)
    {

    }
}
