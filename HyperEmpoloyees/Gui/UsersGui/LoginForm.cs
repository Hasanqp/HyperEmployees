using HyperEmpoloyees.Code.Helpers;
using HyperEmpoloyees.Code.Models;
using HyperEmpoloyees.Core;
using HyperEmpoloyees.Data.EF;
using System.Data;

namespace HyperEmpoloyees.Gui.UsersGui
{
    public partial class LoginForm : Form
    {
        private readonly IDataHelper<Core.User> userDataHelper;
        private readonly IDataHelper<Role> rolesDataHelper;
        private readonly IDataHelper<SystemRecord> systemRecordsDataHelper;
        Main mainForm;

        public LoginForm()
        {
            InitializeComponent();

            userDataHelper = new UserRepository();
            rolesDataHelper = new RoleRepository();
            systemRecordsDataHelper = new SystemRecordRepository();


        }

        #region Events
        private async void buttonLogin_Click(object sender, EventArgs e)
        {
            // Check the fileds
            if (!IsValid())
            {
                MsgHelper.ShowRequiredFields();
            }
            pictureBoxLoading.Visible = true;
            try
            {
                await LoginAsync();
            }
            finally
            {
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

        private async Task LoginAsync()
        {
            // Check user Name and Password
            string userName = textBoxUserName.Text,
                   password = textBoxPassword.Text;
            var user = await Task.Run(() =>
            userDataHelper.GetAllData()
            .FirstOrDefault(x => x.UserName == userName && x.Password == password)
            ) ?? new Core.User();

            if (user.Id <= 0)
            {
                MessageBox.Show(
                    "Неверная информация для входа в систему",
                    "Ошибка входа в систему",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                    );
                return;
            }

            // Set Local User
            LocalUser.Id = user.Id;
            LocalUser.UserName = user.UserName;
            LocalUser.Password = user.Password;
            LocalUser.Address = user.Address;
            LocalUser.UserId = user.UserId;
            LocalUser.FullName = user.FullName;
            LocalUser.Email = user.Email;
            LocalUser.IsSecondaryUser = user.IsSecondaryUser;
            LocalUser.Role = user.Role;

            // Load roles
            RolesHelper.localRoles = await Task.Run(() =>
                rolesDataHelper.GetAllData()
                    .Where(x => x.UsersId == user.Id)
                    .ToList()
            );

            if (RolesHelper.localRoles.Count == 0)
            {
                MsgHelper.ShowServerError();
                return;
            }

            // System record
            SystemRecordHelper.Add(
                "Регистрироваться",
                $"Пользователь {user.FullName} вошел в систему"
            );

            Main main = new Main();
            main.Show();
            this.Hide();
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        #endregion
    }
}
