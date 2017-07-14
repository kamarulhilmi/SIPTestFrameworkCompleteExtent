using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public class LoginPage : Browser
    {

        private int PAGE_LOAD_TIMEOUT = 10;

        public bool IsAt()
        {
            By element = By.Id("login_error");
            return WaitUntilElementDisplayed(element, PAGE_LOAD_TIMEOUT);
        }

        public void Goto()
        {
            Goto("/Account/Login");
        }

        public void Login(string username, string password)
        {

            var usernameField = Driver.FindElement(By.Id("input_user_name"));
            usernameField.SendKeys(username);

            var passwordField = Driver.FindElement(By.Id("input_password"));
            passwordField.SendKeys(password);

            Driver.FindElement(By.Id("btn_login")).Click();

        }

        public void TakeScreenShot()
        {
            ITakesScreenshot screenshotDriver = Driver as ITakesScreenshot;
            Screenshot screenshot = screenshotDriver.GetScreenshot();
            string fp = "D:\\" + "snapshot" + "_" + DateTime.Now.ToString("dd_MMMM_hh_mm_ss_tt") + ".png";
            screenshot.SaveAsFile(fp, ScreenshotImageFormat.Png);
        }

    }
}
