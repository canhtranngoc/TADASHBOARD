using System;
using OpenQA.Selenium;

namespace TADASHBOARRD.PageActions.PanelsPage
{
    public class PanelsPage: GeneralPage.GeneralPage
    {
        #region Methods

        /// <summary>
        /// Method to open new panel dialog
        /// </summary>
        public void OpenNewPanelDialog()
        {
            WaitInSpecificTime(10);
            Click("add new link");
        }

        /// <summary>
        /// Method to delete all panels
        /// </summary>
        public void DeleteAllPanels()
        {
            try
            {
                Click("check all link");
                Click("delete link");
                AcceptAlert();
            }
            catch (WebDriverException)
            {
                Console.WriteLine("no panel displays");
            }
        }

        #endregion
    }
}
