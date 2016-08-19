namespace TADASHBOARRD.PageActions.GeneralPage
{
    public class NewPageDialog: GeneralPage
    {
        #region Methods

        /// <summary>
        /// Method to create a new page
        /// </summary>
        public void CreateNewPage(string pageName, string parentPage, string numberOfColumns, string displayAfter, string status)
        {
            // Comment li do
            Sleep(1);        
            if (parentPage != "")
            {
                SelectValueDropdownList("parent page combobox", parentPage);
            }
            // Comment li do
            Sleep(1);
            EnterValue("page name textbox", pageName);
            if (numberOfColumns != "")
            {
                SelectItemByText("number of columns combobox", numberOfColumns);
            }
            if (displayAfter != "")
            {
                SelectItemByText("display after combobox", displayAfter);
            }
            // Comment li do
            Sleep(1);
            if (status == "public")
            {
                TickCheckbox("public checkbox");
            }

            if (status == "unpublic")
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
