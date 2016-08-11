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
        public void TC01()
        {
            NavigateTADashboard();
            LoginPage loginPage = new LoginPage();
            loginPage.Login(TestData.defaulRepository, TestData.validUsername, TestData.validPassword);
            GeneralPage generalPage = new GeneralPage();
            Thread.Sleep(1000);
            generalPage.OpenPanelsPage();
            PanelsPage panelPage = new PanelsPage();
            panelPage.OpenNewPanelDialogFromPanelsPage();
            NewPanelDialog newPanelDialog = new NewPanelDialog();
            Thread.Sleep(1000);
            newPanelDialog.AddNewPanel(TestData.panelName, "Name");
        }
    }
}
