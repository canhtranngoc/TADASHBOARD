using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TADASHBOARRD.Common;
using TADASHBOARRD.PageActions.GeneralPage;
using TADASHBOARRD.PageActions.LoginPage;

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
            
            generalPage.OpenNewPanelDialogFromGeneralPage();
            
            NewPageDialog newPageDialog= new NewPageDialog();
            newPageDialog.CreateNewPage("canh12312132");


        }
    }
}
