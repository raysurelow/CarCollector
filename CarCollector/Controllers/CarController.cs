using CarCollector.DataAccessors.Interfaces;
using CarCollector.Models;
using CarCollector.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Dynamic;

namespace CarCollector.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ICarDataAccessor _carDataAccessor;

        public CarController(ICarDataAccessor carDataAccessor)
        {
            _carDataAccessor = carDataAccessor;
        }

        [HttpPost]
        public IActionResult Post([FromBody] PostCarRequest request)
        {
            if (request.car == null)
            {
                return BadRequest();
            }
            var car = request.car;
            try
            {
                var newCarId = _carDataAccessor.CreateCar(car, request.garageId);
                return Ok(newCarId);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
