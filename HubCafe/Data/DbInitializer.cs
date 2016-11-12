using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Hubcafe.Data;

namespace HubCafe.Models
{
    public static class DbInitializer
    {
        public static void Initialize(RestaurantContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Pizzas.Any())
            {
                return;   // DB has been seeded
            }

            var pizzas = new Pizza[]
            {
            new Pizza{Name="Carson",Size=16,ingredients="onions,muchroom",OrderDate=DateTime.Parse("2005-09-01")},
            new Pizza{Name="heros",Size=16,ingredients="onions,muchroom",OrderDate=DateTime.Parse("2005-09-01")},
            new Pizza{Name="Carson",Size=16,ingredients="onions,muchroom",OrderDate=DateTime.Parse("2005-09-01")},
            new Pizza{Name="Carson",Size=16,ingredients="onions,muchroom",OrderDate=DateTime.Parse("2005-09-01")},
            new Pizza{Name="Carson",Size=16,ingredients="onions,muchroom",OrderDate=DateTime.Parse("2005-09-01")},

            };
            foreach (Pizza s in pizzas)
            {
                context.Pizzas.Add(s);
            }
            context.SaveChanges();
            var salads = new Salad[]
           {
            new Salad{Name="Carson",Size=16,ingredients="onions,muchroom",OrderDate=DateTime.Parse("2005-09-01")},
            new Salad{Name="heros",Size=16,ingredients="onions,muchroom",OrderDate=DateTime.Parse("2005-09-01")},
            new Salad{Name="Carson",Size=16,ingredients="onions,muchroom",OrderDate=DateTime.Parse("2005-09-01")},
            new Salad{Name="Carson",Size=16,ingredients="onions,muchroom",OrderDate=DateTime.Parse("2005-09-01")},
            new Salad{Name="Carson",Size=16,ingredients="onions,muchroom",OrderDate=DateTime.Parse("2005-09-01")},

           };
            foreach (Salad s in salads)
            {
                context.Salads.Add(s);
            }
            context.SaveChanges();

            var pastas = new Pasta[]
             {
            new Pasta{Name="Carson",Size=16,ingredients="onions,muchroom",OrderDate=DateTime.Parse("2005-09-01")},
            new Pasta{Name="heros",Size=16,ingredients="onions,muchroom",OrderDate=DateTime.Parse("2005-09-01")},
            new Pasta{Name="Carson",Size=16,ingredients="onions,muchroom",OrderDate=DateTime.Parse("2005-09-01")},
            new Pasta{Name="Carson",Size=16,ingredients="onions,muchroom",OrderDate=DateTime.Parse("2005-09-01")},
            new Pasta{Name="Carson",Size=16,ingredients="onions,muchroom",OrderDate=DateTime.Parse("2005-09-01")},

             };
            foreach (Pasta s in pastas)
            {
                context.Pastas.Add(s);
            }
            context.SaveChanges();

            var orders = new Order[]
            {
            new Order{PizzaName="Carson",PastaName="Carson",SaladName="Carson"},
           

            };
            foreach (Order e in orders)
            {
                context.Orders.Add(e);
            }
            context.SaveChanges();
        }
    }
}