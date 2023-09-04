namespace CarLoc.Models; 

public abstract class Vehicle {
    public string licensePlate { get; set; }
    public string model { get; set; }
    public string make { get; set; }
    public int year { get; set; }
    
}