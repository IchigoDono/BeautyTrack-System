using BeautyTrackSystem.BLL.Models.AuthModels;
using BeautyTrackSystem.DLL.Models.Entities;

namespace BeautyTrackSystem.BLL.Mapper
{
    public class AuthMapper
    {
        public static UserEntityModel GetUserEntityModel(RegisterModel registerModel)
        {
            UserEntityModel user = new UserEntityModel
            {
                FirstName = registerModel.FirstName,
                LastName = registerModel.LastName,
                Email = registerModel.Email
            };
            return user;
        }
        public static UserModel GetUserModel(UserEntityModel userEntityModel)
        {
            UserModel user = new UserModel
            {
                FirstName = userEntityModel.FirstName,
                LastName = userEntityModel.LastName,
                Email = userEntityModel.Email
            };
            return user;
        }
    }
}
