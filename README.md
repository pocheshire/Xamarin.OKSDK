# Xamarin.OKSDK
Port ok-sdk for iOS and Android

##How to use 

###iOS
First you should select External and IOS platforms and enable Client OAuth authorization using ok.ru app edit form. 
Also your should send request for LONG_ACCESS_TOKEN to [api-support](mailto:api-support@ok.ru) or you can simple not request for LONG_ACCESS_TOKEN permission during OAuth authorization.

Add *ok{appId}* schema to your app Info.plist file. For example *ok12345* if your app has appId *12345*.
Don't forget add ok{appId}://authorize to allowed redirect urls for your application in ok.ru app profile. Also you should add next block to your Info.plist file.
```xml
 <key>NSAppTransportSecurity</key>
    <dict>
        <key>NSAllowsArbitraryLoads</key>
        <true/>
    </dict>
```

Add OKSDK.cs to your project.

Init your sdk in AppDelegate FinishedLaunching
```csharp
public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
{
    var settings = new OKSDKInitSettings();
    settings.AppKey = @"ABCDEFGABCDEGF";
    settings.AppId = @"12345";
    settings.ControllerHandler = this.Window.RootViewController;
    
    OKSDK.InitWithSettings(settings);
    
    return true;
}
```

Add openUrl to AppDelegate openURL
```csharp
public override bool OpenUrl(UIApplication application, NSUrl url, string sourceApplication, NSObject annotation)
{
    OKSDK.OpenUrl(url);
    return true;
}
```

To understand how to interact with OKSDK please look at examples  [repository](https://github.com/apiok/ok-ios-sdk-examples)

###Android
