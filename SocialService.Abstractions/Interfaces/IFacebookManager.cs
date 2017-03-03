using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SocialService.Abstractions.Interfaces
{
  public interface IFacebookManager:IBaseManager
  {
        string ClientId { get; set; }
        event EventHandler<FacebookProfile> OnUserAuthentication;
        Task<Page> ShowLoginPageAsync(Page page);
        Task<FacebookProfile> GetFacebookProfileAsync(Page page);
        Task<FacebookProfile> GetFacebookProfileAsync(string accessToken);
  }
}
