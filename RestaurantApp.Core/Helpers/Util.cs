using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantApp.Data.Models;
using SocialService.Abstractions;

namespace RestaurantApp.Core.Helpers
{
   public static class Util
    {
        public static UserModel FacebookProfileToUsermodel(FacebookProfile facebook)
        {
            var userModel = new UserModel();
            userModel.FacebookId = facebook.Id;
            userModel.FirstName = facebook.FirstName;
            userModel.LastName = facebook.LastName;
            userModel.Gender = facebook.Gender == "male" ? GenderType.Woman : GenderType.Man;
            return userModel;
        }
        public static string SanitizePhoneNumber(this string value)
        {

            return new string(value.ToCharArray().Where(char.IsDigit).ToArray());

        }

        public static bool IsNullOrWhiteSpace(this string value)
        {

            return string.IsNullOrWhiteSpace(value);

        }
    }
}
