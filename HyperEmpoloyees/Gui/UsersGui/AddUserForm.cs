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
    public partial class AddUserForm : Form
    {
        private readonly IDataHelper<Users> dataHelperForUser;
        private readonly IDataHelper<Roles> dataHelperForRoles;
        private readonly IDataHelper<SystemRecords> dataHelperForSystemRecords;
        private readonly Main main;
        private int Id;
        private DateTime userCreatedDate;
        private readonly UsersUserControl page;

        public AddUserForm(Main main, int id, UsersUserControl page)
        {
            InitializeComponent();

            dataHelperForUser = new UsersEF();
            dataHelperForRoles = new RolesEF();
            dataHelperForSystemRecords = new SystemRecordsEF();

            this.Owner = main;


            AddSecondaryUser();
            SetRoles();
            this.main = main;
            this.Id = id;
            this.page = page;

            if(Id > 0)
            {
                SetDataForEdit();
            }
        }

        #region Evints
        private void checkBoxSecondaryUser_CheckedChanged(object sender, EventArgs e)
        {
            if (Code.Models.LocalUser.Role == "Admin")
            {
                comboBoxUserId.Enabled = checkBoxSecondaryUser.Checked;
            }
            else
            {
                comboBoxUserId.Enabled = false;
            }
        }

        private async void buttonSave_Click(object sender, EventArgs e)
        {
            // Check the fileds
            if (!IsValid())
            {
                MsgHelper.ShowRequiredFields();
            }
            else
            {
                // Show Loading
                LoadingForm.Instance(main).Show();
                // Check Connection
                if (await Task.Run(() => dataHelperForUser.IsCanConnect()))
                {
                    // Check Duplicated Item

                    string fullName = textBoxFullName.Text;
                    string userName = textBoxUserName.Text;

                    var result = await Task.Run(() => dataHelperForUser
                    .GetAllData()
                    .Where(x => x.Id != Id)
                    .Where(x => x.FullName == fullName || x.UserName == userName)
                    .FirstOrDefault() ?? new Users());

                    if (result.Id > 0)
                    {
                        // Msg for Duplicatad data
                        LoadingForm.Instance(main).Show();
                        MsgHelper.ShowDuplicatedItems();
                    }
                    else
                    {
                        // Add
                        if (Id == 0)
                        {
                            Add();
                        }
                        else
                        {
                            // Edit
                            Edit();
                        }
                    }
                }
                else
                {
                    LoadingForm.Instance(main).Show();
                    MsgHelper.ShowServerError();
                }

                LoadingForm.Instance(main).Hide();
            }

        }

        #endregion
        #region Methods
        private void SetRoles()
        {
            if (Code.Models.LocalUser.Role == "Admin")
            {
                // Admin
                // Add Roles
                comboBoxRole.Items.Clear();
                comboBoxRole.Items.Add("Admin");
                comboBoxRole.Items.Add("User");
                comboBoxRole.Items.Add("Read");

                comboBoxUserId.Enabled = false;
                checkBoxSecondaryUser.Enabled = true;
                comboBoxRole.SelectedIndex = 1;
            }
            else
            {
                // User
                // Add Roles
                comboBoxRole.Items.Clear();
                comboBoxRole.Items.Add("User");
                comboBoxRole.Items.Add("Read");

                checkBoxSecondaryUser.Enabled = false;
                comboBoxUserId.Enabled = false;
                checkBoxSecondaryUser.Checked = true;
                comboBoxRole.SelectedIndex = 0;
            }
        }

        private void AddSecondaryUser()
        {
            comboBoxUserId.Items.Clear();
            comboBoxUserId.Items.Add(Code.Models.LocalUser.UserId);
            comboBoxUserId.SelectedIndex = 0;
        }

        private void SetRolesByMainRole()
        {
            if (comboBoxRole.SelectedIndex.ToString() == "Admin") // Admin
            {
                checkBoxAbout.Checked = true;
                checkBoxAdd.Checked = true;
                checkBoxDelete.Checked = true;
                checkBoxEdit.Checked = true;
                checkBoxEmpolyees.Checked = true;
                checkBoxExport.Checked = true;
                checkBoxHelp.Checked = true;
                checkBoxHome.Checked = true;
                checkBoxHomeSearch.Checked = true;
                checkBoxPrint.Checked = true;
                checkBoxReports.Checked = true;
                checkBoxRetirment.Checked = true;
                checkBoxSalaryIndex.Checked = true;
                checkBoxSearch.Checked = true;
                checkBoxSettings.Checked = true;
                checkBoxSystemRecords.Checked = true;
                checkBoxUsers.Checked = true;
            }
            else if (comboBoxRole.SelectedIndex.ToString() == "User") // User
            {
                checkBoxAbout.Checked = true;
                checkBoxAdd.Checked = true;
                checkBoxDelete.Checked = true;
                checkBoxEdit.Checked = true;
                checkBoxEmpolyees.Checked = true;
                checkBoxExport.Checked = true;
                checkBoxHelp.Checked = true;
                checkBoxHome.Checked = true;
                checkBoxHomeSearch.Checked = true;
                checkBoxPrint.Checked = true;
                checkBoxReports.Checked = true;
                checkBoxRetirment.Checked = true;
                checkBoxSalaryIndex.Checked = true;
                checkBoxSearch.Checked = true;
                checkBoxSettings.Checked = true;
                checkBoxSystemRecords.Checked = true;
                checkBoxUsers.Checked = true;
            }
            else // Read
            {

                checkBoxAbout.Checked = true;
                checkBoxAdd.Checked = false;
                checkBoxDelete.Checked = false;
                checkBoxEdit.Checked = false;
                checkBoxEmpolyees.Checked = true;
                checkBoxExport.Checked = true;
                checkBoxHelp.Checked = true;
                checkBoxHome.Checked = true;
                checkBoxHomeSearch.Checked = true;
                checkBoxPrint.Checked = true;
                checkBoxReports.Checked = true;
                checkBoxRetirment.Checked = true;
                checkBoxSalaryIndex.Checked = true;
                checkBoxSearch.Checked = true;
                checkBoxSettings.Checked = true;
                checkBoxSystemRecords.Checked = true;
                checkBoxUsers.Checked = false;
            }
        }

        private bool IsValid()
        {
            if (textBoxFullName.Text.Length < 3 ||
                textBoxPassword.Text.Length < 3 ||
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

        private string SetUserId()
        {
            if (checkBoxSecondaryUser.Checked)
            {
                return comboBoxUserId.SelectedItem.ToString() ?? LocalUser.UserId;
            }
            else
            {
                return Guid.NewGuid().ToString();
            }
        }

        private async void Add()
        {
            // Set User
            Users users = new Users
            {
                FullName = textBoxFullName.Text,
                Password = textBoxPassword.Text,
                UserName = textBoxUserName.Text,
                Email = textBoxEmail.Text,
                Address = textBoxAddress.Text,
                CreatedDate = DateTime.Now.Date,
                EditedDate = DateTime.Now.Date,
                Role = comboBoxRole.SelectedItem.ToString() ?? "User",
                PhoneNumber = textBoxPhone.Text,
                IsSecondaryUser = checkBoxSecondaryUser.Checked,
                UserId = SetUserId()
            };

            // Send Data to data base
            var result = await Task.Run(() => dataHelperForUser.Add(users));
            if (result == "1")
            {
                // Add User Roles
                foreach (var item in flowLayoutPanelRoles.Controls)
                {
                    CheckBox checkBox = (CheckBox)item;
                    // Set
                    Roles roles = new Roles
                    {
                        Key = checkBox.Name,
                        Value = checkBox.Checked,
                        UsersId = users.Id
                    };

                    // Send
                    await Task.Run(() => dataHelperForRoles.Add(roles));
                }

                // Success
                SystemRecordHelper.Add("Добавить пользователя",
                    $"Добавлен новый пользователь с идентификатором {users.Id}");
                page.LoadData();
                ToastHelper.ShowAddToast();
                this.Close();
            }
            else
            {
                // Msg Box with result
                MessageBox.Show(result);
            }
        }

        private async void Edit()
        {
            // Set User
            Users users = new Users
            {
                Id=Id,
                FullName = textBoxFullName.Text,
                Password = textBoxPassword.Text,
                UserName = textBoxUserName.Text,
                Email = textBoxEmail.Text,
                Address = textBoxAddress.Text,
                CreatedDate = userCreatedDate,
                EditedDate = DateTime.Now.Date,
                Role = comboBoxRole.SelectedItem.ToString() ?? "User",
                PhoneNumber = textBoxPhone.Text,
                IsSecondaryUser = checkBoxSecondaryUser.Checked,
                UserId = SetUserId()
            };

            // Send Data to data base
            var result = await Task.Run(() => dataHelperForUser.Edit(users));
            if (result == "1")
            {
                // Remove Old User Roles
                var oldroles = await Task.Run(() => dataHelperForRoles
                .GetAllData().Where(x=>x.UsersId==Id).ToList()??new List<Roles>());
                foreach(var role in oldroles)
                {
                    await Task.Run(() => dataHelperForRoles.Delete(role.Id));
                }
                // Add User Roles
                foreach (var item in flowLayoutPanelRoles.Controls)
                {
                    CheckBox checkBox = (CheckBox)item;
                    // Set
                    Roles roles = new Roles
                    {
                        Key = checkBox.Name,
                        Value = checkBox.Checked,
                        UsersId = users.Id
                    };

                    // Send
                    await Task.Run(() => dataHelperForRoles.Add(roles));
                }

                // Success
                SystemRecordHelper.Add("Изменение пользователем. ",
                    $"Существующий пользователь с таким идентификатором был изменен {users.Id}");
                page.LoadData();
                ToastHelper.ShowEditToast();
                this.Close();
            }
            else
            {
                // Msg Box with result
                MessageBox.Show(result);
            }
        }

        private async void SetDataForEdit()
        {
            // Get Edit User Data
            var _user = await Task.Run(() => dataHelperForUser.Find(Id));
            if (_user != null)
            {
                textBoxFullName.Text = _user.FullName;
                textBoxPassword.Text = _user.Password;
                textBoxUserName.Text = _user.UserName;
                textBoxEmail.Text = _user.Email;
                textBoxPhone.Text = _user.PhoneNumber;
                textBoxAddress.Text = _user.Address;
                comboBoxRole.SelectedItem = _user.Role;
                checkBoxSecondaryUser.Checked = _user.IsSecondaryUser;
                userCreatedDate=_user.CreatedDate;
            }

            // Set Roles

            // Add User Roles
            foreach (var item in flowLayoutPanelRoles.Controls)
            {
                CheckBox checkBox = (CheckBox)item;

                checkBox.Checked = await Task.Run(() => dataHelperForRoles
                .GetAllData()
                .Where(x =>x.UsersId == Id && x.Key ==  checkBox.Name)
                .Select(x => x.Value).FirstOrDefault());
            }
        }
        #endregion
    }
}
