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
            Click("add new link");
        }

        public void DeletePanel(string name)
        {
            ClickOnDynamicElement("delete a panel link", name);
            AcceptAlert();
        }

        public void DeleteAllPanels()
        {
            try
            {
                Click("check all link");
                Click("delete link");
                AcceptAlert();
            }
            catch (WebDriverException)
            {
                Console.WriteLine("no panel displays");
            }
        }

    }
}
