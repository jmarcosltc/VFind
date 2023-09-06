using System.Data.Entity;
using CarLoc.Context;

namespace CarLoc.Utility; 

public class RandomLocGenerator {

    public static void GenerateLocations()
    {
        const double maxLat = 90;
        const double minLat = -90;

        const double maxLon = 180;
        const double minLon = -180;

        var random = new Random();

        using var ctx = new CarContext();
        var allCars = ctx.Cars.ToList();

        while (true)
        {
            foreach (var car in allCars)
            {
                // pseudo random eh mole
                var randomLat = Math.Round(random.NextDouble() * (maxLat - minLat) + minLat, 4);
                var randomLon = Math.Round(random.NextDouble() * (maxLon - minLon) + minLon, 4);

                car.lastLoc.latitude = randomLat;
                car.lastLoc.longitude = randomLon;

                ctx.SaveChanges();
                // Console.WriteLine($"Location changed: {randomLat}, {randomLon}");
            }
            Thread.Sleep(5000);
        }
        
    }
}