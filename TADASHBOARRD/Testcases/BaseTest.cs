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
        public void TestInitializeMothod()
        {
            NavigateTADashboard();
        }
        [TestCleanup]
        public void TestCleanupMothod()
        {
            switch(TestContext.TestName)
            {
                case "DA_PANEL_TC030_Verify_that_no_special_character_is_allowed_to_be_inputted_into_Display_Name_field":
                    newPanelDialog.AcceptAlert();
                    newPanelDialog.CloseNewPanelDialog();
                    newPanelDialog.Logout();
                    break;

                default:
                    WebDriver.driver.Manage().Cookies.DeleteAllCookies();
                    break;
            }
            
        }

    }
}
