using Microsoft.AspNetCore.Mvc;
using Sat.Recruitment.Transversal.Common;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

using Sat.Recruitment.Transversal.Common;
using Sat.Recruitment.Application.Interface;
using Sat.Recruitment.Application.DTO;

namespace Sat.Recruitment.Api.Controllers
{

    [ApiController]
     [Route("[controller]")]
    public class UsersController : ControllerBase
    {

        //private readonly List<User> _users = new List<User>();
        private readonly IUserApplication _userApplication;

        public UsersController(IUserApplication userApplication)
        {
            _userApplication = userApplication;
        }

        [HttpPost]
        [Route("/create-user")]
        public async Task<IActionResult> CreateUser([FromBody] UserDTO user)
        {
            Result<bool> response = await _userApplication.InsertAsync(user);

            if (!response.Data)
                return BadRequest(response);
            return Ok(response);

        
        }

       
    }
   
}
