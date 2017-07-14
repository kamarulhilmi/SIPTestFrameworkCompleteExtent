using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public class EditUserPage : Browser
    {
        private static int PAGE_LOAD_TIMEOUT = 10;

        public bool IsAt()
        {
            By element = By.XPath("//label[contains(text(),'Edit User')]");
            return WaitUntilElementDisplayed(element, PAGE_LOAD_TIMEOUT);

        }
    }
}
