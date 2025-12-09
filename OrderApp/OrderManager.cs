namespace OrderApp
{
    internal class Order
    {
        public string CustomerEmail { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }

    internal class OrderManager
    {
        private readonly List<Order> _orders = new();

        public void CreateOrder()
        {
            Console.WriteLine("=== Create new order ===");

            Console.Write("Customer email: ");
            string email = Console.ReadLine();

            Console.Write("Product name: ");
            string product = Console.ReadLine();

            Console.Write("Quantity: ");
            int quantity = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Unit price: ");
            decimal unitPrice = decimal.Parse(Console.ReadLine() ?? "0");

            var order = new Order
            {
                CustomerEmail = email,
                ProductName = product,
                Quantity = quantity,
                UnitPrice = unitPrice
            };

            ValidateOrder(order);
            CalculateTotalPrice(order);
            SaveOrder(order);
            SendConfirmationEmail(order);

            Console.WriteLine("Order created successfully.");
        }

        public void ValidateOrder(Order order)
        {
            if (string.IsNullOrWhiteSpace(order.CustomerEmail))
                Console.WriteLine("WARNING: Customer email is missing.");

            if (string.IsNullOrWhiteSpace(order.ProductName))
                Console.WriteLine("WARNING: Product name is missing.");

            if (order.Quantity <= 0)
                Console.WriteLine("WARNING: Quantity must be greater than 0.");

            if (order.UnitPrice <= 0)
                Console.WriteLine("WARNING: Unit price must be greater than 0.");
        }

        public void CalculateTotalPrice(Order order)
        {
            order.TotalPrice = order.Quantity * order.UnitPrice;

            if (order.Quantity >= 10)
            {
                order.TotalPrice *= 0.9m; // 10% discount
            }
        }

        public void SaveOrder(Order order)
        {
            _orders.Add(order);

            // Fake save to file
            var line =
                $"{DateTime.Now:O};{order.CustomerEmail};{order.ProductName};{order.Quantity};{order.UnitPrice};{order.TotalPrice}";
            File.AppendAllLines("orders.txt", new[] { line });

            Console.WriteLine("Order saved.");
        }

        public void SendConfirmationEmail(Order order)
        {
            Console.WriteLine();
            Console.WriteLine("=== Sending confirmation email ===");
            Console.WriteLine($"To: {order.CustomerEmail}");
            Console.WriteLine($"Subject: Order confirmation for {order.ProductName}");
            Console.WriteLine($"Body: Thank you for your order of {order.Quantity} x {order.ProductName}.");
            Console.WriteLine($"Total: {order.TotalPrice:C}");
            Console.WriteLine("=== Email sent ===");
            Console.WriteLine();
        }
    }
}
