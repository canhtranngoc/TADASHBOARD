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
            SelectValueDropdownList("series combobox", name);
            Click("ok button");
        }
        public string GetErrorMessage()
        {
            return GetTextAlert();
        }
        public void CloseNewPanelDialog()
        {
            Click("cancel button");
        }
        public void CheckChartTypeOptions()
        {
            // Wait 1 second for the New Panel Dialog to load
            Sleep(1);
            int count = CountComboboxChildren("//select[@id='cbbChartType']/option");
            for (int i = 1; i <= count; i++)
            {
                string actual = GetTextDynamicElement("chart type child", i.ToString());
                i = Convert.ToInt32(i);
                CheckTextDisplays(TestData.chartTypeArray[i - 1], actual);
            }
        }
        public void selectChartType(string chartType)
        {
            Sleep(1);
            SelectValueDropdownList("chart type combobox", chartType);
        }


        public bool checkStatuses(string chartType)
        {
            return checkStatus(chartType);
        }
        public bool checkStatus(string chartType)
        {
            bool check = false;
            switch (chartType)
            {
                case "Stacked Bar":
                    if (FindWebElement("category combobox").Text.Contains(""))
                    {                   
                        return check = true;                    
                    }
                    else
                    {
                        Console.WriteLine("hi");
                    }
                    break;
                case "":
                    break;
            }
            return check;
        }
    }
}
