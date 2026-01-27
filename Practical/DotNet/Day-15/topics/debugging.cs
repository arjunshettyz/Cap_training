using System;
using System.Collections.Generic;

namespace CollectionDemo
{
    // User class
    class User
    {
        public string? Name { get; set; }
        public int Age { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // LIST EXAMPLE
            List<User> users = new List<User>();

            users.Add(new User { Name = "Aryan", Age = 22 });
            users.Add(new User { Name = "Mohit", Age = 32 });
            users.Add(new User { Name = "Sushant", Age = 68 });
            users.Add(new User { Name = "Ritik", Age = 63 });
            users.Add(new User { Name = "Sahil", Age = 52 });

            Console.WriteLine("Users List:");
            foreach (var user in users)
            {
                Console.WriteLine($"User Name: {user.Name}, User Age: {user.Age}");
            }

            Console.WriteLine();

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(45);
            queue.Enqueue(55);
            queue.Enqueue(65);
            queue.Enqueue(75);
            queue.Enqueue(25);

            Console.WriteLine("Queue Elements:");
            while (queue.Count > 0)
            {
                Console.Write(queue.Dequeue() + " ");
            }

            Console.WriteLine();
        }
    }
}
