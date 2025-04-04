using System;

class Program
{
    static void Main(string[] args)
    {
         Console.WriteLine("--- Online Ordering System ---");

        Address addressUSA = new Address(
            "123 Main St",
            "Anytown",
            "CA",
            "USA"
        );
        Address addressCanada = new Address(
            "456 Maple Ave",
            "Toronto",
            "ON",
            "Canada"
        );

        Customer customerUSA = new Customer("John Doe", addressUSA);
        Customer customerCanada = new Customer("Jane Smith", addressCanada);

        Console.WriteLine("\n--- Order 1 ---");
        Order order1 = new Order(customerUSA);
        order1.AddProduct(new Product("Laptop", "LP1000", 1200.50m, 1));
        order1.AddProduct(new Product("Mouse", "MS250", 25.99m, 1));
        order1.AddProduct(new Product("Keyboard", "KB500", 75.00m, 1));

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.CalculateTotalCost():F2}"); 

        Console.WriteLine("\n--- Order 2 ---");
        Order order2 = new Order(customerCanada);
        order2.AddProduct(new Product("Webcam", "WC300", 45.50m, 1));
        order2.AddProduct(new Product("USB Hub", "UH104", 15.75m, 2)); 

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.CalculateTotalCost():F2}");

        Console.WriteLine("\n--- End of Orders ---");
    }
}