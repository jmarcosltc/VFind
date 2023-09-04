using CarLoc.Context;
using CarLoc.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarLoc.Controllers; 

[Route("api/owner")]
[ApiController]
public class CarOwnerController: Controller {
    
    [HttpGet]
    public IActionResult GetOwners()
    {
        using var context = new CarContext();
        var owners = context.CarOwners.ToList();
            
        return Ok(owners);
    }
    
    [HttpPost]
    public IActionResult Create([FromBody] CarOwner owner)
    {
        
            
        using var ctx = new CarContext();
            
        ctx.CarOwners.Add(owner);
        ctx.SaveChanges();

        return Ok();
    }
}