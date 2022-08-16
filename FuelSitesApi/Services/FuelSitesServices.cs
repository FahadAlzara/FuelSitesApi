namespace FuelSitesApi.Services
{
    public class FuelSitesServices
    {
        private readonly DataContext _context;
        public FuelSitesServices(DataContext context)
        {
            _context = context;
        }
        public List<FuelSite> Get()
        {
            return _context.FuelSites.ToList();
        }

        public FuelSite GetById(int Id)
        {
            return _context.FuelSites.Find(Id);
        }

        public void Add(FuelSite site)
        {
            _context.FuelSites.Add(site);
            _context.SaveChanges();
            _context.FuelSites.ToList();
            return;
        }
    }
}
