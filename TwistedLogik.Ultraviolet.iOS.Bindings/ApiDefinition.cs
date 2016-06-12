﻿using System;
using CoreAnimation;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using OpenGLES;
using UIKit;

namespace TwistedLogik.Ultraviolet.iOS.Bindings
{
    // @interface SDLUIKitDelegate : NSObject <UIApplicationDelegate>
    [BaseType(typeof(NSObject))]
    interface SDLUIKitDelegate : IUIApplicationDelegate
    {
        // +(id)sharedAppDelegate;
        [Static]
        [Export("sharedAppDelegate")]
        NSObject SharedAppDelegate { get; }

        // +(NSString *)getAppDelegateClassName;
        [Static]
        [Export("getAppDelegateClassName")]
        string AppDelegateClassName { get; }

        // -(void)hideLaunchScreen;
        [Export("hideLaunchScreen")]
        void HideLaunchScreen();
    }
}