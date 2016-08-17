using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TADASHBOARRD.Common;

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
            for (int i = 1; i <= 5; i++)
            {
                string actual = FindDynamicWebElement("chart type child", i.ToString()).Text;
                i = Convert.ToInt32(i);
                CheckTextDisplays(TestData.chartTypeArray[i], actual);
            }
        }
        public void selectChartType(string chartType)
        {
            Sleep(1);
            EnterValueDropdownList("chart type combobox", chartType);
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
                    //if (FindWebElement("category combobox").GetAttribute("disable") == "")
                    //{
                    //    return check = true;
                    //}
                    break;
                case "":
                    break;
            }
            return check;

        }
    }
}
