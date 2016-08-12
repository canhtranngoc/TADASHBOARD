using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TADASHBOARRD.Common;
using TADASHBOARRD.PageActions.GeneralPage;

namespace TADASHBOARRD.PageActions.PanelsPage
{
    public class PanelsPage:GeneralPage.GeneralPage
    {
        public void OpenNewPanelDialogFromPanelsPage()
        {
            System.Threading.Thread.Sleep(1000);
            Click("addnew link");
        }
    }
}
