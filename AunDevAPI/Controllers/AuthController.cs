using AunDevAPI.Entities;
using AunDevAPI.Entities.Form;
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
    public class AuthController : ControllerBase
    {
        private readonly TokenManager _tokenManager;
        private readonly IClientBLLRepo _clientBLLRepo;
        private readonly IDevBLLRepo _devBLLRepo;
        public AuthController(TokenManager tokenManager, IClientBLLRepo clientBLLRepo,IDevBLLRepo devBLLRepo)
        {
            _tokenManager = tokenManager;
            _clientBLLRepo = clientBLLRepo;
            _devBLLRepo = devBLLRepo;
        }

        [HttpPost("LoginClient")]
        public IActionResult LoginClient(LoginForm form)
        {
            ClientBLL currentUser = _clientBLLRepo.Login(form.Email, form.Passwd);
            if (currentUser is null)
            {
                return BadRequest();
            }

            ClientWithToken client = new ClientWithToken
            {
                ClientId = currentUser.Id,
                Firstname = currentUser.Firstname,
                Lastname = currentUser.Lastname,
                Company = currentUser.Company,
                Email = currentUser.Email,
                Phone = currentUser.Phone,
                Token = _tokenManager.GenerateJWT(currentUser)
            };

            return Ok(client);
        }

        [HttpPost("LoginDev")]
        public IActionResult LoginDev(LoginForm form)
        {
            DevBLL currentDev = _devBLLRepo.login(form.Email, form.Passwd);

            if (currentDev is null)
            {
                return BadRequest();
            }

            DevWithToken dev = new DevWithToken()
            {
                DevId = currentDev.Id,
                Firstname = currentDev.Firstname,
                Lastname = currentDev.Lastname,
                BirthDate = currentDev.BirthDate,
                Email = currentDev.Email,
                Phone = currentDev.Phone,
                Token = _tokenManager.GenerateJWT(currentDev)
            };
            return Ok(dev);
        }
    }
}
