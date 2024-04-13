using BeautyTrackSystem.BLL.Extensions;
using BeautyTrackSystem.BLL.Mapper;
using BeautyTrackSystem.BLL.Models.AuthModels;
using BeautyTrackSystem.BLL.Models.Responses;
using BeautyTrackSystem.BLL.Services.Interfaces;
using BeautyTrackSystem.DLL.Models.Entities;
using BeautyTrackSystem.DLL.Repositories.Interfaces;

namespace BeautyTrackSystem.BLL.Services.Realization
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task<ServiceResponse<JwtDTO>> Login(LoginDTO loginModel)
        {
            ServiceResponse<JwtDTO> serviceResponse = new ServiceResponse<JwtDTO>();
            User userEntityModel = await _authRepository.Get(loginModel.Email);
            if (userEntityModel == null)
            {
                serviceResponse.Message = "Incorrect username or password";
                return serviceResponse;
            }

            Boolean isPasswordValid = PasswordHelper
                .VerifyPasswordHash(loginModel.Password, userEntityModel.PasswordHash, userEntityModel.PasswordSalt);

            if (!isPasswordValid)
            {
                serviceResponse.Message = "Incorrect username or password";
                return serviceResponse;
            }

            JwtDTO jwtViewModel = TokenGen.GenerateToken(userEntityModel);

            serviceResponse.IsSuccess = true;
            serviceResponse.Data = jwtViewModel;
            return serviceResponse;
        }

        public async Task<ServiceResponse<UserDTO>> Register(RegisterDTO registerModel)
        {
            ServiceResponse<UserDTO> serviceResponse = new ServiceResponse<UserDTO>();

            Boolean isUserExists = await _authRepository.IsUserExistByEmail(registerModel.Email);

            if (isUserExists)
            {
                serviceResponse.Message = "User already exist";
                return serviceResponse;
            }

            User user = AuthMapper.GetUserEntityModel(registerModel);
            PasswordDTO passwordModel = PasswordHelper.CreatePasswordHash(registerModel.Password);
            user.PasswordHash = passwordModel.PasswordHash;
            user.PasswordSalt = passwordModel.PasswordSalt;
            await _authRepository.AddUser(user);

            serviceResponse.IsSuccess = true;
            serviceResponse.Data = AuthMapper.GetUserModel(user);
            return serviceResponse;
        }

        public async Task<ServiceResponse<Boolean>> RestorePassword(RestorePasswordDTO restorePasswordModel)
        {
            ServiceResponse<Boolean> serviceResponse = new ServiceResponse<Boolean>();

            Boolean isUserExists = await _authRepository.IsUserExistByEmail(restorePasswordModel.Email);

            if (!isUserExists)
            {
                serviceResponse.Message = "User is not already exist";
                return serviceResponse;
            }

            User user = await _authRepository.Get(restorePasswordModel.Email);
            PasswordDTO passwordModel = PasswordHelper.CreatePasswordHash(restorePasswordModel.Password);
            user.PasswordHash = passwordModel.PasswordHash;
            user.PasswordSalt = passwordModel.PasswordSalt;
            await _authRepository.UpdateUser(user);

            serviceResponse.IsSuccess = true;
            serviceResponse.Data = true;
            return serviceResponse;
        }
    }
}
