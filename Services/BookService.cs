using DependencyRoomBooking.Models;
using DependencyRoomBooking.Repositories.Contracts;
using DependencyRoomBooking.Services.Contracts;

namespace DependencyRoomBooking.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;

    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<Guid?> BookARoom(string email, DateTime day, Guid roomId)
    {
        var book = new Book(email, roomId, day);

        var saved = await _bookRepository.Save(book);

        if (saved.Value)
        {
            var bookedRoom = await _bookRepository.GetBookByRoomIdAndBetweenDateStartAndDateEnd(roomId, day.Date, day.Date.AddDays(1).AddTicks(-1));

            return bookedRoom.Room;
        }
        else
            return null;
    }

    public async Task<bool> VerifyIfRoomHasBooked(Guid roomId, DateTime dateStart, DateTime dateEnd)
    {
        var book = await _bookRepository.GetBookByRoomIdAndBetweenDateStartAndDateEnd(roomId, dateStart, dateEnd);

        if (book == null)
            return false;
        else
            return true;
    }
}
