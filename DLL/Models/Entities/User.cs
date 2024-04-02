using BeautyTrackSystem.DLL.Enums;

namespace BeautyTrackSystem.DLL.Models.Entities
{
    public class User
    {
        public Int32 Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
        public Byte[] PasswordHash { get; set; }
        public Byte[] PasswordSalt { get; set; }
        public Roles RoleId { get; set; }
    }
}
