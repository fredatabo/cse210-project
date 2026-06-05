using System;

class Program
{
    static void Main(string[] args)
    {
        // Create addresses
        Address usaAddress = new Address("123 Main Street", "Texas", "NY", "USA");
        Address canadaAddress = new Address("456 Maple Avenue", "Toronto", "ON", "Canada");

        // Create customers
        Customer customer1 = new Customer("John Doe", usaAddress);
        Customer customer2 = new Customer("Sarah Matinez", canadaAddress);

        // Create products
        Product laptop = new Product("Laptop", 1001, 888.99, 1);
        Product mouse = new Product("Wireless Mouse", 1002, 29.99, 2);
        Product keyboard = new Product("Mechanical Keyboard", 1003, 89.99, 1);
        Product monitor = new Product("24-inch Monitor", 1004, 199.99, 1);
        Product usbCable = new Product("USB-C Cable", 1005, 12.99, 3);
        Product headset = new Product("Gaming Headset", 1006, 59.99, 1);

        // Create first order
        Order order1 = new Order(customer1);
        order1.AddProduct(laptop);
        order1.AddProduct(mouse);
        order1.AddProduct(keyboard);

        // Create second order
        Order order2 = new Order(customer2);
        order2.AddProduct(monitor);
        order2.AddProduct(usbCable);
        order2.AddProduct(headset);

        // Display order 1 details
        Console.WriteLine("ORDER #1");
        Console.WriteLine("========");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.GetTotalCost():F2}\n");

        // Display order 2 details
        Console.WriteLine("ORDER #2");
        Console.WriteLine("========");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.GetTotalCost():F2}");

    }
}