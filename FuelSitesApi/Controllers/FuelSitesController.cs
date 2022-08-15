global using FuelSitesApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FuelSitesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuelSitesController : ControllerBase
    {
        private readonly DataContext context;

        public FuelSitesController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<FuelSite>>> Get()
        {
            return Ok(await context.FuelSites.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FuelSite>> Get(int id)
        {   
            var site = await context.FuelSites.FindAsync(id);
            if (site == null)
                return BadRequest("Site not found");
            return Ok(site);
        }

        [HttpPost]
        public async Task<ActionResult<List<FuelSite>>> AddSite(FuelSite site)
        {
            context.FuelSites.Add(site);
            await context.SaveChangesAsync();
            return Ok(await context.FuelSites.ToListAsync());
        }
    }
}
