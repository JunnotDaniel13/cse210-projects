using System;
using System.Text; 

public class Address
{
    private string _streetAddress;
    private string _city;
    private string _stateProvince;
    private string _country;

    public Address(string street, string city, string state, string country)
    {
        _streetAddress = street;
        _city = city;
        _stateProvince = state;
        _country = country;
    }

    public bool IsInUSA()
    {
        return _country.Equals("USA", StringComparison.OrdinalIgnoreCase);
    }

    public string GetFullAddressString()
    {
        StringBuilder addressBuilder = new StringBuilder();
        addressBuilder.AppendLine(_streetAddress);
        addressBuilder.AppendLine($"{_city}, {_stateProvince}");
        addressBuilder.Append(_country);
        return addressBuilder.ToString();
    }
}
