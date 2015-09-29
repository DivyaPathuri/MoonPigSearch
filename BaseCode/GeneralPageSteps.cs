using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace MoonPig.BaseCode
{
    [Binding]
    public static class GeneralPageSteps                          
    {
        public const int DefaultTimeout = 10;
        public static void Wait(this IWebDriver driver, int seconds = DefaultTimeout)
        {
            if (seconds <= 60)
                seconds *= 100;

            System.Threading.Thread.Sleep(seconds);
        }
        public static IWebElement WaitForElement(this IWebDriver driver, By by, Func<IWebElement, bool> predicate = null, int seconds = DefaultTimeout)
        {
            return driver.WaitForElements(by, predicate, seconds).First();
        }

        public static void ClickByCss(string css)
        {
            BaseHelper.CurrentDriver.WaitForElement(By.CssSelector(css)).Click();
        }

        public static IEnumerable<IWebElement> WaitForElements(this IWebDriver driver, By by, Func<IWebElement, bool> predicate = null, int seconds = DefaultTimeout)
        {
            IEnumerable<IWebElement> els;
            var retry = 0;

            do
            {
                retry++;
                driver.Wait(1);

                els = driver.FindElements(by);
                if (predicate != null)
                    els = els.Where(predicate);

            } while (els.Count() == 0 && retry < seconds);

            return els;
        }

    }
}
