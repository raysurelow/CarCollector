using CarCollector.DataAccessors.Interfaces;
using CarCollector.Models;
using System.Data.SqlClient;

namespace CarCollector.DataAccessors
{
    public class GarageDataAccessor : IGarageDataAccessor
    {
        private readonly IConfiguration _configuration;

        public GarageDataAccessor(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public List<Garage> GetGarages()
        {
            var garages = new List<Garage>();
            using (var connection = new SqlConnection(_configuration.GetConnectionString("CarCollectorDatabase")))
            {
                var sql = "SELECT GARAGEID, NAME, STREETADDR, CITY, STATE, ZIPCODE FROM GARAGE";
                connection.Open();
                using SqlCommand command = new SqlCommand(sql, connection);
                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var garage = new Garage()
                    {
                        GarageId = (int)reader["GARAGEID"],
                        Name = reader["NAME"].ToString(),
                        StreetAddr = reader["STREETADDR"].ToString(),
                        City = reader["CITY"].ToString(),
                        State = reader["STATE"].ToString(),
                        ZipCode = (int)reader["ZIPCODE"],
                    };
                    garages.Add(garage);
                }
                reader.Close();
                foreach (Garage garage in garages)
                {
                    var cars = new List<Car>();
                    var carSql = "SELECT C.CARID, MAKE, MODEL, YEAR, DESCRIPTION, IMAGE FROM CAR AS C INNER JOIN GARAGEMAP ON C.CARID = GARAGEMAP.CARID WHERE GARAGEMAP.GARAGEID = @GARAGEID";
                    using SqlCommand carCommand = new SqlCommand(carSql, connection);
                    carCommand.Parameters.AddWithValue("@GARAGEID", garage.GarageId);
                    using SqlDataReader carCommandReader = carCommand.ExecuteReader();
                    while (carCommandReader.Read())
                    {
                        var car = new Car()
                        {
                            CarId = (int)carCommandReader["CARID"],
                            Make = carCommandReader["MAKE"].ToString(),
                            Model = carCommandReader["MODEL"].ToString(),
                            Year = (int)carCommandReader["YEAR"],
                            Description = carCommandReader["DESCRIPTION"].ToString(),
                            Image = carCommandReader["IMAGE"].ToString()
                        };
                        cars.Add(car);
                    }
                    garage.Cars = cars;
                }
            }
            return garages;
        }
    }
}
