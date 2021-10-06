using AunDevAPI.Entities;
using AunDevAPI.Entities.Form;
using AunDevAPI.Mapper;
using AunDevAPI.Tools;
using BLL.Entities;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AunDevAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private IClientBLLRepo _clientBLLRepo;

        public ClientController(IClientBLLRepo clientBLLRepo)
        {
            _clientBLLRepo = clientBLLRepo;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterClientForm form)
        {
            //si le model state pas valide on retourne une badrequest
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _clientBLLRepo.Register(form.ToBLL());
            return Ok();
        }
        
        private int GetConnectedClientId()
        {
            ClaimsPrincipal cp = HttpContext.User;
            string Id = cp.Claims.SingleOrDefault(c => c.Type == ClaimTypes.Sid).Value;

            return int.Parse(Id);
        }
    }
}
