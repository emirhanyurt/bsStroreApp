﻿using entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/authentication")]
    [ApiExplorerSettings(GroupName ="v1")]
    public class AuthemticationController:ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public AuthemticationController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]

        public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistrationDto)
        {
            
            var result = await _serviceManager.AuthenticationService.RegisterUser(userForRegistrationDto);

            if(!result.Succeeded)
            {
                foreach(var item in result.Errors)
                {
                    ModelState.TryAddModelError(item.Code, item.Description);
                }
                return BadRequest(ModelState);
            }
            

            return StatusCode(201);
        }
        [HttpPost("login")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]

        public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto userForAuthentication)
        {
            if (!await _serviceManager.AuthenticationService.ValidateUser(userForAuthentication))
            return Unauthorized();

            var tokenDto = await _serviceManager.AuthenticationService.CreateToken(populateExp: true);

            return Ok(tokenDto);
        }
        [HttpPost("refresh")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Refresh([FromBody] TokenDto tokenDto)
        {
            var tokenDtoToReturn = await _serviceManager
                .AuthenticationService
                .RefreshToken(tokenDto);
            return Ok(tokenDtoToReturn);
        }
    }

}
