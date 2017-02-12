using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace RestaurantApp.Core.Helpers
{
    /// <summary>
    /// This is the Settings static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters. 
    /// </summary>
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        #region Setting Constants

        public static string AuthenticationEndpoint { get; set; }

        private const string UserIdKey = "user_id_key";
        private static readonly int UserIdDefault = 0;

        private const string AccessTokenKey = "access_token_key";
        private static readonly string AccessTokenDefault = string.Empty;

        private const string FirstStartKey = "first_start_key";
        private static readonly bool FirstStartDefault = true;
        #endregion

        public static int UserId
        {
            get
            {
                return AppSettings.GetValueOrDefault(UserIdKey, UserIdDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(UserIdKey, value);
            }
        }

        public static string AccessToken
        {
            get
            {
                return AppSettings.GetValueOrDefault(AccessTokenKey, AccessTokenDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(AccessTokenKey, value);
            }
        }
        public static bool FirstStart
        {
            get
            {
                return AppSettings.GetValueOrDefault(FirstStartKey, FirstStartDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(FirstStartKey, value);
            }
        }

        public static void RemoveUserId()
        {
            AppSettings.Remove(UserIdKey);
        }

        public static void RemoveAccessToken()
        {
            AppSettings.Remove(AccessTokenKey);
        }
        public static void RemoveFirstStart()
        {
            AppSettings.Remove(FirstStartKey);
        }

    }

}