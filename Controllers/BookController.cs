using Dapper;
using DependencyRoomBooking.Commands;
using DependencyRoomBooking.Models;
using DependencyRoomBooking.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace DependencyRoomBooking.Controllers;

[ApiController]
public class BookController : ControllerBase
{
    ICustomerService _serviceCostumer;
    IBookService _bookService;
    public BookController(ICustomerService serviceCostumer, IBookService bookService)
    {
        _serviceCostumer = serviceCostumer;
        _bookService = bookService;
    }

    public async Task<IActionResult> Book(BookRoomCommand command)
    {
        // Recupera o usuário
        var customer = _serviceCostumer.GetCustomerByEmailAsync(command.Email);

        if (customer == null)
            return NotFound();

        // Verifica se a sala está disponível
        var bookedRoom = await _bookService.VerifyIfRoomHasBooked(command.RoomId, command.Day.Date, command.Day.Date.AddDays(1).AddTicks(-1));

        // Se existe uma reserva, a sala está indisponível
        if (bookedRoom)
            return BadRequest();

        // Tenta fazer um pagamento
        var client = new RestClient("https://payments.com");
        var request = new RestRequest()
            .AddQueryParameter("api_key", "c20c8acb-bd76-4597-ac89-10fd955ac60d")
            .AddJsonBody(new
            {
                User = command.Email,
                CreditCard = command.CreditCard
            });
        var response = await client.PostAsync<PaymentResponse>(request, new CancellationToken());

        // Se a requisição não pode ser completa
        if (response is null)
            return BadRequest();

        // Se o status foi diferente de "pago"
        if (response?.Status != "paid")
            return BadRequest();

        // Cria a reserva
        var book = new Book(command.Email, command.RoomId, command.Day);

        // Salva os dados
        await connection.ExecuteAsync("INSERT INTO [Book] VALUES(@date, @email, @room)", new
        {
            book.Date,
            book.Email,
            book.Room
        });

        // Retorna o número da reserva
        return Ok();
    }
}