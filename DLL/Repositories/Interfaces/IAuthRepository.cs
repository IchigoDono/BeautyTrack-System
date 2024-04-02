using BeautyTrackSystem.DLL.Models.Entities;

namespace BeautyTrackSystem.DLL.Repositories.Interfaces
{
    public interface IAuthRepository
    {
        Task AddUser(User userEntityModel);
        Task UpdateUser(User userEntityModel);
        Task<Boolean> IsUserExistByEmail(String email);
        Task<User> Get(String email);
    }
}
