
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using RelevantCodes.ExtentReports;

namespace Common.Reporting
{
    public class ReportingTasks
    {
        private ExtentReports extent;
        private ExtentTest test;

        public ReportingTasks(ExtentReports extentInstance)
        {
            extent = extentInstance;
        }

        public void InitializeTest()
        {
            test = extent.StartTest(TestContext.CurrentContext.Test.Name);
        }

        public void FinalizeTest()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                ? ""
                : string.Format("<pre>{0}</pre>", TestContext.CurrentContext.Result.Message);
            LogStatus logstatus;

            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = LogStatus.Fail;
                    break;
                case TestStatus.Inconclusive:
                    logstatus = LogStatus.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = LogStatus.Skip;
                    break;
                default:
                    logstatus = LogStatus.Pass;
                    break;
            }
            test.Log(logstatus, "Test ended with " + logstatus + stacktrace);
            extent.EndTest(test);
            extent.Flush();
        }

        public void CleanUpReporting()
        {
            extent.Close();
        }

    }
}
