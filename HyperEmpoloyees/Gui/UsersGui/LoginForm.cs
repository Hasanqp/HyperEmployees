using DocumentFormat.OpenXml.Spreadsheet;
using HyperEmpoloyees.Code.Helpers;
using HyperEmpoloyees.Code.Models;
using HyperEmpoloyees.Core;
using HyperEmpoloyees.Data.EF;
using HyperEmpoloyees.Gui.LoadingGui;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HyperEmpoloyees.Gui.UsersGui
{
    public partial class LoginForm : Form
    {
        private readonly IDataHelper<Core.Users> dataHelperForUser;
        private readonly IDataHelper<Roles> dataHelperForRoles;
        private readonly IDataHelper<SystemRecords> dataHelperForSystemRecords;
        Main main;

        public LoginForm()
        {
            InitializeComponent();

            dataHelperForUser = new UsersEF();
            dataHelperForRoles = new RolesEF();
            dataHelperForSystemRecords = new SystemRecordsEF();


        }

        #region Evints
        private async void buttonLogin_Click(object sender, EventArgs e)
        {
            // Check the fileds
            if (!IsValid())
            {
                MsgHelper.ShowRequiredFields();
            }
            else
            {
                // Show Loading
                pictureBoxLoading.Visible = true;
                // Check Connection
                if (await Task.Run(() => dataHelperForUser.IsCanConnect()))
                {
                    Login();
                }
                else
                {
                    pictureBoxLoading.Visible = false;
                    MsgHelper.ShowServerError();
                }

                pictureBoxLoading.Visible = false;
            }
        }
        #endregion
        #region Methods
        private bool IsValid()
        {
            if (textBoxPassword.Text.Length < 3 ||
                textBoxUserName.Text.Length < 3
                )
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private async void Login()
        {
            // Check user Name and Password
            string userName = textBoxUserName.Text,
                   password = textBoxPassword.Text;
            var user = await Task.Run(() =>
            dataHelperForUser.GetAllData()
            .Where(x => x.UserName == userName && x.Password == password)
            .FirstOrDefault() ?? new Core.Users());
            if (user.Id > 0)
            {
                // Set User Information
                LocalUser.Id = user.Id;
                LocalUser.UserName = user.UserName;
                LocalUser.Password = user.Password;
                LocalUser.Address = user.Address;
                LocalUser.UserId = user.UserId;
                LocalUser.FullName = user.FullName;
                LocalUser.Email = user.Email;
                LocalUser.IsSecondaryUser = user.IsSecondaryUser;

                // Get and Set roles
                RolesHelper.localRoles = await Task.Run(() => dataHelperForRoles
                .GetAllData()
                .Where(x => x.UsersId == user.Id).ToList());

                // Success
                SystemRecordHelper.Add("Регистрироваться",
                    $"Регистрироваться. Пользователь {user.FullName} вошел в систему ");

                Main main = new Main();
                main.Show();
                this.Hide();

            }
            else
            {
                // Msg Box with result
                MessageBox.Show("Неверная информация для входа в систему", "Ошибка входа в систему", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        #endregion
    }
}
