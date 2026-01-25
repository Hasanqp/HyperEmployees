using HyperEmpoloyees.Code.Helpers;
using HyperEmpoloyees.Code.Models;
using HyperEmpoloyees.Core;
using HyperEmpoloyees.Data.EF;
using HyperEmpoloyees.Gui.EmployeeRewardsGui;
using HyperEmpoloyees.Gui.EmployeesRecordsGui;
using HyperEmpoloyees.Gui.HomeGui;
using HyperEmpoloyees.Gui.LoadingGui;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HyperEmpoloyees.Gui.EmpoloyeesGui
{
    public partial class AddEmployeesForm : Form
    {
        private readonly IDataHelper<Employee> employeesDataHelper;
        private readonly IDataHelper<EmployeesRecord> employeeRecordsDataHelper;
        private readonly IDataHelper<SalaryRate> salaryRateDataHelper;
        private readonly IDataHelper<SystemRecord> systemRecordDataHelper;
        private readonly Main mainForm;
        private int employeeId;
        private DateTime userCreatedDate;
        private Employee employee;
        private List<SalaryRate> salarys;
        private readonly EmployeesUserControl parentPage;

        public AddEmployeesForm(Main mainForm, int employeeId, EmployeesUserControl parentPage)
        {
            InitializeComponent();

            employeesDataHelper = new EmployeeRepository();
            employeeRecordsDataHelper = new EmployeeRecordsRepository();
            systemRecordDataHelper = new SystemRecordRepository();
            salaryRateDataHelper = new SalaryRateRepository();
            this.Owner = mainForm;
            salarys = new List<SalaryRate>();

            this.mainForm = mainForm;
            this.employeeId = employeeId;
            this.parentPage = parentPage;
            employee = new Employee();

            if (this.employeeId > 0)
            {
                SetDataForEdit();
            }

            // Set Gui
            labelSBouncCurrency.Text = Properties.Settings.Default.Currency;
            labelSalaryCurrency.Text = Properties.Settings.Default.Currency;
            SetRolesOfTabs();
            AutoFillData();
            GetSalaryRates();
        }

        #region Evints
        private async void buttonSave_Click(object sender, EventArgs e)
        {
            LoadEmployeeFromForm();

            // Check the fileds
            if (!IsValid(employee))
            {
                MsgHelper.ShowRequiredFields();
                return;
            }

            // Show Loading
            LoadingForm.Instance(mainForm).Show();

            // Check Connection
            if (!await Task.Run(() => employeesDataHelper.IsCanConnect()))
            {
                LoadingForm.Instance(mainForm).Hide();
                MsgHelper.ShowServerError();
                return;
            }

            var result = await Task.Run(() =>
                employeesDataHelper
                    .GetDataByUser(LocalUser.UserId)
                    .FirstOrDefault(x => x.Id != employeeId && x.Name == employee.Name)
            );

            if (result != null && result.Id > 0)
            {
                LoadingForm.Instance(mainForm).Hide();
                MsgHelper.ShowDuplicatedItems();
                return;
            }

            // Add / Edit
            if (employeeId == 0)
                await Task.Run(() => employeesDataHelper.Add(employee));
            else
                await Task.Run(() => employeesDataHelper.Edit(employee));

            HomeUserControl.Instance().RefreshCharts();

            parentPage.LoadData();
            LoadingForm.Instance(mainForm).Hide();

        }

        private void textBoxEmployees_MouseLeave(object sender, EventArgs e)
        {
            /*if (!float.TryParse(textBoxFullName.Text, out float value) || value < 0)
            {
                textBoxFullName.Text = "0";
                MsgHelper.ShowNumberVaild();
            }*/
        }

        private void textBoxCurrentSalary_MouseLeave(object sender, EventArgs e)
        {
            if (!float.TryParse(textBoxCurrentSalary.Text, out float value) || value < 0)
            {
                textBoxCurrentSalary.Text = "0";
                MsgHelper.ShowNumberVaild();
            }
        }

        private void textBoxNextSalary_MouseLeave(object sender, EventArgs e)
        {
            if (!float.TryParse(textBoxNextSalary.Text, out float value) || value < 0)
            {
                textBoxNextSalary.Text = "0";
                MsgHelper.ShowNumberVaild();
            }
        }

        private void numericUpDownCurrentStage_ValueChanged(object sender, EventArgs e)
        {
            AutoComplete(salarys);
        }

        private void numericUpDownCurrentDegree_ValueChanged_1(object sender, EventArgs e)
        {
            AutoComplete(salarys);
        }

        private void numericUpDownNextDegree_ValueChanged(object sender, EventArgs e)
        {
            AutoComplete(salarys);
        }

        private void numericUpDownNextStage_ValueChanged(object sender, EventArgs e)
        {
            AutoComplete(salarys);
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            this.Close();
            parentPage.buttonAdd_Click(sender, e);
        }

        private void buttonAutoCol_Click(object sender, EventArgs e)
        {
            SetDataForEdit();
            AutoComplete(salarys);
        }

        private void buttonUpgrade_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Вы уверены в правильности этой процедуры",
                "Сделайте обновление",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Save Record
                AddRecords();

                // Upgrade Data
                UpdateBeforeSaveRecord();

                // Save Data
                EditEmployee();

            }
        }

        private void UpdateBeforeSaveRecord()
        {
            numericUpDownCurrentDegree.Value = numericUpDownNextDegree.Value;
            numericUpDownCurrentStage.Value = numericUpDownNextStage.Value;
            textBoxCurrentSalary.Text = textBoxNextSalary.Text;
            dateTimePickerCurrentDate.Value = dateTimePickerNextDate.Value;
            richTextBoxNote.Text = string.Empty;
            AutoComplete(salarys);
        }
        #endregion
        #region Methods
        private bool IsValid(Employee employee)
        {
            if (employee == null)
                return false;

            if (string.IsNullOrWhiteSpace(employee.Name))
                return false;

            if (string.IsNullOrWhiteSpace(employee.JobTitle))
                return false;

            if (employee.CurrentSalary <= 0)
                return false;

            if (employee.CurrentDegree <= 0)
                return false;

            if (employee.CurrentStage <= 0)
                return false;

            if (string.IsNullOrWhiteSpace(employee.UsersId))
                return false;

            return true;
        }

        private async void AddRecords()
        {
            // Set Employees
            EmployeesRecord employeeRecord = new EmployeesRecord
            {
                Name = textBoxFullName.Text,
                JobTitle = comboBoxJopTitle.Text,
                EmploymentStatus = comboBoxEmpState.Text,
                LastPromotionDate = dateTimePickerLastPromotion.Value.Date,

                CurrentDegree = (int)numericUpDownCurrentDegree.Value,
                CurrentStage = (int)numericUpDownCurrentStage.Value,
                CurrentSalary = (float)Convert.ToDouble(textBoxCurrentSalary.Text),
                CurrentDate = dateTimePickerCurrentDate.Value.Date,

                NextDegree = (int)numericUpDownNextDegree.Value,
                NextStage = (int)numericUpDownNextStage.Value,
                NextSalary = (float)Convert.ToDouble(textBoxNextSalary.Text),
                NextDate = dateTimePickerNextDate.Value.Date,

                Note = richTextBoxNote.Text,

                AddedDate = DateTime.Now,
                UpdateDate = DateTime.Now,

                UsersId = LocalUser.UserId,
                EmployeesId = employeeId,
            };

            // Send Data to data base
            var result = await Task.Run(() => employeeRecordsDataHelper.Add(employeeRecord));
            if (result == "1")
            {

                // Success
                SystemRecordHelper.Add("Добавьте запись о сотруднике",
                    $"Добавлена запись о сотруднике с идентификационным номером {employeeRecord.Id}");
                parentPage.LoadData();

                HomeUserControl.Instance().RefreshCharts();

                ToastHelper.ShowAddToast();
                employeeId = employeeRecord.Id;
                SetRolesOfTabs();
            }
            else
            {
                // Msg Box with result
                MessageBox.Show(result);
            }
        }

        private async void EditEmployee()
        {
            // Set Employees
            Employee employee = new Employee
            {
                Name = textBoxFullName.Text,
                JobTitle = comboBoxJopTitle.Text,
                EmploymentState = comboBoxEmpState.Text,
                LastPromotionDate = dateTimePickerLastPromotion.Value.Date,

                CurrentDegree = (int)numericUpDownCurrentDegree.Value,
                CurrentStage = (int)numericUpDownCurrentStage.Value,
                CurrentSalary = (float)Convert.ToDouble(textBoxCurrentSalary.Text),
                CurrentDate = dateTimePickerCurrentDate.Value.Date,

                NextDegree = (int)numericUpDownNextDegree.Value,
                NextStage = (int)numericUpDownNextStage.Value,
                NextSalary = (float)Convert.ToDouble(textBoxNextSalary.Text),
                NextDate = dateTimePickerNextDate.Value.Date,

                Note = richTextBoxNote.Text,

                AddedDate = DateTime.Now,
                UpdateDate = DateTime.Now,

                UsersId = LocalUser.UserId,
                Id = employeeId
            };

            // Send Data to data base
            var result = await Task.Run(() => employeesDataHelper.Edit(employee));
            if (result == "1")
            {
                // Success
                SystemRecordHelper.Add("Изменить сотрудника",
                    $"Существующий сотрудник с идентификатором был изменен. {employee.Id}");
                parentPage.LoadData();

                HomeUserControl.Instance().RefreshCharts();

                ToastHelper.ShowEditToast();
            }
            else
            {
                // Msg Box with result
                MessageBox.Show(result);
            }
        }

        private async void SetDataForEdit()
        {
            // Get Edit Employees Data
            var _employees = await Task.Run(() => employeesDataHelper.Find(employeeId));
            if (_employees.Id > 0)
            {
                textBoxFullName.Text = _employees.Name;
                comboBoxJopTitle.Text = _employees.JobTitle;
                comboBoxEmpState.Text = _employees.EmploymentState;
                dateTimePickerLastPromotion.Value = _employees.LastPromotionDate;

                numericUpDownCurrentDegree.Value = _employees.CurrentDegree;
                numericUpDownCurrentStage.Value = _employees.CurrentStage;
                textBoxCurrentSalary.Text = _employees.CurrentSalary.ToString();
                dateTimePickerCurrentDate.Value = _employees.CurrentDate;

                numericUpDownNextDegree.Value = _employees.NextDegree;
                numericUpDownNextStage.Value = _employees.NextStage;
                textBoxNextSalary.Text = _employees.NextSalary.ToString();
                dateTimePickerNextDate.Value = _employees.NextDate;

                richTextBoxNote.Text = _employees.Note;
                
            }
        }

        private async void SetRolesOfTabs()
        {
            if (employeeId == 0)
            {
                buttonAutoCol.Enabled = false;
                buttonNew.Enabled = false;
                buttonUpgrade.Enabled = false;

                foreach (TabPage tab in tabControl1.TabPages)
                {
                    if (tab.Name != "tabPage1")
                    {
                        tab.Enabled = false;
                    }
                }
            }
            else
            {
                buttonAutoCol.Enabled = true;
                buttonNew.Enabled = true;
                buttonUpgrade.Enabled = true;

                foreach (TabPage tab in tabControl1.TabPages)
                {
                    if (tab.Name != "tabPage1")
                    {
                        tab.Enabled = true;
                    }
                }
                AddUserControlEffecteedValueGui();
            }
        }

        private async void AddUserControlEffecteedValueGui()
        {
            // Book Thanks
            tabControl1.TabPages[1].Controls.Clear();
            Employee employees = await Task.Run(() => employeesDataHelper.Find(employeeId));
            EmployeeRewardsUserControl employeeRewardsUserControl = new EmployeeRewardsUserControl(employees);
            employeeRewardsUserControl.Dock = DockStyle.Fill;
            tabControl1.TabPages[1].Controls.Add(employeeRewardsUserControl);

            // Bouns Records
            tabControl1.TabPages[4].Controls.Clear();
            EmployeesRecordsUserControl empoloyeesRecordsUserControl  = new EmployeesRecordsUserControl(employees);
            empoloyeesRecordsUserControl.Dock = DockStyle.Fill;
            tabControl1.TabPages[4].Controls.Add(empoloyeesRecordsUserControl);
        }

        private async void AutoFillData()
        {
            List<string?> dataList = new List<string?>();

            LoadingForm.Instance(mainForm).Show();
            if (await Task.Run(() => employeesDataHelper.IsCanConnect()))
            {
                // AutoFill Job Title
                // Get Data
                dataList = await Task.Run(() => employeesDataHelper
                .GetDataByUser(LocalUser.UserId)
                .Select(x => x.JobTitle).Distinct().ToList());
                // Fill ComboBox
                comboBoxJopTitle.DataSource = dataList;
                comboBoxJopTitle.AutoCompleteCustomSource = ConvertToAutoCompleteStringCollection(dataList);


                // AutoFill Job Title
                // Get Data
                dataList = await Task.Run(() => employeesDataHelper
                .GetDataByUser(LocalUser.UserId)
                .Select(x => x.EmploymentState).Distinct().ToList());
                // Fill ComboBox
                dataList.Add("Бонусов");
                dataList.Add("Продвижение");
                dataList.Add("Участие в розыгрыше бонуса");
                dataList.Add("Остановился");
                comboBoxEmpState.DataSource = dataList.Distinct().ToList();
                comboBoxEmpState.AutoCompleteCustomSource = ConvertToAutoCompleteStringCollection(dataList);

            }
            LoadingForm.Instance(mainForm).Hide();
        }

        private AutoCompleteStringCollection ConvertToAutoCompleteStringCollection(List<string?> dataList)
        {
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            foreach (var item in dataList)
            {
                collection.Add(item);
            }
            return collection;
        }

        private async void GetSalaryRates()
        {
            LoadingForm.Instance(mainForm).Show();
            if (await Task.Run(() => employeesDataHelper.IsCanConnect()))
            {
                salarys = await Task.Run(() => salaryRateDataHelper.GetDataByUser(LocalUser.UserId));
            }
            LoadingForm.Instance(mainForm).Hide();
        }

        private void AutoComplete(List<SalaryRate> salaryRateslist)
        {
            // Get Current Data
            int currentDegree = (int)numericUpDownCurrentDegree.Value;
            int currentStage = (int)numericUpDownCurrentStage.Value;

            var currentRate = salaryRateslist.Where(x => x.Degree == currentDegree)
                .FirstOrDefault() ?? new SalaryRate();
            if (currentRate != null)
            {
                if (currentRate.PromotionYear == currentStage)
                {
                    // Повышения
                    numericUpDownNextDegree.Value = currentDegree > 1 ? currentDegree - 1 : currentDegree;
                    numericUpDownNextStage.Value = 1;
                    comboBoxEmpState.SelectedItem = "Продвижение";
                }
                else
                {
                    // бонусов wedit
                    numericUpDownNextDegree.Value = currentDegree;
                    numericUpDownNextStage.Value = currentStage + 1;
                    comboBoxEmpState.SelectedItem = "бонусов";
                }

                // Set Date
                dateTimePickerNextDate.Value = dateTimePickerCurrentDate.Value.AddYears(1);

                //// Set Saalry
                //textBoxCurrentSalary.Text = GetSalary(currentStage, currentRate).ToString();
                //textBoxNextSalary.Text = GetSalary((int)numericUpDownNextStage.Value, currentRate).ToString();

                // Set Saalry
                double currentSalary = GetSalary(currentStage, currentRate);
                double nextSalary = GetSalary((int)numericUpDownNextStage.Value, currentRate);

                // promotion must NOT reduce salary
                if (nextSalary < currentSalary)
                {
                    nextSalary = currentSalary;
                }

                textBoxCurrentSalary.Text = currentSalary.ToString("F0");
                textBoxNextSalary.Text = nextSalary.ToString("F0");
            }
        }

        private double GetSalary(int stage, SalaryRate salaryRate)
        {
            double baseSalary = salaryRate.Salary;
            double bonusPercent = salaryRate.BonusYearRate / 100.0;

            if (stage <= 1)
                return baseSalary;

            int bonusYears = stage - 1;
            double bonusAmount = baseSalary * bonusPercent * bonusYears;

            return baseSalary + bonusAmount;
        }

        private void LoadEmployeeFromForm()
        {
            employee.Name = textBoxFullName.Text.Trim();
            employee.JobTitle = comboBoxJopTitle.Text.Trim();
            employee.EmploymentState = comboBoxEmpState.Text;
            employee.LastPromotionDate = dateTimePickerLastPromotion.Value.Date;

            employee.CurrentDegree = (int)numericUpDownCurrentDegree.Value;
            employee.CurrentStage = (int)numericUpDownCurrentStage.Value;
            float.TryParse(textBoxCurrentSalary.Text, out float currentSalary);
            employee.CurrentSalary = currentSalary;
            employee.CurrentDate = dateTimePickerCurrentDate.Value.Date;

            employee.NextDegree = (int)numericUpDownNextDegree.Value;
            employee.NextStage = (int)numericUpDownNextStage.Value;
            float.TryParse(textBoxNextSalary.Text, out float nextSalary);
            employee.NextSalary = nextSalary;
            employee.NextDate = dateTimePickerNextDate.Value.Date;

            employee.Note = richTextBoxNote.Text;
            employee.UsersId = LocalUser.UserId;
            employee.UpdateDate = DateTime.Now;

            if (employeeId == 0)
                employee.AddedDate = DateTime.Now;

            employee.Id = employeeId;
        }
        #endregion
    }
}
