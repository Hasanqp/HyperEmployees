using HyperEmpoloyees.Code.Helpers;
using HyperEmpoloyees.Code.Models;
using HyperEmpoloyees.Core;
using HyperEmpoloyees.Data.EF;
using HyperEmpoloyees.Gui.LoadingGui;
using System.Data;

namespace HyperEmpoloyees.Gui.SystemRecordsGui
{
    public partial class SystemRecordsUserControl : UserControl
    {
        private static SystemRecordsUserControl? systemRecordsControl;
        private static Main mainForm;
        private IDataHelper<Core.SystemRecord> systemRecordDataHelper;
        private List<Core.SystemRecord> systemRecords;
        private List<int> deleteIds;

        public SystemRecordsUserControl()
        {
            InitializeComponent();
            systemRecordDataHelper = new SystemRecordRepository();
            systemRecords = new List<SystemRecord>();
            deleteIds = new List<int>();
            LoadData();
        }

        public static SystemRecordsUserControl Instance(Main main)
        {
            mainForm = main;
            return systemRecordsControl ?? (systemRecordsControl = new SystemRecordsUserControl());
        }

        #region Events
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
                            LoadingForm.Instance(mainForm).Show();
                            if (await Task.Run(() => systemRecordDataHelper.IsCanConnect()))
                            {
                                // Loop into Id List
                                foreach (int Id in deleteIds)
                                {
                                    await Task.Run(() => systemRecordDataHelper.Delete(Id));
                                }
                                ToastHelper.ShowDeleteToast();
                                LoadData();
                            }
                            else
                            {
                                LoadingForm.Instance(mainForm).Hide();
                                MsgHelper.ShowServerError();
                            }

                            LoadingForm.Instance(mainForm).Hide();
                        }
                    }
                    else
                    {

                        MsgHelper.ShowDeleteSelectRow();
                    }
                }
                else
                {
                    LoadingForm.Instance(mainForm).Hide();
                    MsgHelper.ShowEmptyDataGridView();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }


        private void buttonSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void textBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search();
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void buttonExportAll_Click(object sender, EventArgs e)
        {
            // Show Loading
            LoadingForm.Instance(mainForm).Show();
            if (await Task.Run(() => systemRecordDataHelper.IsCanConnect()))
            {
                // Start Load Data
                // Check if Admin or not
                if (LocalUser.Role == "Admin")
                {
                    // Get All Data
                    systemRecords = await Task.Run(() => systemRecordDataHelper.GetAllData());
                }
                else
                {
                    // Get Data By User
                    systemRecords = await Task.Run(() => systemRecordDataHelper.GetDataByUser(LocalUser.UserId));
                }
                LoadingForm.Instance(mainForm).Hide();

                ExportExcel(systemRecords);
            }
            else
            {
                // No Conection
                LoadingForm.Instance(mainForm).Hide();
                ShowServerErrorState();
                MsgHelper.ShowServerError();
            }
            // Hide Loading
            LoadingForm.Instance(mainForm).Hide();
        }

        private void buttonExportDataGridView_Click(object sender, EventArgs e)
        {
            // Get Data
            var data = dataGridView1.DataSource as List<SystemRecord>;
            if (data != null)
            {
                ExportExcel(data);
            }
        }

        private void ExportExcel(List<SystemRecord> data)
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
            ExcelHelper.Export(dataTable, "SystemRecords");
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
            try
            {
                // Show Loading
                LoadingForm.Instance(mainForm).Show();
                if (await Task.Run(() => systemRecordDataHelper.IsCanConnect()))
                {
                    // Start Load Data
                    // Check if Admin or not
                    if (LocalUser.Role == "Admin")
                    {
                        // Get All Data
                        systemRecords = await Task.Run(() => systemRecordDataHelper.GetAllData());
                    }
                    else
                    {
                        // Get Data By User
                        systemRecords = await Task.Run(() => systemRecordDataHelper.GetDataByUser(LocalUser.UserId));
                    }
                    // No Of all items in db
                    labelNoOfItems.Text = systemRecords.Count.ToString();
                    // Get And set parameters
                    var idlist = systemRecords.Select(x => x.Id).ToArray();
                    int index = comboBoxNoOfPage.SelectedIndex;
                    int noOfItemIndex = index * Properties.Settings.Default.NoDataGridViewItems;

                    // Fill DataGridView
                    dataGridView1.DataSource = systemRecords
                        .Skip(index * Properties.Settings.Default.NoDataGridViewItems)
                        .Take(Properties.Settings.Default.NoDataGridViewItems)
                        .ToList();


                    // Show Empty Data
                    ShowEmptyDataState();

                    LoadingForm.Instance(mainForm).Hide();
                }
                else
                {
                    // No Conection
                    LoadingForm.Instance(mainForm).Hide();
                    ShowServerErrorState();
                    MsgHelper.ShowServerError();
                }
                // Hide Loading
                LoadingForm.Instance(mainForm).Hide();
            }
            catch
            { }

        }

        #endregion

        #region Methods
        public async void LoadData()
        {
            // Show Loading
            LoadingForm.Instance(mainForm).Show();
            if (await Task.Run(() => systemRecordDataHelper.IsCanConnect()))
            {
                // Start Load Data
                // Check if Admin or not
                if (LocalUser.Role == "Admin")
                {
                    // Get All Data
                    systemRecords = await Task.Run(() => systemRecordDataHelper.GetAllData());
                }
                else
                {
                    // Get Data By User
                    systemRecords = await Task.Run(() => systemRecordDataHelper.GetDataByUser(LocalUser.UserId));
                }

                // No Of all items in db
                labelNoOfItems.Text = systemRecords.Count.ToString();
                // Fill DataGridView
                dataGridView1.DataSource = systemRecords.Take(Properties.Settings.Default.NoDataGridViewItems).ToList();
                if (systemRecords.Count <= Properties.Settings.Default.NoDataGridViewItems)
                {
                    comboBoxNoOfPage.Items.Clear();
                    comboBoxNoOfPage.Items.Add(0);
                }
                else
                {
                    // Get And Add No Of Pages
                    double value = Convert.ToDouble(systemRecords.Count) / Convert.ToDouble(Properties.Settings.Default.NoDataGridViewItems);
                    int noOfPage = Convert.ToInt32(Math.Round(value, MidpointRounding.AwayFromZero));
                    comboBoxNoOfPage.Items.Clear();
                    for (int i = 0; i <= noOfPage; i++)
                    {
                        comboBoxNoOfPage.Items.Add(i);
                    }
                }

                // Set Columns Title
                SetColumns();

                // Show Empty Data
                ShowEmptyDataState();

                LoadingForm.Instance(mainForm).Hide();
            }
            else
            {
                // No Conection
                LoadingForm.Instance(mainForm).Hide();
                ShowServerErrorState();
                MsgHelper.ShowServerError();
            }
            // Hide Loading
            LoadingForm.Instance(mainForm).Hide();
        }

        public async void Search()
        {
            // Show Loading
            LoadingForm.Instance(mainForm).Show();
            if (await Task.Run(() => systemRecordDataHelper.IsCanConnect()))
            {
                // Start Load Data
                string searchItem = textBoxSearch.Text;
                // Check if Admin or not
                if (LocalUser.Role == "Admin")
                {
                    // Get All Data
                    systemRecords = await Task.Run(() => systemRecordDataHelper.SearchAll(searchItem));
                }
                else
                {
                    // Get Data By User
                    systemRecords = await Task.Run(() => systemRecordDataHelper.SearchByUser(LocalUser.UserId, searchItem));
                }

                // Fill DataGridView
                dataGridView1.DataSource = systemRecords.ToList();

                // Set Columns Title
                // SetColumns();

                // Show Empty Data
                ShowEmptyDataState();

                LoadingForm.Instance(mainForm).Hide();
            }
            else
            {
                // No Conection
                LoadingForm.Instance(mainForm).Hide();
                ShowServerErrorState();
                MsgHelper.ShowServerError();
            }
            // Hide Loading
            LoadingForm.Instance(mainForm).Hide();
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
            dataGridView1.Columns[0].HeaderCell.Value = "Id";
            dataGridView1.Columns[1].HeaderCell.Value = "Полное имя";
            dataGridView1.Columns[2].HeaderCell.Value = "Имя устройства";
            dataGridView1.Columns[3].HeaderCell.Value = "MAC";
            dataGridView1.Columns[4].HeaderCell.Value = "Заглавие";
            dataGridView1.Columns[5].HeaderCell.Value = "Описание";
            dataGridView1.Columns[6].HeaderCell.Value = "Дата создания";
            dataGridView1.Columns[7].HeaderCell.Value = "Идентификатор пользователя";
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

        private DataTable ArrangeDataTable(DataTable dataTable)
        {
            dataTable.Columns["Id"].SetOrdinal(0);
            dataTable.Columns["Id"].ColumnName = "Id";

            dataTable.Columns["UserFullName"].SetOrdinal(1);
            dataTable.Columns["UserFullName"].ColumnName = "Полное имя";


            dataTable.Columns["DeviceName"].SetOrdinal(2);
            dataTable.Columns["DeviceName"].ColumnName = "Имя устройства";


            dataTable.Columns["MachinId"].SetOrdinal(3);
            dataTable.Columns["MachinId"].ColumnName = "MAC";

            dataTable.Columns["Title"].SetOrdinal(4);
            dataTable.Columns["Title"].ColumnName = "Заглавие";

            dataTable.Columns["Description"].SetOrdinal(5);
            dataTable.Columns["Description"].ColumnName = "Описание";

            dataTable.Columns["CreatedDate"].SetOrdinal(6);
            dataTable.Columns["CreatedDate"].ColumnName = "Дата создания";

            dataTable.Columns["UsersId"].SetOrdinal(7);
            dataTable.Columns["UsersId"].ColumnName = "Идентификатор пользователя";

            return dataTable;
        }
        #endregion


    }
}
