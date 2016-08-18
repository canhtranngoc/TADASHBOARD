using Microsoft.VisualStudio.TestTools.UnitTesting;
using TADASHBOARRD.Common;
using TADASHBOARRD.PageActions.LoginPage;
using TADASHBOARRD.PageActions.GeneralPage;
using TADASHBOARRD.PageActions.PanelsPage;
using System.Threading;

namespace TADASHBOARRD.Testcases
{
    [TestClass]
    public class PanelsTestCases : BaseTest
    {
        private LoginPage loginPage;
        private GeneralPage generalPage;
        private PanelsPage panelsPage;
        private NewPanelDialog newPanelDialog;
        private NewPageDialog newPageDialog;

        [TestMethod]
        public void DA_PANEL_TC030_Verify_that_no_special_character_is_allowed_to_be_inputted_into_Display_Name_field()
        {
            loginPage = new LoginPage();
            loginPage.Login(TestData.defaulRepository, TestData.validUsername, TestData.validPassword);
            generalPage = new GeneralPage();
            // wait for Panel Page link displays
            Thread.Sleep(1000);
            generalPage.OpenPanelsPage();
            panelsPage = new PanelsPage();
            panelsPage.OpenNewPanelDialog();
            newPanelDialog = new NewPanelDialog();
            newPanelDialog.AddNewPanel(TestData.specialPanelName, TestData.panelSeries);
            string actualInvalidNameMessage = newPanelDialog.GetErrorMessage();
            // VP: Message "Invalid display name. The name can't contain high ASCII characters or any of following characters: /:*?<>|"#{[]{};" is displayed
            CheckTextDisplays(actualInvalidNameMessage, TestData.errorInvalidNamePanelPage);
        }

        [TestMethod]
        public void DA_PANEL_TC036_Verify_that_all_chart_types_Pie_SingleBar_StackedBar_GroupBar_Line_are_listed_correctly_under_Chart_Type_dropped_down_menu()
        {
            loginPage = new LoginPage();
            loginPage.Login(TestData.defaulRepository, TestData.validUsername, TestData.validPassword);
            generalPage = new GeneralPage();
            generalPage.OpenAddPageDialog();
            newPageDialog = new NewPageDialog();
            string pageName = CommonActions.GetDateTime();
            newPageDialog.CreateNewPage(pageName, TestData.defaultParentPage, TestData.defaultNumberOfColumns, TestData.defaultDisplayAfter, TestData.statusNotPublic);
            generalPage.OpenNewPanelDialogFromChoosePanels();
            newPanelDialog = new NewPanelDialog();
            // VP: Check that 'Chart Type' are listed 5 options: 'Pie', 'Single Bar', 'Stacked Bar', 'Group Bar' and 'Line'
            newPanelDialog.CheckChartTypeOptions();
            newPanelDialog.CloseNewPanelDialog();
            // Post-Condition
            generalPage.DeleteAllPages();
            generalPage.Logout();
        }

        [TestMethod]
        public void DA_PANEL_TC043_Verify_that_only_integer_number_inputs_from_300_800_are_valid_for_Height_field()
        {
            loginPage = new LoginPage();
            loginPage.Login(TestData.defaulRepository, "canh.tran", "123");
            generalPage = new GeneralPage();
            generalPage.OpenAddPageDialog();
            newPageDialog = new NewPageDialog();
            string pageName = CommonActions.GetDateTime();
            newPageDialog.CreateNewPage(pageName, TestData.defaultParentPage, TestData.defaultNumberOfColumns, TestData.defaultDisplayAfter, TestData.statusNotPublic);
            generalPage.OpenRandomChartPanelInstance();
            PanelConfigurationDialog panelConfigurationDialog = new PanelConfigurationDialog();
            panelConfigurationDialog.EnterValueToHeighThenClickOk("299");
            // VP: Error message 'Panel height must be greater than or equal to 300 and lower than or equal to 800' display
            string actualErrorMessage = panelConfigurationDialog.GetTextPopup();
            CheckTextDisplays(TestData.errorMessageWhenEnterOutOfRule, actualErrorMessage);
            panelConfigurationDialog.AcceptAlert();
            panelConfigurationDialog.EnterValueToHeighThenClickOk("801");
            // VP: Error message 'Panel height must be greater than or equal to 300 and lower than or equal to 800' display
            string actualErrorMessage1 = panelConfigurationDialog.GetTextPopup();
            CheckTextDisplays(TestData.errorMessageWhenEnterOutOfRule, actualErrorMessage1);
            panelConfigurationDialog.AcceptAlert();
            panelConfigurationDialog.EnterValueToHeighThenClickOk("-2");
            // VP: Error message 'Panel height must be greater than or equal to 300 and lower than or equal to 800' display
            string actualErrorMessage2 = panelConfigurationDialog.GetTextPopup();
            CheckTextDisplays(TestData.errorMessageWhenEnterOutOfRule, actualErrorMessage2);
            panelConfigurationDialog.AcceptAlert();
            panelConfigurationDialog.EnterValueToHeighThenClickOk("3.1");
            // VP: Error message 'Panel height must be greater than or equal to 300 and lower than or equal to 800' display
            string actualErrorMessage3 = panelConfigurationDialog.GetTextPopup();
            CheckTextDisplays(TestData.errorMessageWhenEnterOutOfRule, actualErrorMessage3);
            panelConfigurationDialog.AcceptAlert();
            panelConfigurationDialog.EnterValueToHeighThenClickOk("abc");
            // VP: Error message 'Panel height must be an integer number' display
            string actualErrorMessage4 = panelConfigurationDialog.GetTextPopup();
            CheckTextDisplays(TestData.errorMessageWhenEnterCharacter, actualErrorMessage4);
        }
    }
}
