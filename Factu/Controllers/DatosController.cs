using DB.Data;
using DB.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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

        [HttpGet]
        [Route("GetDatos")]
        public IActionResult GetDatos()
        {
            var ret = _context.Entidades.FirstOrDefault();

            return StatusCode(StatusCodes.Status200OK, ret);
        }

        [HttpPost]
        [Route("SetDatos")]
        public IActionResult SetDatos(Entidad nueva)
        {
            var ret = _context.Entidades.FirstOrDefault();
            if (ret == null) {
                ret = new Entidad();
                _context.Entidades.Add(ret);
            }
            ret.Name = nueva.Name;
            ret.IdFiscal = nueva.IdFiscal;
            ret.Direccion = nueva.Direccion;
            ret.CCC = nueva.CCC;
            ret.EntidadBancaria = nueva.EntidadBancaria;

            _context.SaveChanges();

            return StatusCode(StatusCodes.Status200OK, ret);
        }

    }
}
