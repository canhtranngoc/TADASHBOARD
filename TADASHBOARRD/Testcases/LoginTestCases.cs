using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TADASHBOARRD.Common;
using TADASHBOARRD.PageActions.LoginPage;
using TADASHBOARRD.PageActions.GeneralPage;
using TADASHBOARRD.PageActions;

namespace TADASHBOARRD.Testcases
{
    [TestClass]
    public class LoginTestCases:BaseTest
    {
        [TestMethod]
        public void DA_LOGIN_TC001_Verify_that_user_can_login_specific_repository_successfully_via_Dashboard_login_page_with_correct_credentials()
        {
            NavigateTADashboard();
            LoginPage loginPage = new LoginPage();
            loginPage.Login(TestData.defaulRepository, TestData.validUsername, TestData.validPassword);
            GeneralPage generalPage = new GeneralPage();
            string actual= generalPage.GetUserName();
            CheckTextDisplays(actual, TestData.validUsername);
        }

        [TestMethod]
        public void DA_LOGIN_TC004_Verify_that_user_is_able_to_log_in_different_repositories_successfully_after_logging_out_current_repository()
        {
            NavigateTADashboard();
            LoginPage loginPage = new LoginPage();
            loginPage.Login(TestData.defaulRepository, TestData.validUsername,TestData.validPassword);


            GeneralPage generalPage = new GeneralPage();
            generalPage.Logout();

            loginPage.Login(TestData.testRepository, TestData.validUsername, TestData.validPassword);


        }
    }
}
