using HyperEmpoloyees.Data.EF;
using HyperEmpoloyees.Gui.UsersGui;

namespace HyperEmpoloyees
{
    partial class StartForm : Form
    {
        private HyperEmpoloyeesDbContext db;
        public StartForm()
        {
            InitializeComponent();
            Code.Helpers.ConStringHelper.SetConString();
        }
        #region Events
        private void linkLabelSetServer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Show Settings Form
            Gui.SettingsGui.SettingsForm settingsForm = new Gui.SettingsGui.SettingsForm();
            settingsForm.Show();
        }

        private void linkLabelExit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Exit();
        }
        #endregion

        private async void timerStart_Tick(object sender, EventArgs e)
        {
            db = new HyperEmpoloyeesDbContext();

            // Check the con
            labelState.Text = "Подключение к базе данных";
            if (await db.Database.CanConnectAsync())
            {
                // Show Login From
                timerStart.Enabled = false;
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                this.Hide();
            }
            else
            {
                panelSettings.Visible = true;
                labelState.Text = "Не удалось подключиться... Мы вернемся через некоторое время";
            }
        }
    }
}
