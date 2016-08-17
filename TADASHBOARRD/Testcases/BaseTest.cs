using Microsoft.VisualStudio.TestTools.UnitTesting;
using TADASHBOARRD.Common;
using TADASHBOARRD.PageActions.PanelsPage;
using TADASHBOARRD.PageActions.GeneralPage;

namespace TADASHBOARRD.Testcases
{
    [TestClass]
    public class BaseTest : CommonActions
    {
        public TestContext TestContext { get; set; }
        NewPanelDialog newPanelDialog = new NewPanelDialog();
        GeneralPage generalPage = new GeneralPage();

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
            switch (TestContext.TestName)
            {
                case "DA_PANEL_TC030_Verify_that_no_special_character_is_allowed_to_be_inputted_into_Display_Name_field":
                    newPanelDialog.AcceptAlert();
                    newPanelDialog.CloseNewPanelDialog();
                    newPanelDialog.Logout();
                    break;
                case "DA_MP_TC020_Verify_that_user_is_able_to_delete_sibbling_page_as_long_as_that_page_has_not_children_page_under_it":
                    generalPage.AcceptAlert();
                    generalPage.DeleteAllPages();
                    generalPage.Logout();
                    break;
                default:
                    WebDriver.driver.Manage().Cookies.DeleteAllCookies();
                    break;
            }

        }

    }
}
