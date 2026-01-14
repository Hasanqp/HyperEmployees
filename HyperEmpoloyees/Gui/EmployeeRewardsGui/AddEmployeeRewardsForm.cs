using HyperEmpoloyees.Code.Helpers;
using HyperEmpoloyees.Code.Models;
using HyperEmpoloyees.Core;
using HyperEmpoloyees.Data.EF;
using HyperEmpoloyees.Gui.LoadingGui;
using System.Data;

namespace HyperEmpoloyees.Gui.EmployeeRewardsGui
{
    public partial class AddEmployeeRewardsForm : Form
    {
        private readonly IDataHelper<EmployeeReward> employeeRewardDataHelper;
        private readonly IDataHelper<Employee> employeeDataHelper;
        private readonly IDataHelper<SystemRecord> systemRecordDataHelper;
        private readonly Main mainForm;
        private int emloyeeRewardId;
        private DateTime userCreatedDate;
        private readonly EmployeeRewardsUserControl parentPage;
        private Employee employee;

        public AddEmployeeRewardsForm(
            Main mainForm,
            int emloyeeRewardId, 
            EmployeeRewardsUserControl parentPage, 
            Employee employee)
        {
            InitializeComponent();

            employeeRewardDataHelper = new EmployeeRewardRepository();
            systemRecordDataHelper = new SystemRecordRepository();
            employeeDataHelper = new EmployeeRepository();

            this.Owner = mainForm;
            this.mainForm = mainForm;
            this.emloyeeRewardId = emloyeeRewardId;
            this.parentPage = parentPage;
            this.employee = employee;
            if (this.emloyeeRewardId > 0)
            {
                SetDataForEdit();
            }
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
                LoadingForm.Instance(mainForm).Show();
                // Check Connection
                if (await Task.Run(() => employeeRewardDataHelper.IsCanConnect()))
                {
                    // Check Duplicated Item

                    string refBook = textBoxRef.Text;
                    var dateBook = dateTimePickerBookThaDate.Value.Date;

                    var result = await Task.Run(() => employeeRewardDataHelper
                    .GetDataByUser(LocalUser.UserId)
                    .FirstOrDefault(x =>x.Id != emloyeeRewardId &&
                    x.Reference == refBook &&
                    x.BookThankDate == dateBook)
                    );

                    if (result != null)
                    {
                        // Msg for Duplicatad data
                        LoadingForm.Instance(mainForm).Hide();
                        MsgHelper.ShowDuplicatedItems();
                        return;
                    }
                    else
                    {
                        // Add
                        if (emloyeeRewardId == 0)
                        {
                            await AddEmployeeReward();
                        }
                        else
                        {
                            // Edit
                            await EditBookThank();
                        }
                    }
                }
                else
                {
                    LoadingForm.Instance(mainForm).Hide();
                    MsgHelper.ShowServerError();
                }

                LoadingForm.Instance(mainForm).Hide();
            }

        }

        private void textBoxBookThanks_MouseLeave(object sender, EventArgs e)
        {

        }

        #endregion
        #region Methods
        private bool IsValid()
        {
            return
            !string.IsNullOrWhiteSpace(textBoxRef.Text) && numericUpDownEffect.Value > 0;
        }

        private async Task AddEmployeeReward()
        {
            // Set BookThanks
            EmployeeReward bookThank = new EmployeeReward
            {
                UserId = LocalUser.UserId,
                EffectValue = (int)numericUpDownEffect.Value,
                AddedDate = DateTime.Now.Date,
                BookThankDate = dateTimePickerBookThaDate.Value.Date,
                EmployeesId = employee.Id,
                Note = richTextBoxNote.Text,
                Reference = textBoxRef.Text,
            };

            // Send Data to data base
            var result = await Task.Run(() => employeeRewardDataHelper.Add(bookThank));
            if (result == "1")
            {

                // Success
                SystemRecordHelper.Add("Добавить книга благодарностей",
                    $"Была добавлена Книга благодарностей, которая содержит идентификационный номер {bookThank.Id}");

                // Add Data To Employees
                employee.Note = employee.Note + " | " + $"Благодарим за {bookThank.EffectValue}дневное действие числа {bookThank.Reference} от {bookThank.BookThankDate}";
                employee.NextDate = employee.NextDate.AddDays(bookThank.EffectValue - 1);

                var empResult = await Task.Run(() => employeeDataHelper.Edit(employee));
                if (empResult != "1")
                {
                    MessageBox.Show(empResult);
                }

                parentPage.LoadData();
                ToastHelper.ShowAddToast();
            }
            else
            {
                // Msg Box with result
                MessageBox.Show(result);
            }
        }

        private async Task EditBookThank()
        {
            // Set BookThanks
            EmployeeReward bookThanks = new EmployeeReward
            {
                UserId = LocalUser.UserId,
                EffectValue = (int)numericUpDownEffect.Value,
                AddedDate = DateTime.Now.Date,
                BookThankDate = dateTimePickerBookThaDate.Value.Date,
                EmployeesId = employee.Id,
                Note = richTextBoxNote.Text,
                Reference = textBoxRef.Text,
                Id = emloyeeRewardId
            };

            // Send Data to data base
            var result = await Task.Run(() => employeeRewardDataHelper.Edit(bookThanks));
            if (result == "1")
            {
                // Success
                SystemRecordHelper.Add("Измененная книга благодарностей",
                    $"измененная книга благодарностей с идентификационным номером {bookThanks.Id}");
                parentPage.LoadData();
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
            // Get Edit Employee Rewards Data
            var bookThank = await Task.Run(() => employeeRewardDataHelper.Find(emloyeeRewardId));
            if (bookThank != null && bookThank.Id > 0)
            {
                textBoxRef.Text = bookThank.Reference;
                numericUpDownEffect.Value = bookThank.EffectValue;
                richTextBoxNote.Text = bookThank.Note;
                dateTimePickerBookThaDate.Value = bookThank.BookThankDate;
            }
        }
        #endregion

        
    }
}
