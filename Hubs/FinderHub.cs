using CarLoc.Context;
using Microsoft.AspNetCore.SignalR;

namespace CarLoc.Hubs; 

public class FinderHub: Hub {
    public async Task SendLocation()
    {
        
        using var ctx = new CarContext();
        var allCars = ctx.Cars.ToList();

        while (true)
        {
            foreach (var car in allCars)
            {
                Console.WriteLine($"License Plate: {car.licensePlate}\n" +
                                  $"- Latitude: {car.lastLoc.latitude}\n" +
                                  $"- Longitude: {car.lastLoc.longitude}");
                await Clients.All.SendAsync("RecieveLocation", $"{car.licensePlate}", $"{car.lastLoc.latitude}", $"{car.lastLoc.longitude}");
            }
            Thread.Sleep(2000);
        }
    }
}