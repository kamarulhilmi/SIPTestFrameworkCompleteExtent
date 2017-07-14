using NUnit.Framework;
using Framework;

namespace KamTests
{
    public class TestSet03_EditItemFunction : MyTestBase
    {
        [TestCase("auto1")]
        [TestCase("qatest")]
        [TestCase("AutomationTest05")]
        [TestCase("AutomationTest06")]
        public void RunTest_TC06_NewUserSuccessfullyEdited(string editeduser)
        {
            Pages.Login.Goto();
            Pages.Login.Login("admin", "admin");
            Assert.IsTrue(Pages.MapDashboard.IsAt(), "The user can't access map dahsboard page.");

            Pages.MapDashboard.UserManagement();
            Assert.IsTrue(Pages.UserManagement.IsAt(), "The user can't access user management page.");

            Pages.UserManagement.EditUser(editeduser);
            Pages.UserManagement.ConfirmEdit();
        }

        [TestCase("auto")]
        [TestCase("qatest")]
        [TestCase("AutomationTest05")]
        [TestCase("AutomationTest06")]
        public void RunTest_TC10_UserGroupSuccessfullyEdited(string editedgroup)
        {
            Pages.Login.Goto();
            Pages.Login.Login("admin", "admin");
            Assert.IsTrue(Pages.MapDashboard.IsAt(), "The user can't access map dahsboard page.");

            Pages.MapDashboard.UserGroup();
            Assert.IsTrue(Pages.UserGroup.IsAt(), "The user can't access User Group page.");

            Pages.UserGroup.EditUserGroup(editedgroup);
            Pages.UserGroup.ConfirmEdit();
        }

        [Test]
        public void RunTest_TC13_NewRouteSuccessfullyEdited()
        {
            Pages.Login.Goto();
            Pages.Login.Login("admin", "admin");
            Assert.IsTrue(Pages.MapDashboard.IsAt(), "The user can't access map dahsboard page.");

            Pages.MapDashboard.Route();
            Assert.IsTrue(Pages.Route.IsAt(), "The user can't access Route page.");

            Pages.AddRoute.EditRoute("AutoTestRoute");
            Pages.AddRoute.ConfirmEdit();
        }

        [Test]
        public void RunTest_TC16_NewPOISuccessfullyEdited()
        {
            Pages.Login.Goto();
            Pages.Login.Login("admin", "admin");
            Assert.IsTrue(Pages.MapDashboard.IsAt(), "The user can't access map dahsboard page.");

            Pages.MapDashboard.POIManagement();
            Assert.IsTrue(Pages.POIManagement.IsAt(), "The user can't access POI Management page.");

            Pages.POIManagement.EditPOI("AutoTestPOI");
            Pages.POIManagement.ConfirmEdit();
        }
    }
}
