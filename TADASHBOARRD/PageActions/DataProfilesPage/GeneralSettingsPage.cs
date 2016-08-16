using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TADASHBOARRD.Common;

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

        public void CheckItemTypeOptions()
        {
            // Wait 1 second for the Dialog to load
            Sleep(1);
            int count = CountComboboxChildren("//select[@id='cbbEntityType']/option");
            //Console.WriteLine(count);
            for (int i = 1; i <= count; i++)
            {
                string actual = GetTextDynamicElement("item type combobox child", i.ToString());
                Console.WriteLine(actual);
                i = Convert.ToInt32(i);
                CheckTextDisplays(TestData.itemTypeArray[i - 1], actual);
            }
        }
    }
}
