using System;
using System.Threading.Tasks;
using SocialService.Abstractions;
using SocialService.Abstractions.Interfaces;
using Xamarin.Forms;

namespace SocialService
{
    public class FacebookManagerImplementation : IFacebookManager
    {
        public string ClientId
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public Task<FacebookProfile> GetFacebookProfileAsync(INavigation navigation)
        {
            throw new NotImplementedException();
        }

        public Task<FacebookProfile> GetFacebookProfileAsync(string accessToken)
        {
            throw new NotImplementedException();
        }
    }
}