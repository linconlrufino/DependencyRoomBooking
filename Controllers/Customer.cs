﻿namespace DependencyRoomBooking.Controllers;

public class Customer
{
    public Customer(string email)
    {
        Email = email;
    }

    public string Email { get; private set; }
}
