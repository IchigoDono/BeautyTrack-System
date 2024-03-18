namespace BeautyTrackSystem.BLL.Models.AuthModels
{
    public class PasswordModel
    {
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
