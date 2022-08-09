namespace DependencyRoomBooking.Controllers;

public class Book
{
    public Book(string email, Guid room, DateTime date)
    {
        Email = email;
        Room = room;
        Date = date;
    }

    public string Email { get; private set; }
    public Guid Room { get; private set; }
    public DateTime Date { get; private set; }
}
