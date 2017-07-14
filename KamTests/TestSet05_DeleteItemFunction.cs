using NUnit.Framework;
using Framework;

namespace KamTests
{
    public class TestSet05_DeleteItemFunction : MyTestBase
    {
        [Test]
        public void RunTest_TC07_NewUserSuccessfullyDeleted()
        {
            Pages.Login.Goto();
            Pages.Login.Login("admin", "admin");
            Assert.IsTrue(Pages.MapDashboard.IsAt(), "The user can't access map dahsboard page.");

            Pages.MapDashboard.UserManagement();
            Assert.IsTrue(Pages.UserManagement.IsAt(), "The user can't access user management page.");

            Pages.UserManagement.DeleteUser("AutomationTesting03");
            Pages.UserManagement.ConfirmDelete();
        }

        [Test]
        public void RunTest_TC11_UserGroupSuccessfullyDeleted()
        {
            Pages.Login.Goto();
            Pages.Login.Login("admin", "admin");
            Assert.IsTrue(Pages.MapDashboard.IsAt(), "The user can't access map dahsboard page.");

            Pages.MapDashboard.UserGroup();
            Assert.IsTrue(Pages.UserGroup.IsAt(), "The user can't access User Group page.");

            Pages.UserGroup.DeleteUserGroup("AutomationTest03");
            Pages.UserGroup.ConfirmDelete();
        }

        [Test]
        public void RunTest_TC14_NewRouteSuccessfullyDelete()
        {
            Pages.Login.Goto();
            Pages.Login.Login("admin", "admin");
            Assert.IsTrue(Pages.MapDashboard.IsAt(), "The user can't access map dahsboard page.");

            Pages.MapDashboard.Route();
            Assert.IsTrue(Pages.Route.IsAt(), "The user can't access User Group page.");

            Pages.AddRoute.DeleteRoute("AutoTestRoute");
            Pages.AddRoute.ConfirmDelete();
        }

        [Test]
        public void RunTest_TC17_NewPOISuccessfullyDelete()
        {
            Pages.Login.Goto();
            Pages.Login.Login("admin", "admin");
            Assert.IsTrue(Pages.MapDashboard.IsAt(), "The user can't access map dahsboard page.");

            Pages.MapDashboard.POIManagement();
            Assert.IsTrue(Pages.POIManagement.IsAt(), "The user can't access POI Management page.");

            Pages.POIManagement.DeletePOI("AutoTestPOI");
            Pages.POIManagement.ConfirmDelete();
        }
    }
}
