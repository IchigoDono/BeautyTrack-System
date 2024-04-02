namespace BeautyTrackSystem.BLL.Models.AuthModels
{
    public class PasswordDTO
    {
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
