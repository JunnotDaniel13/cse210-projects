using System;

public class Customer
{
    private string _name;
    private Address _address; 

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    public bool IsUSAAddress()
    {
        return _address.IsInUSA();
    }

    public string Name
    {
        get { return _name; }
    }

    public string GetAddressString()
    {
        return _address.GetFullAddressString();
    }
}
