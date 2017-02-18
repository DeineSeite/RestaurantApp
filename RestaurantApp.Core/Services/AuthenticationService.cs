using System;
using System.Threading.Tasks;
using FreshMvvm;
using RestaurantApp.Core.Helpers;
using RestaurantApp.Core.Interfaces;
using RestaurantApp.Data.Models;

namespace RestaurantApp.Core.Services
{
    public class AuthenticationService :BaseService,IAuthenticationService
    {

        public bool IsAuthenticated => !string.IsNullOrEmpty(Settings.AccessToken);

        public async Task<bool> LoginAsync(string userEmail, string password)
        {
            var auth = new AuthenticationRequest
            {
                UserEmail = userEmail,
                Password = password
            };

            var builder = new UriBuilder(Settings.AuthenticationEndpoint);
            builder.Path = "api/login";

            var uri = builder.ToString();

            var authenticationInfo =
                await RequestProvider.PostAsync<AuthenticationRequest, AuthenticationResponse>(uri, auth);
            Settings.UserId = authenticationInfo.UserId;
            Settings.AccessToken = authenticationInfo.AccessToken;
            return true;
        }

        public Task LogoutAsync()
        {
            Settings.RemoveUserId();
            Settings.RemoveAccessToken();

            return Task.FromResult(false);
        }

        public int GetCurrentUserId()
        {
            return Settings.UserId;
        }

        public Task<UserModel> GetCurrentProfileAsync()
        {
            var userId = GetCurrentUserId();

            var builder = new UriBuilder(Settings.AuthenticationEndpoint);
            builder.Path = $"api/Profile/234s";

            var uri = builder.ToString();
            var userModel= RequestProvider.GetAsync<UserModel>(uri);
            return userModel;
        }



        public Task<UserModel> SignUp(UserModel profile)
        {
            var builder = new UriBuilder(Settings.AuthenticationEndpoint);
            builder.Path = $"api/Profile/SignUp/";
            var uri = builder.ToString();
            var userModel= RequestProvider.PostAsync(uri, profile);
            return userModel;
        }

      
    }
}