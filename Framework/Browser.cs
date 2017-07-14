using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Threading;

namespace Framework
{
    public class Browser
    {
        public static IWebDriver webDriver = new ChromeDriver(@"C:\library");
        //public static IWebDriver webDriver = new FirefoxDriver();
        //public static IWebDriver webDriver = new InternetExplorerDriver(@"C:\library");
        //public static IWebDriver webDriver = new EdgeDriver(@"C:\library");

        //private static string baseUrl = "http://172.17.11.110:1010";
        //private static string baseUrl = "http://172.17.11.83:7882";
        private static string baseUrl = "http://172.17.16.177:8080";

        internal static bool WaitUntilElementDisplayed(By element, int timeout)
        {
            for (int i = 0; i < timeout; i++)
            {
                if (ElementIsDisplayed(element))
                {
                    return true;
                }
                Thread.Sleep(1000);
            }
            return false;

        }

        public static bool ElementIsDisplayed(By element)
        {
            var present = false;
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
            try
            {
                present = webDriver.FindElement(element).Displayed;
            }
            catch (NoSuchElementException)
            {

            }
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            return present;
        }

        //properties
        public static ISearchContext Driver
        {
            get
            {
                return webDriver;
            }

        }

        public static string Title
        {
            get
            {
                return webDriver.Title;
            }
        }

        //method

        public static void Initialize()
        {
            Goto("");
        }

        public static void Quit()
        {
            
            webDriver.Quit();
        }

        public static void Goto(string relativeUrl)
        {
            webDriver.Navigate().GoToUrl(string.Format("{0}/{1}", baseUrl, relativeUrl));
        }
    }
}
