using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public class RoutePage : Browser
    {
        private int PAGE_LOAD_TIMEOUT = 10;

        public bool IsAt()
        {
            By element = By.XPath("//label[contains(text(),'Route')]");
            return WaitUntilElementDisplayed(element, PAGE_LOAD_TIMEOUT);
        }

        public void AddRoute()
        {
            var addRouteButton = Driver.FindElement(By.Id("btnAddRoute"));
            addRouteButton.Click();
        }

    }
}
