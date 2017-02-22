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
        private readonly IRequestProvider _requestProvider;

        public bool IsAuthenticated => !string.IsNullOrEmpty(Settings.AccessToken);

        public AuthenticationService(IRequestProvider requestProvider)
        {
            _requestProvider = requestProvider;
            _requestProvider.AccessToken = Settings.AccessToken;
        }
        public async Task<bool> LoginAsync(string userEmail, string password)
        {
            var auth = new AuthenticationRequest
            {
                UserEmail = userEmail,
                Password = password
            };

            var builder = new UriBuilder(Settings.AuthenticationEndpoint);
            builder.Path = "api/Profile/Login/";

            var uri = builder.ToString();

            var authenticationInfo =
                await _requestProvider.PostAsync<AuthenticationRequest, UserModel>(uri, auth);
            Settings.UserId = authenticationInfo.Id;
            Settings.UserName = authenticationInfo.FirstName+" "+authenticationInfo.LastName;
            Settings.AccessToken = authenticationInfo.AccessToken;
            return true;
        }

        public Task LogoutAsync()
        {
            Settings.RemoveUserId();
            Settings.RemoveUserName();
            Settings.RemoveAccessToken();
            Settings.RemoveIsLogin();

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
            builder.Path = $"api/Profile/GetProfile/{userId}/";

            var uri = builder.ToString();
            var userModel= _requestProvider.GetAsync<UserModel>(uri);
            return userModel;
        }



        public Task<UserModel> SignUp(UserModel profile)
        {
            var builder = new UriBuilder(Settings.AuthenticationEndpoint);
            builder.Path = $"api/Profile/SignUp/";
            var uri = builder.ToString();
            var userModel= _requestProvider.PostAsync(uri, profile);
            return userModel;
        }

      
    }
}