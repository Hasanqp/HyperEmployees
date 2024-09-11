using HyperEmpoloyees.Data.EF;
using HyperEmpoloyees.Gui.UsersGui;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HyperEmpoloyees
{
    partial class StartForm : Form
    {
        private DBContext db;
        public StartForm()
        {
            InitializeComponent();
            Code.Helpers.ConStringHelper.SetConString();
        }
        #region Evints
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
            db = new DBContext();

            // Check the con
            labelState.Text = "Подключение к базе данных";
            if (await db.Database.CanConnectAsync())
            {
                // Show login Form
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

        private void StartForm_Load(object sender, EventArgs e)
        {

        }
    }
}
