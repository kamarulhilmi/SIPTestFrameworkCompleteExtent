using NUnit.Framework;
using Framework;

namespace KamTests
{
    public class TestSet02_AddItemFunction : MyTestBase
    {
        [TestCase("AutomationTest06", "Test Engineer", "kamarulhilmi@recogine.com", "Damansara", "AutomationTest06", "Operation", "auto", "Male", "0135906715", "1991/01/05", "auto")]
        [TestCase("AutomationTest07", "Test Engineer", "kamarulhilmi@recogine.com", "Damansara", "AutomationTest07", "Operation", "auto", "Male", "0135906715", "1991/01/05", "auto")]
        [TestCase("AutomationTest08", "Test Engineer", "kamarulhilmi@recogine.com", "Damansara", "AutomationTest08", "Operation", "auto", "Female", "0135906715", "1991/01/05", "auto")]
        [TestCase("AutomationTest09", "Test Engineer", "kamarulhilmi@recogine.com", "Damansara", "AutomationTest09", "Operation", "auto", "Female", "0135906715", "1991/01/05", "auto")]
        [TestCase("AutomationTest10", "Test Engineer", "kamarulhilmi@recogine.com", "Damansara", "AutomationTest10", "Operation", "auto", "Female", "0135906715", "1991/01/05", "auto")]
        
        public void RunTest_TC05_NewUserSuccessfullyAdded(string name, string position, string email, string address, string username, string usergroupName, string password, string gender, string contactNumber, string dob, string confirmPassword)
        {
            Pages.Login.Goto();
            Pages.Login.Login("admin", "admin");
            Assert.IsTrue(Pages.MapDashboard.IsAt(), "The user can't access map dahsboard page.");

            Pages.MapDashboard.UserManagement();
            Assert.IsTrue(Pages.UserManagement.IsAt(), "The user can't access user management page.");

            Pages.UserManagement.AddNewUser();
            Assert.IsTrue(Pages.AddNewUser.IsAt(), "The user can't access add user page");

            Pages.AddNewUser.AddUser(name, position, email, address, username, usergroupName, password, gender, contactNumber, dob, confirmPassword);

            Pages.UserManagement.AddNewUserConfirm();
        }

        [Test]
        public void RunTest_TC09_UserGroupSuccessfullyAdded()
        {
            Pages.Login.Goto();
            Pages.Login.Login("admin", "admin");
            Assert.IsTrue(Pages.MapDashboard.IsAt(), "The user can't access map dahsboard page.");

            Pages.MapDashboard.UserGroup();
            Assert.IsTrue(Pages.UserGroup.IsAt(), "The user can't access User Group page.");

            Pages.UserGroup.AddUserGroup();
            Assert.IsTrue(Pages.AddUserGroup.IsAt(), "The user can't access Add User Group page");

            Pages.AddUserGroup.AddGroup("AutomationTest03");
        }

        [Test]
        public void RunTest_TC12_NewRouteSuccessfullyAdded()
        {
            Pages.Login.Goto();
            Pages.Login.Login("admin", "admin");
            Assert.IsTrue(Pages.MapDashboard.IsAt(), "The user can't access map dahsboard page.");

            Pages.MapDashboard.Route();
            Assert.IsTrue(Pages.Route.IsAt(), "The user can't access Route page.");

            Pages.Route.AddRoute();
            Pages.AddRoute.AddNewRoute(
                "AutoTestRoute", //route name
                "FF17E0");          //route color
            Pages.AddRoute.Confirm();
        }

        [Test]
        public void RunTest_TC15_NewPOISuccessfullyAdded()
        {
            Pages.Login.Goto();
            Pages.Login.Login("admin", "admin");
            Assert.IsTrue(Pages.MapDashboard.IsAt(), "The user can't access map dahsboard page.");

            Pages.MapDashboard.POIManagement();
            Assert.IsTrue(Pages.POIManagement.IsAt(), "The user can't access POI Management page.");

            Pages.POIManagement.AddPOI();
            Assert.IsTrue(Pages.AddPOI.IsAt(), "The user can't access Add POI page");

            Pages.AddPOI.AddNewPOI(
                "AutoTestPOI",
                "Gym",
                "24 Hours & 7 Days");
            Pages.AddPOI.Confirm();
        }
    }
}
