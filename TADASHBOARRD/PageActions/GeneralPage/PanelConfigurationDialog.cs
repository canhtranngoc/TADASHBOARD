namespace TADASHBOARRD.PageActions.GeneralPage
{
    class PanelConfigurationDialog: GeneralPage
    {
        #region Methods

        /// <summary>
        /// Method to enter value to height textbox then click ok button
        /// </summary>
        public void EnterValueToHeighThenClickOk(string value)
        {
            // Comment li do
            Sleep(1);
            EnterValue("height textbox", value);
            Click("ok button");
        }

        /// <summary>
        /// Method to cancel panel configuration dialog
        /// </summary>
        public void CancelPanelConfigurationDialog()
        {
            // Comment li do
            Sleep(1);
            Click("cancel button");
        }

        #endregion
    }
}
