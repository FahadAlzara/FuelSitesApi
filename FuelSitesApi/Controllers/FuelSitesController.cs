global using FuelSitesApi.Models;
using FuelSitesApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FuelSitesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuelSitesController : ControllerBase
    {
        private readonly DataContext context;
        private readonly FuelSitesServices _services;

        public FuelSitesController(DataContext context
            , FuelSitesServices services)
        {
            this.context = context;
            _services = services;
        }

        [HttpGet]
        public ActionResult<List<FuelSite>> Get()
        {
            return Ok(_services.Get());
        }

        [HttpGet("{id}")]
        public ActionResult<FuelSite> GetById(int id)
        {
            var site = _services.GetById(id);
            if (site == null)
            {
                return BadRequest("Site not found");
            }
            return Ok(site);
        }

        [HttpPost]
        public ActionResult<List<FuelSite>> Add(FuelSite site)
        {
            _services.Add(site);
            return Ok();
        }
    }
}
