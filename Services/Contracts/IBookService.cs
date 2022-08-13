namespace DependencyRoomBooking.Services.Contracts;

public interface IBookService
{
    public Task<bool> VerifyIfRoomHasBooked(
        Guid roomId,
        DateTime dateStart,
        DateTime dateEnd);

    public Task<Guid?> BookARoom(
        string email,
        DateTime day,
        Guid roomId);
}
