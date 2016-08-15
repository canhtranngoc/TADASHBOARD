using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TADASHBOARRD.PageActions.LoginPage;
using TADASHBOARRD.Common;
using TADASHBOARRD.PageActions.GeneralPage;
using TADASHBOARRD.PageActions.PanelsPage;
using System.Threading;

namespace TADASHBOARRD.Testcases.Draft
{
    [TestClass]
    public class UnitTest1: BaseTest
    {
        [TestMethod]
        public void TestMethod123()
        {
            LoginPage loginPage = new LoginPage();
            loginPage.Login(TestData.defaulRepository, TestData.validUsername, TestData.validPassword);
            GeneralPage generalPage = new GeneralPage();
            Thread.Sleep(1000);
            generalPage.OpenPanelsPage();
            PanelsPage panelsPage = new PanelsPage();
            Thread.Sleep(1000);
            panelsPage.OpenNewPanelDialogFromPanelsPage();
            NewPanelDialog newPanelDialog = new NewPanelDialog();
            newPanelDialog.AddNewPanel("ngan", "Name");
            Thread.Sleep(1000);
            panelsPage.DeletePanel("ngan");
            panelsPage.DeleteAllPanels();
            string a = "Invalid display name.The name can't contain high ASCII characters or any of following characters: /:*?<>|\"" +  "#{[]{};";
            string b = "\"";
            Console.WriteLine(a);
            Console.WriteLine(b);
        }
    }
}
