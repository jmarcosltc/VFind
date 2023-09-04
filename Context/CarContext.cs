using System.Data.Entity;
using CarLoc.Models;

namespace CarLoc.Context; 

public class CarContext : DbContext {

    public CarContext() : base()
    {
        // temporario
        Database.SetInitializer<CarContext>(new DropCreateDatabaseIfModelChanges<CarContext>());
    }
    public DbSet<Car> Cars { get; set; }
    public DbSet<CarOwner> CarOwners { get; set; }
}