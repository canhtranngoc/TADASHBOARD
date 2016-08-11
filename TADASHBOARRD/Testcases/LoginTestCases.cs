using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TADASHBOARRD.Common;
using TADASHBOARRD.PageActions.LoginPage;
using TADASHBOARRD.PageActions.GeneralPage;
using TADASHBOARRD.PageActions;
using TADASHBOARRD.PageActions.GeneralPage;


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
            generalPage.Logout();
        }

        [TestMethod]
        public void DA_LOGIN_TC006_Verify_that_Password_input_is_case_sensitive()
        {
            NavigateTADashboard();
            LoginPage loginPage = new LoginPage();
            loginPage.Login(TestData.defaulRepository, TestData.testUsername, TestData.testUppercasePassword);
            GeneralPage generalPage = new GeneralPage();
            string actual = generalPage.GetUserName();
            CheckTextDisplays(actual, TestData.testUsername);
            generalPage.Logout();
            loginPage.Login(TestData.defaulRepository, TestData.testUsername, TestData.testLowercasePassword);
            string actualMessage = generalPage.GetTextPopup();
            CheckTextDisplays(actualMessage, TestData.errorLoginMessage);
            generalPage.ConfirmPopup();
        }

        [TestMethod]
        public void DA_LOGIN_TC008_Verify_that_password_with_special_characters_is_working_correctly()
        {

        }

    }
}
