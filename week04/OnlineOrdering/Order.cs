using System.Text; 

public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>(); 
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public decimal CalculateTotalCost()
    {
        decimal totalProductsCost = 0;
        foreach (Product product in _products)
        {
            totalProductsCost += product.GetTotalCost();
        }

        decimal shippingCost = _customer.IsUSAAddress() ? 5.00m : 35.00m; 

        return totalProductsCost + shippingCost;
    }

    public string GetPackingLabel()
    {
        StringBuilder labelBuilder = new StringBuilder();
        labelBuilder.AppendLine("--- Packing Label ---");
        foreach (Product product in _products)
        {
            labelBuilder.AppendLine(
                $"  Product: {product.Name} (ID: {product.ProductId})"
            );
        }
        labelBuilder.AppendLine("---------------------");
        return labelBuilder.ToString();
    }

    public string GetShippingLabel()
    {
        StringBuilder labelBuilder = new StringBuilder();
        labelBuilder.AppendLine("--- Shipping Label ---");
        labelBuilder.AppendLine($"  Name: {_customer.Name}");
        labelBuilder.AppendLine($"  Address:\n{_customer.GetAddressString()}"); 
        labelBuilder.AppendLine("----------------------");
        return labelBuilder.ToString();
    }
}
