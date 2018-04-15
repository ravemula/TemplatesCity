﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Web;

namespace GetMyDeviceOnline.Utils
{
    public class ConfigHelper
    {
        // The AAD Instance is the instance of Azure, for example public Azure or Azure China.
        // The Client ID is used by the application to uniquely identify itself to Azure AD.
        // The App Key is a credential used to authenticate the application to Azure AD.  Azure AD supports password and certificate credentials.
        // The GraphResourceId the resource ID of the AAD Graph API.  We'll need this to request a token to call the Graph API.
        // The GraphApiVersion specifies which version of the AAD Graph API to call.
        // The tenant is the domain name of the AAD tenant used to sign users in.
        // The Post Logout Redirect Uri is the URL where the user will be redirected after they sign out.
        // The Authority is the sign-in URL of the tenant.

        private static readonly string aadInstance = ConfigurationManager.AppSettings["ida:AADInstance"];
        private static string clientId = ConfigurationManager.AppSettings["ida:ClientId"];
        private static string appKey = ConfigurationManager.AppSettings["ida:AppKey"];
        private static string graphResourceId = ConfigurationManager.AppSettings["ida:GraphUrl"];
        private static string graphApiVersion = ConfigurationManager.AppSettings["ida:GraphApiVersion"];
        private static string tenant = ConfigurationManager.AppSettings["ida:Tenant"];
        private static readonly string postLogoutRedirectUri = ConfigurationManager.AppSettings["ida:PostLogoutRedirectUri"];
        private static readonly string authority = String.Format(CultureInfo.InvariantCulture, aadInstance, tenant);

        
        public static string ClientId { get { return clientId; } }
        internal static string AppKey { get { return appKey; } }
        internal static string GraphResourceId { get { return graphResourceId; } }
        internal static string GraphApiVersion { get { return graphApiVersion; } }
        internal static string Tenant { get { return tenant; } }
        internal static string Authority { get { return authority; } }
        internal static string AadInstance { get { return aadInstance; } }
        internal static string PostLogoutRedirectUri { get { return postLogoutRedirectUri; } }
        internal static string GraphServiceRoot { get { return graphResourceId + '/' + tenant; } }

    }
}