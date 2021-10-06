using AunDevAPI.Entities.Form;
using AunDevAPI.Mapper;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AunDevAPI.Controllers
{
    [Authorize("DevRequired")]
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private ISkillBLLRepo _skillBLLRepo;

        public SkillController(ISkillBLLRepo skillBLLRepo)
        {
            _skillBLLRepo = skillBLLRepo;
        }

        [HttpPost("AjouterSkill")]
        public IActionResult AJouterSkill(SkillForm form)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _skillBLLRepo.AjouterSkill(form.ToBLL());
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _skillBLLRepo.Delete(id);
            return Ok();
        }

        [AllowAnonymous]
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_skillBLLRepo.GetAll());
        }
    }
}
