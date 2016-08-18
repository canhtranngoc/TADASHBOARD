namespace TADASHBOARRD.PageActions.GeneralPage
{
    public class NewPageDialog : GeneralPage
    {
        public void CreateNewPage(string pageName, string parentPage, string numberOfColumns, string displayAfter, string status)
        {
            Sleep(1);
            EnterValue("page name textbox", pageName);
            if (parentPage != "")
            {
                EnterValueDropdownList("parent page combobox", parentPage);
            }
            if (numberOfColumns != "")
            {
                SelectItemByText("number of columns combobox", numberOfColumns);
            }
            if (displayAfter != "")
            {
                SelectItemByText("display after combobox", displayAfter);
            }
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
            Sleep(1);
        }
    }
}
