using DB.Data;
using DB.Models;
using Microsoft.AspNetCore.Mvc;

namespace Factu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        public ClientController(ILogger<ClientController> logger, FactuContext context)
        {
            _logger = logger;
            _context = context;
        }

        private readonly ILogger<ClientController> _logger;
        private readonly FactuContext _context;

        [HttpGet]
        [Route("GetClients")]
        public IActionResult GetClients()
        {
            var ret = _context.Clientes.ToList();

            return StatusCode(StatusCodes.Status200OK, ret);
        }

        [HttpPost]
        [Route("SaveClient")]
        public IActionResult SaveClient(Cliente client)
        {
            var clientDb = _context.Clientes.Where(x => x.Id == client.Id).FirstOrDefault();

            if (clientDb == null)
            {
                _context.Clientes.Add(client);
            }
            else
            {
                clientDb.Direccion = client.Direccion;
                clientDb.Name = client.Name;
                clientDb.IdFiscal = client.IdFiscal;
            }

            _context.SaveChanges();

            return StatusCode(StatusCodes.Status200OK, clientDb);
        }

    }
}
