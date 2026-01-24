using HyperEmpoloyees.Code.Helpers;
using HyperEmpoloyees.Code.Models;
using HyperEmpoloyees.Core;
using HyperEmpoloyees.Data.EF;
using HyperEmpoloyees.Gui.LoadingGui;
using System.Data;

namespace HyperEmpoloyees.Gui.SalaryRateGui
{
    public partial class AddSalaryRateForm : Form
    {
        private readonly IDataHelper<SalaryRate> salaryDataHelper;
        private readonly IDataHelper<SystemRecord> systemRecordDataHelper;
        private readonly Main mainForm;
        private int salaryId;
        private DateTime userCreatedDate;
        private readonly SalaryRateUserControl parentPage;

        public AddSalaryRateForm(Main mainForm, int salaryId, SalaryRateUserControl parentPage)
        {
            InitializeComponent();

            salaryDataHelper = new SalaryRateRepository();
            systemRecordDataHelper = new SystemRecordRepository();

            this.Owner = mainForm;
            this.mainForm = mainForm;
            this.salaryId = salaryId;
            this.parentPage = parentPage;

            if (this.salaryId > 0)
            {
                SetDataForEdit();
            }

            // Set Gui
            labelSBouncCurrency.Text = Properties.Settings.Default.Currency;
            labelSalaryCurrency.Text = Properties.Settings.Default.Currency;
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
                if (await Task.Run(() => salaryDataHelper.IsCanConnect()))
                {
                    // Check Duplicated Item

                    int degree = (int)numericUpDownDegree.Value;

                    var result = await Task.Run(() => salaryDataHelper
                    .GetDataByUser(LocalUser.UserId)
                    .Where(x => x.Id != salaryId)
                    .Where(x => x.Degree == degree)
                    .FirstOrDefault() ?? new SalaryRate());

                    if (result.Id > 0)
                    {
                        // Msg for Duplicatad data
                        LoadingForm.Instance(mainForm).Show();
                        MsgHelper.ShowDuplicatedItems();
                    }
                    else
                    {
                        // Add
                        if (salaryId == 0)
                        {
                            AddSalary();
                        }
                        else
                        {
                            // Edit
                            EditSalary();
                        }
                    }
                }
                else
                {
                    LoadingForm.Instance(mainForm).Show();
                    MsgHelper.ShowServerError();
                }

                LoadingForm.Instance(mainForm).Hide();
            }

        }

        private void textBoxSalary_MouseLeave(object sender, EventArgs e)
        {
            if (!float.TryParse(textBoxSalary.Text, out float salaryRate) || salaryRate < 0)
            {
                textBoxSalary.Text = "0";
                MsgHelper.ShowNumberVaild();
            }
        }

        private void textBoxBouncYear_MouseLeave(object sender, EventArgs e)
        {
            if (!float.TryParse(textBoxBouncYear.Text, out float salaryRate) || salaryRate < 0)
            {
                textBoxBouncYear.Text = "0";
                MsgHelper.ShowNumberVaild();
            }
        }
        #endregion
        #region Methods
        private bool IsValid()
        {
            return
                numericUpDownDegree.Value > 0 &&
                numericUpDownPromtion.Value >= 0 &&
                float.TryParse(textBoxSalary.Text, out var salary) && salary >= 0 &&
                float.TryParse(textBoxBouncYear.Text, out var bonus) && bonus >= 0;
        }

        private async void AddSalary()
        {
            // Set Salary
            SalaryRate salaryRate = new SalaryRate
            {
                Degree= (int)numericUpDownDegree.Value,
                PromotionYear= (int)numericUpDownPromtion.Value,
                Salary= (float)Convert.ToDecimal(textBoxSalary.Text),
                BonusYearRate= (float)Convert.ToDecimal(textBoxBouncYear.Text),
                UsersId = LocalUser.UserId,
            };

            // Send Data to data base
            var result = await Task.Run(() => salaryDataHelper.Add(salaryRate));
            if (result == "1")
            {

                // Success
                SystemRecordHelper.Add("Добавить Функциональная оценка",
                    $"Была добавлена функциональная оценка, которая содержит идентификационный номер {salaryRate.Id}");
                parentPage.LoadData();
                ToastHelper.ShowAddToast();
            }
            else
            {
                // Msg Box with result
                MessageBox.Show(result);
            }
        }

        private async void EditSalary()
        {
            // Set Salary
            SalaryRate salaryRate = new SalaryRate
            {
                Degree = (int)numericUpDownDegree.Value,
                PromotionYear = (int)numericUpDownPromtion.Value,
                Salary = (float)Convert.ToDecimal(textBoxSalary.Text),
                BonusYearRate = (float)Convert.ToDecimal(textBoxBouncYear.Text),
                UsersId = LocalUser.UserId,
                Id=salaryId
            };

            // Send Data to data base
            var result = await Task.Run(() => salaryDataHelper.Edit(salaryRate));
            if (result == "1")
            {
                // Success
                SystemRecordHelper.Add("Изменение функциональной оценки.",
                    $"Была изменена функциональная оценка, которая соответствует идентификационному номеру {salaryRate.Id}");
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
            // Get Edit Salary Data
            var _salary = await Task.Run(() => salaryDataHelper.Find(salaryId));
            if (_salary != null)
            {
                textBoxSalary.Text = _salary.Salary.ToString();
                textBoxBouncYear.Text = _salary.BonusYearRate.ToString();
                numericUpDownDegree.Value = _salary.Degree;
                numericUpDownPromtion.Value = _salary.PromotionYear;
            }
        }

        #endregion
    }
}
