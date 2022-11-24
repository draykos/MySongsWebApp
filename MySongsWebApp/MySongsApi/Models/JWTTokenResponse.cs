namespace MySongsApi.Models
{
    public class JWTTokenResponse
    {
        public string? Token { get; set; }
        public string? RefreshToken { get; set; }
    }
}
