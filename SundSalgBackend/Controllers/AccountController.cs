using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SundSalgBackend.Data;
using SundSalgBackend.Code;
using SundSalgBackend.Models;
using SundSalgBackend.Models.DataTransferObjects;
using Microsoft.AspNetCore.WebUtilities;
using AutoMapper;
using System.IdentityModel.Tokens.Jwt;
using NuGet.Protocol.Core.Types;
using SundSalgBackend.Contracts;

namespace SundSalgBackend.Controllers
{
    [Route("api/accounts")]
    [ApiController]
    public class AccountController : ControllerBase

    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;
        private readonly IdentityContext _context;
        private readonly JwtHandler _jwtHandler;
        private readonly IRepositoryManager _repository;
        public AccountController(
            SignInManager<User> signInManager,
            UserManager<User> userManager,
            IMapper mapper,
            IdentityContext context,
            JwtHandler jwtHandler,
            IRepositoryManager repository
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _context = context;
            _jwtHandler = jwtHandler;
            _repository = repository;
        }
        [HttpPost("Registration")]
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistration)
        {
            if (userForRegistration == null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            var user = _mapper.Map<User>(userForRegistration);
            var result = await _userManager.CreateAsync(user, userForRegistration.Password);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);

                return BadRequest(new RegistrationResponseDto { Errors = errors });
            }

            await _userManager.AddToRoleAsync(user, "Administrator");

            return StatusCode(201);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserForAuthenticationDto userForAuthentication)
        {
            var user = await _userManager.FindByNameAsync(userForAuthentication.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, userForAuthentication.Password))
            {
                return Unauthorized(new AuthResponseDto { ErrorMessage = "Invalid Authentication" });
            }

            var signingCredentials = _jwtHandler.GetSigningCredentials();
            var claims = await _jwtHandler.GetClaims(user);
            var tokenOptions = _jwtHandler.GenerateTokenOptions(signingCredentials, claims);
            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return Ok(new AuthResponseDto { IsAuthSuccessful = true, Token = token });
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<UserProfileDto>>>UserDetails(string id)
        {
            var user = await _userManager.FindByEmailAsync(id);
            if (user == null || !ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok(user);
        }
        [HttpPatch]

        [HttpGet("Logout")]
        public async Task<ActionResult> LogOut()
        {
            if (User.Identity.IsAuthenticated)
            {
                await _signInManager.SignOutAsync();
                return StatusCode(200);
            }
            else
            {
                return StatusCode(200);
            }
        }
        [HttpPut("Edit")]
        public IActionResult EditUser([FromBody] UserProfileDto userEdit)
        {
            if (userEdit == null || !ModelState.IsValid)
            {
                return BadRequest();
            }
            var user = _mapper.Map<User>(userEdit);
            _repository.Account.UpdateAccount(user);

            return StatusCode(201);
        }

    }
}
