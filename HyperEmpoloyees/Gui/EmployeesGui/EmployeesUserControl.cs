using HyperEmpoloyees.Code.Helpers;
using HyperEmpoloyees.Code.Models;
using HyperEmpoloyees.Core;
using HyperEmpoloyees.Data.EF;
using HyperEmpoloyees.Gui.EmployeesGui;
using HyperEmpoloyees.Gui.LoadingGui;
using System.Data;

namespace HyperEmpoloyees.Gui.EmpoloyeesGui
{
    public partial class EmployeesUserControl : UserControl
    {
        private static EmployeesUserControl? employeesUserControl;
        private AddEmployeesForm addEmployeesForm;
        private static Main mainForm;
        private IDataHelper<Core.Employee> employeeDataHelper;
        private List<Core.Employee> employees;
        private List<int> deleteIds;

        public EmployeesUserControl()
        {
            InitializeComponent();
            employeeDataHelper = new EmployeeRepository();
            employees = new List<Employee>();
            deleteIds = new List<int>();
            LoadData();
        }

        public static EmployeesUserControl Instance(Main main)
        {
            mainForm = main;
            return employeesUserControl ?? (employeesUserControl = new EmployeesUserControl());
        }

        #region Events
        public void buttonAdd_Click(object sender, EventArgs e)
        {
            if (addEmployeesForm == null || addEmployeesForm.IsDisposed)
            {
                addEmployeesForm = new AddEmployeesForm(mainForm, 0, this);
                addEmployeesForm.Show();
            }
            else
            {
                addEmployeesForm.Focus();
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            EditEmployee();
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
                            if (await Task.Run(() => employeeDataHelper.IsCanConnect()))
                            {
                                // Loop into Id List
                                foreach (int Id in deleteIds)
                                {
                                    await Task.Run(() => employeeDataHelper.Delete(Id));
                                    SystemRecordHelper.Add("Удалить сотрудника",
                                        $"Текущий сотрудник с идентификационным номером был удален {Id.ToString()}");
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

        private async void buttonRefresh_Click(object sender, EventArgs e)
        {
            await LoadData();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditEmployee();
        }

        private async void buttonExportAll_Click(object sender, EventArgs e)
        {
            // Show Loading
            LoadingForm.Instance(mainForm).Show();
            if (await Task.Run(() => employeeDataHelper.IsCanConnect()))
            {
                // Start Load Data
                // Check if Admin or not
                employees = await LoadEmployees();
                LoadingForm.Instance(mainForm).Hide();

                ExportExcel(employees);
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
            var data = (List<Employee>)dataGridView1.DataSource;
            ExportExcel(data);
        }

        private void ExportExcel(List<Employee> data)
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
            ExcelHelper.Export(dataTable, "Employees");
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
                if (await Task.Run(() => employeeDataHelper.IsCanConnect()))
                {
                    // Start Load Data
                    // Check if Admin or not
                    employees = await LoadEmployees();

                    // No Of all items in db
                    labelNoOfItems.Text = employees.Count.ToString();
                    // Get And set parameters
                    var idlist = employees.Select(x => x.Id).ToArray();
                    int index = comboBoxNoOfPage.SelectedIndex;
                    int noOfItemIndex = index * Properties.Settings.Default.NoDataGridViewItems;

                    // Fill DataGridView
                    dataGridView1.DataSource = employees.Where(x => x.Id <= idlist[noOfItemIndex])
                        .Take(Properties.Settings.Default.NoDataGridViewItems).ToList();

                    // Show Empty Data
                    ShowEmptyDataState();

                    // Clear Data
                    employees.Clear();
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
        public async Task LoadData()
        {
            // Show Loading
            LoadingForm.Instance(mainForm).Show();
            if (await Task.Run(() => employeeDataHelper.IsCanConnect()))
            {
                // Start Load Data
                // Check if Admin or not
                employees = await LoadEmployees();

                // No Of all items in db
                labelNoOfItems.Text = employees.Count.ToString();
                // Fill DataGridView
                dataGridView1.DataSource = employees.Take(Properties.Settings.Default.NoDataGridViewItems).ToList();
                if (employees.Count <= Properties.Settings.Default.NoDataGridViewItems)
                {
                    comboBoxNoOfPage.Items.Clear();
                    comboBoxNoOfPage.Items.Add(0);
                }
                else
                {
                    // Get And Add No Of Pages
                    double value = Convert.ToDouble(employees.Count) / Convert.ToDouble(Properties.Settings.Default.NoDataGridViewItems);
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
                employees.Clear();
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

        public async Task Search()
        {
            // Show Loading
            LoadingForm.Instance(mainForm).Show();
            if (await Task.Run(() => employeeDataHelper.IsCanConnect()))
            {
                // Start Load Data
                string searchItem = textBoxSearch.Text;
                // Check if Admin or not
                employees = await Task.Run(() =>
                employeeDataHelper.GetDataByUser(LocalUser.UserId));


                // Fill DataGridView
                dataGridView1.DataSource = employees.ToList();

                // Set Columns Title
                // SetColumns();

                // Show Empty Data
                ShowEmptyDataState();

                // Clear Data
                employees.Clear();
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
            dataGridView1.Columns[1].Width = 150;
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
        }

        private void EditEmployee()
        {
            // Check Data if not Empty
            if (!dgvHelper.IsEmpty(dataGridView1))
            {
                // Get Id
                int Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                if (addEmployeesForm == null || addEmployeesForm.IsDisposed)
                {
                    addEmployeesForm = new AddEmployeesForm(mainForm, Id, this);
                    addEmployeesForm.Show();
                }
                else
                {
                    addEmployeesForm.Focus();
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

            dataTable.Columns["Name"].SetOrdinal(1);
            dataTable.Columns["Name"].ColumnName = "Полное имя";

            dataTable.Columns["JobTitle"].SetOrdinal(2);
            dataTable.Columns["JobTitle"].ColumnName = "Должность";

            dataTable.Columns["EmploymentState"].SetOrdinal(3);
            dataTable.Columns["EmploymentState"].ColumnName = "Статус";

            dataTable.Columns["CurrentSalary"].SetOrdinal(4);
            dataTable.Columns["CurrentSalary"].ColumnName = $"Текущая зарплата {Properties.Settings.Default.Currency}";

            dataTable.Columns["NextSalary"].SetOrdinal(5);
            dataTable.Columns["NextSalary"].ColumnName = $"Следующая зарплата {Properties.Settings.Default.Currency}";

            dataTable.Columns["LastPromotionDate"].SetOrdinal(6);
            dataTable.Columns["LastPromotionDate"].ColumnName = "Последнее повышение";

            // Remove columns we don't want in Excel
            string[] columnsToRemove =
                {
                "UsersId",
                "Note",
                "AddedDate",
                "UpdateDate",
                "CurrentDate",
                "CurrentDegree",
                "CurrentStage",
                "NextDate",
                "NextDegree",
                "NextStage",
                "Records",
                "Rewards"
            };

            foreach (var column in columnsToRemove)
            {
                if (dataTable.Columns.Contains(column))
                    dataTable.Columns.Remove(column);
            }


            //dataTable.Columns.Remove("UsersId");
            //dataTable.Columns.Remove("Note");
            //dataTable.Columns.Remove("AddedDate");
            //dataTable.Columns.Remove("UpdateDate");

            return dataTable;
        }

        private async Task<List<Employee>> LoadEmployees()
        {
            if (LocalUser.Role == "Admin")
                return await Task.Run(() => employeeDataHelper.GetDataByUser(LocalUser.UserId));

            return await Task.Run(() => employeeDataHelper.GetDataByUser(LocalUser.UserId));
        }

        private Employee? GetSelectedEmployee()
        {
            if (dataGridView1.CurrentRow == null)
                return null;

            return dataGridView1.CurrentRow.DataBoundItem as Employee;
        }
        #endregion

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {   
                MsgHelper.ShowEmptyDataGridView();
                return;
            }

            using (EmployeePrintForm printForm = new EmployeePrintForm(dataGridView1))
            {
                printForm.ShowDialog();
            }
        }
    }
}
