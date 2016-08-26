using System;
using TADASHBOARRD.Common;

namespace TADASHBOARRD.PageActions.DataProfilesPage
{
    class GeneralSettingsPage : GeneralPage.GeneralPage
    {
        #region Methods

        ///<summary>
        /// Method to cancel general settings
        ///</summary>
        public void CancelGeneralSettings()
        {
            Click("cancel button");
        }

        ///<summary>
        /// Method to create a new data profile
        ///</summary>
        public void CreateNewProfile(string name, string itemtype, string relateddata, string action)
        {
            // Sleep 1 second before enter value
            Sleep(1);
            EnterValue("name textbox", name);
            SelectValueDropdownList("item type combobox", itemtype);
            SelectValueDropdownList("related data combobox", relateddata);
            if (action.ToUpper() == "FINISH")
            {
                Click("finish button");
            }
            else if (action.ToUpper() == "NEXT")
            {
                Click("next button");
            }
        }

        ///<summary>
        /// Method to check item type options display correctly or not
        ///</summary>
        public void CheckItemTypeOptions()
        {
            WaitInSpecificTime(10);
            int count = CountComboboxChildren("//select[@id='cbbEntityType']/option");
            for (int i = 1; i <= count; i++)
            {
                string actual = GetTextDynamicElement("item type combobox child", i.ToString());
                Console.WriteLine(actual);
                i = Convert.ToInt32(i);
                CheckTextDisplays(TestData.itemTypeArray[i - 1], actual);
            }
        }

        #endregion
    }
}
