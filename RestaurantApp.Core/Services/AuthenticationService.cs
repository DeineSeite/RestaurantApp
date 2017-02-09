using System;
using System.Threading.Tasks;
using RestaurantApp.Core.Helpers;
using RestaurantApp.Core.Interfaces;
using RestaurantApp.Data.Models;

namespace RestaurantApp.Core.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IRequestProvider _requestProvider;

        public AuthenticationService(IRequestProvider requestProvider)
        {
            _requestProvider = requestProvider;
        }

        public bool IsAuthenticated => !string.IsNullOrEmpty(Settings.AccessToken);

        public async Task<bool> LoginAsync(string userName, string password)
        {
            var auth = new AuthenticationRequest
            {
                UserName = userName,
                Credentials = password,
                GrantType = "password"
            };

            var builder = new UriBuilder(Settings.AuthenticationEndpoint);
            builder.Path = "api/login";

            var uri = builder.ToString();

            var authenticationInfo =
                await _requestProvider.PostAsync<AuthenticationRequest, AuthenticationResponse>(uri, auth);
            Settings.UserId = authenticationInfo.UserId;
            Settings.AccessToken = authenticationInfo.AccessToken;

            return true;
        }

        public Task LogoutAsync()
        {
            Settings.RemoveUserId();
            Settings.RemoveProfileId();
            Settings.RemoveAccessToken();
            Settings.RemoveCurrentBookingId();

            return Task.FromResult(false);
        }

        public int GetCurrentUserId()
        {
            return Settings.UserId;
        }
    }
}