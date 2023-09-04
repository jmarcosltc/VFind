using CarLoc.Context;
using Microsoft.AspNetCore.SignalR;

namespace CarLoc.Hubs; 

public class FinderHub: Hub {
    public async Task SendLocation()
    {
        using var ctx = new CarContext();
        var allCars = ctx.Cars.ToList();

        foreach (var car in allCars)
        {
            Console.WriteLine(car);
            Console.WriteLine($"License Plate: {car.licensePlate}");
        }
    }
}