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
            Sleep(1);
            EnterValue("display name textbox", name);
            EnterValueDropdownList("series combobox", name);
            Click("ok button");
        }
        public string GetErrorMessage()
        {
            return GetTextPopup();
        }
        public void CloseNewPanelDialog()
        {
            Click("cancel button");
        }
       
    }
}
