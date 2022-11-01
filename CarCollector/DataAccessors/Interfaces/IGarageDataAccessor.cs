using CarCollector.Models;

namespace CarCollector.DataAccessors.Interfaces
{
    public interface IGarageDataAccessor
    {
        public List<Garage> GetGarages();
    }
}
