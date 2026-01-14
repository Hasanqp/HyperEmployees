using HyperEmpoloyees.Code.Helpers;
using HyperEmpoloyees.Code.Models;
using HyperEmpoloyees.Core;
using HyperEmpoloyees.Data.EF;
using HyperEmpoloyees.Gui.LoadingGui;
using System.Data;

namespace HyperEmpoloyees.Gui.EmployeeRewardsGui
{
    public partial class EmployeeRewardsUserControl : UserControl
    {
        private static EmployeeRewardsUserControl? bookThanksUserControl;
        private AddEmployeeRewardsForm addEmployeeRewardsForm;
        private static Main mainForm;
        private IDataHelper<Core.EmployeeReward> employeeRewardDataHelper;
        private List<Core.EmployeeReward> employeeRewards;
        private List<int> deleteIds;
        private readonly Employee employee;

        public EmployeeRewardsUserControl(Employee employee)
        {
            InitializeComponent();
            employeeRewardDataHelper = new EmployeeRewardRepository();
            employeeRewards = new List<EmployeeReward>();
            deleteIds = new List<int>();
            this.employee = employee;
            LoadData();

        }

        #region Evints
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (addEmployeeRewardsForm == null || addEmployeeRewardsForm.IsDisposed)
            {
                addEmployeeRewardsForm = new AddEmployeeRewardsForm(mainForm, 0, this, employee);
                addEmployeeRewardsForm.Show();
            }
            else
            {
                addEmployeeRewardsForm.Focus();
            }

        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            Edit();
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
                            LoadingForm.Instance(mainForm).Show();
                            if (await Task.Run(() => employeeRewardDataHelper.IsCanConnect()))
                            {
                                // Loop into Id List
                                foreach (int Id in deleteIds)
                                {
                                    await Task.Run(() => employeeRewardDataHelper.Delete(Id));
                                    SystemRecordHelper.Add("Удалите книгу благодарностей",
                                        $"Книга благодарностей с идентификационным номером {Id.ToString()} была удалена");
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
            Edit();
        }

        private async void buttonExportAll_Click(object sender, EventArgs e)
        {
            // Show Loading
            LoadingForm.Instance(mainForm).Show();
            if (await Task.Run(() => employeeRewardDataHelper.IsCanConnect()))
            {
                // Start Load Data
                // Check if Admin or not
                employeeRewards = await LoadRewards();

                LoadingForm.Instance(mainForm).Hide();

                ExportExcel(employeeRewards);
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
            var data = (List<EmployeeReward>)dataGridView1.DataSource;
            ExportExcel(data);
        }

        private void ExportExcel(List<EmployeeReward> data)
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
            ExcelHelper.Export(dataTable, "BookThanks");
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
                if (await Task.Run(() => employeeRewardDataHelper.IsCanConnect()))
                {
                    // Start Load Data
                    // Check if Admin or not
                    employeeRewards = await LoadRewards();

                    // No Of all items in db
                    labelNoOfItems.Text = employeeRewards.Count.ToString();
                    // Get And set parameters
                    var idlist = employeeRewards.Select(x => x.Id).ToArray();
                    int index = comboBoxNoOfPage.SelectedIndex;
                    int noOfItemIndex = index * Properties.Settings.Default.NoDataGridViewItems;

                    // Fill DataGridView
                    dataGridView1.DataSource = employeeRewards.Where(x => x.Id <= idlist[noOfItemIndex])
                        .Take(Properties.Settings.Default.NoDataGridViewItems).ToList();

                    // Show Empty Data
                    ShowEmptyDataState();

                    // Clear Data
                    employeeRewards.Clear();
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
            if (await Task.Run(() => employeeRewardDataHelper.IsCanConnect()))
            {
                // Start Load Data
                // Check if Admin or not
                employeeRewards = await LoadRewards();

                // No Of all items in db
                labelNoOfItems.Text = employeeRewards.Count.ToString();
                // Fill DataGridView
                dataGridView1.DataSource = employeeRewards.Take(Properties.Settings.Default.NoDataGridViewItems).ToList();
                if (employeeRewards.Count <= Properties.Settings.Default.NoDataGridViewItems)
                {
                    comboBoxNoOfPage.Items.Clear();
                    comboBoxNoOfPage.Items.Add(0);
                }
                else
                {
                    // Get And Add No Of Pages
                    double value = Convert.ToDouble(employeeRewards.Count) / Convert.ToDouble(Properties.Settings.Default.NoDataGridViewItems);
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

                // Clear Data
                employeeRewards.Clear();
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
            if (await Task.Run(() => employeeRewardDataHelper.IsCanConnect()))
            {
                // Start Load Data
                string searchItem = textBoxSearch.Text;
                // Check if Admin or not
                employeeRewards = await LoadRewards();

                // Fill DataGridView
                dataGridView1.DataSource = employeeRewards.ToList();

                // Set Columns Title
                // SetColumns();

                // Show Empty Data
                ShowEmptyDataState();

                // Clear Data
                employeeRewards.Clear();
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
            dataGridView1.Columns[1].HeaderCell.Value = "Влияние";
            dataGridView1.Columns[2].HeaderCell.Value = "Числа";
            dataGridView1.Columns[3].HeaderCell.Value = "Дата";
            dataGridView1.Columns[4].HeaderCell.Value = "Примечания";
            dataGridView1.Columns[5].HeaderCell.Value = "Дата добавления";

            // Visible Of Columns
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
        }

        private void Edit()
        {
            // Check Data if not Empty
            if (!dgvHelper.IsEmpty(dataGridView1) && dataGridView1.CurrentRow.Selected == true)
            {
                // Get Id
                int Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                if (addEmployeeRewardsForm == null || addEmployeeRewardsForm.IsDisposed)
                {
                    addEmployeeRewardsForm = new AddEmployeeRewardsForm(mainForm, Id, this, employee);
                    addEmployeeRewardsForm.Show();
                }
                else
                {
                    addEmployeeRewardsForm.Focus();
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

        private async Task<List<EmployeeReward>> LoadRewards()
        {
            return await Task.Run(() =>
                employeeRewardDataHelper.GetDataByUser(LocalUser.UserId)
            );
        }
        #endregion
    }
}
