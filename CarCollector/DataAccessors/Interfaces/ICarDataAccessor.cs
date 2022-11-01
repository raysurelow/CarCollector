using CarCollector.Models;

namespace CarCollector.DataAccessors.Interfaces
{
    public interface ICarDataAccessor
    {
        public int CreateCar(Car car, int? garageId = null);
    }
}
