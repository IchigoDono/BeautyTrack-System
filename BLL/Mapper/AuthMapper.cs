using BeautyTrackSystem.BLL.Models.AuthModels;
using BeautyTrackSystem.DLL.Models.Entities;

namespace BeautyTrackSystem.BLL.Mapper
{
    public class AuthMapper
    {
        public static User GetUserEntityModel(RegisterDTO registerModel)
        {
            User user = new User
            {
                FirstName = registerModel.FirstName,
                LastName = registerModel.LastName,
                Email = registerModel.Email
            };
            return user;
        }
        public static UserDTO GetUserModel(User userEntityModel)
        {
            UserDTO user = new UserDTO
            {
                FirstName = userEntityModel.FirstName,
                LastName = userEntityModel.LastName,
                Email = userEntityModel.Email
            };
            return user;
        }
    }
}
