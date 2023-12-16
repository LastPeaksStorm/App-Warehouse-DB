using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Contexts;
using System.Text;

namespace Sklad
{
    public class Program
    {
        static void Main(string[] args)
        {
            AddNewProvider("Black Jack");
            AddNewCustomer("Don Eduardo");
            AddNewProduct("tomato", (decimal)10, 1, 140);
            //AddNewOrder((decimal)50, 5, 1, 1);
            //AddNewWarePurchase("potato", 2, (decimal)10.5, 1, 1);

            Console.WriteLine($"Total Sold: ${GetTheSold()}");
            Console.WriteLine($"Total Spent: ${GetTheSpent()}");

            Console.WriteLine("\nWare Purchases History:");

            DisplayTheWarePurchasesOnConsole();


            Console.WriteLine("\nOrders History:");

            DisplayTheOrdersOnConsole();

            Console.ReadKey();
        }

        public static void AddNewProduct(string name, decimal price, int providerId, int pcs = 0)
        {
            using (var context = new WarehouseContext())
            {
                var productThereAlready = context.Products.FirstOrDefault(p => p.Name.Equals(name));
                if (productThereAlready == null)
                {
                    context.Products.Add(new Product { Name = name, Price = price, PiecesLeft = pcs, ProviderId = providerId });
                }
                context.SaveChanges();
            }
        }
        public static void AddNewProvider(string name)
        {
            using (var context = new WarehouseContext())
            {
                var providerThereAlready = context.Providers.FirstOrDefault(p => p.Name.Equals(name));
                if (providerThereAlready == null)
                {
                    context.Providers.Add(new Provider { Name = name });
                }
                context.SaveChanges();
            }
        }
        public static void AddNewOrder(decimal totalPrice, int quantity, int customerId, int productId)
        {
            using (var context = new WarehouseContext())
            {
                var product = context.Products.Find(productId);
                if (quantity > 0 && product != null && product.PiecesLeft > quantity)
                {
                    context.Orders.Add(new Order { Quantity = quantity, TotalPrice = totalPrice, CustomerId = customerId, ProductId = productId });
                    context.SaveChanges();
                }
            }
        }
        public static void AddNewCustomer(string name)
        {
            using (var context = new WarehouseContext())
            {
                var customerThereAlready = context.Customers.FirstOrDefault(p => p.Name.Equals(name));
                if (customerThereAlready == null)
                {
                    context.Customers.Add(new Customer { Name = name });
                }
                context.SaveChanges();
            }
        }
        public static void AddNewWarePurchase(string productName, int quantity, decimal totalPrice, int providerId, int productId)
        {
            using (var context = new WarehouseContext())
            {
                var product = context.Products.Find(productId);
                if (quantity > 0 && product == null)
                {
                    AddNewProduct(productName, totalPrice / quantity, quantity, providerId);
                }
                context.WarePurchases.Add(new WarePurchase { Quantity = quantity, TotalPrice = totalPrice, ProviderId = providerId, ProductId = productId });

                context.SaveChanges();
            }
        }

        public static decimal GetTheSold()
        {
            using (var context = new WarehouseContext())
            {
                return context.Orders.Sum(o => o.TotalPrice);
            }
        }

        public static decimal GetTheSpent()
        {
            using (var context = new WarehouseContext())
            {
                return context.WarePurchases.Sum(o => o.TotalPrice);
            }
        }


        public static void DisplayTheOrdersOnConsole()
        {
            using (var context = new WarehouseContext())
            {
                var table = new ConsoleTable("ID", "Quantity", "Total price", "Customer ID", "Product ID");
                foreach (var order in context.Orders.ToList())
                {
                    table.AddRow(order.Id, $"{order.Quantity}pcs", $"${order.TotalPrice}", order.CustomerId, order.ProductId);
                }
                table
                    .Configure(o => o.NumberAlignment = Alignment.Right)
                    .Write(Format.Alternative);
            }
        }
        public static void DisplayTheWarePurchasesOnConsole()
        {
            using (var context = new WarehouseContext())
            {
                var table = new ConsoleTable("ID", "Quantity", "Total price", "Provider ID", "Product ID");
                foreach (var warePurchase in context.WarePurchases.ToList())
                {
                    table.AddRow(warePurchase.Id, $"{warePurchase.Quantity}pcs", $"${warePurchase.TotalPrice}", warePurchase.ProviderId, warePurchase.ProductId);
                }
                table
                .Configure(o => o.NumberAlignment = Alignment.Right)
                .Write(Format.Alternative);
            }
        }
    }
}
