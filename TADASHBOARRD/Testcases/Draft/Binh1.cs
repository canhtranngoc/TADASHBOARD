using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TADASHBOARRD.PageActions.LoginPage;
using TADASHBOARRD.Common;
using TADASHBOARRD.PageActions.GeneralPage;
using System.Threading;

namespace TADASHBOARRD.Testcases.Draft
{
    [TestClass]
    public class Binh1:BaseTest
    {
        public void Binh()
        {
            NavigateTADashboard();
            LoginPage loginPage = new LoginPage();
            loginPage.Login(TestData.defaulRepository, TestData.validUsername, TestData.validPassword);
            GeneralPage generalPage = new GeneralPage();
            generalPage.PerformDelete();
            generalPage.OpenAddPageDialog();
            NewPageDialog newPageDialog = new NewPageDialog();
            newPageDialog.CreateNewPage("Binh", "", "", "", "");
            generalPage.OpenAddPageDialog();
            newPageDialog.CreateNewPage("Binh1", "Binh", "", "", "");
            generalPage.OpenAddPageDialog();
            newPageDialog.CreateNewPage("Binh2", "Binh", "", "", "");
            generalPage.PerformDelete();
        }
    }
}
