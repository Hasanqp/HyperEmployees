using HyperEmpoloyees.Code.Helpers;

namespace HyperEmpoloyees
{
    public partial class Main : Form
    {
        private PageHelper pageHelper;
        public Main()
        {
            InitializeComponent();

            // Set HomePage
            pageHelper = new PageHelper(this);
            // Get and Set The window state
            SetWindowState(Properties.Settings.Default.IsMaxScreen);

            SetRoles();
        }
        #region Methods
        // Test
        private void SetRoles()
        {
            /*Code.Models.LocalUser.UserId = "1111235";
            Code.Models.LocalUser.Id = 1;
            Code.Models.LocalUser.Role = "Admin";
            Code.Models.LocalUser.FullName = "Hasan Ali";
            Code.Models.LocalUser.UserName = "Hasan";*/
        }

        // bool IsMax
        private void SetWindowState(bool IsMax)
        {
            if (IsMax)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveWinodwStateSettings();
            Application.Exit();
        }

        private void SaveWinodwStateSettings()
        {
            // Save Window State
            if (WindowState == FormWindowState.Maximized)
            {
                Properties.Settings.Default.IsMaxScreen = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.IsMaxScreen = false;
                Properties.Settings.Default.Save();
            }
        }

        #endregion
        #region Evints

        private void buttonHome_Click(object sender, EventArgs e)
        {
            pageHelper.SetPage(Gui.HomeGui.HomeUserControl.Instance());
        }

        private void buttonUsers_Click(object sender, EventArgs e)
        {
            pageHelper.SetPage(Gui.UsersGui.UsersUserControl.Instance(this));
        }

        private void buttonSalaryCategory_Click(object sender, EventArgs e)
        {
            pageHelper.SetPage(Gui.SalaryRateGui.SalaryRateUserControl.Instance(this));
        }

        private void buttonEmployees_Click(object sender, EventArgs e)
        {
            pageHelper.SetPage(Gui.EmpoloyeesGui.EmpoloyeesUserControl.Instance(this));
        }

        private void buttonRetiremnt_Click(object sender, EventArgs e)
        {

        }

        private void buttonReports_Click(object sender, EventArgs e)
        {

        }

        private void buttonSystemRecords_Click(object sender, EventArgs e)
        {
            pageHelper.SetPage(Gui.SystemRecordsGui.SystemRecordsUserControl.Instance(this));
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            Gui.SettingsGui.SettingsForm settingsForm = new Gui.SettingsGui.SettingsForm();
            settingsForm.Show();
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {

        }

        private void buttonAbout_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
