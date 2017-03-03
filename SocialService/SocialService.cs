using System;
using System.Threading;
using SocialService.Abstractions;
using SocialService.Abstractions.Interfaces;


namespace SocialService
{
    /// <summary>
    ///     Cross platform SocialService implemenations
    /// </summary>
    public class SocialService
    {

        #region FacebookManager

        private static readonly Lazy<IFacebookManager> _facebookManager =
            new Lazy<IFacebookManager>(() => CreateFacebookManager(), LazyThreadSafetyMode.PublicationOnly);

        /// <summary>
        ///     Current FacebookManager
        /// </summary>
        public static IFacebookManager FacebookManager
        {
            get
            {
                var ret = _facebookManager.Value;
                if (ret == null)
                    throw NotImplementedInReferenceAssembly();
                return ret;
            }
        }

        private static IFacebookManager CreateFacebookManager()
        {
            return new FacebookManager();
        }

        #endregion

        #region TwitterManager

        private static readonly Lazy<ITwitterManager> _twitterManager =
            new Lazy<ITwitterManager>(() => CreateTwitterManager(), LazyThreadSafetyMode.PublicationOnly);

        /// <summary>
        ///     Current FacebookManager
        /// </summary>
        public static ITwitterManager TwitterkManger
        {
            get
            {
                var ret = _twitterManager.Value;
                if (ret == null)
                    throw NotImplementedInReferenceAssembly();
                return ret;
            }
        }

        private static ITwitterManager CreateTwitterManager()
        {
#if PORTABLE
            return null;
#else
            return new TwitterManagerImplementation();
#endif
        }

        #endregion

        internal static Exception NotImplementedInReferenceAssembly()
        {
            return
                new NotImplementedException(
                    "This functionality is not implemented in the portable version of this assembly.  You should reference the NuGet package from your main application project in order to reference the platform-specific implementation.");
        }

    }
}