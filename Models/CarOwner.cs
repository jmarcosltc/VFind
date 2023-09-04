using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarLoc.Models; 

[Table("carowners")]
public class CarOwner : Person {
    
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }

    public ICollection<Car> Cars { get; set; } = new List<Car>();
}