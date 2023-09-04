using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarLoc.Models; 

[Table("cars")]
public class Car {
    
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int carId { get; set; }
    public string licensePlate { get; set; }
    public string model { get; set; }
    public string make { get; set; }
    public int year { get; set; }
    
    public Location lastLoc { get; set; }
    
    public CarOwner CarOwner { get; set; }
}