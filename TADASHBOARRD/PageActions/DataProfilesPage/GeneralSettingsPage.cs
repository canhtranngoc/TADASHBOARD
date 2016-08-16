using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TADASHBOARRD.PageActions.DataProfilesPage
{
    class GeneralSettingsPage : GeneralPage.GeneralPage
    {
        public void ClickNextWithoutName()
        {
            Click("next button");
        }
        public void ClickFinishWithoutName()
        {
            Click("finish button");
        }
        public void CancelGeneralSettings()
        {
            Click("cancel button");
        }

        public void CreateNewProfile(string name, string itemtype, string relateddata)
        {
            EnterValue("name textbox", name);
            EnterValueDropdownList("item type combobox",itemtype);
            EnterValueDropdownList("related data combobox",relateddata);
            Click("finish button");
        }
    }
}
