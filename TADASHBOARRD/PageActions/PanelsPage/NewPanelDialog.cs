using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TADASHBOARRD.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;


namespace TADASHBOARRD.PageActions.PanelsPage
{
    public class NewPanelDialog : GeneralPage.GeneralPage
    {
        public void AddNewPanel(string name, string series)
        {
            Sleep(1);
            EnterValue("display name textbox", name);
            EnterValueDropdownList("series dropdown list", name);
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
        public void CheckChartTypeOptions()
        {
            // Wait 1 second for the New Panel Dialog to load
            Sleep(1);
            for (int i = 1; i <= 5; i++)
            {
                string actual = GetTextDynamicElement("chart type child", i.ToString());
                Console.WriteLine(actual);
                i = Convert.ToInt32(i);
                CheckTextDisplays(TestData.chartTypeArray[i - 1], actual);
            }
        }
    }
}
