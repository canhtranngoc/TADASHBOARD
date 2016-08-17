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
    public class MainPageTestCases : BaseTest
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
            generalPage.OpenAddPageDialog();
            newPageDialog = new NewPageDialog();
            string pageName = CommonActions.GetDateTime();
            newPageDialog.CreateNewPage(pageName, TestData.defaultParentPage, TestData.defaultNumberOfColumns, TestData.defaultDisplayAfter, TestData.statusNotPublic);
            string actualPageName = generalPage.GetSecondPageName();
            // VP: Check "Test" page is displayed besides "Overview" page
            CheckTextDisplays(pageName, actualPageName);
            // Post-Condition
            generalPage.DeleteAllPages();
            generalPage.Logout();
        }

        [TestMethod]
        public void DA_MP_TC014_Verify_that_Public_pages_can_be_visible_and_accessed_by_all_users_of_working_repository()
        {
            loginPage = new LoginPage();
            loginPage.Login(TestData.defaulRepository, TestData.validUsername, TestData.validPassword);
            generalPage = new GeneralPage();
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
            generalPage.Logout();
        }

        [TestMethod]
        public void DA_MP_TC026_Verify_that_page_column_is_correct_when_user_edit_Number_of_Columns_field_of_a_specific_page()
        {
            loginPage = new LoginPage();
            loginPage.Login(TestData.defaulRepository, TestData.validUsername, TestData.validPassword);
            generalPage = new GeneralPage();
            generalPage.OpenAddPageDialog();
            newPageDialog = new NewPageDialog();
            string pageName = GetDateTime();
            newPageDialog.CreateNewPage(pageName, TestData.defaultParentPage, TestData.defaultNumberOfColumns, TestData.defaultDisplayAfter, TestData.statusNotPublic);
            generalPage.OpenPage(pageName);
            generalPage.OpenEditPageDialog();
            newPageDialog.EditPage(TestData.newPageName, TestData.defaultParentPage, TestData.newNumberOfColumns, TestData.defaultDisplayAfter, TestData.statusNotPublic);
            generalPage.OpenEditPageDialog();
            string numberOfColumns = newPageDialog.GetSelectedValueInNumberOfColumns();
            // VP: There are 3 columns on the above created page
            CheckTextDisplays(numberOfColumns,TestData.newNumberOfColumns);
            // Post-Condition
            generalPage.DeleteAllPages();
            generalPage.Logout();
        }
    }
}
