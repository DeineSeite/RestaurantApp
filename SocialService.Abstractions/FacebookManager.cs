using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SocialService.Abstractions;
using SocialService.Abstractions.Interfaces;
using Xamarin.Forms;

namespace SocialService.Abstractions
{
   public class FacebookManager: IFacebookManager
    {
        public FacebookManager()
        {
            ClientId = "165942640479284";
        }
        public string ClientId { get; set; }
        public event EventHandler<FacebookProfile> OnUserAuthentication;


        /// <summary>
        /// Get Facebook profile without Login Page
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public async Task<FacebookProfile> GetFacebookProfileAsync(string accessToken)
        {
            var requestUrl =
               "https://graph.facebook.com/v2.7/me/?fields=name,picture,work,website,religion,location,locale,link,cover,age_range,bio,birthday,devices,email,first_name,last_name,gender,hometown,is_verified,languages&access_token="
               + accessToken;

            var httpClient = new HttpClient();

            var userJson = await httpClient.GetStringAsync(requestUrl);

            var facebookProfile = JsonConvert.DeserializeObject<FacebookProfile>(userJson);

            return facebookProfile;
        }

        public async Task<FacebookProfile> GetFacebookProfileAsync(Page page)
        {
            
            return null;
        }

        public async Task<Page> ShowLoginPageAsync(Page page)
        {
            var loginPage = new FacebookLoginPage(ClientId);
            loginPage.OnUserIsLogin += LoginPage_OnUserIsLogin;
            await page.Navigation.PushAsync(loginPage);
            return loginPage;
        }

        private async void LoginPage_OnUserIsLogin(object sender, string accessToken)
        {
            var profile = await GetFacebookProfileAsync(accessToken);
            //fire result Event
            OnUserAuthentication?.Invoke(this, profile);
        }
    }
}
