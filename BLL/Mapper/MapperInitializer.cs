using BeautyTrack_System.Bll.Models;
using BeautyTrackSystem.BLL.Models;
using BeautyTrackSystem.DLL.Models.Entities;

namespace BeautyTrackSystem.BLL.Mapper
{
    public class MapperInitializer
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
