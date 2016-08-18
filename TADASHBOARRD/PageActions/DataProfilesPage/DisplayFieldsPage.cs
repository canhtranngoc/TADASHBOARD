using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using TADASHBOARRD.Common;


namespace TADASHBOARRD.PageActions.DataProfilesPage
{
    public class DisplayFieldsPage : GeneralPage.GeneralPage
    {
        protected readonly By tableDisplayFields = By.XPath("//*[@id='profilesettings']/tbody/tr");

        ///<summary>
        ///
        ///</summary>
        public void ClickCheckAllLink()
        {
            Click("checkall link");
        }

        ///<summary>
        ///
        ///</summary>
        public void ClickUnCheckAllLink()
        {
            Click("uncheckall link");
        }

        ///<summary>
        ///
        ///</summary>
        public bool AreAllCheckboxChecked()
        {
            bool check = true;
            int rownumber = WebDriver.driver.FindElements(tableDisplayFields).Count;
            for (int row = 3; row < rownumber - 1; row++)
            {
                string xpathcolumn = string.Format("//*[@id='profilesettings']/tbody/tr[{0}]/td", row);
                int columnnumber = WebDriver.driver.FindElements(By.XPath(xpathcolumn)).Count;
                for(int column = 1; column<=columnnumber; column++)
                {
                    string xpathCheckbox = string.Format("//*[@id='profilesettings']/tbody/tr[{0}]/td[{1}]//input[@type = 'checkbox']", row, column);
                    Console.WriteLine(row);
                    Console.WriteLine(column);
                    if (WebDriver.driver.FindElement(By.XPath(xpathCheckbox)).Selected == false)
                    {
                        check = false;
                        break;
                    }
                }
            }
            return check;
        }

        ///<summary>
        ///
        ///</summary>
        public bool AreAllCheckboxUnChecked()
        {
            bool check = true;
            int rownumber = WebDriver.driver.FindElements(tableDisplayFields).Count;
            for (int row = 3; row < rownumber - 1; row++)
            {
                string xpathcolumn = string.Format("//*[@id='profilesettings']/tbody/tr[{0}]/td", row);
                int columnnumber = WebDriver.driver.FindElements(By.XPath(xpathcolumn)).Count;
                for (int column = 1; column <= columnnumber; column++)
                {
                    string xpathCheckbox = string.Format("//*[@id='profilesettings']/tbody/tr[{0}]/td[{1}]//input[@type = 'checkbox']", row, column);
                    Console.WriteLine(row);
                    Console.WriteLine(column);
                    if (WebDriver.driver.FindElement(By.XPath(xpathCheckbox)).Selected == true)
                    {
                        check = false;
                        break;
                    }
                }
            }
            return check;
        }
    }
}
