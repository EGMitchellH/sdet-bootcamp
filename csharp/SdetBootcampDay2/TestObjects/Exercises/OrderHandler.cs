﻿namespace SdetBootcampDay2.TestObjects.Exercises
{
    public class OrderHandler
    {
        private IDictionary<OrderItem, int>? stock = new Dictionary<OrderItem, int>();
        private readonly PaymentProcessor paymentProcessor;

        /**
         * TODO: can you apply Dependency Inversion here to make this code more flexible,
         * allowing users to inject the stock, and thereby make the code easier to test?
         * Do the same for the PaymentProcessor. You do not need to create interfaces as
         * was shown in the example (although if you want to, be my guest!)
         * After you have done that, update the existing tests and add the tests that were
         * not possible before.
         */
        public OrderHandler(IDictionary<OrderItem, int> new_stock, PaymentProcessor new_payment_processor)
        {
            this.stock = new_stock;
            this.paymentProcessor = new_payment_processor;
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
