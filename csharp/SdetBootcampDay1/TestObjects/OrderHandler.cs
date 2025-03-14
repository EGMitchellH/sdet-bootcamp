namespace SdetBootcampDay1.TestObjects
{
    public class OrderHandler
    {
        private IDictionary<OrderItem, int>? stock = new Dictionary<OrderItem, int>();
        private readonly PaymentProcessor paymentProcessor;

        public OrderHandler()
        {
            this.stock.Add(OrderItem.FIFA_24, 10);
            this.stock.Add(OrderItem.Fortnite, 100);
            this.stock.Add(OrderItem.SuperMarioBros3, 5);

            this.paymentProcessor = new PaymentProcessor(PaymentProcessorType.Stripe);
        }

        [Obsolete]
        public bool OrderAndPay(OrderItem item, int quantity)
        {
            if (!this.stock!.TryGetValue(item, out int result))
            {
                throw new ArgumentException($"Unknown item {item}");
            }

            if (this.stock[item] < quantity)
            {
                throw new ArgumentException($"Insufficient stock for item {item}");
            }

            this.stock[item] -= quantity;

            return this.paymentProcessor.PayFor(item, quantity);
        }

        public void Order(OrderItem item, int quantity)
        {
            if (!this.stock!.TryGetValue(item, out int result))
            {
                throw new ArgumentException($"Unknown order item {item}");
            }

            if (this.stock[item] < quantity)
            {
                throw new ArgumentException($"Insufficient stock to order item {item}");
            }

            this.stock[item] -= quantity;
        }

        public bool Pay(OrderItem item, int quantity)
        {
            if (!this.stock!.TryGetValue(item, out int result))
            {
                throw new ArgumentException($"Unknown pay item {item}");
            }
            
            if (this.stock[item] < quantity)
            {
                throw new ArgumentException($"Insufficient stock to pay for item {item}");
            }
            
            return this.paymentProcessor.PayFor(item, quantity);
        }

        public void AddStock(OrderItem item, int quantity)
        {
            if (!this.stock!.TryGetValue(item, out int result))
            {
                throw new ArgumentException($"Unknown item {item}");
            }

            this.stock[item] += quantity;
        }

        public int GetStockFor(OrderItem item)
        {
            if (!this.stock!.TryGetValue(item, out int result))
            {
                throw new ArgumentException($"Unknown item {item}");
            }

            return this.stock[item]; 
        }
    }
}
