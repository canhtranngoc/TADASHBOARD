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
    public class MainPageTestCases:BaseTest
    {
        [TestMethod]
        public void DA_MP_TC012_Verify_that_user_is_able_to_add_additional_pages_besides_Overview_page_successfully()
        {
            NavigateTADashboard();
            LoginPage loginPage = new LoginPage();
            loginPage.Login(TestData.defaulRepository, TestData.validUsername, TestData.validPassword);
            GeneralPage generalPage = new GeneralPage();
            generalPage.OpenAddPageDialog();
            NewPageDialog newPageDialog= new NewPageDialog();
            newPageDialog.CreateNewPage("canh9","", "", "","public");

            generalPage.OpenAddPageDialog();
            newPageDialog.CreateNewPage("canh6", "canh9", "", "", "public");

            generalPage.OpenAddPageDialog();
            newPageDialog.CreateNewPage("canh5", "canh9", "", "", "public");


        }
    }
}
