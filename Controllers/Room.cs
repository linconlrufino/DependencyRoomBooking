namespace DependencyRoomBooking.Controllers;

public class Room
{
    public Room(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }

    public Guid Id { get; private set; }
    public string Name { get; private set; }
}
