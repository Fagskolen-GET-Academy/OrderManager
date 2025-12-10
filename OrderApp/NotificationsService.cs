namespace OrderApp
{
    internal class NotificationsService
    {
        public void SendOrderConfirmation(Order order)
        {
            Console.WriteLine();
            Console.WriteLine("=== Sending confirmation email ===");
            Console.WriteLine($"To: {order.CustomerEmail}");
            Console.WriteLine($"Subject: Order confirmation for {order.ProductName}");
            Console.WriteLine($"Total: {order.TotalPrice:C}");
            Console.WriteLine("=== Email sent ===");
            Console.WriteLine();
        }

    }
}
