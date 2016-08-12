using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TADASHBOARRD.Common;
using TADASHBOARRD.PageActions.LoginPage;
using TADASHBOARRD.PageActions.GeneralPage;
using System.Threading;

namespace TADASHBOARRD.Testcases.Draft
{
    [TestClass]
    public class Dieu2: BaseTest
    {
        [TestMethod]
        public void TestMethod2()
        {
            NavigateTADashboard();
            LoginPage loginPage = new LoginPage();
            loginPage.Login(TestData.defaulRepository, TestData.validUsername, TestData.validPassword);
            GeneralPage generalPage = new GeneralPage();

            //generalPage.OpenAddPageDialog();
            //NewPageDialog newPageDialog = new NewPageDialog();
            //newPageDialog.CreateNewPage("Dieu", "", "", "", "");

            //generalPage.OpenAddPageDialog();
            //newPageDialog.CreateNewPage("Dieu1", "Dieu", "", "", "");

            //generalPage.OpenAddPageDialog();
            //newPageDialog.CreateNewPage("Dieu2", "Dieu1", "", "", "");
            Thread.Sleep(2000);
            generalPage.DeletePages();
        }
    }
}
