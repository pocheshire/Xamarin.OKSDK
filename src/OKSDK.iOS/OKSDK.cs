using System;
using Foundation;
using UIKit;
using System.Linq;

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

        #region NSString (OKConnection)

        private static NSString OK_MD5(this NSString self)
        {
            return new NSString("");
        }

        private static NSString OK_Encode(this NSString self)
        {
            return new NSString("");
        }

        private static NSString OK_Decode(this NSString self)
        {
            return new NSString("");
        }

        #endregion

        #region NSUrl (OKConnection)

        private static NSMutableDictionary OK_Params(this NSUrl self)
        {
            var result = new NSMutableDictionary();
            var pairs = string.IsNullOrEmpty(self.Fragment) ? self.Query.Split('&') : self.Fragment.Split('&');
            foreach (var pair in pairs)
            {
                var kv = pair.Split('=');
                if (kv.Length == 2)
                    result.Add(new NSString(kv[0]), new NSString(kv[1]));
            }

            return result;
        }

        #endregion

        #region NSBundle (CFBundleURLTypes)

        private static bool OK_HasRegisteredURLScheme (NSString urlScheme)
        {
            var urlTypes = NSBundle.MainBundle.ObjectForInfoDictionary("CFBundleURLTypes") as NSArray;


            for (nuint i = 0; i < urlTypes.Count; i++)
            {
                var urlType = urlTypes.GetItem<NSDictionary>(i);
                var urlSchemes = urlType.ValueForKey(new NSString("CFBundleURLSchemes")) as NSArray;

                if (urlSchemes.Contains(urlScheme))
                    return true;
            }

            return false;
        }

        #endregion

        #region NSDictionary (OKConnection)

        private static NSError OK_Error(this NSDictionary self)
        {
            if (self.ContainsKey(new NSString("error_code")))
            {
                return new NSError(new NSString(OK_API_ERROR_CODE_DOMAIN), (self["error_code"] as NSNumber).NIntValue, NSDictionary.FromObjectAndKey(self["error_msg"], new NSString("NSLocalizedDescriptionKey")));
            }

            if (self.ContainsKey(new NSString("error")))
            {
                return new NSError(new NSString(OK_API_ERROR_CODE_DOMAIN), -1, NSDictionary.FromObjectAndKey(self["error"], new NSString("NSLocalizedDescriptionKey")));
            }

            return null;
        }

        private static NSDictionary OK_Union (this NSDictionary self, NSDictionary dict)
        {
            var dictionary = new NSMutableDictionary(self);
            dictionary.SetValuesForKeysWithDictionary(dict);
            return dictionary;
        }

        private static NSString OK_QueryStringWithSignature (this NSDictionary self, NSString secretKey, NSString sigName)
        {
            var sigSource = new NSMutableString();
            var queryString = new NSMutableString();

            var sortedKeys = self.Keys.OrderBy((NSObject arg) => arg);
            foreach (var key in sortedKeys)
            {
                var @value = self[key] as NSString;
                sigSource.Append(NSString.LocalizedFormat(@"%@=%@\", key, value));
                queryString.Append(NSString.LocalizedFormat(@"%@=%@&", key, value.OK_Encode()));
            }

            sigSource.Append(secretKey);
            queryString.Append(NSString.LocalizedFormat(@"%@=%@&", sigName, sigSource.OK_MD5()));

            return queryString;
        }

        private static NSString OK_QueryString (this NSDictionary self)
        {
    //        NSMutableString* queryString = [NSMutableString string];
    //for (NSString* key in self) [queryString appendString:[NSString stringWithFormat: @"%@=%@&", [key ok_encode], [self[key] ok_encode]]];
    //        return queryString;
        }

        private static NSString OK_JSON(this NSDictionary self, NSError error)
        {
            //NSData *data = [NSJSONSerialization dataWithJSONObject:self options:0 error:&error ];
            //return data?[[NSString alloc] initWithData: data encoding:NSUTF8StringEncoding]:nil;
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

