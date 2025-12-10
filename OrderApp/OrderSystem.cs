namespace OrderApp
{

    namespace OrderSystem
    {
        internal class OrderManager
        {
            private readonly OrderValidator _validator = new();
            private readonly PriceCalculator _calculator = new();
            private readonly OrderRepository _repository = new();
            private readonly NotificationsService _notifier = new();

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

                _validator.ValidateOrder(order);

                order.TotalPrice = _calculator.CalculateTotalPrice(order);

                _repository.Save(order);

                _notifier.SendOrderConfirmation(order);

                Console.WriteLine("Order created successfully.");
            }
        }
    }

}
