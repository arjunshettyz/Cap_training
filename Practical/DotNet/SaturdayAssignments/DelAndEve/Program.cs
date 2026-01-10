using System;
using System.Collections.Generic;

namespace EcommerceAssessment
{
    // GENERIC REPOSITORY
    class Repository<T>
    {
        private List<T> items = new List<T>();

        public void Add(T item)
        {
            items.Add(item);
        }

        public List<T> GetAll()
        {
            return items;
        }
    }

    // ORDER MODEL
    class Order
    {
        public int OrderId { get; set; }
        public string? CustomerName { get; set; }
        public double Amount { get; set; }

        public override string ToString()
        {
            return $"Order Id: {OrderId}, Customer: {CustomerName}, Amount: {Amount}";
        }
    }

    // DELEGATE
    public delegate void OrderCallback(string message);

    // ORDER PROCESSOR WITH EVENT
    class OrderProcessor
    {
        public event Action<string>? OrderProcessed;

        public void ProcessOrder(
            Order order,
            Func<double, double> taxCalculator,
            Func<double, double> discountCalculator,
            Predicate<Order> validator,
            OrderCallback callback)
        {
            if (!validator(order))
            {
                callback("Order validation failed");
                return;
            }

            double tax = taxCalculator(order.Amount);
            double discount = discountCalculator(order.Amount);

            order.Amount = order.Amount + tax - discount;

            callback($"Order {order.OrderId} processed successfully");
            OrderProcessed?.Invoke($"Event on Order {order.OrderId} completed");
        }
    }

    // CALLER CLASS
    class EcommerceOrderCaller
    {
        public static void EcommerceOutput()
        {
            Repository<Order> orderRepo = new Repository<Order>();

            orderRepo.Add(new Order { OrderId = 1, CustomerName = "Shivansh", Amount = 5000 });
            orderRepo.Add(new Order { OrderId = 2, CustomerName = "Naman", Amount = 2000 });
            orderRepo.Add(new Order { OrderId = 3, CustomerName = "Rohan", Amount = 3000 });

            Func<double, double> taxCalculator = amount => amount * 0.18;
            Func<double, double> discountCalculator = amount => amount * 0.05;

            Predicate<Order> validator = order => order.Amount >= 3000;

            OrderCallback callback = message =>
                Console.WriteLine($"Callback : {message}");

            Action<string> logger = message =>
                Console.WriteLine($"Logger : {message}");

            Action<string> notifier = message =>
                Console.WriteLine($"Notifier : {message}");

            OrderProcessor processor = new OrderProcessor();
            processor.OrderProcessed += logger;
            processor.OrderProcessed += notifier;

            foreach (var order in orderRepo.GetAll())
            {
                processor.ProcessOrder(
                    order,
                    taxCalculator,
                    discountCalculator,
                    validator,
                    callback
                );
                Console.WriteLine();
            }

            List<Order> orders = orderRepo.GetAll();
            orders.Sort((o1, o2) => o2.Amount.CompareTo(o1.Amount));

            Console.WriteLine("Sorted Orders in Descending Amount");
            foreach (var order in orders)
            {
                Console.WriteLine(order);
            }
        }
    }

    // PROGRAM ENTRY POINT
    class Program
    {
        static void Main(string[] args)
        {
            EcommerceOrderCaller.EcommerceOutput();
        }
    }
}