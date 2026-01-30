using System;

class Program
{
    static void Main(string[] args)
    {
        // Order 1: Customer in USA
        Address address1 = new Address("123 Main St", "Springfield", "IL", "USA");
        Customer customer1 = new Customer("John Doe", address1);
        Order order1 = new Order(customer1);   
        order1.AddProduct(new Product(1, "Laptop", 999.99, 1));
        order1.AddProduct(new Product(2, "Mouse", 25.50, 2));

        // Order 2: Customer outside USA
        Address address2 = new Address("456 Elm St", "Guayaquil", "Guayas", "Ecuador");
        Customer customer2 = new Customer("Francisco Perez ", address2);
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product(3, "Smartphone", 799.99, 1));
        order2.AddProduct(new Product(4, "Headphones", 199.99, 1));
        order2.AddProduct(new Product(5, "Charger", 49.99, 1));

        // Display Order 1 details
        List<Order> orders = new List<Order> { order1, order2 };

        foreach (Order order in orders)
        {
            Console.WriteLine("====================================");
            Console.WriteLine(order.GeneratePackingLabel());
            Console.WriteLine(order.GenerateShippingLabel());
            Console.WriteLine($"Total Cost: ${order.CalculateTotalCost():F2}\n");
            Console.WriteLine("====================================");
        }
 
    }
}