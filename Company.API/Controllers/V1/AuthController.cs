using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using AutoMapper;

namespace Company.API.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AuthController : ControllerBase
    {
        readonly IMapper mapper;
        readonly IAuthService authService;

        public AuthController(IMapper mapper, IAuthService authService) => (this.mapper, this.authService) = (mapper, authService);

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UserRegisterRequest userRegisterRequest)
        {
            AuthResult authResult = await authService.Register(userRegisterRequest);
            if (!authResult.Success)
                return BadRequest(mapper.Map<AuthFailedResponse>(authResult));
            return Ok(mapper.Map<AuthSuccessResponse>(authResult));
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest userLoginRequest)
        {
            AuthResult authResult = await authService.Login(userLoginRequest);
            if (!authResult.Success)
                return BadRequest(mapper.Map<AuthFailedResponse>(authResult));
            return Ok(mapper.Map<AuthSuccessResponse>(authResult));
        }
    }
}
