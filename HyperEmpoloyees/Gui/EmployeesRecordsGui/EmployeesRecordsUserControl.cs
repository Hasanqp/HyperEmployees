using HyperEmpoloyees.Code.Helpers;
using HyperEmpoloyees.Code.Models;
using HyperEmpoloyees.Core;
using HyperEmpoloyees.Data.EF;
using HyperEmpoloyees.Gui.LoadingGui;
using System.Data;

namespace HyperEmpoloyees.Gui.EmployeesRecordsGui
{
    public partial class EmployeesRecordsUserControl : UserControl
    {
        private static Main mainForm;
        private IDataHelper<Core.EmployeesRecord> employeesRecordsDataHelper;
        private List<Core.EmployeesRecord> employeesRecords;
        private List<int> deleteIds;
        private Employee employee;

        public EmployeesRecordsUserControl(Employee employee)
        {
            InitializeComponent();
            employeesRecordsDataHelper = new EmployeeRecordsRepository();
            employeesRecords = new List<EmployeesRecord>();
            deleteIds = new List<int>();
            this.employee = employee;
            LoadData();
        }

        #region Evints
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
                            if (await Task.Run(() => employeesRecordsDataHelper.IsCanConnect()))
                            {
                                // Loop into Id List
                                foreach (int Id in deleteIds)
                                {
                                    await Task.Run(() => employeesRecordsDataHelper.Delete(Id));
                                    SystemRecordHelper.Add("Удалить бонуса",
                                        $"Существующая премия с идентификационным номером {Id.ToString()} была удалена");
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
            if (await Task.Run(() => employeesRecordsDataHelper.IsCanConnect()))
            {
                // Start Load Data
                // Check if Admin or not
                employeesRecords = await LoadEmployeesRecords();

                LoadingForm.Instance(mainForm).Hide();

                ExportExcel(employeesRecords);
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
            var data = (List<EmployeesRecord>)dataGridView1.DataSource;
            ExportExcel(data);
        }

        private void ExportExcel(List<EmployeesRecord> data)
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
            ExcelHelper.Export(dataTable, "EmployeesRecords");
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
                if (await Task.Run(() => employeesRecordsDataHelper.IsCanConnect()))
                {
                    // No Of all items in db
                    if (employeesRecords == null || employeesRecords.Count == 0)
                        // Start Load Data
                        // Check if Admin or not
                        employeesRecords = await LoadEmployeesRecords();

                    // Get And set parameters
                    int index = comboBoxNoOfPage.SelectedIndex;
                    int pageSize = Properties.Settings.Default.NoDataGridViewItems;
                    int skip = index * pageSize;

                    // Fill DataGridView
                    dataGridView1.DataSource = employeesRecords
                        .Skip(skip)
                        .Take(pageSize)
                        .ToList();

                    // Show Empty Data
                    ShowEmptyDataState();                }
                else
                {
                    // No Conection
                    ShowServerErrorState();
                    MsgHelper.ShowServerError();
                }
                // Hide Loading
                LoadingForm.Instance(mainForm).Hide();
            }
            catch
            { }
            finally
            {
                LoadingForm.Instance(mainForm).Hide();
            }


        }

        #endregion

        #region Methods
        public async void LoadData()
        {
            // Show Loading
            LoadingForm.Instance(mainForm).Show();

            if (await Task.Run(() => employeesRecordsDataHelper.IsCanConnect()))
            {
                // Start Load Data
                // Check if Admin or not
                employeesRecords = await LoadEmployeesRecords();

                // No Of all items in db
                labelNoOfItems.Text = employeesRecords.Count.ToString();

                // Fill DataGridView
                dataGridView1.DataSource = employeesRecords.Take(Properties.Settings.Default.NoDataGridViewItems).ToList();
                if (employeesRecords.Count <= Properties.Settings.Default.NoDataGridViewItems)
                {
                    comboBoxNoOfPage.Items.Clear();
                    comboBoxNoOfPage.Items.Add(0);
                }
                else
                {
                    // Get And Add No Of Pages
                    double value = Convert.ToDouble(employeesRecords.Count) / Convert.ToDouble(Properties.Settings.Default.NoDataGridViewItems);
                    int pageCount = (int)Math.Ceiling((double)employeesRecords.Count / Properties.Settings.Default.NoDataGridViewItems);

                    comboBoxNoOfPage.Items.Clear();
                    for (int i = 0; i < pageCount; i++)
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
            if (await Task.Run(() => employeesRecordsDataHelper.IsCanConnect()))
            {
                // Start Load Data
                string searchItem = textBoxSearch.Text;
                // Check if Admin or not
                employeesRecords = await LoadEmployeesRecords();

                // Fill DataGridView
                dataGridView1.DataSource = employeesRecords.ToList();

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
            dataGridView1.Columns[2].HeaderCell.Value = "Должность";
            dataGridView1.Columns[3].HeaderCell.Value = "Статус";
            dataGridView1.Columns[4].Visible = false;

            dataGridView1.Columns[5].HeaderCell.Value = "Текущая оценка";
            dataGridView1.Columns[6].HeaderCell.Value = "Текущий этап";
            dataGridView1.Columns[7].HeaderCell.Value = "Текущая заработная плата";
             dataGridView1.Columns[8].HeaderCell.Value = "Текущая история";

             dataGridView1.Columns[9].HeaderCell.Value = "Следующая степень";
            dataGridView1.Columns[10].HeaderCell.Value = "Следующий этап";
            dataGridView1.Columns[11].HeaderCell.Value = "Следующая зарплата";
            dataGridView1.Columns[12].HeaderCell.Value = "Следующая дата";

            // Visible Of Columns
            dataGridView1.Columns[13].Visible = false;
            dataGridView1.Columns[14].Visible = false;
            dataGridView1.Columns[15].Visible = false;
            dataGridView1.Columns[16].Visible = false;
            dataGridView1.Columns[17].Visible = false;
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

            dataTable.Columns["Degree"].SetOrdinal(1);
            dataTable.Columns["Degree"].ColumnName = "Функциональная оценка";

            dataTable.Columns["Salary"].SetOrdinal(2);
            dataTable.Columns["Salary"].ColumnName = $"Зарплата {Properties.Settings.Default.Currency}";

            dataTable.Columns["BounsYearRate"].SetOrdinal(3);
            dataTable.Columns["BounsYearRate"].ColumnName = $"Ежегодное пособие {Properties.Settings.Default.Currency}";

            dataTable.Columns["PromotionMonth"].SetOrdinal(4);
            dataTable.Columns["PromotionMonth"].ColumnName = "Годы продвижения по службе";

            // Removed columns
            dataTable.Columns.Remove("UsersId");

            return dataTable;
        }

        private async Task<List<EmployeesRecord>> LoadEmployeesRecords()
        {
            return await Task.Run(() =>
                employeesRecordsDataHelper.GetDataByUser(LocalUser.UserId)
            );
        }
        #endregion
    }
}
