using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppSignalr.App_Start
{
    public class SignalrConfiguration
    {
        public static HubConfiguration Config()
        {
            HubConfiguration conf = new HubConfiguration
            {
                EnableCrossDomain = false,
                EnableDetailedErrors = true,
                EnableJavaScriptProxies = true
            };
            return conf;
        }
    }
}