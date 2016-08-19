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

        public void DeleteAllProfiles()
        {
            if (DoesElementPresent("check all link")==true)
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
            Sleep(1);
            string xpathDataProfile = string.Format("//a[.='{0}']", name);
            ClickItemXpath(xpathDataProfile);
            CheckDataProfileSettingHeader("display fields tab", TestData.displayFields);
            CheckDataProfileSettingHeader("sort fields tab", TestData.sortFields);
            CheckDataProfileSettingHeader("filter fields tab", TestData.filterFields);
            CheckDataProfileSettingHeader("statistic fields tab", TestData.statisticFields);
            CheckDataProfileSettingHeader("display sub-fields tab", TestData.displaySubFields);
            CheckDataProfileSettingHeader("sort sub-fields tab", TestData.sortSubFields);
            CheckDataProfileSettingHeader("filter sub - fields tab", TestData.filterSubFields);
            CheckDataProfileSettingHeader("statistic sub-fields tab", TestData.statisticSubFields);
        }
        public void CheckDataProfileSettingHeader(string tab, string header)
        {
            Click(tab);
            // Wait for new page to load
            Sleep(1);
            CheckTextDisplays(header, GetText("fields header"));
        }
    }
}
