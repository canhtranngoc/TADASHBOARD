using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TADASHBOARRD.PageActions.LoginPage;
using TADASHBOARRD.PageActions.GeneralPage;
using TADASHBOARRD.Common;

namespace TADASHBOARRD.Testcases.Draft
{
    [TestClass]
    public class Binh2:BaseTest
    {
        [TestMethod]
        public void testbinh()
        {
            NavigateTADashboard();
            LoginPage loginPage = new LoginPage();
            loginPage.Login(TestData.defaulRepository, TestData.validUsername, TestData.validPassword);
            GeneralPage generalPage = new GeneralPage();
            generalPage.gotoPage("Overview/binh");
            generalPage.PerformDelete();
        }
    }
}
