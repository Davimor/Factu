using DB.Data;
using Microsoft.AspNetCore.Mvc;

namespace Factu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatosController : ControllerBase
    {
        public DatosController(ILogger<DatosController> logger, FactuContext context)
        {
            _logger = logger;
            _context = context;
        }

        private readonly ILogger<DatosController> _logger;
        private readonly FactuContext _context;

        [HttpGet]
        [Route("GetEntidadesBancarias")]
        public IActionResult GetEntidadesBancarias()
        {
            var ret = _context.EntidadesBancarias.ToList();

            return StatusCode(StatusCodes.Status200OK, ret);
        }
    }
}
