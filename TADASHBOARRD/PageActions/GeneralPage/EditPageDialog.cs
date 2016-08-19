namespace TADASHBOARRD.PageActions.GeneralPage
{
    class EditPageDialog: GeneralPage
    {
        #region Methods

        ///<summary>
        /// Method to edit page
        ///</summary>
        public void EditPage(string newPageName, string newParentPage, string newNumberOfColumns, string newDisplayAfter, string newStatus)
        {
            // Comment li do
            Sleep(1);
            EnterValue("page name textbox", newPageName);
            if (newParentPage != "")
            {
                SelectValueDropdownList("parent page combobox", newParentPage);
            }
            if (newNumberOfColumns != "")
            {
                SelectItemByText("number of columns combobox", newNumberOfColumns);
            }
            if (newDisplayAfter != "")
            {
                SelectItemByText("display after combobox", newDisplayAfter);
            }
            // Comment li do
            Sleep(1);
            if (newStatus == "public")
            {
                TickCheckbox("public checkbox");
            }
            if (newStatus == "unpublic")
            {
                UntickCheckbox("public checkbox");
            }
            Click("ok button");
            // Comment li do
            Sleep(1);
        }

        #endregion
    }
}
