namespace RestaurantApp.Data.Models
{
    public class AuthenticationResponse
    {
        public int UserId { get; set; }

        public string AccessToken { get; set; }
    }
}