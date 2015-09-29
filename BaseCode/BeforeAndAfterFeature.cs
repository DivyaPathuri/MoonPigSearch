using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace MoonPig.BaseCode
{
    [Binding]
     public class BeforeAndAfterFeature :BaseHelper
    {
        [BeforeScenario]
        public static void TagNameSelector()
        {
            var getTagName = FeatureContext.Current.FeatureInfo.Tags.ToList().FirstOrDefault();
            if (getTagName!=null &&getTagName.Contains("firefox"))
            {
                  EnsureDriverIsInitialised();
                CurrentDriver.Manage().Window.Maximize();
            }
        }
        [AfterScenario]
        public static void FinalizeDriver()
        {
            if (CurrentDriver != null)
            {
                CurrentDriver.Quit();
                CurrentDriver = null;
            }
        }
    }
}
