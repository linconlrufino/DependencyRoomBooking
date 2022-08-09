namespace DependencyRoomBooking.Controllers;

public class CreditCard
{
    public CreditCard(string number, string holder, string expiration, string cvv)
    {
        Number = number;
        Holder = holder;
        Expiration = expiration;
        Cvv = cvv;
    }

    public string Number { get; private set; }
    public string Holder { get; private set; }
    public string Expiration { get; private set; }
    public string Cvv { get; private set; }
}