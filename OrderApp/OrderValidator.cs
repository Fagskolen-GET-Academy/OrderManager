namespace OrderApp
{
    internal class OrderValidator
    {
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
    }
}
