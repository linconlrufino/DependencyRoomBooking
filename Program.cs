using DependencyRoomBooking.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();

var connStr = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddSqlConnection(connStr);
builder.Services.AddRepositories();
builder.Services.AddServices();

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
