using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TADASHBOARRD.Common;
using TADASHBOARRD.PageActions;
using TADASHBOARRD.PageActions.LoginPage;
using TADASHBOARRD.PageActions.GeneralPage;

namespace TADASHBOARRD.Testcases
{
    [TestClass]
    public class UnitTest1:BaseTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            NavigateTADashboard();
            LoginPage loginPage = new LoginPage();
            loginPage.Login(TestData.defaulRepository, TestData.validUsername, TestData.validPassword);
        }
    }
}
