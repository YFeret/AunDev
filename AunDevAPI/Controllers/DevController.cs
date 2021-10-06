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
using System.Threading.Tasks;

namespace AunDevAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevController : ControllerBase
    {
        private readonly IDevBLLRepo _devBLLRepo;

        public DevController(IDevBLLRepo devBLLRepo)
        {
            _devBLLRepo = devBLLRepo;
        }

        [HttpPost("Register")]
        public IActionResult Register(RegisterDevForm form)
        {
            //si le model state pas valide on retourne une badrequest
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _devBLLRepo.Register(form.ToBLL());
            return Ok();
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_devBLLRepo.Get());
        }
    }
}
