using NUnit.Framework;
using Framework;

namespace KamTests
{
    public class TestSet04_ResetPasswordFunction : MyTestBase
    {
        [TestCase("auto")]
        [TestCase("qatest")]
        [TestCase("AutomationTest05")]
        [TestCase("AutomationTest06")]
        public void RunTest_TC08_NewUserPasswordSuccessfullyReset(string resetPassword)
        {
            Pages.Login.Goto();
            Pages.Login.Login("admin", "admin");
            Assert.IsTrue(Pages.MapDashboard.IsAt(), "The user can't access map dahsboard page.");

            Pages.MapDashboard.UserManagement();
            Assert.IsTrue(Pages.UserManagement.IsAt(), "The user can't access user management page.");

            Pages.UserManagement.ResetPassword(resetPassword);
            Pages.UserManagement.ConfirmResetPassword();
        }
    }
}
