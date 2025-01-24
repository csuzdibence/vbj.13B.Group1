using Cars.Database;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        using var context = new ManufacturingContext();
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
        SeedData(context);
        RunQueries(context);
    }

    static void SeedData(ManufacturingContext context)
    {
        var factory1 = new Factory { Name = "Tesla" };
        var factory2 = new Factory { Name = "Ford" };

        var hq1 = new Headquarters { Address = "Palo Alto", Factory = factory1 };
        var hq2 = new Headquarters { Address = "Detroit", Factory = factory2 };

        var car1 = new Car { Model = "Model S", Factory = factory1 };
        var car2 = new Car { Model = "Model 3", Factory = factory1 };
        var car3 = new Car { Model = "F-150", Factory = factory2 };
        var car4 = new Car { Model = "Mustang", Factory = factory2 };

        var part1 = new Part { Name = "Battery" };
        var part2 = new Part { Name = "Tire" };
        var part3 = new Part { Name = "Engine" };
        var part4 = new Part { Name = "Transmission" };

        // N-N kapcsolat
        var carParts = new List<CarPart>
            {
                new CarPart { Car = car1, Part = part1 },
                new CarPart { Car = car1, Part = part2 },
                new CarPart { Car = car2, Part = part1 },
                new CarPart { Car = car2, Part = part2 },
                new CarPart { Car = car3, Part = part3 },
                new CarPart { Car = car3, Part = part4 },
                new CarPart { Car = car4, Part = part3 },
                new CarPart { Car = car4, Part = part4 },
            };

        context.AddRange(factory1, factory2);
        context.AddRange(hq1, hq2);
        context.AddRange(car1, car2, car3, car4);
        context.AddRange(part1, part2, part3, part4);
        context.AddRange(carParts);

        context.SaveChanges();
    }

    static void RunQueries(ManufacturingContext context)
    {
        // 1. feladat gyárak a főhadiszállásukkal
        var factories = context.Factories.Include(f => f.Headquarters).ToList();
        Console.WriteLine("\nFactories and their Headquarters:");
        foreach (var factory in factories)
        {
            Console.WriteLine($"- {factory.Name}, Headquarters: {factory.Headquarters.Address}");
        }

        // Query 2: Konkrét gyár neve alapján autók listázása
        Console.WriteLine("\nAutók a Tesla által gyártva:");
        var teslaCars = context.Cars.Where(c => c.Factory.Name == "Tesla").ToList();
        foreach (var car in teslaCars)
        {
            Console.WriteLine($"- {car.Model}");
        }

        // Query 3: Összes autó alkatrészt specifikus autó modell alapján
        Console.WriteLine("\nParts used by 'Model S':");
        var modelSParts = context.CarParts
            .Where(cp => cp.Car.Model == "Model S")
            .Include(cp => cp.Part)
            .ToList();
        foreach (var carPart in modelSParts)
        {
            Console.WriteLine($"- {carPart.Part.Name}");
        }

        // Query 4: Összes autó és részei
        var carsWithParts = context.Cars
            .Include(c => c.CarParts)
            .ThenInclude(cp => cp.Part)
            .ToList();
        Console.WriteLine("\nCars and their parts:");
        foreach (var car in carsWithParts)
        {
            Console.WriteLine($"- {car.Model}");
            foreach (var carPart in car.CarParts)
            {
                Console.WriteLine($"  - Part: {carPart.Part.Name}");
            }
        }
    }
}