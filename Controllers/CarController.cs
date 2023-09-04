using CarLoc.Context;
using CarLoc.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarLoc.Controllers {
    
    [Route("api/car")]
    [ApiController]
    public class CarController : Controller {

        [HttpPost]
        public IActionResult Create([FromBody] Car car)
        {
            
            // Mudar escopo?
            using var ctx = new CarContext();
            
            ctx.Cars.Add(car);
            ctx.SaveChanges();

            return Ok();
        }

        [HttpGet]
        public IActionResult GetCars()
        {
            using var context = new CarContext();
            var cars = context.Cars.ToList();

            return Ok(cars);
        }
        

    }
}
