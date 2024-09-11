using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HyperEmpoloyees.Gui.SettingsGui
{
    partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            GetSettings();
        }
        #region Evints
        private void buttonSaveGeneralSettings_Click(object sender, EventArgs e)
        {
            SaveGenralSettings();
        }
        #endregion
        #region Methods
        private void SaveGenralSettings()
        {
            // Set Settings
            Properties.Settings.Default.CompanyName = textBoxCompanyName.Text;
            Properties.Settings.Default.Currency = textBoxCurrency.Text;
            Properties.Settings.Default.NoDataGridViewItems = (int)numericUpDownOfItems.Value;

            // Save
            Properties.Settings.Default.Save();
            MessageBox.Show("Настройки были сохранены");
        }

        private void GetSettings()
        {
            // Genral Settings
            textBoxCompanyName.Text = Properties.Settings.Default.CompanyName;
            textBoxCurrency.Text = Properties.Settings.Default.Currency;
            numericUpDownOfItems.Value = Properties.Settings.Default.NoDataGridViewItems;

            // Connection Settings
            if (Properties.Settings.Default.ConType == "Локальной")
            {
                radioButtonLocal.Checked = true;
                textBoxUserName.Enabled = false;
                textBoxPassword.Enabled = false;
                numericUpDownDuration.Enabled = false;
            }
            else
            {
                radioButtonNetwork.Checked = true;
                textBoxUserName.Enabled = true;
                textBoxPassword.Enabled = true;
                numericUpDownDuration.Enabled = true;
            }
            textBoxServer.Text = Properties.Settings.Default.Server;
            textBoxDataBase.Text = Properties.Settings.Default.DataBase;
            textBoxUserName.Text = Properties.Settings.Default.UserName;
            textBoxPassword.Text = Properties.Settings.Default.Password;
            numericUpDownDuration.Value = Properties.Settings.Default.NoDataGridViewItems;
        }
        #endregion

        private void buttonSaveConnection_Click(object sender, EventArgs e)
        {
            // Connection Settings
            if (radioButtonLocal.Checked)
            {
                Properties.Settings.Default.ConType = "Локальной";
            }
            else
            {
                Properties.Settings.Default.ConType = "Сетевой";
            }
            Properties.Settings.Default.Server = textBoxServer.Text;
            Properties.Settings.Default.DataBase = textBoxDataBase.Text;
            Properties.Settings.Default.UserName = textBoxUserName.Text;
            Properties.Settings.Default.Password = textBoxPassword.Text;
            Properties.Settings.Default.ConDuration = (int)numericUpDownDuration.Value;
            Properties.Settings.Default.Save();
            MessageBox.Show("Настройки были сохранены");

            Application.Exit();
        }

        private void radioButtonLocal_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonLocal.Checked)
            {
                textBoxUserName.Enabled = false;
                textBoxPassword.Enabled = false;
                numericUpDownDuration.Enabled = false;
            }
        }

        private void radioButtonNetwork_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonNetwork.Checked)
            {
                textBoxUserName.Enabled = true;
                textBoxPassword.Enabled = true;
                numericUpDownDuration.Enabled = true;
            }
        }
    }
}
