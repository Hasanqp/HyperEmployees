using HyperEmpoloyees.Code.Models;

namespace HyperEmpoloyees.Gui.HomeGui
{
    public partial class HomeUserControl : UserControl
    {
        private static HomeUserControl? homeUserControl;
        public HomeUserControl()
        {
            InitializeComponent();
            labelWelcome.Text = $"Добро пожаловать, {LocalUser.FullName}";
            labelCompanyName.Text = Properties.Settings.Default.CompanyName;
        }

        public static HomeUserControl Instance()
        {
            return homeUserControl ?? (homeUserControl = new HomeUserControl());
        }
    }
}
