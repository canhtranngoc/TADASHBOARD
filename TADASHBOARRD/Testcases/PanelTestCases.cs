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
        private LoginPage loginPage;
        private GeneralPage generalPage;
        private PanelsPage panelsPage;
        private NewPanelDialog newPanelDialog;

        [TestMethod]
        public void DA_PANEL_TC030_Verify_that_no_special_character_is_allowed_to_be_inputted_into_Display_Name_field()
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
            string actualInvalidNameMessage = newPanelDialog.GetErrorMessage();
            // Post-Condition
            newPanelDialog.AcceptAlert();
            newPanelDialog.CloseNewPanelDialog();
            newPanelDialog.Logout();
            // VP: Message "Invalid display name. The name can't contain high ASCII characters or any of following characters: /:*?<>|"#{[]{};" is displayed
            CheckTextDisplays(actualInvalidNameMessage, TestData.errorInvalidNamePanelPage);
        }
        [TestMethod]
        public void DA_PANEL_TC032_Verify_that_user_is_not_allowed_to_create_panel_with_duplicated_Display_Name ()
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
            string actualDuplicateMessage = newPanelDialog.GetErrorMessage();
            //VP: Warning message: "Dupicated panel already exists. Please enter a different name" show up
            CheckTextDisplays(actualDuplicateMessage, TestData.errorDuplicatedNamePanelPage);
            // Post-Condition
            newPanelDialog.AcceptAlert();
            newPanelDialog.CloseNewPanelDialog();
            panelsPage.DeleteAllPanels();
            panelsPage.Logout();
        }
    }
}
