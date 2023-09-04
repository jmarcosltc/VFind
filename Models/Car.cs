using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarLoc.Models; 

[Table("cars")]
public class Car : Vehicle {
    
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int carId { get; set; }
    
    public Location lastLoc { get; set; }
    
    public CarOwner CarOwner { get; set; }
    
}