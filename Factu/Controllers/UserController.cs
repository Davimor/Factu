using Azure.Core;
using DB.Data;
using DB.Models;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Numerics;

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
        [Route("Login")]
        public async Task<IActionResult> Login(string access_token)
        {
            var res = await GetUserInfo(access_token);

            User loggedUser = null;
            if (res != null)
            {
                loggedUser = new User() { Fullname = res["name"].ToString(), Email = res["email"].ToString(), Name = res["given_name"].ToString(), Apellido = res["family_name"].ToString() };
            }

            if (loggedUser != null)
            {
                var dbUser = _context.Users.Where(x => x.Email == loggedUser.Email).FirstOrDefault();
                if (dbUser == null)
                {
                    _context.Users.Add(loggedUser);
                    _logger.LogInformation($"Nuevo usuario: {loggedUser.Email}");
                    dbUser = _context.Users.Where(x => x.Email == loggedUser.Email).FirstOrDefault();
                }

                dbUser.Loggins.Add(new Loggins { DateAccess=DateTime.Now});
                _logger.LogTrace($"Nuevo login: {loggedUser.Email}");
                _context.SaveChanges();
                
                return StatusCode(StatusCodes.Status200OK, loggedUser);
            }

            return StatusCode(StatusCodes.Status500InternalServerError, "Error login");
        }


        public async Task<JObject> GetUserInfo(string access_token)
        {

            var request = new HttpRequestMessage(HttpMethod.Get, "https://www.googleapis.com/oauth2/v3/userinfo");
            var client = new HttpClient();//_clientFactory.CreateClient();
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", access_token);
            HttpResponseMessage response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
            string ret = "";
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                ret = await response.Content.ReadAsStringAsync();
                //players = JsonConvert.DeserializeObject<List<Player>>(apiString);
            }
            return JObject.Parse(ret);
        }

    }
}
