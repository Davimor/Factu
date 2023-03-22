using DB.Data;
using DB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Factu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public UserController(ILogger<UserController> logger, FactuContext context)
        {
            _logger = logger;
            _context = context;
        }

        private readonly ILogger<UserController> _logger;
        private readonly FactuContext _context;

        [HttpGet]
        public User Login(string access_token)
        {
            return new User() { Id=1, Email="test@test.com", Name="Test Test"};
        }

    }
}
