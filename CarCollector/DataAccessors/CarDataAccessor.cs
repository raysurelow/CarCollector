using Azure.Core;
using CarCollector.DataAccessors.Interfaces;
using CarCollector.Models;
using System.Data.SqlClient;

namespace CarCollector.DataAccessors
{
    public class CarDataAccessor: ICarDataAccessor
    {
        private readonly IConfiguration _configuration;

        public CarDataAccessor(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public int CreateCar(Car car, int? garageId = null)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("CarCollectorDatabase"));
            connection.Open();
            var carSql = "INSERT INTO CAR (MAKE, MODEL, YEAR, DESCRIPTION, IMAGE) output INSERTED.CARID VALUES (@Make, @Model, @Year, @Description, @Image)";
            using SqlCommand carCommand = new SqlCommand(carSql, connection);
            carCommand.Parameters.AddWithValue("@Make", car.Make ?? string.Empty);
            carCommand.Parameters.AddWithValue("@Model", car.Model ?? string.Empty);
            carCommand.Parameters.AddWithValue("@Year", car.Year ?? 0);
            carCommand.Parameters.AddWithValue("@Description", car.Description ?? string.Empty);
            carCommand.Parameters.AddWithValue("@Image", car.Image ?? string.Empty);
            int newCarId = (int)carCommand.ExecuteScalar();
            if (garageId != null && garageId > 0)
            {
                var garageMapSql = "INSERT INTO GARAGEMAP (GARAGEID, CARID) values (@GarageId,@CarId)";
                using SqlCommand garageMapCommand = new SqlCommand(garageMapSql, connection);
                garageMapCommand.Parameters.AddWithValue("@GarageId", garageId);
                garageMapCommand.Parameters.AddWithValue("@CarId", newCarId);
                garageMapCommand.ExecuteNonQuery();
            }

            return newCarId;
        }
    }
}
