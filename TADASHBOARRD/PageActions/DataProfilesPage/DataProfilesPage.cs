using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using TADASHBOARRD.Common;

namespace TADASHBOARRD.PageActions.DataProfilesPage
{
    public class DataProfilesPage : GeneralPage.GeneralPage
    {
        ///<summary>
        ///
        ///</summary>
        public void OpenCreateProfilePageFromDataProfilesPage()
        {
            Sleep(1);
            Click("add new link");
        }

        ///<summary>
        ///
        ///</summary>
        // Viet thanh dynamic jason
        public void DeleteProfile(string name)
        {
            ClickOnDynamicElement("delete a profile link", name);
            AcceptAlert();
        }

        ///<summary>
        ///
        ///</summary>
        // Xem lai Does Element roi the vao day
        public void DeleteAllProfiles()
        {
            if (DoesElementPresent("check all link") == true)
            {
                Click("check all link");
                Click("delete link");
                AcceptAlert();
            }
        }

        ///<summary>
        ///
        ///</summary>
        public void CheckDataProfileOtherSettingPages(string name)
        {
            // Wait for page loads
            Sleep(1);
            string xpathDataProfile = string.Format("//a[.='{0}']", name);
            WebDriver.driver.FindElement(By.XPath(xpathDataProfile)).Click();
            Click("display fields tab");
            // Wait for page loads
            Sleep(1);
            CheckTextDisplays(TestData.displayFields, GetText("fields header"));
            Click("sort fields tab");
            // Wait for page loads
            Sleep(1);
            CheckTextDisplays(TestData.sortFields, GetText("fields header"));
            Click("filter fields tab");
            // Wait for page loads
            Sleep(1);
            CheckTextDisplays(TestData.filterFields, GetText("fields header"));
            Click("statistic fields tab");
            // Wait for page loads
            Sleep(1);
            CheckTextDisplays(TestData.statisticFields, GetText("fields header"));
            Click("display sub-fields tab");
            // Wait for page loads
            Sleep(1);
            CheckTextDisplays(TestData.displaySubFields, GetText("fields header"));
            Click("sort sub-fields tab");
            // Wait for page loads
            Sleep(1);
            CheckTextDisplays(TestData.sortSubFields, GetText("fields header"));
            Click("filter sub-fields tab");
            // Wait for page loads
            Sleep(1);
            CheckTextDisplays(TestData.filterSubFields, GetText("fields header"));
            Click("statistic sub-fields tab");
            // Wait for page loads
            Sleep(1);
            CheckTextDisplays(TestData.statisticSubFields, GetText("fields header"));
        }
    }
}
