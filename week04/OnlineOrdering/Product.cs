using System;

public class Product
{
    private string _name;
    private string _productId;
    private decimal _pricePerUnit; 
    private int _quantity;

    public Product(string name, string id, decimal price, int quantity)
    {
        _name = name;
        _productId = id;
        _pricePerUnit = price;
        _quantity = quantity;
    }

    public decimal GetTotalCost()
    {
        return _pricePerUnit * _quantity;
    }

    public string Name
    {
        get { return _name; }
    }

    public string ProductId
    {
        get { return _productId; }
    }

    public decimal PricePerUnit
    {
        get { return _pricePerUnit; }
    }

    public int Quantity
    {
        get { return _quantity; }
    }
}
