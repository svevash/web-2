using System.Linq;
using ToyShop.Models;

namespace ToyShop
{
    public class SampleData
    {
        public static void Initialize(ShopContext context)
        {
            if (!context.Toys.Any())
            {
                context.Toys.AddRange(
                    new Toy()
                    {
                        Name = "Cat",
                        Type = "Soft toy",
                        Price = 100
                    },
                    new Toy()
                    {
                        Name = "Dog",
                        Type = "Soft toy",
                        Price = 200
                    },
                    new Toy()
                    {
                        Name = "Barbie",
                        Type = "Doll",
                        Price = 300
                    }
                );
                context.SaveChanges();
            }
            if (!context.Types.Any())
            {
                context.Types.AddRange(
                    new ToyType()
                    {
                        Name = "Soft toy",
                    },
                    new ToyType()
                    {
                        Name = "Doll",
                    },
                    new ToyType()
                    {
                        Name = "Car",
                    }
                );
                context.SaveChanges();
            }
        }
    }
}