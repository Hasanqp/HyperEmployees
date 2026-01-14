using HyperEmpoloyees.Code.Helpers;
using HyperEmpoloyees.Code.Models;
using HyperEmpoloyees.Core;
using HyperEmpoloyees.Data.EF;
using HyperEmpoloyees.Gui.LoadingGui;
using System.Data;

namespace HyperEmpoloyees.Gui.UsersGui
{
    public partial class AddUserForm : Form
    {
        private readonly IDataHelper<Core.User> userDataHelper;
        private readonly IDataHelper<Role> roleDataHelper;
        private readonly IDataHelper<SystemRecord> systemRecordsDataHelper;
        private readonly Main mainForm;
        private int userId;
        private DateTime userCreatedDate = DateTime.Now;
        private readonly UsersUserControl parentPage;

        public AddUserForm(Main mainForm, int userId, UsersUserControl parentPage)
        {
            InitializeComponent();

            userDataHelper = new UserRepository();
            roleDataHelper = new RoleRepository();
            systemRecordsDataHelper = new SystemRecordRepository();


            // Set owner only when Main context exists
            if (mainForm != null)
                this.Owner = mainForm;


            AddSecondaryUser();
            SetRoles();

            this.mainForm = mainForm;
            this.parentPage = parentPage;
            this.userId = userId;

            // Edit mode only when valid user id is provided
            if (this.userId > 0)
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
                LoadingForm.Instance(mainForm).Show();
                // Check Connection
                if (await Task.Run(() => userDataHelper.IsCanConnect()))
                {
                    // Check Duplicated Item

                    string fullName = textBoxFullName.Text;
                    string userName = textBoxUserName.Text;

                    var result = await Task.Run(() => userDataHelper
                    .GetAllData()
                    .Where(x => x.Id != userId)
                    .Where(x => x.FullName == fullName || x.UserName == userName)
                    .FirstOrDefault() ?? new Core.User());

                    if (result.Id > 0)
                    {
                        // Msg for Duplicatad data
                        LoadingForm.Instance(mainForm).Show();
                        MsgHelper.ShowDuplicatedItems();
                    }
                    else
                    {
                        // Add
                        if (userId == 0)
                        {
                            AddUser();
                        }
                        else
                        {
                            // Edit
                            EditUser();
                        }
                    }
                }
                else
                {
                    LoadingForm.Instance(mainForm).Show();
                    MsgHelper.ShowServerError();
                }

                LoadingForm.Instance(mainForm).Hide();
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

        private void comboBoxRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetRolesByMainRole();
        }

        private void SetRolesByMainRole()
        {
            string role = comboBoxRole.SelectedItem?.ToString() ?? "";

            // Reset first
            if (comboBoxRole.SelectedItem?.ToString() != "Admin")
            {
                // Enforce security
                foreach (var item in flowLayoutPanelRoles.Controls)
                {
                    if (item is CheckBox cb)
                        cb.Checked = false;
                }
            }

            // Common permissions
            checkBoxAbout.Checked = true;
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

            if (role == "Admin") // Admin
            {
                // Full access
                checkBoxAdd.Checked = true;
                checkBoxEdit.Checked = true;
                checkBoxDelete.Checked = true;
                checkBoxUsers.Checked = true;

                checkBoxSystemRecords.Checked = true;
            }
            else if (role == "User") // User
            {
                checkBoxAdd.Checked = true;
                checkBoxEdit.Checked = true;
                checkBoxDelete.Checked = true;
                checkBoxUsers.Checked = true;

                checkBoxSystemRecords.Checked = false;
            }
            else // Read
            {

                checkBoxAdd.Checked = false;
                checkBoxEdit.Checked = false;
                checkBoxDelete.Checked = false;
                checkBoxUsers.Checked = false;

                checkBoxSystemRecords.Checked = false;
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

        private async void AddUser()
        {
            // Set User
            Core.User users = new Core.User
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
            var result = await Task.Run(() => userDataHelper.Add(users));
            if (result == "1")
            {
                // Add User Roles
                foreach (var item in flowLayoutPanelRoles.Controls)
                {
                    CheckBox checkBox = (CheckBox)item;
                    // Set
                    Role roles = new Role
                    {
                        Key = checkBox.Name,
                        Value = checkBox.Checked,
                        UsersId = users.Id
                    };

                    // Send
                    await Task.Run(() => roleDataHelper.Add(roles));
                }

                // Success
                SystemRecordHelper.Add("Добавить пользователя",
                    $"Добавлен новый пользователь с идентификатором {users.Id}");
                parentPage.LoadDataAsync();
                ToastHelper.ShowAddToast();
                this.Close();
            }
            else
            {
                // Msg Box with result
                MessageBox.Show(result);
            }
        }

        private async void EditUser()
        {
            // Set User
            Core.User users = new Core.User
            {
                Id = userId,
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
            var result = await Task.Run(() => userDataHelper.Edit(users));
            if (result == "1")
            {
                // Remove Old User Roles
                var oldroles = await Task.Run(() => roleDataHelper
                .GetAllData().Where(x => x.UsersId == userId).ToList() ?? new List<Role>());
                foreach (var role in oldroles)
                {
                    await Task.Run(() => roleDataHelper.Delete(role.Id));
                }
                // Add User Roles
                foreach (var item in flowLayoutPanelRoles.Controls)
                {
                    CheckBox checkBox = (CheckBox)item;
                    // Set
                    Role roles = new Role
                    {
                        Key = checkBox.Name,
                        Value = checkBox.Checked,
                        UsersId = users.Id
                    };

                    // Send
                    await Task.Run(() => roleDataHelper.Add(roles));
                }

                // Success
                SystemRecordHelper.Add("Изменение пользователем. ",
                    $"Существующий пользователь с таким идентификатором был изменен {users.Id}");
                parentPage.LoadDataAsync();
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
            var _user = await Task.Run(() => userDataHelper.Find(userId));
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
                userCreatedDate = _user.CreatedDate;
            }

            // Set Roles

            // Add User Roles
            foreach (var item in flowLayoutPanelRoles.Controls)
            {
                CheckBox checkBox = (CheckBox)item;

                checkBox.Checked = await Task.Run(() => roleDataHelper
                .GetAllData()
                .Where(x => x.UsersId == userId && x.Key == checkBox.Name)
                .Select(x => x.Value).FirstOrDefault());
            }
        }

        #endregion
    }
}
