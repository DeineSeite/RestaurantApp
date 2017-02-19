namespace RestaurantApp.Data.Models
{
    public class AuthenticationResponse
    {
        public int UserId { get; set; }
        public int FirstName { get; set; }
        public int LastName { get; set; }
        public string AccessToken { get; set; }
    }
}