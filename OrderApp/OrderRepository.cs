namespace OrderApp
{
    internal class OrderRepository
    {
        private readonly List<Order> _orders = new();

        public void Save(Order order)
        {
            _orders.Add(order);

            var line =
                $"{DateTime.Now:O};{order.CustomerEmail};{order.ProductName};{order.Quantity};{order.UnitPrice};{order.TotalPrice}";

            File.AppendAllLines("orders.txt", new[] { line });
        }
    }
}
