﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TADASHBOARRD.PageActions.LoginPage;
using TADASHBOARRD.PageActions.GeneralPage;
using TADASHBOARRD.Common;

namespace TADASHBOARRD.Testcases
{
    [TestClass]
    public class MainPageTestCases : BaseTest
    {
        private LoginPage loginPage;
        private GeneralPage generalPage;
        private NewPageDialog newPageDialog;
        private EditPageDialog editPageDialog;

        [TestMethod]
        public void DA_MP_TC020_Verify_that_user_is_able_to_delete_sibbling_page_as_long_as_that_page_has_not_children_page_under_it()
        {
            loginPage = new LoginPage();
            loginPage.Login(TestData.defaulRepository, TestData.validUsername, TestData.validPassword);
            generalPage = new GeneralPage();
            generalPage.OpenAddPageDialog();
            newPageDialog = new NewPageDialog();
            string pageName1 = GetDateTime();
            newPageDialog.CreateNewPage(pageName1, TestData.overviewPage, TestData.blankNumberOfColumns, TestData.blankDisplayAfter, TestData.statusPublic);
            generalPage.OpenAddPageDialog();
            newPageDialog = new NewPageDialog();
            string pageName2 = GetDateTime();
            newPageDialog.CreateNewPage(pageName2, pageName1, TestData.blankNumberOfColumns, TestData.blankDisplayAfter, TestData.statusPublic);
            generalPage.goToPage(TestData.overviewPage + "/" + pageName1);
            generalPage.PerformDelete();
            string actualMessage = generalPage.GetTextAlert();
            //VP: Check message "Can't delete page "page 1" since it has children page"
            generalPage.CheckDynamicTextDisplays(pageName1, actualMessage);
        }

        [TestMethod]
        public void DA_MP_TC021_Verify_that_user_is_able_to_edit_the_name_of_the_page_Parent_and_Sibbling_successfully()
        {
            loginPage = new LoginPage();
            loginPage.Login(TestData.defaulRepository, TestData.validUsername, TestData.validPassword);
            generalPage = new GeneralPage();
            generalPage.OpenAddPageDialog();
            newPageDialog = new NewPageDialog();
            string pageName1 = GetDateTime();

            newPageDialog.CreateNewPage(pageName1, TestData.overviewPage, TestData.defaultNumberOfColumns, TestData.defaultDisplayAfter, TestData.statusNotPublic);

            generalPage.OpenAddPageDialog();
            newPageDialog = new NewPageDialog();
            string pageName2 = GetDateTime();

            newPageDialog.CreateNewPage(pageName2, pageName1, TestData.defaultNumberOfColumns, TestData.defaultDisplayAfter, TestData.statusNotPublic);
            generalPage.goToPage(TestData.overviewPage + "/" + pageName1);

            generalPage.OpenEditPageDialog();
            editPageDialog = new EditPageDialog();
            string pageName1Edit = GetDateTime();

            editPageDialog.EditPage(pageName1Edit, TestData.defaultParentPage, TestData.defaultNumberOfColumns, TestData.defaultDisplayAfter, TestData.statusNotPublic);
            // VP: User is able to edit the name of parent page successfully
            string pageName1AfterEdit = generalPage.GetPageNameOfPageOpened();
            Console.WriteLine(pageName1AfterEdit);
            CheckTextDisplays(pageName1Edit, pageName1AfterEdit);

            generalPage.goToPage(TestData.overviewPage + "/" + pageName1Edit + "/" + pageName2);
            generalPage.OpenEditPageDialog();
            editPageDialog = new EditPageDialog();
            string pageName2Edit = GetDateTime();

            editPageDialog.EditPage(pageName2Edit, TestData.defaultParentPage, TestData.defaultNumberOfColumns, TestData.defaultDisplayAfter, TestData.statusNotPublic);
            string pageName2AfterEdit = generalPage.GetPageNameOfPageOpened();
            // VP: User is able to edit the name of sibbling page successfully
            Console.WriteLine(pageName2AfterEdit);
            CheckTextDisplays(pageName2Edit, pageName2AfterEdit);

            // Post-Condition
            generalPage.DeleteAllPages();
            generalPage.Logout();
        }
    }
}
