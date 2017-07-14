using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public class AddRoutePage : Browser
    {
        public void AddNewRoute(string routeName, string routeColor)
        {
            var routename = Driver.FindElement(By.Id("routename"));
            routename.SendKeys(routeName);

            var routecolor = Driver.FindElement(By.Id("routeColor"));
            routecolor.Clear();
            routecolor.SendKeys(routeColor);

        }

        public void Confirm()
        {
            var confirmButton = Driver.FindElement(By.Id("btnSubmitRoute"));
            confirmButton.Click();
        }

        public static string v = ".";
        public void EditRoute(string routeName)
        {
            //need to working with html table
            By locator = By.Id("tableRouteData");
            var table = Driver.FindElement(locator);

            //collection of all row in the table
            IList<IWebElement> collectionOfRows = table.FindElements(By.XPath("//*[@id='tableRouteData']/tbody/tr"));

            var columnCounter = 1;
            var columnIndex = 4;
            string DESIRED_VALUE = routeName;

            //logic
            for (int tr = 0; tr < collectionOfRows.Count; tr++)
            {
                var row = collectionOfRows[tr];

                IList<IWebElement> allCellsInRow = row.FindElements(By.XPath("./*"));

                foreach (var cell in allCellsInRow)
                {
                    if (cell.Text == DESIRED_VALUE)
                    {
                        string desiredValueLocator = string.Format(".//*[@id='tableRouteData']/tbody/tr[{0}]/td[{1}]/i[1]", tr + 1, columnIndex);
                        v = desiredValueLocator;
                    }
                    columnCounter++;
                }
            }
        }

        public void ConfirmEdit()
        {
            var editRouteButton = Driver.FindElement(By.XPath(v));
            editRouteButton.Click();
        }

        public void DeleteRoute(string routeName)
        {
            //need to working with html table
            By locator = By.Id("tableRouteData");
            var table = Driver.FindElement(locator);

            //collection of all row in the table
            IList<IWebElement> collectionOfRows = table.FindElements(By.XPath("//*[@id='tableRouteData']/tbody/tr"));

            var columnCounter = 1;
            var columnIndex = 4;
            string DESIRED_VALUE = routeName;

            //logic
            for (int tr = 0; tr < collectionOfRows.Count; tr++)
            {
                var row = collectionOfRows[tr];

                IList<IWebElement> allCellsInRow = row.FindElements(By.XPath("./*"));

                foreach (var cell in allCellsInRow)
                {
                    if (cell.Text == DESIRED_VALUE)
                    {
                        string desiredValueLocator = string.Format(".//*[@id='tableRouteData']/tbody/tr[{0}]/td[{1}]/i[2]", tr + 1, columnIndex);
                        v = desiredValueLocator;
                    }
                    columnCounter++;
                }
            }
        }

        public void ConfirmDelete()
        {
            var deleteRouteButton = Driver.FindElement(By.XPath(v));
            deleteRouteButton.Click();

            var toConfirmDelete = Driver.FindElement(By.XPath("//button[contains(text(),'Yes')]"));
            toConfirmDelete.Click();
        }
    }
}
