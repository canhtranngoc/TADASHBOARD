using System;
using TADASHBOARRD.Common;

namespace TADASHBOARRD.PageActions.PanelsPage
{
    public class NewPanelDialog: GeneralPage.GeneralPage
    {
        #region Methods

        /// <summary>
        /// Method a add new panel
        /// </summary>
        public void AddNewPanel(string name, string series)
        {
            EnterValue("display name textbox", name);
            SelectValueDropdownList("series combobox", series);
            Click("ok button");
        }

        /// <summary>
        /// Method to close new panel dialog
        /// </summary>
        public void CloseNewPanelDialog()
        {
            Click("cancel button");
        }

        /// <summary>
        /// Method to check all options of chart type
        /// </summary>
        public void CheckChartTypeOptions()
        {
            WaitInSpecificTime(10);
            int count = CountComboboxChildren("//select[@id='cbbChartType']/option");
            for (int i = 1; i <= count; i++)
            {
                string actual = GetTextDynamicElement("chart type child", i.ToString());
                i = Convert.ToInt32(i);
                CheckTextDisplays(TestData.chartTypeArray[i - 1], actual);
            }
        }

        #endregion
    }
}
