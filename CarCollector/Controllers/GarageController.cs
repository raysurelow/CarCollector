using CarCollector.DataAccessors.Interfaces;
using CarCollector.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace CarCollector.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GarageController : ControllerBase
    {
        private readonly IGarageDataAccessor _garageDataAccessor;

        public GarageController(IGarageDataAccessor garageDataAccessor)
        {
            _garageDataAccessor = garageDataAccessor;
        }
        [HttpGet]
        public IEnumerable<Garage> Get()
        {
            return GetGarages();
        }

        private IEnumerable<Garage> GetGarages()
        {
            return _garageDataAccessor.GetGarages();
        }
    }
}
