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

    public async Task<bool> VerifyIfRoomHasBooked(Guid roomId, DateTime dateStart, DateTime dateEnd)
    {
        var book = await _bookRepository.GetBookByRoomIdAndBetweenDateStartAndDateEnd(roomId, dateStart, dateEnd);

        if (book == null)
            return false;
        else
            return true;
    }
}
