using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FuelSitesApi.Models;
using FuelSitesApi.Services;
using AutoMapper;
using FuelSitesApi.DTOs.UserDTOs;

namespace FuelSitesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {
        private readonly DataContext context;
        private readonly UserLoginServices _services;
        private readonly IMapper _mapper;

        public UserLoginController(DataContext context
            , UserLoginServices services, IMapper mapper)
        {
            this.context = context;
            _services = services;
            _mapper = mapper;
        }


        [HttpPost]
        public ActionResult Login(User user)
        {
            if (!(_services.Login(user)))
            {
                return BadRequest("not found");
            }
            return Ok("user found");

        }

        [HttpPost("NewUser")]
        public ActionResult Add(UserLoginDTO user)
        {
            var userMapped = _mapper.Map<User>(user);
            _services.Add(userMapped);
            return Ok();
        }

        [HttpDelete]
        public ActionResult Delete(int userId)
        {
            _services.Delete(userId);
            return Ok();
        }

        [HttpPatch]
        public ActionResult Update(User user)
        {
            _services.Update(user);
            return Ok();
        }
    }
}
