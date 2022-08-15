using System.ComponentModel.DataAnnotations;

namespace FuelSitesApi.Models
{
    public class FuelSite
    {
        [Key]
        public int SiteId { get; set; }
        public int PumpCount { get; set; }
        public int WorkersCount { get; set; }   
        public int OperationTime { get; set; }
        public int TankCapacity { get; set; }
        public string? City { get; set; }  
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}
