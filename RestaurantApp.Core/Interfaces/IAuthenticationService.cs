using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantApp.Data.Models;

namespace RestaurantApp.Core.Interfaces
{
    public interface IAuthenticationService
    {
        bool IsAuthenticated { get; }
        Task<bool> LoginAsync(string userName, string password);

        Task LogoutAsync();
        Task<UserModel> SignUp(UserModel profile);
        int GetCurrentUserId();
        Task<UserModel> GetCurrentProfileAsync();
    }
}
