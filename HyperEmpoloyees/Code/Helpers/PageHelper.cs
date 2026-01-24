using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperEmpoloyees.Code.Helpers
{
    internal class PageHelper
    {
        private readonly Main main;

        public PageHelper(Main main) 
        {
            this.main = main;
        }

        public void SetPage(UserControl pageUserControl)
        {
            // Get The Current Page
            var oldPage=main.panelContainer.Controls.OfType<UserControl>().FirstOrDefault();

            // Remove The old page
            if(oldPage != null && oldPage != pageUserControl)
            {
                main.panelContainer.Controls.Remove(oldPage);
            }

            // Add new page
            if(oldPage != pageUserControl)
            {
                pageUserControl.Dock = DockStyle.Fill;
                main.panelContainer.Controls.Add(pageUserControl);
            }
        }
    }
}
