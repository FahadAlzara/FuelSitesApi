using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FuelSitesApi.Models;

namespace FuelSitesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuelSitesController : ControllerBase
    {

        private static List<FuelSite> sites = new List<FuelSite>
        {
            new FuelSite
                {
                    SiteId = 2,
                    PumpCount = 6,
                    WorkersCount = 3,
                    OperationTime = 24,
                    TankCapacity = 750,
                    City = "Sharjah",
                    Longitude = 25.311141688403644,
                    Latitude = 55.37848989763386
                },
              new FuelSite
                {
                    SiteId = 1,
                    PumpCount = 4,
                    WorkersCount = 2,
                    OperationTime = 24,
                    TankCapacity = 500,
                    City = "Dubai",
                    Longitude = 25.232196370558018,
                    Latitude = 55.31142272237029
                },

        };


        [HttpGet]
        public ActionResult<List<FuelSite>> Get()
        {
            return Ok(sites);
        }

        [HttpGet("{id}")]
        public ActionResult<FuelSite> Get(int id)
        {   
            var site = sites.Where(a => a.SiteId == id);
            if (site == null)
                return BadRequest("Site not found");
            return Ok(site);
        }

        [HttpPost]
        public ActionResult<List<FuelSite>> AddSite(FuelSite site)
        {
            sites.Add(site);
            return Ok(sites);
        }
    }
}
