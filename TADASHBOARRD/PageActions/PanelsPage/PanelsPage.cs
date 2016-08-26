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
            Click("add new link");
        }

        /// <summary>
        /// Method to delete all panels
        /// </summary>
        public void DeleteAllPanels()
        {
           if (DoesElementPresent("check all link") == true)
            {
                Click("check all link");
                Click("delete link");
                AcceptAlert();
            }
        }

        #endregion
    }
}
