using System;
using Foundation;
using UIKit;

namespace OKSDK.iOS
{
    public enum OKSDKErrorCode
    {
        NotInitialized = 1,
        NoSchemaRegistered = 2,
        BadOAuthRedirectUri = 3,
        BadApiReponse = 4,
        OAuthError = 5,
        UserConfirmationDialogAlreadyInProgress = 6,
        NotAuthorized = 7,
        CancelledByUser = 8
    }
    
    public class OKSDKInitSettings
    {
        public string AppId { get; set; }
        public string AppKey { get; set; }
        public UIViewController ControllerHandler { get; set; }
    }

    public class OKConnection
    {
        public OKSDKInitSettings Settings { get; set; }
        public string OAuthRedirectScheme { get; set; }
        public string OAuthRedirectUri { get; set; }

        public NSOperationQueue Queue { get; set; }
        public WeakReference<UIViewController> SafariVC { get; set; }

        public string AccessToken { get; set; }
        public string AccessTokenSecretKey { get; set; }
        public string SdkToken { get; set; }

        public NSMutableDictionary CompletiionHandlers { get; set; }
    }

    public static class OKSDK
    {
        private static UIColor OKColor = UIColor.FromRGBA(237, 129, 43, 100);

        private const string OK_SDK_VERSION = @"2.0.12";
        private const double OK_REQUEST_TIMEOUT = 180.0;
        private const int OK_MAX_CONCURRENT_REQUESTS = 3;
        private const string OK_OAUTH_URL = @"https://connect.ok.ru/oauth/authorize";
        private const string OK_WIDGET_URL = @"https://connect.ok.ru/dk?st.cmd=";
        private const string OK_API_URL = @"https://api.ok.ru/fb.do?";
        private const string OK_OAUTH_APP_URL = @"okauth://authorize";
        private const string OK_USER_DEFS_ACCESS_TOKEN = @"ok_access_token";
        private const string OK_USER_DEFS_SECRET_KEY = @"ok_secret_key";
        private const string OK_SDK_NOT_INIT_COMMON_ERROR = @"OKSDK not initialized you should call initWithSettings first";

        private const string OK_API_ERROR_CODE_DOMAIN = @"ru.ok.api";
        private const string OK_SDK_ERROR_CODE_DOMAIN = @"ru.ok.sdk";

        public delegate void OKResultBlock(NSData data);
        public delegate void OKErrorBlock(NSError error);

        public delegate void OKCompletitionHandler(NSData data, NSError error);

        #region String (OKConnection)

        private static string OK_MD5(this string self)
        {
            return string.Empty;
        }

        private static string OK_Encode(this string self)
        {
            return string.Empty;
        }

        private static string OK_Decode(this string self)
        {
            return string.Empty;
        }

        #endregion

        #region NSUrl (OKConnection)

        private static NSMutableDictionary OK_Params(this NSUrl self)
        {
            var result = new NSMutableDictionary();
            var pairs = 
        }

        #endregion

        #region OKSDK

        public static void InitWithSettings(OKSDKInitSettings settings)
        {
            
        }

        public static void AuthorizeWithPermissions(string[] permissions, OKResultBlock resultBlock, OKErrorBlock errorBlock)
        {
            
        }

        public static void InvokeMethod (string method, NSDictionary data, OKResultBlock resultBlock, OKErrorBlock errorBlock)
        {
            
        }

        public static void InvokeSdkMethod(string method, NSDictionary data, OKResultBlock resultBlock, OKErrorBlock errorBlock)
        {

        }

        public static void SdkInit(OKResultBlock resultBlock, OKErrorBlock errorBlock)
        {

        }

        public static void GetInstallSource(OKResultBlock resultBlock, OKErrorBlock errorBlock)
        {

        }

        public static bool OpenUrl(NSUrl url)
        {
            return true;
        }

        public static void ShowWidget(string command, NSDictionary arguments, NSDictionary options, OKResultBlock resultBlock, OKErrorBlock errorBlock)
        {

        }

        public static void Shutdown()
        {

        }

        public static void ClearAuth()
        {

        }

        public static string CurrentAccessToken()
        {
            return string.Empty;
        }

        public static string CurrentAccessTokenSecretKey()
        {
            return string.Empty;
        }

        #endregion
    }
}

