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
            // Wait for edit page is loaded
            Sleep(1);
            EnterValue("page name textbox", newPageName);
            if (newNumberOfColumns != "")
            {
                SelectItemByText("number of columns combobox", newNumberOfColumns);
            }
            if (newDisplayAfter != "")
            {
                SelectItemByText("display after combobox", newDisplayAfter);
            }
            // Wait for combobox value is changed
            Sleep(1);
            if (newStatus == "public")
            {
                TickCheckbox("public checkbox");
            }
            if (newStatus == "unpublic")
            {
                UntickCheckbox("public checkbox");
            }
            if (newParentPage != "")
            {
                SelectValueDropdownList("parent page combobox", newParentPage);
            }
            Click("ok button");
        }

        #endregion
    }
}
