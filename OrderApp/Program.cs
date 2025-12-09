namespace OrderApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var orderManager = new OrderManager();
            orderManager.CreateOrder();
        }
    }
}
