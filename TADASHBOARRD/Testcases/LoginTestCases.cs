using Microsoft.VisualStudio.TestTools.UnitTesting;
using TADASHBOARRD.Common;
using TADASHBOARRD.PageActions.LoginPage;
using TADASHBOARRD.PageActions.GeneralPage;

namespace TADASHBOARRD.Testcases
{
    [TestClass]
    public class LoginTestCases:BaseTest
    {
        [TestMethod]
        public void DA_LOGIN_TC001_Verify_that_user_can_login_specific_repository_successfully_via_Dashboard_login_page_with_correct_credentials()
        {
            LoginPage loginPage = new LoginPage();
            loginPage.Login(TestData.defaulRepository, TestData.validUsername, TestData.validPassword);
            GeneralPage generalPage = new GeneralPage();
            string actual= generalPage.GetUserName();
            CheckTextDisplays(actual, TestData.validUsername);
            generalPage.Logout();
        }

        [TestMethod]
        public void DA_LOGIN_TC002_Verify_that_user_fails_to_login_specific_repository_successfully_via_Dashboard_login_page_with_incorrect_credentials()
        {
            LoginPage loginPage = new LoginPage();
            loginPage.Login(TestData.defaulRepository, TestData.invalidUsername, TestData.invalidPassword);
            string actual = loginPage.GetTextPopup();
            CheckTextDisplays(TestData.errorLoginMessage, actual);
            loginPage.ClosePopup();
        }

        [TestMethod]
        public void DA_LOGIN_TC004_Verify_that_user_is_able_to_login_different_repositories_successfully_after_logging_out_current_repository()
        {
            LoginPage loginPage = new LoginPage();
            loginPage.Login(TestData.defaulRepository, TestData.validUsername, TestData.validPassword);
            GeneralPage generalPage = new GeneralPage();
            generalPage.Logout();
            loginPage.Login(TestData.testRepository, TestData.validUsername, TestData.validPassword);
            string actual = generalPage.GetUserName();
            CheckTextDisplays(TestData.validUsername, actual);
            generalPage.Logout();
        }

        [TestMethod]
        public void DA_LOGIN_TC006_Verify_that_Password_input_is_case_sensitive()
        {
            LoginPage loginPage = new LoginPage();
            loginPage.Login(TestData.defaulRepository, TestData.testUsername, TestData.testUppercasePassword);
            GeneralPage generalPage = new GeneralPage();
            string actual = generalPage.GetUserName();
            CheckTextDisplays(actual, TestData.testUsername);
            generalPage.Logout();
            loginPage.Login(TestData.defaulRepository, TestData.testUsername, TestData.testLowercasePassword);
            string actualMessage = generalPage.GetTextPopup();
            CheckTextDisplays(TestData.errorLoginMessage, actualMessage);
            generalPage.ClosePopup();
        }

        [TestMethod]
        public void DA_LOGIN_TC008_Verify_that_password_with_special_characters_is_working_correctly()
        {
            LoginPage loginPage = new LoginPage();
            loginPage.Login(TestData.defaulRepository, TestData.specialUsername, TestData.specialCharactersPassword);
            GeneralPage generalPage = new GeneralPage();
            string actual = generalPage.GetUserName();
            CheckTextDisplays(TestData.specialUsername, actual);
            generalPage.Logout();
        }



    }
}
