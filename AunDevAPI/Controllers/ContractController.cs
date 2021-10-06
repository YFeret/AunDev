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
    [Authorize("isClientConnected")]
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        private readonly IContractBLLRepo _contractBLLRepo;

        public ContractController(IContractBLLRepo contractBLLRepo)
        {
            _contractBLLRepo = contractBLLRepo;
        }

        [HttpPost("AjouterContrat")]
        public IActionResult AddContract(AddContractForm form)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            
            return Ok();
        }
    }
}
