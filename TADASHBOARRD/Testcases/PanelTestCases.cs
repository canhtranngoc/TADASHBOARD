using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TADASHBOARRD.Common;
using TADASHBOARRD.PageActions.LoginPage;
using TADASHBOARRD.PageActions.GeneralPage;
using TADASHBOARRD.PageActions.PanelsPage;
using System.Threading;

namespace TADASHBOARRD.Testcases
{
    [TestClass]
    public class PanelTestCases : BaseTest
    {
        public LoginPage loginPage;
        public GeneralPage generalPage;
        public PanelsPage panelsPage;
        public NewPanelDialog newPanelDialog;

        [TestMethod]
        public void DA_PANEL_TC032_Verify_that_no_special_character_is_allowed_to_be_inputted_into_Display_Name_field()
        {
            loginPage = new LoginPage();
            loginPage.Login(TestData.defaulRepository, TestData.validUsername, TestData.validPassword);
            generalPage = new GeneralPage();
            Thread.Sleep(1000);
            generalPage.OpenPanelsPage();
            panelsPage = new PanelsPage();
            panelsPage.OpenNewPanelDialog();
            newPanelDialog = new NewPanelDialog();
            newPanelDialog.AddNewPanel(TestData.specialPanelName, TestData.panelSeries);
            string actual1 = newPanelDialog.GetErrorMessage();
            //CheckTextDisplays(actual1,TestData.errorInvalidNamePanelPage);
        }
        [TestMethod]
        public void DA_PANEL_TC030_Verify_that_user_is_not_allowed_to_create_panel_with_duplicated_Display_Name ()
        {
            loginPage = new LoginPage();
            loginPage.Login(TestData.defaulRepository, TestData.validUsername, TestData.validPassword);
            generalPage = new GeneralPage();
            generalPage.OpenPanelsPage();
            panelsPage = new PanelsPage();
            panelsPage.OpenNewPanelDialog();
            newPanelDialog = new NewPanelDialog();
            newPanelDialog.AddNewPanel(TestData.duplicatedPanelName, TestData.panelSeries);
            panelsPage.OpenNewPanelDialog();
            newPanelDialog = new NewPanelDialog();
            newPanelDialog.AddNewPanel(TestData.duplicatedPanelName, TestData.panelSeries);
            string actual2 = newPanelDialog.GetErrorMessage();
            CheckTextDisplays(actual2,TestData.errorDuplicatedNamePanelPage);
            // post - condition
            newPanelDialog.AcceptAlert();
            newPanelDialog.CloseNewPanelDialog();
            panelsPage.DeleteAllPanels();
        }
    }
}
