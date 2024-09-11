using HyperEmpoloyees.Code.Helpers;
using HyperEmpoloyees.Code.Models;
using HyperEmpoloyees.Core;
using HyperEmpoloyees.Data.EF;
using HyperEmpoloyees.Gui.LoadingGui;
using System.Data;

namespace HyperEmpoloyees.Gui.BookThanksGui
{
    public partial class AddBookThanksForm : Form
    {
        private readonly IDataHelper<BookThanks> dataHelperForBookThanks;
        private readonly IDataHelper<Employees> dataHelperForEmployees;
        private readonly IDataHelper<SystemRecords> dataHelperForSystemRecords;
        private readonly Main main;
        private int Id;
        private DateTime userCreatedDate;
        private readonly BookThanksUserControl page;
        private Employees employees;

        public AddBookThanksForm(Main main, int id, BookThanksUserControl page, Employees employees)
        {
            InitializeComponent();

            dataHelperForBookThanks = new BookThanksEF();
            dataHelperForSystemRecords = new SystemRecordsEF();
            dataHelperForEmployees = new EmployeesEF();

            this.Owner = main;
            this.main = main;
            this.Id = id;
            this.page = page;
            this.employees = employees;
            if (Id > 0)
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
                LoadingForm.Instance(main).Show();
                // Check Connection
                if (await Task.Run(() => dataHelperForBookThanks.IsCanConnect()))
                {
                    // Check Duplicated Item

                    string refBook = textBoxRef.Text;
                    var dateBook = dateTimePickerBookThaDate.Value.Date;

                    var result = await Task.Run(() => dataHelperForBookThanks
                    .GetDataByUser(LocalUser.UserId)
                    .Where(x => x.Id != Id)
                    .Where(x => x.Ref == refBook && x.BookThankDate==dateBook)
                    .FirstOrDefault() ?? new BookThanks());

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

        private void textBoxBookThanks_MouseLeave(object sender, EventArgs e)
        {
            if (!float.TryParse(textBoxRef.Text, out float bookThanks) || bookThanks < 0)
            {
                textBoxRef.Text = "0";
                MsgHelper.ShowNumberVaild();
            }
        }

        #endregion
        #region Methods
        private bool IsValid()
        {
            if (
                textBoxRef.Text != string.Empty
                )
            {
                return true;
            }
            else
            {
                return true;
            }
        }

        private async void Add()
        {
            // Set BookThanks
            BookThanks bookThanks = new BookThanks
            {
                UserId = LocalUser.UserId,
                EffectValue = (int)numericUpDownEffect.Value,
                AddedDate = DateTime.Now.Date,
                BookThankDate = dateTimePickerBookThaDate.Value.Date,
                EmployeesId = employees.Id,
                Note = richTextBoxNote.Text,
                Ref = textBoxRef.Text,
            };

            // Send Data to data base
            var result = await Task.Run(() => dataHelperForBookThanks.Add(bookThanks));
            if (result == "1")
            {

                // Success
                SystemRecordHelper.Add("Добавить книга благодарностей",
                    $"Была добавлена Книга благодарностей, которая содержит идентификационный номер {bookThanks.Id}");

                // Add Data To Employees
                employees.Note = employees.Note + " | " + $"Благодарим за {bookThanks.EffectValue}дневное действие числа {bookThanks.Ref} от {bookThanks.BookThankDate}";
                employees.NextDate = employees.NextDate.AddDays(bookThanks.EffectValue - 1);

                await Task.Run(() => dataHelperForEmployees.Edit(employees));

                page.LoadData();
                ToastHelper.ShowAddToast();
            }
            else
            {
                // Msg Box with result
                MessageBox.Show(result);
            }
        }

        private async void Edit()
        {
            // Set BookThanks
            BookThanks bookThanks = new BookThanks
            {
                UserId = LocalUser.UserId,
                EffectValue = (int)numericUpDownEffect.Value,
                AddedDate = DateTime.Now.Date,
                BookThankDate = dateTimePickerBookThaDate.Value.Date,
                EmployeesId = employees.Id,
                Note = richTextBoxNote.Text,
                Ref = textBoxRef.Text,
                Id = Id
            };

            // Send Data to data base
            var result = await Task.Run(() => dataHelperForBookThanks.Edit(bookThanks));
            if (result == "1")
            {
                // Success
                SystemRecordHelper.Add("Измененная книга благодарностей",
                    $"измененная книга благодарностей с идентификационным номером {bookThanks.Id}");
                page.LoadData();
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
            // Get Edit BookThanks Data
            var _bookThanks = await Task.Run(() => dataHelperForBookThanks.Find(Id));
            if (_bookThanks != null)
            {
                textBoxRef.Text = _bookThanks.Ref;
                numericUpDownEffect.Value = _bookThanks.EffectValue;
                richTextBoxNote.Text = _bookThanks.Note;
                dateTimePickerBookThaDate.Value = _bookThanks.BookThankDate;
            }
        }
        #endregion

        
    }
}
