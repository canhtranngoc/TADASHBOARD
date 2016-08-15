using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using TADASHBOARRD.Common;

namespace TADASHBOARRD.PageActions.DataProfilesPage
{
    public class DataProfilesPage : GeneralPage.GeneralPage
    {
        public void OpenCreateProfilePageFromDataProfilesPage()
        {
            Sleep(1);
            Click("add new link");
        }

        public void DeleteProfile(string name)
        {
            string xpathLinkDelete = string.Format("//tbody//a[.='{0}']/../..//a[.='Delete']", name);
            WebDriver.driver.FindElement(By.XPath(xpathLinkDelete)).Click();
            AcceptAlert();
        }

    }
}
