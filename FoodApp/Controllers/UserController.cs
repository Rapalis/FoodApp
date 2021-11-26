using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FoodApp.Constants;
using FoodApp.Models;
using FoodApp.Models.DataTransferObjects;
using FoodApp.Models.DataTransferObjects.Responses;
using FoodApp.Services;
using FoodApp.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FoodApp.Controllers
{
    [Route(RouteConsts.BASE_URL)]
    [ApiController]
    public class UserController : Controller
    {
        public readonly IUserService _userManager;
        public readonly IMapper _mapper;
        public readonly IAuthService _authService;
        public UserController(IUserService userManager, IMapper mapper, IAuthService authService)
        {
            _authService = authService;
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult> Register(RegisterUserDTO registerUserDTO)
        {
            var user = await _userManager.FindByNameAsync(registerUserDTO.UserName);
            if(user != null)
                return BadRequest("Invalid request");
            var newUser = new User
            {
                Email = registerUserDTO.Email,
                UserName = registerUserDTO.UserName,
                Role = "SimpleUser"
            };

            var createUserResult = await _userManager.CreateAsync(newUser, registerUserDTO.Password);

            if (createUserResult == null)
                return BadRequest("Could not create user");

            // await _userManager.AddToRoleAsync(newUser, "SimpleUser");
            return CreatedAtAction(nameof(Register), _mapper.Map<UserDTO>(createUserResult));
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<SuccessfulLoginResponseDTO>> Login(LoginUserDTO loginUserDTO)
        {
            var user = await _userManager.FindByNameAsync(loginUserDTO.UserName);
            if (user == null)
                return BadRequest("User name or password is invalid");

            var isPasswrodValid = await _userManager.CheckPasswordAsync(user.Id, loginUserDTO.Password);
            if(!isPasswrodValid)
                return BadRequest("User name or password is invalid");

            var accessToken = await _authService.CreateAccessTokenAsync(user);

            return Ok(new SuccessfulLoginResponseDTO(accessToken));
        }

    }
}
