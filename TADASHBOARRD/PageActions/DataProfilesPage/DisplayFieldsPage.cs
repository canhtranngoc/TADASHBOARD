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

        public void ClickCheckAllLink()
        {
            Click("checkall link");
        }

        public void ClickUnCheckAllLink()
        {
            Click("uncheckall link");
        }

        public bool AreAllCheckboxChecked()
        {
            bool check = true;
            int n = WebDriver.driver.FindElements(tableDisplayFields).Count;
            Console.WriteLine(n);
            for (int cot = 1; cot <=2; cot++)
            {
                for (int dong = 3; dong < n - 1; dong++)
                {
                    string xpathCheckbox = string.Format("//*[@id='profilesettings']/tbody/tr[{0}]/td[{1}]//input[@type = 'checkbox']", dong, cot);
                    if (WebDriver.driver.FindElement(By.XPath(xpathCheckbox)).Selected == false)
                    {
                        check = false;
                        break;
                    }
                }
            }
            return check;
        }

        public bool AreAllCheckboxUnChecked()
        {
            bool check = true;
            int n = WebDriver.driver.FindElements(tableDisplayFields).Count;
            Console.WriteLine(n);
            for (int cot = 1; cot <= 2; cot++)
            {
                for (int dong = 3; dong < n - 1; dong++)
                {
                    string xpathCheckbox = string.Format("//*[@id='profilesettings']/tbody/tr[{0}]/td[{1}]//input[@type = 'checkbox']", dong, cot);
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
