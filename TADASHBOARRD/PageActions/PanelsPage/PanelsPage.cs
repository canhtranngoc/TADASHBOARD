using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TADASHBOARRD.Common;
using TADASHBOARRD.PageActions.GeneralPage;
using OpenQA.Selenium;

namespace TADASHBOARRD.PageActions.PanelsPage
{
    public class PanelsPage:GeneralPage.GeneralPage
    {
        public void OpenNewPanelDialog()
        {
            Sleep(1);
            Click("addnew link");
        }

        public void DeletePanel(string name)
        {
            //string xpathLinkDelete = string.Format("//tbody//a[.='{0}']/../..//a[.='Delete']", name);
            //WebDriver.driver.FindElement(By.XPath(xpathLinkDelete)).Click();
            //FindDynamicWebElements("delete link",name).Click();
            ClickOnDynamicElement("delete link", name);
            AcceptAlert();
        }

        public void DeleteAllPanels()
        {
            try
            {
                Click("checkall link");
                Click("delete link");
                AcceptAlert();
            }
            catch (WebDriverException)
            {
                Console.WriteLine("no panels display");
            }
        }

    }
}
