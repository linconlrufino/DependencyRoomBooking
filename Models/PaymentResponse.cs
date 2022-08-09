namespace DependencyRoomBooking.Models;

public class PaymentResponse
{
    public PaymentResponse(int code, string status)
    {
        Code = code;
        Status = status;
    }

    public int Code { get; private set; }
    public string Status { get; private set; }
}