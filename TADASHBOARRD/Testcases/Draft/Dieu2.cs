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
            loginPage.Login(TestData.defaulRepository, "dieu.nguyen", "123");
            GeneralPage generalPage = new GeneralPage();

            generalPage.OpenAddPageDialog();
            NewPageDialog newPageDialog = new NewPageDialog();
            newPageDialog.CreateNewPage("Dieu1", "", "", "", "");

            generalPage.OpenAddPageDialog();
            newPageDialog.CreateNewPage("Dieu11", "Dieu1", "", "", "");

            generalPage.OpenAddPageDialog();
            newPageDialog.CreateNewPage("Dieu22", "Dieu1", "", "", "");

            //Thread.Sleep(1000);
            //generalPage.OpenOverviewPage();     
            generalPage.DeletePages();
        }
    }
}
