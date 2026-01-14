using HyperEmpoloyees.Code.Helpers;

namespace HyperEmpoloyees.Gui.SettingsGui
{
    partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            GetSettings();
        }
        #region Events
        private void buttonSaveGeneralSettings_Click(object sender, EventArgs e)
        {
            SaveGeneralSettings();
        }

        private void buttonSaveConnection_Click(object sender, EventArgs e)
        {
            if (!ValidateConnectionSettings()) return;

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

        #endregion
        #region Methods
        private void SaveGeneralSettings()
        {
            // Set Settings
            Properties.Settings.Default.CompanyName = textBoxCompanyName.Text;
            Properties.Settings.Default.Currency = textBoxCurrency.Text;
            Properties.Settings.Default.NoDataGridViewItems = (int)numericUpDownOfItems.Value;

            // Save
            Properties.Settings.Default.Save();
            MessageBox.Show("Настройки были сохранены. Пожалуйста, перезапустите приложение для применения изменений.");
        }

        private void GetSettings()
        {
            // General Settings
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
                radioButtonLocal.Checked = true;
                SetConnectionFieldsEnabled(radioButtonNetwork.Checked);
            }
            textBoxServer.Text = Properties.Settings.Default.Server;
            textBoxDataBase.Text = Properties.Settings.Default.DataBase;
            textBoxUserName.Text = Properties.Settings.Default.UserName;
            textBoxPassword.Text = Properties.Settings.Default.Password;
            numericUpDownDuration.Value = Properties.Settings.Default.ConDuration;
        }

        private void SetConnectionFieldsEnabled(bool enabled)
        {
            textBoxUserName.Enabled = enabled;
            textBoxPassword.Enabled = enabled;
            numericUpDownDuration.Enabled = enabled;
        }

        private bool ValidateConnectionSettings()
        {
            if (radioButtonNetwork.Checked)
            {
                if (string.IsNullOrWhiteSpace(textBoxServer.Text) ||
                    string.IsNullOrWhiteSpace(textBoxDataBase.Text))
                {
                    MsgHelper.ShowRequiredFields();
                    return false;
                }
            }
            return true;
        }

        #endregion
    }
}
