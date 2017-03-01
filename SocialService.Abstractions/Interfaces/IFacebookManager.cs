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
        Task<FacebookProfile> GetFacebookProfileAsync(INavigation navigation);
        Task<FacebookProfile> GetFacebookProfileAsync(string accessToken);
  }
}
