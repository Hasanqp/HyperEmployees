using HyperEmpoloyees.Code.Helpers;
using HyperEmpoloyees.Code.Models;
using HyperEmpoloyees.Core;
using HyperEmpoloyees.Data.EF;
using HyperEmpoloyees.Gui.LoadingGui;
using System.Data;
using System.Drawing.Printing;

namespace HyperEmpoloyees.Gui.SalaryRateGui
{
    public partial class SalaryRateUserControl : UserControl
    {
        private static SalaryRateUserControl? salaryRateUserControl;
        private AddSalaryRateForm addSalaryRateForm;
        private static Main mainForm;
        private IDataHelper<Core.SalaryRate> dataHelper;
        private List<Core.SalaryRate> data;
        private List<int> IdDeleteList;

        public SalaryRateUserControl()
        {
            InitializeComponent();
            dataHelper = new SalaryRateRepository();
            data = new List<SalaryRate>();
            IdDeleteList = new List<int>();
            LoadData();
        }

        public static SalaryRateUserControl Instance(Main main)
        {
            mainForm = main;
            return salaryRateUserControl ?? (salaryRateUserControl = new SalaryRateUserControl());
        }

        #region Evints
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (addSalaryRateForm == null || addSalaryRateForm.IsDisposed)
            {
                addSalaryRateForm = new AddSalaryRateForm(mainForm, 0, this);
                addSalaryRateForm.Show();
            }
            else
            {
                addSalaryRateForm.Focus();
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
                    if (IdDeleteList.Count > 0)
                    {
                        if (MsgHelper.ShowDeleteDialog())
                        {
                            LoadingForm.Instance(mainForm).Show();
                            if (await Task.Run(() => dataHelper.IsCanConnect()))
                            {
                                // Loop into Id List
                                foreach (int Id in IdDeleteList)
                                {
                                    await Task.Run(() => dataHelper.Delete(Id));
                                    SystemRecordHelper.Add("Удаление функциональной оценки",
                                        $"Функциональная оценка, содержащая идентификационный номер, была удалена{Id.ToString()}");
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
            if (await Task.Run(() => dataHelper.IsCanConnect()))
            {
                // Start Load Data
                // Check if Admin or not
                if (LocalUser.Role == "Admin")
                {
                    // Get All Data
                    data = await Task.Run(() => dataHelper.GetDataByUser(LocalUser.UserId));
                }
                else
                {
                    // Get Data By User
                    data = await Task.Run(() => dataHelper.GetDataByUser(LocalUser.UserId));
                }
                LoadingForm.Instance(mainForm).Hide();

                ExportExcel(data);
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
            var data = (List<SalaryRate>)dataGridView1.DataSource;
            ExportExcel(data);
        }

        private void ExportExcel(List<SalaryRate> data)
        {
            // Define Data Table
            DataTable dataTable = new DataTable();

            // Convert to Data Table
            using (var reader = FastMember.ObjectReader.Create(data))
            {
                dataTable.Load(reader);
            }

            // Re-Set DataTable
            dataTable = arrangedDataTable(dataTable);

            // Send to export
            ExcelHelper.Export(dataTable, "SalaryRate");
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
                if (await Task.Run(() => dataHelper.IsCanConnect()))
                {
                    // Start Load Data
                    // Check if Admin or not
                    if (LocalUser.Role == "Admin")
                    {
                        // Get All Data
                        data = await Task.Run(() => dataHelper.GetDataByUser(LocalUser.UserId));
                    }
                    else
                    {
                        // Get Data By User
                        data = await Task.Run(() => dataHelper.GetDataByUser(LocalUser.UserId));
                    }
                    // No Of all items in db
                    labelNoOfItems.Text = data.Count.ToString();
                    // Get And set parameters
                    var idlist = data.Select(x => x.Id).ToArray();
                    int index = comboBoxNoOfPage.SelectedIndex;
                    int noOfItemIndex = index * Properties.Settings.Default.NoDataGridViewItems;

                    // Fill DataGridView
                    dataGridView1.DataSource = data.Where(x => x.Id <= idlist[noOfItemIndex])
                        .Take(Properties.Settings.Default.NoDataGridViewItems).ToList();

                    // Show Empty Data
                    ShowEmptyDataState();

                    // Clear Data
                    data.Clear();
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
            if (await Task.Run(() => dataHelper.IsCanConnect()))
            {
                // Start Load Data
                // Check if Admin or not
                if (LocalUser.Role == "Admin")
                {
                    // Get All Data
                    data = await Task.Run(() => dataHelper.GetDataByUser(LocalUser.UserId));
                }
                else
                {
                    // Get Data By User
                    data = await Task.Run(() => dataHelper.GetDataByUser(LocalUser.UserId));
                }

                // No Of all items in db
                labelNoOfItems.Text = data.Count.ToString();
                // Fill DataGridView
                dataGridView1.DataSource = data.Take(Properties.Settings.Default.NoDataGridViewItems).ToList();
                if (data.Count <= Properties.Settings.Default.NoDataGridViewItems)
                {
                    comboBoxNoOfPage.Items.Clear();
                    comboBoxNoOfPage.Items.Add(0);
                }
                else
                {
                    // Get And Add No Of Pages
                    double value = Convert.ToDouble(data.Count) / Convert.ToDouble(Properties.Settings.Default.NoDataGridViewItems);
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
                data.Clear();
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
            if (await Task.Run(() => dataHelper.IsCanConnect()))
            {
                // Start Load Data
                string searchItem = textBoxSearch.Text;
                // Check if Admin or not
                if (LocalUser.Role == "Admin")
                {
                    // Get All Data
                    data = await Task.Run(() => dataHelper.SearchByUser(LocalUser.UserId, searchItem));
                }
                else
                {
                    // Get Data By User
                    data = await Task.Run(() => dataHelper.SearchByUser(LocalUser.UserId, searchItem));
                }

                // Fill DataGridView
                dataGridView1.DataSource = data.ToList();

                // Set Columns Title
                // SetColumns();

                // Show Empty Data
                ShowEmptyDataState();

                // Clear Data
                data.Clear();
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
            dataGridView1.Columns[1].HeaderCell.Value = "Функциональная оценка";
            dataGridView1.Columns[2].HeaderCell.Value = "Зарплата";
            dataGridView1.Columns[3].HeaderCell.Value = "Ежегодное пособие";
            dataGridView1.Columns[4].HeaderCell.Value = "Годы продвижения по службе";

            // Visible Of Columns
            dataGridView1.Columns[5].Visible = false;
        }

        private void Edit()
        {
            // Check Data if not Empty
            if (!dgvHelper.IsEmpty(dataGridView1) && dataGridView1.CurrentRow.Selected == true)
            {
                // Get Id
                int Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                if (addSalaryRateForm == null || addSalaryRateForm.IsDisposed)
                {
                    addSalaryRateForm = new AddSalaryRateForm(mainForm, Id, this);
                    addSalaryRateForm.Show();
                }
                else
                {
                    addSalaryRateForm.Focus();
                }
            }
            else
            {
                MsgHelper.ShowEmptyDataGridView();
            }
        }

        private void SetIdDeleteList()
        {
            IdDeleteList.Clear();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Selected)
                {
                    IdDeleteList.Add(Convert.ToInt32(row.Cells[0].Value));
                }
            }
        }

        private DataTable arrangedDataTable(DataTable dataTable)
        {
            dataTable.Columns["Id"].SetOrdinal(0);
            dataTable.Columns["Id"].ColumnName = "Id";

            dataTable.Columns["Degree"].SetOrdinal(1);
            dataTable.Columns["Degree"].ColumnName = "Функциональная оценка";

            dataTable.Columns["Salary"].SetOrdinal(2);
            dataTable.Columns["Salary"].ColumnName = $"Зарплата {Properties.Settings.Default.Currency}";

            dataTable.Columns["BonusYearRate"].SetOrdinal(3);
            dataTable.Columns["BonusYearRate"].ColumnName = $"Ежегодное пособие {Properties.Settings.Default.Currency}";

            dataTable.Columns["PromotionYear"].SetOrdinal(4);
            dataTable.Columns["PromotionYear"].ColumnName = "Годы продвижения по службе";

            // Removed columns
            dataTable.Columns.Remove("UsersId");

            return dataTable;
        }
        #endregion
    }
}
