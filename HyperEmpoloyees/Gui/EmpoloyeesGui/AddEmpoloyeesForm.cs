using DocumentFormat.OpenXml.Drawing;
using HyperEmpoloyees.Code.Helpers;
using HyperEmpoloyees.Code.Models;
using HyperEmpoloyees.Core;
using HyperEmpoloyees.Data.EF;
using HyperEmpoloyees.Gui.BookThanksGui;
using HyperEmpoloyees.Gui.EmployeesRecordsGui;
using HyperEmpoloyees.Gui.LoadingGui;
using System.Data;

namespace HyperEmpoloyees.Gui.EmpoloyeesGui
{
    public partial class AddEmpoloyeesForm : Form
    {
        private readonly IDataHelper<Employees> dataHelperForEmployees;
        private readonly IDataHelper<EmployeesRecords> dataHelperForEmployeesRecords;
        private readonly IDataHelper<SalaryRate> dataHelperForSalaryRate;
        private readonly IDataHelper<SystemRecords> dataHelperForSystemRecords;
        private readonly Main main;
        private int Id;
        private DateTime userCreatedDate;
        private List<SalaryRate> salaryList;
        private readonly EmpoloyeesUserControl page;

        public AddEmpoloyeesForm(Main main, int id, EmpoloyeesUserControl page)
        {
            InitializeComponent();

            dataHelperForEmployees = new EmployeesEF();
            dataHelperForEmployeesRecords = new EmployeesRecordsEF();
            dataHelperForSystemRecords = new SystemRecordsEF();
            dataHelperForSalaryRate = new SalaryRateEF();
            this.Owner = main;
            salaryList = new List<SalaryRate>();

            this.main = main;
            this.Id = id;
            this.page = page;

            if (Id > 0)
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
                if (await Task.Run(() => dataHelperForEmployees.IsCanConnect()))
                {
                    // Check Duplicated Item

                    string FullName = textBoxFullName.Text;

                    var result = await Task.Run(() => dataHelperForEmployees
                    .GetDataByUser(LocalUser.UserId)
                    .Where(x => x.Id != Id)
                    .Where(x => x.Name == FullName)
                    .FirstOrDefault() ?? new Employees());

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

        private void textBoxEmployees_MouseLeave(object sender, EventArgs e)
        {
            if (!float.TryParse(textBoxFullName.Text, out float employees) || employees < 0)
            {
                textBoxFullName.Text = "0";
                MsgHelper.ShowNumberVaild();
            }
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
            AutoComplate(salaryList);
        }

        private void numericUpDownCurrentDegree_ValueChanged_1(object sender, EventArgs e)
        {
            AutoComplate(salaryList);
        }

        private void numericUpDownNextDegree_ValueChanged(object sender, EventArgs e)
        {
            AutoComplate(salaryList);
        }

        private void numericUpDownNextStage_ValueChanged(object sender, EventArgs e)
        {
            AutoComplate(salaryList);
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            this.Close();
            page.buttonAdd_Click(sender, e);
        }

        private void buttonAutoCol_Click(object sender, EventArgs e)
        {
            SetDataForEdit();
            AutoComplate(salaryList);
        }

        private void buttonUpgrade_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Вы уверены в правильности этой процедуры", "Сделайте обновление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            // Save Record
            AddRecords();
            // Upgrade Data
            UpdateBeforeSaveRecord();
            // Save Data
            Edit();
        }

        private void UpdateBeforeSaveRecord()
        {
            numericUpDownCurrentDegree.Value = numericUpDownNextDegree.Value;
            numericUpDownCurrentStage.Value = numericUpDownNextStage.Value;
            textBoxCurrentSalary.Text = textBoxNextSalary.Text;
            dateTimePickerCurrentDate.Value = dateTimePickerNextDate.Value;
            richTextBoxNote.Text = string.Empty;
            AutoComplate(salaryList);
        }
        #endregion
        #region Methods
        private bool IsValid()
        {
            if (textBoxFullName.Text.Length < 3 ||
                comboBoxJopTitle.Text.Length < 3 ||
                comboBoxEmpState.Text.Length < 3
                )
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private async void Add()
        {
            // Set Employees
            Employees employees = new Employees
            {
                Name = textBoxFullName.Text,
                JopTitle = comboBoxJopTitle.Text,
                EmpState = comboBoxEmpState.Text,
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
            };

            // Send Data to data base
            var result = await Task.Run(() => dataHelperForEmployees.Add(employees));
            if (result == "1")
            {

                // Success
                SystemRecordHelper.Add("Добавить сотрудника",
                    $"Добавлен новый сотрудник с идентификационным номером {employees.Id}");
                page.LoadData();
                ToastHelper.ShowAddToast();
                Id = employees.Id;
                SetRolesOfTabs();
            }
            else
            {
                // Msg Box with result
                MessageBox.Show(result);
            }
        }

        private async void AddRecords()
        {
            // Set Employees
            EmployeesRecords employees = new EmployeesRecords
            {
                Name = textBoxFullName.Text,
                JopTitle = comboBoxJopTitle.Text,
                EmpState = comboBoxEmpState.Text,
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
                EmployeesId = Id,
            };

            // Send Data to data base
            var result = await Task.Run(() => dataHelperForEmployeesRecords.Add(employees));
            if (result == "1")
            {

                // Success
                SystemRecordHelper.Add("Добавьте запись о сотруднике",
                    $"Добавлена запись о сотруднике с идентификационным номером {employees.Id}");
                page.LoadData();
                ToastHelper.ShowAddToast();
                Id = employees.Id;
                SetRolesOfTabs();
            }
            else
            {
                // Msg Box with result
                MessageBox.Show(result);
            }
        }

        private async void Edit()
        {
            // Set Employees
            Employees employees = new Employees
            {
                Name = textBoxFullName.Text,
                JopTitle = comboBoxJopTitle.Text,
                EmpState = comboBoxEmpState.Text,
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
                Id = Id
            };

            // Send Data to data base
            var result = await Task.Run(() => dataHelperForEmployees.Edit(employees));
            if (result == "1")
            {
                // Success
                SystemRecordHelper.Add("Изменить сотрудника",
                    $"Существующий сотрудник с идентификатором был изменен. {employees.Id}");
                page.LoadData();
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
            var _employees = await Task.Run(() => dataHelperForEmployees.Find(Id));
            if (_employees.Id > 0)
            {
                textBoxFullName.Text = _employees.Name;
                comboBoxJopTitle.Text = _employees.JopTitle;
                comboBoxEmpState.Text = _employees.EmpState;
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
            if (Id == 0)
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
            Employees employees = await Task.Run(() => dataHelperForEmployees.Find(Id));
            BookThanksUserControl bookThanksUserControl = new BookThanksUserControl(employees);
            bookThanksUserControl.Dock = DockStyle.Fill;
            tabControl1.TabPages[1].Controls.Add(bookThanksUserControl);

            // Bouns Records
            tabControl1.TabPages[4].Controls.Clear();
            EmpoloyeesRecordsUserControl empoloyeesRecordsUserControl  = new EmpoloyeesRecordsUserControl(employees);
            empoloyeesRecordsUserControl.Dock = DockStyle.Fill;
            tabControl1.TabPages[4].Controls.Add(empoloyeesRecordsUserControl);
        }

        private async void AutoFillData()
        {
            List<string?> dataList = new List<string?>();

            LoadingForm.Instance(main).Show();
            if (await Task.Run(() => dataHelperForEmployees.IsCanConnect()))
            {
                // AutoFill Job Title
                // Get Data
                dataList = await Task.Run(() => dataHelperForEmployees
                .GetDataByUser(LocalUser.UserId)
                .Select(x => x.JopTitle).Distinct().ToList());
                // Fill ComboBox
                comboBoxJopTitle.DataSource = dataList;
                comboBoxJopTitle.AutoCompleteCustomSource = ConvertToAutoCompleteStringCollection(dataList);


                // AutoFill Job Title
                // Get Data
                dataList = await Task.Run(() => dataHelperForEmployees
                .GetDataByUser(LocalUser.UserId)
                .Select(x => x.EmpState).Distinct().ToList());
                // Fill ComboBox
                dataList.Add("Бонусов");
                dataList.Add("Продвижение");
                dataList.Add("Участие в розыгрыше бонуса");
                dataList.Add("Остановился");
                comboBoxEmpState.DataSource = dataList.Distinct().ToList();
                comboBoxEmpState.AutoCompleteCustomSource = ConvertToAutoCompleteStringCollection(dataList);

            }
            LoadingForm.Instance(main).Hide();
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
            LoadingForm.Instance(main).Show();
            if (await Task.Run(() => dataHelperForEmployees.IsCanConnect()))
            {
                salaryList = await Task.Run(() => dataHelperForSalaryRate.GetDataByUser(LocalUser.UserId));
            }
            LoadingForm.Instance(main).Hide();
        }

        private void AutoComplate(List<SalaryRate> salaryRateslist)
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

                // Set Saalry
                textBoxCurrentSalary.Text = GetSalary(currentStage, currentRate).ToString();
                textBoxNextSalary.Text = GetSalary((int)numericUpDownNextStage.Value, currentRate).ToString();
            }
        }

        private double GetSalary(int stage, SalaryRate salaryRate)
        {
            if (stage == 1)
            {
                return salaryRate.Salary;
            }
            else
            {
                return (--stage * salaryRate.BounsYearRate) + salaryRate.Salary;
            }
        }
        #endregion
    }
}
