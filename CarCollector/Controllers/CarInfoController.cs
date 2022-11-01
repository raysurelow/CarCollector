using CarCollector.Models;
using CarCollectorV2;
using Microsoft.AspNetCore.Mvc;
using static System.Net.WebRequestMethods;

namespace CarCollector.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarInfoController : ControllerBase
    {
        private static readonly Car[] carInfo = new[]
        {
            new Car{
                Make = "Toyota",
                Model = "Corolla",
                Year = 2022,
                Image = "https://carcollectorstorage.blob.core.windows.net/file-container/Toyota-Corolla.png"
            },
            new Car{
                Make = "Toyota",
                Model = "Avalon",
                Year = 2022,
                Image = "https://carcollectorstorage.blob.core.windows.net/file-container/Toyota-Avalon.png"
            },
            new Car{
                Make = "Toyota",
                Model = "Prius",
                Year = 2022,
                Image = "https://carcollectorstorage.blob.core.windows.net/file-container/Toyota-Prius.png"
            },
            new Car{
                Make = "Honda",
                Model = "Civic",
                Year = 2022,
                Image = "https://carcollectorstorage.blob.core.windows.net/file-container/Honda-Civic.png"
            },
            new Car{
                Make = "Honda",
                Model = "Accord",
                Year = 2022,
                Image = "https://carcollectorstorage.blob.core.windows.net/file-container/Honda-Accord.png"
            },
            new Car{
                Make = "Honda",
                Model = "CR-V",
                Year = 2022,
                Image = "https://carcollectorstorage.blob.core.windows.net/file-container/Honda-CR-V.png"
            },
            new Car{
                Make = "Porsche",
                Model = "911",
                Year = 2022,
                Image = "https://carcollectorstorage.blob.core.windows.net/file-container/porsche-911.jpg"
            },
            new Car{
                Make = "Porsche",
                Model = "Taycan",
                Year = 2022,
                Image = "https://carcollectorstorage.blob.core.windows.net/file-container/porsche-taycan.jpg"
            },
            new Car{
                Make = "Subaru",
                Model = "Crosstrek",
                Year = 2022,
                Image = "https://carcollectorstorage.blob.core.windows.net/file-container/Subaru-Crosstrek.png"
            },
            new Car{
                Make = "Subaru",
                Model = "Forester",
                Year = 2022,
                Image = "https://carcollectorstorage.blob.core.windows.net/file-container/Subaru-Forester.png"
            },
            new Car{
                Make = "Subaru",
                Model = "Outback",
                Year = 2022,
                Image = "https://carcollectorstorage.blob.core.windows.net/file-container/Subaru-Outback.png"
            },
            new Car{
                Make = "Jeep",
                Model = "Wrangler",
                Year = 2022,
                Image = "https://carcollectorstorage.blob.core.windows.net/file-container/Jeep-Wrangler.png"
            }
        };
        [HttpGet]
        public Car[] Get()
        {
            return carInfo;
        }
    }
}
