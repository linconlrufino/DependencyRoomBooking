using DependencyRoomBooking.Commands;
using DependencyRoomBooking.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace DependencyRoomBooking.Controllers;

[ApiController]
public class BookController : ControllerBase
{
    ICustomerService _serviceCostumer;
    IBookService _bookService;
    IPaymentService _paymentService;
    public BookController(ICustomerService serviceCostumer, IBookService bookService, IPaymentService paymentService)
    {
        _serviceCostumer = serviceCostumer;
        _bookService = bookService;
        _paymentService = paymentService;
    }

    [HttpPost]
    public async Task<IActionResult> Book(BookRoomCommand command)
    {
        var customer = _serviceCostumer.GetCustomerByEmailAsync(command.Email);

        if (customer == null)
            return NotFound();

        var bookedRoom = await _bookService.VerifyIfRoomHasBooked(command.RoomId, command.Day.Date, command.Day.Date.AddDays(1).AddTicks(-1));

        if (bookedRoom)
            return BadRequest();

        var responsePayment = await _paymentService.MakePayment(command.Email, command.CreditCard);

        if (responsePayment is null)
            return BadRequest();

        if (responsePayment?.Status != "paid")
            return BadRequest();

        var bookingNumber = await _bookService.BookARoom(command.Email, command.Day, command.RoomId);

        if (bookingNumber is not null)
            return Ok(bookingNumber);
        else
            return BadRequest();
    }
}