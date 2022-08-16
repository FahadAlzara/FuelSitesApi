using AutoMapper;
using FuelSitesApi.DTOs.UserDTOs;

namespace FuelSitesApi.Services
{
    public class UserLoginServices
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UserLoginServices(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool Login(User user)
        {
            var ExistUser = _context.Users.FirstOrDefault(u => u.UserName == user.UserName
                && u.Password == user.Password && !u.Deleted);
            if(ExistUser == null)
            {
                return false;
            }
            return true;
        }

        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public bool Delete(int userId)
        {
            var user = _context.Users.FirstOrDefault(i => i.Id == userId);
            if(user is null)
            {
                return false;
            }
            user.Deleted = true;
            _context.Users.Update(user);
            _context.SaveChanges();
            return true;
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }
    }
}
