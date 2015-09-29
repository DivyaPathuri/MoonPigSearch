using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace MoonPig.BaseCode
{
   public class BaseHelper
    {
        public static RemoteWebDriver CurrentDriver { get; set; }
        public static string Domain
        {
            get
            {
                var appSetting = ConfigurationManager.AppSettings["domain"];
                return !string.IsNullOrEmpty(appSetting) ? appSetting : Environment.GetEnvironmentVariable("domain");
            }
        }

        public static string BaseUrl
        {
            get { return "http://" + Domain; }
        }
        public static string Browser
        {
            get
            {
                return ConfigurationManager.AppSettings["browser"];
            }
        }
        public static string BrowserVersion
        {
            get
            {
                return ConfigurationManager.AppSettings["browser_version"];
            }
        }

        public static void EnsureDriverIsInitialised()
        {
            if (CurrentDriver == null)
            {
              CurrentDriver = new FirefoxDriver();
            }
        }
    }
}
