﻿using IoTdotnet.Dtos;
using IoTdotnet.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text;

namespace IoTdotnet.Controllers
{
    [Route("")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IotUserService _userService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IotUserService service, ILogger<AuthController> logger)
        {
            _userService = service;
            _logger = logger;
        }

        
        [HttpPost("register")]
        public async Task<IActionResult> Register(IotUserRegisterDto registerDto)
        {

            var exist_user = await _userService.GetUserVMByUserName(registerDto.UserName);
            if (exist_user is not null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { Status = "Error", Message = "User creation failed. There is a user with the same name" });
            }
            var newuser = await _userService.CreateUserAsync(registerDto);
            if (newuser == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                new { Status = "Error", Message = "User creation failed." });
            }
            return Ok(new { Status = "OK", Message = "User has been created!" });

            //var existingUser = await _userManager.FindByNameAsync(registerDto.UserName);
            //if (existingUser != null)
            //{

            //}

            //var newUser = new ApplicationUser
            //{
            //    Email = registerDto.Email,
            //    UserName = registerDto.UserName,
            //    SecurityStamp = Guid.NewGuid().ToString(),
            //};
            //var result = await _userManager.CreateAsync(newUser, registerDto.Password);
            //if (!result.Succeeded)
            //{
            //    return StatusCode(StatusCodes.Status500InternalServerError,
            //        new { Status = "Error", Message = "Error during user creation." });
            //}

        }

        [HttpPost("DeleteAccount/{id}")]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            if(await _userService.RemoveUserAsync(id))
            {
                return Ok(new { Status = "OK", Message = "Account has been deleted!" });
            }
            return StatusCode(StatusCodes.Status404NotFound);
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var user = await _userService.GetUserByUserName(loginDto.UserName);
            if (user != null && user.Password.Equals(loginDto.Password) )
            //if (user != null && await _userService.CheckPasswordAsync(user, loginDto.Password))
            {
                //var authClaims = new List<Claim>
                //{
                //    new Claim(ClaimTypes.Name, user.UserName),
                //    new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                //};

                //var userRoles = await _userManager.GetRolesAsync(user);
                //foreach (var role in userRoles)
                //{
                //    authClaims.Add(new Claim(ClaimTypes.Role, role));
                //}

                //var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
                //var token = new JwtSecurityToken(
                //    issuer: _configuration["JWT:ValidIssuer"],
                //    audience: _configuration["JWT:ValidAudience"],
                //    expires: DateTime.Now.AddHours(3),
                //    claims: authClaims,
                //    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256));

                //return Ok(new LoginViewModel
                //{
                //    Token = new JwtSecurityTokenHandler().WriteToken(token),
                //    Expires = token.ValidTo
                //});
                return Ok();
            }

            return Unauthorized();
        }











    }
}
