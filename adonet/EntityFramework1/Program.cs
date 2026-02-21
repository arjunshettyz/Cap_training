using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

// Entities
public class Order
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public List<OrderItem> OrderItems { get; set; } = new();
}

public class OrderItem
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }

    public int OrderId { get; set; }
    public Order Order { get; set; }
}

// DTO
public class OrderDTO
{
    public int CustomerId { get; set; }
    public List<OrderItemDTO> Items { get; set; } = new();
}

public class OrderItemDTO
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}

// DbContext
public class AppDbContext : DbContext
{
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer("Server=.;Database=OrderDB;Trusted_Connection=True;TrustServerCertificate=True");
}

// Program
class Program
{
    static void Main()
    {
        var orderDTO = new OrderDTO
        {
            CustomerId = 101,
            Items = new List<OrderItemDTO>
            {
                new OrderItemDTO { ProductId = 1, Quantity = 2 },
                new OrderItemDTO { ProductId = 2, Quantity = 3 }
            }
        };

        using var db = new AppDbContext();

        var order = new Order
        {
            CustomerId = orderDTO.CustomerId
        };

        foreach (var item in orderDTO.Items)
        {
            order.OrderItems.Add(new OrderItem
            {
                ProductId = item.ProductId,
                Quantity = item.Quantity
            });
        }

        db.Orders.Add(order);

        // Single SaveChanges inserts both Order and OrderItems
        db.SaveChanges();

        // Output OrderId
        Console.WriteLine(order.Id);
    }
}