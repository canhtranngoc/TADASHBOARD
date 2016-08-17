using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TADASHBOARRD.Common;
using TADASHBOARRD.PageActions.PanelsPage;
using TADASHBOARRD.PageActions.GeneralPage;
using TADASHBOARRD.PageActions.DataProfilesPage;
using TADASHBOARRD.PageActions.LoginPage;

namespace TADASHBOARRD.Testcases
{
    [TestClass]
    public class BaseTest : CommonActions
    {
        public TestContext TestContext { get; set; }
        NewPanelDialog newPanelDialog = new NewPanelDialog();
        DataProfilesPage dataProfilesPage = new DataProfilesPage();

        [AssemblyInitialize]
        public static void AssemblyInitializeMeThod(TestContext testContext)
        {
            BrowserManager.OpenBrowser(TestData.browser);
        }

        [AssemblyCleanup]
        public static void AssemblyCleapUpMethod()
        {
            BrowserManager.CloseBrowser();
        }

        [TestInitialize]
        public void TestInitializeMethod()
        {
            NavigateTADashboard();
        }
        [TestCleanup]
        public void TestCleanupMethod()
        {
            switch(TestContext.TestName)
            {
                case "DA_PANEL_TC030_Verify_that_no_special_character_is_allowed_to_be_inputted_into_Display_Name_field":
                    newPanelDialog.AcceptAlert();
                    newPanelDialog.CloseNewPanelDialog();
                    newPanelDialog.Logout();
                    WebDriver.driver.Manage().Cookies.DeleteAllCookies();
                    break;
                case "DA_DP_TC076_Verify_that_for_newly_created_data_profile_user_is_able_to_navigate_through_other_setting_pages_on_the_left_navigation_panel":
                    dataProfilesPage.OpenDataProfilesPage();
                    dataProfilesPage.DeleteAllProfiles();
                    dataProfilesPage.Logout();                    
                    break;
                default:
                    WebDriver.driver.Manage().Cookies.DeleteAllCookies();
                    break;
            }       
        }
    }
}
