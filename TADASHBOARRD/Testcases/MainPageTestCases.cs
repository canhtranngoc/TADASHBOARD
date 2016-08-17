using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TADASHBOARRD.PageActions.LoginPage;
using TADASHBOARRD.PageActions.GeneralPage;
using TADASHBOARRD.Common;
using TADASHBOARRD.PageActions.PanelsPage;
using System.Threading;

namespace TADASHBOARRD.Testcases
{
    [TestClass]
    public class MainPageTestCases:BaseTest
    {
        private LoginPage loginPage;
        private GeneralPage generalPage;
        private NewPageDialog newPageDialog;
        [TestMethod]
        public void DA_MP_TC012_Verify_that_user_is_able_to_add_additional_pages_besides_Overview_page_successfully()
        {
            loginPage = new LoginPage();
            loginPage.Login(TestData.defaulRepository, TestData.validUsername, TestData.validPassword);
            generalPage = new GeneralPage();
            generalPage.DeleteAllPages();
            generalPage.OpenAddPageDialog();
            newPageDialog= new NewPageDialog();
            string pageName = CommonActions.GetDateTime();
            newPageDialog.CreateNewPage(pageName, TestData.defaultParentPage, TestData.defaultNumberOfColumns, TestData.defaultDisplayAfter, TestData.statusNotPublic);
            string actualPageName = generalPage.GetSecondPageName();
            // VP: Check "Test" page is displayed besides "Overview" page
            CheckTextDisplays(pageName, actualPageName);
            // Post-Condition
            generalPage.DeleteAllPages();
        }

        [TestMethod]
        public void DA_MP_TC014_Verify_that_Public_pages_can_be_visible_and_accessed_by_all_users_of_working_repository()
        {
            loginPage = new LoginPage();
            loginPage.Login(TestData.defaulRepository, TestData.validUsername, TestData.validPassword);
            generalPage = new GeneralPage();
            generalPage.DeleteAllPages();
            generalPage.OpenAddPageDialog();
            newPageDialog = new NewPageDialog();
            string pageName = CommonActions.GetDateTime();
            newPageDialog.CreateNewPage(pageName, TestData.defaultParentPage, TestData.defaultNumberOfColumns, TestData.defaultDisplayAfter, TestData.statusPublic);
            generalPage.Logout();
            loginPage.Login(TestData.defaulRepository, TestData.anotherValidUsername, TestData.anotherValidPassword);
            // VP: Check newly added page is visibled
            generalPage.CheckPageDisplays(pageName);
            // Post-Condition
            generalPage.Logout();
            loginPage.Login(TestData.defaulRepository, TestData.validUsername, TestData.validPassword);
            generalPage.DeleteAllPages();
        }

        [TestMethod]
        public void DA_MP_TC020_Verify_that_user_is_able_to_delete_sibbling_page_as_long_as_that_page_has_not_children_page_under_it()
        {
            loginPage = new LoginPage();
            loginPage.Login(TestData.defaulRepository, TestData.validUsername, TestData.validPassword);
            generalPage = new GeneralPage();
            generalPage.DeleteAllPages();
            generalPage.OpenAddPageDialog();
            newPageDialog = new NewPageDialog();
            string pageName1 = CommonActions.GetDateTime();
            newPageDialog.CreateNewPage(pageName1, TestData.overviewPage, TestData.blankNumberOfColumns, TestData.blankDisplayAfter, TestData.statusPublic);
            generalPage.OpenAddPageDialog();
            newPageDialog = new NewPageDialog();
            string pageName2 = CommonActions.GetDateTime();
            newPageDialog.CreateNewPage(pageName2, pageName1, TestData.blankNumberOfColumns, TestData.blankDisplayAfter, TestData.statusPublic);
            generalPage.GotoPage(TestData.overviewPage+"/"+pageName1);
            generalPage.PerformDelete();
            string actualMessage = generalPage.GetTextPopup();
            generalPage.CheckDynamicTextDisplays(pageName1,actualMessage);
        }
    }
}
