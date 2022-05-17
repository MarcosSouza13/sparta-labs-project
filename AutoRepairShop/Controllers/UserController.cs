using AutoRepairShop.Api.Services.Interfaces;
using AutoRepairShop.Arguments.Login;
using AutoRepairShop.Arguments.User;
using Microsoft.AspNetCore.Mvc;

namespace AutoRepairShop.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddUserRequest request) => await _userService.Add(request.ToUser());

        [HttpGet]
        public async Task<IActionResult> Login([FromBody] LoginRequest request) => await _userService.Login(request.ToLogin());
    }
}
