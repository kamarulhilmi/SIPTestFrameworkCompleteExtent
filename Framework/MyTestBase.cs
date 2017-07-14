using NUnit.Framework;
using RelevantCodes.ExtentReports;
using System.IO;
using Common.Reporting;
using OpenQA.Selenium.Chrome;
using System;

namespace Framework
{
    [TestFixture]
    public abstract class MyTestBase : Browser
    {
        public static ReportingTasks reportingTasks;

        [SetUp]
        public void TestSetup()
        {
            reportingTasks.InitializeTest();
            Browser.Initialize();
        }

        [TearDown]
        public void TestCleanUp()
        {
            reportingTasks.FinalizeTest();
            webDriver.Manage().Cookies.DeleteAllCookies();
        }

        public static void BeginExecution()
        {
            ExtentReports extentReports = ReportingManager.Instance;
            extentReports.LoadConfig(Directory.GetParent(TestContext.CurrentContext.TestDirectory).Parent.FullName + "\\extent-config.xml");
            extentReports.AddSystemInfo("Browser", "Chrome");

            reportingTasks = new ReportingTasks(extentReports);

            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(20);
            webDriver.Manage().Window.Maximize();
        }

        public static void ExitExecution()
        {
            if (webDriver != null)
            {
                webDriver.Quit();
            }
            reportingTasks.CleanUpReporting();
        }
    }
}
