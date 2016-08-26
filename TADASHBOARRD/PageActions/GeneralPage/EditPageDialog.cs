namespace TADASHBOARRD.PageActions.GeneralPage
{
    class EditPageDialog: GeneralPage
    {
        #region Methods

        ///<summary>
        /// Method to edit page
        ///</summary>
        public void EditPage(string newPageName, string newParentPage, string newNumberOfColumns, string newDisplayAfter, string newStatus, int newParentLevel)
        {
            // Wait for edit page is loaded
            Sleep(1);
            if (newParentPage != "")
            {
                if (newParentLevel == 0)
                {
                    SelectItemByText("parent page combobox", newParentPage);
                }
                if (newParentLevel == 1)
                {
                    SelectItemByText("parent page combobox", ("    " + newParentPage));
                }
                if (newParentLevel == 2)
                {
                    SelectItemByText("parent page combobox", ("        " + newParentPage));
                }
                if (newParentLevel == 3)
                {
                    SelectItemByText("parent page combobox", ("            " + newParentPage));
                }
            }
            // Wait for combobox value is changed
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
            Click("ok button");
            // Wait for created page loads
            Sleep(1);
        }

        #endregion
    }
}
