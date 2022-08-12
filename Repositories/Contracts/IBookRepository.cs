using DependencyRoomBooking.Models;

namespace DependencyRoomBooking.Repositories.Contracts;

public interface IBookRepository
{
    public Task<Book?> GetBookByRoomIdAndBetweenDateStartAndDateEnd(
        Guid roomId,
        DateTime dateStart,
        DateTime dateEnd);

}
