
using NUnit.Framework;
using RelevantCodes.ExtentReports;

namespace Common.Reporting
{
    public class ReportingManager
    {
        private static readonly ExtentReports instance = new ExtentReports(TestContext.CurrentContext.TestDirectory + "\\TestResults.html");

        static ReportingManager() { }
        private ReportingManager() { }

        public static ExtentReports Instance
        {
            get
            {
                return instance;
            }
        }
    }
}
