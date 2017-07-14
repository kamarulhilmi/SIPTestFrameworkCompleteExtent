using NUnit.Framework;
using Framework;

namespace KamTests
{
    public class TestSet01_LoginFunction : MyTestBase
    {
        [TestCase("admin", "admin")] //Login as admin
        [TestCase("auto", "auto")] //Login as operator
        [TestCase("qatest", "qatest")] //Login as maintenance
        public void RunTest_TC01_LoginWithValidUsernamePassword(string username, string password)
        {
            Pages.Login.Goto();
            Pages.Login.Login(username, password);
            Assert.IsTrue(Pages.MapDashboard.IsAt(), "The user can't access map dahsboard page.");

            Pages.MapDashboard.LogOut();

        }

        [TestCase("invalidadmin", "admin")]
        [TestCase("invalidauto", "admin")]
        [TestCase("invalidqatest", "admin")]
        [TestCase(" ", "admin")]
        public void RunTest_TC02_LoginWithInvalidUsername(string username, string password)
        {
            Pages.Login.Goto();
            Pages.Login.Login(username, password);
            Assert.IsFalse(Pages.MapDashboard.IsAt(), "User can't login");

            Pages.Login.TakeScreenShot();
        }

        [TestCase("admin", "invalidpassword")]
        [TestCase("auto", "invalidpassword")]
        [TestCase("qatest", "invalidpassword")]
        [TestCase("admin", " ")]
        public void RunTest_TC03_LoginWithInvalidPassword(string username, string password)
        {
            Pages.Login.Goto();
            Pages.Login.Login(username, password);
            Assert.IsFalse(Pages.MapDashboard.IsAt(), "User can't login");

            Pages.Login.TakeScreenShot();
        }

        [TestCase("admin' --", " ")]
        [TestCase("admin' #", " ")]
        [TestCase("admin'/*", " ")]
        [TestCase("' or 1=1--", " ")]
        [TestCase("' or 1=1#", " ")]
        [TestCase("' or 1=1/*", " ")]
        [TestCase("') or '1'='1--", " ")]
        [TestCase("') or ('1'='1--", " ")]
        [TestCase("SELECT Username FROM Users WHERE ID=1", "SELECT MD5(Password) FROM Users WHERE ID=1")]
        [TestCase("*", " ")]
        [TestCase("';DR/**/OP tempTable;", " ")]
        [TestCase("admin", "' or 1=1--")]
        [TestCase("admin", "' or 1=1 --IamJOE")]
        [TestCase("admin", "' or ''='")]
        [TestCase("admin", "%27%20or%20%27%27%3D%27")]
        [TestCase("Guest", "admin")]
        [TestCase(" ", "' UNION SELECT 1, 'anotheruser', 'doesnt matter', 1-- ")]
        [TestCase("' AND users NOT IN ('First User', 'Second User');--", " ")]
        [TestCase("';SELECT TOP 1 name FROM members WHERE NOT EXIST(SELECT TOP 0 name FROM members) ", " ")]
        [TestCase("admin';DROP myTable--", " ")]
        [TestCase("/*!32302 1/0, */ ", " ")]
        [TestCase(" ", "';IF((SELECT user) = 'sa' OR (SELECT user) = 'dbo') SELECT 1 ELSE SELECT 1/0;--")]
        [TestCase("';waitfor delay '0:0:10'-- ", " ")]
        [TestCase("CAST('username' AS SIGNED INTEGER)", " ")]
        [TestCase("' UNION SELECT SUM(columntofind) FROM users--", " ")]
        [TestCase("' + (SELECT TOP 1 username FROM users ) + '", "' + (SELECT TOP 1 password FROM users ) + '")]
        [TestCase("';SHUTDOWN -- ", " ")]
        [TestCase("';SELECT name FROM sysobjects WHERE xtype = 'U';--", " ")]
        [TestCase("';SELECT name FROM syscolumns WHERE id =(SELECT id FROM sysobjects WHERE name = 'known_table_name');--", " ")]
        public void RunTest_TC04_ByPassLoginUsingSqlInjection(string username, string password)
        {
            Pages.Login.Login(username, password);
            Pages.Login.TakeScreenShot();
        }
    }
}
