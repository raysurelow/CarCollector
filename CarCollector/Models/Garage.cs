namespace CarCollector.Models
{
    public class Garage
    {
        public int GarageId { get; set; }
        public string? Name { get; set; }
        public string? StreetAddr { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public int? ZipCode { get; set; }
        public IEnumerable<Car>? Cars { get; set; }
    }
}
