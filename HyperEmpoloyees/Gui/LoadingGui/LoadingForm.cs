using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HyperEmpoloyees.Gui.LoadingGui
{
    public partial class LoadingForm : Form
    {
        private static LoadingForm? loadingForm;
        private static Main mainForm;

        public LoadingForm()
        {
            InitializeComponent();
            this.Owner = mainForm;
        }

        public static LoadingForm Instance(Main main)
        {
            mainForm = main;
            return loadingForm ?? (loadingForm = new LoadingForm());
        }
    }
}
