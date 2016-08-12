using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TADASHBOARRD.Common;

namespace TADASHBOARRD.PageActions.PanelsPage
{
    public class NewPanelDialog: GeneralPage.GeneralPage
    {
        public void AddNewPanel(string name, string series)
        {
            System.Threading.Thread.Sleep(1000);
            EnterValue("display name textbox", name);
            SelectItemByText("series dropdown list", series);
            Click("ok button");
        }
        public void DeletePanel()
        {

        }
    }
}
