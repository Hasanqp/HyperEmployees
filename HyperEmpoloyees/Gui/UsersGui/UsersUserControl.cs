using HyperEmpoloyees.Code.Helpers;
using HyperEmpoloyees.Code.Models;
using HyperEmpoloyees.Core;
using HyperEmpoloyees.Data.EF;
using HyperEmpoloyees.Gui.LoadingGui;
using System.Data;

namespace HyperEmpoloyees.Gui.UsersGui
{
    public partial class UsersUserControl : UserControl
    {
        private static UsersUserControl? _instance;
        private Main _mainForm;


        private AddUserForm addUserForm;
        private bool columnsSet = false;
        private IDataHelper<Core.User> userDataHelper;
        private List<Core.User> users;
        private List<int> deleteIds;
        private int pageSize => Properties.Settings.Default.NoDataGridViewItems;

        public UsersUserControl()
        {
            InitializeComponent();

            userDataHelper = new UserRepository();
            users = new List<User>();
            deleteIds = new List<int>();
        }
        public static UsersUserControl Instance(Main main)
        {
            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new UsersUserControl();
            }

            _instance.Initialize(main);
            return _instance;
        }

        #region Events
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (addUserForm == null || addUserForm.IsDisposed)
            {
                addUserForm = new AddUserForm(_mainForm, 0, this);
                addUserForm.Show();
            }
            else
            {
                addUserForm.Focus();
            }

        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            EditUser();
        }

        private async void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // Check Data if not Empty
                if (!dgvHelper.IsEmpty(dataGridView1))
                {

                    // Get Id
                    SetIdDeleteList();
                    if (deleteIds.Count > 0)
                    {
                        if (MsgHelper.ShowDeleteDialog())
                        {
                            LoadingForm.Instance(_mainForm).Show();
                            try
                            {
                                if (!await Task.Run(() => userDataHelper.IsCanConnect()))
                                {
                                    MsgHelper.ShowServerError();
                                    return;
                                }
                                // Loop into Id List
                                foreach (int Id in deleteIds)
                                {
                                    await Task.Run(() => userDataHelper.Delete(Id));
                                    SystemRecordHelper.Add("Удалить пользователя",
                                        $"Существующий пользователь с таким идентификатором был удален{Id.ToString()}");
                                }

                                ToastHelper.ShowDeleteToast();
                                await LoadDataAsync();
                            }
                            finally
                            {
                                LoadingForm.Instance(_mainForm).Hide();
                            }
                        }
                    }
                    else
                    {

                        MsgHelper.ShowDeleteSelectRow();
                    }
                }
                else
                {
                    LoadingForm.Instance(_mainForm).Hide();
                    MsgHelper.ShowEmptyDataGridView();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            SearchAsync();
        }

        private void textBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchAsync();
            }
        }

        private async void buttonRefresh_Click(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditUser();
        }

        private async void buttonExportAll_Click(object sender, EventArgs e)
        {
            // Show Loading
            LoadingForm.Instance(_mainForm).Show();
            if (await Task.Run(() => userDataHelper.IsCanConnect()))
            {
                // Start Load Data
                // Check if Admin or not
                if (LocalUser.Role == "Admin")
                {
                    // Get All Data
                    users = await Task.Run(() => userDataHelper.GetAllData());
                }
                else
                {
                    // Get Data By User
                    users = await Task.Run(() => userDataHelper.GetDataByUser(LocalUser.UserId));
                }
                LoadingForm.Instance(_mainForm).Hide();
                ExportExcel(users);
            }
            else
            {
                // No Conection
                LoadingForm.Instance(_mainForm).Hide();
                ShowServerErrorState();
                MsgHelper.ShowServerError();
            }
            // Hide Loading
            LoadingForm.Instance(_mainForm).Hide();
        }

        private void buttonExportDataGridView_Click(object sender, EventArgs e)
        {
            // Get Data
            var data = dataGridView1.DataSource as List<User>;
            if (data == null) return;
            {
                ExportExcel(data);
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            try
            {
                comboBoxNoOfPage.SelectedIndex = comboBoxNoOfPage.SelectedIndex + 1;
            }
            catch { }
        }

        private void buttonPrev_Click(object sender, EventArgs e)
        {
            try
            {

                if (comboBoxNoOfPage.SelectedIndex != 0)
                {
                    comboBoxNoOfPage.SelectedIndex = comboBoxNoOfPage.SelectedIndex - 1;
                }
            }
            catch { }
        }

        private async void comboBoxNoOfPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBoxNoOfPage.SelectedIndex;

            dataGridView1.DataSource = users
                .Skip(index * pageSize)
                .Take(pageSize)
                .ToList();

            ShowEmptyDataState();

        }

        #endregion

        #region Methods
        public async Task LoadDataAsync()
        {
            // Show Loading
            LoadingForm.Instance(_mainForm).Show();

            if (!await Task.Run(() => userDataHelper.IsCanConnect()))
            {
                LoadingForm.Instance(_mainForm).Hide();
                ShowServerErrorState();
                return;
            }

            users = LocalUser.Role == "Admin"
                ? await Task.Run(() => userDataHelper.GetAllData())
                : await Task.Run(() => userDataHelper.GetDataByUser(LocalUser.UserId));

            labelNoOfItems.Text = users.Count.ToString();

            comboBoxNoOfPage.Items.Clear();
            int totalPages = (int)Math.Ceiling((double)users.Count / pageSize);
            for (int i = 0; i < totalPages; i++)
                comboBoxNoOfPage.Items.Add(i);

            comboBoxNoOfPage.SelectedIndex = 0;
            columnsSet = false;
            SetColumns();

            LoadingForm.Instance(_mainForm).Hide();
        }

        public async Task SearchAsync()
        {
            // Show Loading
            LoadingForm.Instance(_mainForm).Show();
            try
            {
                if (!await Task.Run(() => userDataHelper.IsCanConnect()))
                {   
                    // Start Load Data
                    ShowServerErrorState();
                    MsgHelper.ShowServerError();
                    return;
                }

                string searchItem = textBoxSearch.Text;

                // Check if Admin or not
                users = LocalUser.Role == "Admin"

                    // Get All Data
                    ? await Task.Run(() => userDataHelper.SearchAll(searchItem))
                    : await Task.Run(() => userDataHelper.SearchByUser(LocalUser.UserId, searchItem));

                labelNoOfItems.Text = users.Count.ToString();

                comboBoxNoOfPage.Items.Clear();
                int totalPages = (int)Math.Ceiling((double)users.Count / pageSize);

                dataGridView1.DataSource = users
                    .Take(pageSize)
                    .ToList();

                columnsSet = false;
                SetColumns();


                for (int i = 0; i < totalPages; i++)
                    comboBoxNoOfPage.Items.Add(i);

                comboBoxNoOfPage.SelectedIndex = totalPages > 0 ? 0 : -1;

                ShowEmptyDataState();
                
            }
            finally
            {
                // Hide Loading
                LoadingForm.Instance(_mainForm).Hide();
            }
        }

        private void ShowEmptyDataState()
        {
            // Set Title and Description
            labelStateTitle.Text = Properties.Resources.EmptyDataStateTitle;
            labelStateDescription.Text = Properties.Resources.EmptyDataStateDescription;
            // Show Empty Data Method
            panelState.Visible = dgvHelper.IsEmpty(dataGridView1);
        }

        private void ShowServerErrorState()
        {
            // Set Title and Description
            labelStateTitle.Text = Properties.Resources.ServerErrorTitle;
            labelStateDescription.Text = Properties.Resources.ServerErrorDescription;
            // Show Empty Server Error state
            panelState.Visible = true;
        }

        private void SetColumns()
        {
            if (columnsSet) return;
            if (dataGridView1.Columns.Count < 12) return;

            dataGridView1.Columns[0].HeaderCell.Value = "Id";
            dataGridView1.Columns[1].HeaderCell.Value = "Полное имя";
            dataGridView1.Columns[2].HeaderCell.Value = "Имя пользователя";
            dataGridView1.Columns[3].HeaderCell.Value = "Пароль";
            dataGridView1.Columns[4].HeaderCell.Value = "Общая действительность";
            dataGridView1.Columns[5].HeaderCell.Value = "Является вторичным пользователем";
            dataGridView1.Columns[6].HeaderCell.Value = "Базовый идентификатор";
            dataGridView1.Columns[7].HeaderCell.Value = "Номер телефона";
            dataGridView1.Columns[8].HeaderCell.Value = "Электронная почта";
            dataGridView1.Columns[9].HeaderCell.Value = "Жилье";
            dataGridView1.Columns[10].HeaderCell.Value = "Дата создания";
            dataGridView1.Columns[11].HeaderCell.Value = "Дата редактирования";

            // Visible Of Columns
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;

            columnsSet = true;
        }

        private void EditUser()
        {
            // Check Data if not Empty
            if (!dgvHelper.IsEmpty(dataGridView1))
            {
                // Get Id
                int Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                if (addUserForm == null || addUserForm.IsDisposed)
                {
                    addUserForm = new AddUserForm(_mainForm, Id, this);
                    addUserForm.Show();
                }
                else
                {
                    addUserForm.Focus();
                }
            }
            else
            {
                MsgHelper.ShowEmptyDataGridView();
            }
        }

        private void SetIdDeleteList()
        {
            deleteIds.Clear();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Selected)
                {
                    deleteIds.Add(Convert.ToInt32(row.Cells[0].Value));
                }
            }
        }

        private void ExportExcel(List<User> data)
        {
            // Define Data Table
            DataTable dataTable = new DataTable();

            // Convert to Data Table
            using (var reader = FastMember.ObjectReader.Create(data))
            {
                dataTable.Load(reader);
            }

            // Re-Set DataTable
            dataTable = ArrangeDataTable(dataTable);

            // Send to export
            ExcelHelper.Export(dataTable, "Users");
        }

        private DataTable ArrangeDataTable(DataTable dataTable)
        {
            dataTable.Columns["Id"].SetOrdinal(0);
            dataTable.Columns["Id"].ColumnName = "Id";

            dataTable.Columns["FullName"].SetOrdinal(1);
            dataTable.Columns["FullName"].ColumnName = "Полное имя";


            dataTable.Columns["UserName"].SetOrdinal(2);
            dataTable.Columns["UserName"].ColumnName = "Имя пользователя";


            dataTable.Columns["Password"].SetOrdinal(3);
            dataTable.Columns["Password"].Expression = "'******'";

            dataTable.Columns["Role"].SetOrdinal(4);
            dataTable.Columns["Role"].ColumnName = "Общая действительность";

            dataTable.Columns["IsSecondaryUser"].SetOrdinal(5);
            dataTable.Columns["IsSecondaryUser"].ColumnName = "Является вторичным пользователем";

            dataTable.Columns["UserId"].SetOrdinal(6);
            dataTable.Columns["UserId"].ColumnName = "Базовый идентификатор";

            dataTable.Columns["PhoneNumber"].SetOrdinal(7);
            dataTable.Columns["PhoneNumber"].ColumnName = "Номер телефона";


            dataTable.Columns["Email"].SetOrdinal(8);
            dataTable.Columns["Email"].ColumnName = "Электронная почта";


            dataTable.Columns["Address"].SetOrdinal(9);
            dataTable.Columns["Address"].ColumnName = "Жилье";


            dataTable.Columns["CreatedDate"].SetOrdinal(10);
            dataTable.Columns["CreatedDate"].ColumnName = "Дата создания";


            dataTable.Columns["EditedDate"].SetOrdinal(11);
            dataTable.Columns["EditedDate"].ColumnName = "Дата редактирования";


            // Removed columns
            dataTable.Columns.Remove("Roles");
            /*dataTable.Columns.Remove("SystemRecords");*/

            return dataTable;
        }

        private void Initialize(Main main)
        {
            _mainForm = main;

            // check data
            if (!DesignMode && IsHandleCreated)
            {
                _ = LoadDataAsync();
            }
        }

        #endregion


    }
}
