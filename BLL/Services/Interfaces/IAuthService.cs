using BeautyTrackSystem.BLL.Models.AuthModels;
using BeautyTrackSystem.BLL.Models.Responses;

namespace BeautyTrackSystem.BLL.Services.Interfaces
{
    public interface IAuthService
    {
        Task<ServiceResponse<UserDTO>> Register(RegisterDTO registerModel);
        Task<ServiceResponse<JwtDTO>> Login(LoginDTO loginModel);
        Task<ServiceResponse<Boolean>> RestorePassword(RestorePasswordDTO restorePasswordModel);
    }
}
