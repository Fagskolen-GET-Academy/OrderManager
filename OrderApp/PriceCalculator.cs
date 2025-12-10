namespace OrderApp
{
    internal class PriceCalculator
    {
        public decimal CalculateTotalPrice(Order order)
        {
            decimal total = order.Quantity * order.UnitPrice;

            if (order.Quantity >= 10)
            {
                total *= 0.9m; // 10% discount
                return total;
            }

            return 0;
        }
    }
}
