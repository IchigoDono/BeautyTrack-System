namespace BeautyTrackSystem.BLL.Models.AuthModels
{
    public class JwtDTO
    {
        public DateTime ExpireDate { get; set; }
        public string Jwt { get; set; }
    }
}
