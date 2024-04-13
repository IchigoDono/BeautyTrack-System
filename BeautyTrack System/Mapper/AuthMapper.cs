using BeautyTrack_System.Models.AuthModels;
using BeautyTrackSystem.BLL.Models.AuthModels;

namespace BeautyTrack_System.Mapper
{
    public class AuthMapper
    {
        public static LoginDTO GetLoginModel(LoginViewModel loginViewModel)
        {
            LoginDTO login = new LoginDTO
            {
                Email = loginViewModel.Email,
                Password = loginViewModel.Password
            };
            return login;
        }

        public static RegisterDTO GetRegisterModel(RegisterViewModel registerViewModel)
        {
            RegisterDTO registerModel = new RegisterDTO
            {
                FirstName = registerViewModel.FirstName,
                LastName = registerViewModel.LastName,
                Email = registerViewModel.Email,
                Password = registerViewModel.Password
            };

            return registerModel;
        }
        public static RestorePasswordDTO GetPasswordRestoreModel(RestorePasswordViewModel restorePasswordViewModel)
        {
            RestorePasswordDTO restorePasswordModel = new RestorePasswordDTO
            {
                Email = restorePasswordViewModel.Email,
                Password = restorePasswordViewModel.Password
            };
            return restorePasswordModel;
        }
    }
}
