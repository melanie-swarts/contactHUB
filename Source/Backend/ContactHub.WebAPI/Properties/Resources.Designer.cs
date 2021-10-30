﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ContactHub.WebAPI.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("ContactHub.WebAPI.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Username already exists..
        /// </summary>
        internal static string ErrorMessage_EmailExists {
            get {
                return ResourceManager.GetString("ErrorMessage_EmailExists", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Incorrect username or password. If you have registered an account, please confirm that you have clicked on the verification link in your email..
        /// </summary>
        internal static string ErrorMessage_InvalidLogin {
            get {
                return ResourceManager.GetString("ErrorMessage_InvalidLogin", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Incorrect username or password..
        /// </summary>
        internal static string ErrorMessage_NoUserFound {
            get {
                return ResourceManager.GetString("ErrorMessage_NoUserFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An email message has been sent containing a link to reset your password..
        /// </summary>
        internal static string SuccessMessage_PasswordReset {
            get {
                return ResourceManager.GetString("SuccessMessage_PasswordReset", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Password has been successfully updated..
        /// </summary>
        internal static string SuccessMessage_PasswordUpdate {
            get {
                return ResourceManager.GetString("SuccessMessage_PasswordUpdate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Your account has been registered. Please check your email to verify your account..
        /// </summary>
        internal static string SuccessMessage_UserRegistration {
            get {
                return ResourceManager.GetString("SuccessMessage_UserRegistration", resourceCulture);
            }
        }
    }
}