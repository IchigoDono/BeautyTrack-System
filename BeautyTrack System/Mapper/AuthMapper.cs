using BeautyTrack_System.Models.AuthModels;
using BeautyTrackSystem.BLL.Models.AuthModels;

namespace BeautyTrack_System.Mapper
{
    public class AuthMapper
    {
        public static LoginModel GetLoginModel(LoginViewModel loginViewModel)
        {
            LoginModel login = new LoginModel
            {
                Email = loginViewModel.Email,
                Password = loginViewModel.Password
            };
            return login;
        }

        public static RegisterModel GetRegisterModel(RegisterViewModel registerViewModel)
        {
            RegisterModel registerModel = new RegisterModel 
            {
                FirstName = registerViewModel.FirstName,
                LastName = registerViewModel.LastName,
                Email = registerViewModel.Email,
                Password = registerViewModel.Password
            };

            return registerModel;
        }
        public static RestorePasswordModel GetPasswordRestoreModel(RestorePasswordViewModel restorePasswordViewModel)
        {
            RestorePasswordModel restorePasswordModel = new RestorePasswordModel
            {
                Email = restorePasswordViewModel.Email,
                Password = restorePasswordViewModel.Password
            };
            return restorePasswordModel;
        }
    }
}
