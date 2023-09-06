using CarLoc.Context;
using Microsoft.AspNetCore.SignalR;

namespace CarLoc.Hubs; 

public class FinderHub: Hub {
    public async Task SendLocation(string licensePlate)
    {
        // DHH3456
        

        while (true)
        {
            using var ctx = new CarContext();
            var carByLicensePlate = (from car in ctx.Cars
                        where car.licensePlate == licensePlate
                        select car).Single();
            await Clients.All.SendAsync("RecieveLocation", $"{carByLicensePlate.licensePlate}", $"{carByLicensePlate.lastLoc.latitude}", $"{carByLicensePlate.lastLoc.longitude}");
            Thread.Sleep(2000);
        }
    }
}