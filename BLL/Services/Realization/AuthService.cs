﻿using BeautyTrackSystem.BLL.Extensions;
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

        public async Task<ServiceResponse<JwtModel>> Login(LoginModel loginModel)
        {
            ServiceResponse<JwtModel> serviceResponse = new ServiceResponse<JwtModel>();
            UserEntityModel userEntityModel =  await _authRepository.Get(loginModel.Email);
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

            JwtModel jwtViewModel = TokenGen.GenerateToken(userEntityModel);

            serviceResponse.IsSuccess = true;
            serviceResponse.Data = jwtViewModel;
            return serviceResponse;
        }

        public async Task<ServiceResponse<UserModel>> Register(RegisterModel registerModel)
        {
            ServiceResponse<UserModel> serviceResponse = new ServiceResponse<UserModel>();

            Boolean isUserExists = await _authRepository.IsUserExistByEmail(registerModel.Email);

            if (isUserExists)
            {
                serviceResponse.Message = "User already exist";
                return serviceResponse;
            }

            UserEntityModel user = AuthMapper.GetUserEntityModel(registerModel);
            PasswordModel passwordModel = PasswordHelper.CreatePasswordHash(registerModel.Password);
            user.PasswordHash = passwordModel.PasswordHash;
            user.PasswordSalt = passwordModel.PasswordSalt;
            await _authRepository.AddUser(user);

            serviceResponse.IsSuccess = true;
            serviceResponse.Data = AuthMapper.GetUserModel(user);
            return serviceResponse;
        }

        public async Task<ServiceResponse<Boolean>> RestorePassword(RestorePasswordModel restorePasswordModel)
        {
            ServiceResponse<Boolean> serviceResponse = new ServiceResponse<Boolean>();

            Boolean isUserExists = await _authRepository.IsUserExistByEmail(restorePasswordModel.Email);

            if (!isUserExists)
            {
                serviceResponse.Message = "User is not already exist";
                return serviceResponse;
            }

            UserEntityModel user = await _authRepository.Get(restorePasswordModel.Email);
            PasswordModel passwordModel = PasswordHelper.CreatePasswordHash(restorePasswordModel.Password);
            user.PasswordHash = passwordModel.PasswordHash;
            user.PasswordSalt = passwordModel.PasswordSalt;
            await _authRepository.UpdateUser(user);

            serviceResponse.IsSuccess = true;
            serviceResponse.Data = true;
            return serviceResponse;
        }
    }
}
