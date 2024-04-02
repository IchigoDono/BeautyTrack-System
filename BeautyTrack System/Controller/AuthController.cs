using BeautyTrack_System.Mapper;
using BeautyTrack_System.Models.AuthModels;
using BeautyTrackSystem.BLL.Models.AuthModels;
using BeautyTrackSystem.BLL.Models.Responses;
using BeautyTrackSystem.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BeautyTrack_System.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            ServiceResponse<UserDTO> response = await _authService.Register(AuthMapper.GetRegisterModel(registerViewModel));
            return Ok(response);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            ServiceResponse<JwtDTO> response = await _authService.Login(AuthMapper.GetLoginModel(loginViewModel));
            return Ok(response);
        }

        [HttpPost("RestorePassword")]
        public async Task<IActionResult> RestorePassword(RestorePasswordViewModel restorePasswordViewModel)
        {
            ServiceResponse<Boolean> response = await _authService.RestorePassword(AuthMapper.GetPasswordRestoreModel(restorePasswordViewModel));
            return Ok(response);
        }
    }
}
