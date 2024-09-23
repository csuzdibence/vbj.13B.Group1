using System;
using System.Collections.Generic;
using System.Threading;
using VBJ._13B.Group1.Console;

public class Program 
{
    private static string[] names = new string[] 
    {
        "Peti", "Zsombor", "Balázs", "Réka"
    };

    private static Random rnd = new Random();

    /// <summary>
    /// Konzol applikáció bemenete -> User ezzel interaktál
    /// </summary>
    public static void Main()
    {
        // Felvesszük a futárokat
        List<Courier> couriers = new List<Courier>();

        for (int i = 0; i < 5; i++)
        {
            int randomNameIndex = rnd.Next(0, names.Length);
            var courier = new Courier(names[randomNameIndex]);
            courier.MaxPackageCount = rnd.Next(4, 8);
            couriers.Add(courier);
        }


        // Szimuláció
        DateTime today = DateTime.Now;
        today = StartSimulationForAYear(today, couriers);
    }

    // Method extraction -> metódus kiemelés, metódus név kijelölés majd Alt+Enter
    // Újrafelhasználható legyen a funkció
    private static DateTime StartSimulationForAYear(DateTime today, List<Courier> couriers)
    {
        // i változó, adott napot
        for (int i = 0; i < 365; i++)
        {
            // String interpoláció -> $ jel + kapcsos zárójelben az érték
            Console.WriteLine($"{i + 1}. nap kezdete");
            // j változó, adott csomagot jelöl

            // előkészítés
            var packages = PreparePackages();

            // futárok kiviszik a csomagokat
            DeliverPackages(couriers, packages);

            // Kitöröljük a csomagjait a futároknak
            ClearAllPackages(couriers);

            today = today.AddDays(1);
            // két másodpercenként telik el egy nap
            Thread.Sleep(2000);
            Console.WriteLine($"{i + 1}. nap vége");
        }

        return today;
    }

    private static void ClearAllPackages(List<Courier> couriers)
    {
        foreach (var courier in couriers)
        {
            courier.ClearPackages();
        }
    }

    private static void DeliverPackages(List<Courier> couriers, List<Package> packages)
    {
        foreach (var package in packages)
        {
            foreach (var courier in couriers)
            {
                if (!courier.PickUpPackage(package))
                {
                    continue;
                }
                Console.WriteLine($"\t\t{package.ID} csomag ki lett szállítva {courier.Name} által.");
                break;
            }
            Thread.Sleep(200);
        }
    }

    private static List<Package> PreparePackages()
    {
        int packageSum = rnd.Next(24, 32);
        List<Package> allPackages = new List<Package>();
        for (int j = 0; j < packageSum; j++)
        {
            var package = new Package();
            allPackages.Add(package);
            Console.WriteLine($"\t{package.ID}. csomag előkészítve");
            Thread.Sleep(50);
        }
        return allPackages;
    }
}