using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantApp.Data.Models;

namespace RestaurantApp.Core.Interfaces
{
    public interface IProfileService
    {
        Task<UserModel> GetCurrentProfileAsync();
        Task<UserModel> SignUp(UserModel profile);
        Task UploadUserImageAsync(UserModel profile, string imageAsBase64);
    }
}
