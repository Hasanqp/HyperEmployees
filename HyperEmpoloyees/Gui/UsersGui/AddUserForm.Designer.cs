namespace HyperEmpoloyees.Gui.UsersGui
{
    partial class AddUserForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            comboBoxRole = new ComboBox();
            textBoxPassword = new TextBox();
            label6 = new Label();
            textBoxUserName = new TextBox();
            label7 = new Label();
            label4 = new Label();
            label5 = new Label();
            textBoxFullName = new TextBox();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            checkBoxSecondaryUser = new CheckBox();
            groupBox2 = new GroupBox();
            comboBoxUserId = new ComboBox();
            buttonSave = new Button();
            textBoxAddress = new TextBox();
            textBoxEmail = new TextBox();
            textBoxPhone = new TextBox();
            label11 = new Label();
            label13 = new Label();
            label14 = new Label();
            groupBox3 = new GroupBox();
            flowLayoutPanelRoles = new FlowLayoutPanel();
            checkBoxAdd = new CheckBox();
            checkBoxDelete = new CheckBox();
            checkBoxEdit = new CheckBox();
            checkBoxExport = new CheckBox();
            checkBoxPrint = new CheckBox();
            checkBoxSearch = new CheckBox();
            checkBoxHomeSearch = new CheckBox();
            checkBoxHome = new CheckBox();
            checkBoxSalaryIndex = new CheckBox();
            checkBoxEmpolyees = new CheckBox();
            checkBoxUsers = new CheckBox();
            checkBoxReports = new CheckBox();
            checkBoxSettings = new CheckBox();
            checkBoxAbout = new CheckBox();
            checkBoxHelp = new CheckBox();
            checkBoxRetirment = new CheckBox();
            checkBoxSystemRecords = new CheckBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            flowLayoutPanelRoles.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(comboBoxRole);
            groupBox1.Controls.Add(textBoxPassword);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(textBoxUserName);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(textBoxFullName);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.ForeColor = Color.FromArgb(0, 0, 192);
            groupBox1.Location = new Point(8, 8);
            groupBox1.Margin = new Padding(2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(2);
            groupBox1.Size = new Size(272, 356);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Информация о знаке";
            // 
            // comboBoxRole
            // 
            comboBoxRole.FormattingEnabled = true;
            comboBoxRole.Location = new Point(6, 256);
            comboBoxRole.Name = "comboBoxRole";
            comboBoxRole.Size = new Size(227, 28);
            comboBoxRole.TabIndex = 3;
            comboBoxRole.SelectedIndexChanged += comboBoxRole_SelectedIndexChanged;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(6, 197);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(227, 27);
            textBoxPassword.TabIndex = 2;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = Color.Red;
            label6.Location = new Point(72, 175);
            label6.Name = "label6";
            label6.Size = new Size(16, 20);
            label6.TabIndex = 0;
            label6.Text = "*";
            // 
            // textBoxUserName
            // 
            textBoxUserName.Location = new Point(6, 135);
            textBoxUserName.Name = "textBoxUserName";
            textBoxUserName.Size = new Size(227, 27);
            textBoxUserName.TabIndex = 1;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ForeColor = Color.Black;
            label7.Location = new Point(7, 234);
            label7.Name = "label7";
            label7.Size = new Size(195, 20);
            label7.TabIndex = 0;
            label7.Text = "Общая действительность :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.Red;
            label4.Location = new Point(150, 113);
            label4.Name = "label4";
            label4.Size = new Size(16, 20);
            label4.TabIndex = 0;
            label4.Text = "*";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.Black;
            label5.Location = new Point(7, 176);
            label5.Name = "label5";
            label5.Size = new Size(70, 20);
            label5.TabIndex = 0;
            label5.Text = "Пароль :";
            // 
            // textBoxFullName
            // 
            textBoxFullName.Location = new Point(6, 72);
            textBoxFullName.Name = "textBoxFullName";
            textBoxFullName.Size = new Size(227, 27);
            textBoxFullName.TabIndex = 0;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            label8.ForeColor = Color.LightGray;
            label8.Location = new Point(155, 56);
            label8.Name = "label8";
            label8.Size = new Size(112, 13);
            label8.TabIndex = 0;
            label8.Text = "на 3 буквы меньше!";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            label9.ForeColor = Color.LightGray;
            label9.Location = new Point(163, 118);
            label9.Name = "label9";
            label9.Size = new Size(112, 13);
            label9.TabIndex = 0;
            label9.Text = "на 3 буквы меньше!";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            label10.ForeColor = Color.LightGray;
            label10.Location = new Point(155, 180);
            label10.Name = "label10";
            label10.Size = new Size(112, 13);
            label10.TabIndex = 0;
            label10.Text = "на 3 буквы меньше!";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.Black;
            label3.Location = new Point(7, 114);
            label3.Name = "label3";
            label3.Size = new Size(148, 20);
            label3.TabIndex = 0;
            label3.Text = "Имя пользователя :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.Red;
            label2.Location = new Point(105, 51);
            label2.Name = "label2";
            label2.Size = new Size(16, 20);
            label2.TabIndex = 0;
            label2.Text = "*";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.Black;
            label1.Location = new Point(7, 51);
            label1.Name = "label1";
            label1.Size = new Size(103, 20);
            label1.TabIndex = 0;
            label1.Text = "Полное имя :";
            // 
            // checkBoxSecondaryUser
            // 
            checkBoxSecondaryUser.AutoSize = true;
            checkBoxSecondaryUser.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            checkBoxSecondaryUser.ForeColor = Color.Black;
            checkBoxSecondaryUser.Location = new Point(5, 49);
            checkBoxSecondaryUser.Name = "checkBoxSecondaryUser";
            checkBoxSecondaryUser.Size = new Size(233, 19);
            checkBoxSecondaryUser.TabIndex = 4;
            checkBoxSecondaryUser.Text = "Является вторичным пользователем";
            checkBoxSecondaryUser.UseVisualStyleBackColor = true;
            checkBoxSecondaryUser.CheckedChanged += checkBoxSecondaryUser_CheckedChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(comboBoxUserId);
            groupBox2.Controls.Add(checkBoxSecondaryUser);
            groupBox2.Controls.Add(buttonSave);
            groupBox2.Controls.Add(textBoxAddress);
            groupBox2.Controls.Add(textBoxEmail);
            groupBox2.Controls.Add(textBoxPhone);
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(label13);
            groupBox2.Controls.Add(label14);
            groupBox2.ForeColor = Color.FromArgb(0, 0, 192);
            groupBox2.Location = new Point(280, 8);
            groupBox2.Margin = new Padding(2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(2);
            groupBox2.Size = new Size(268, 356);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "Дополнительная информация";
            // 
            // comboBoxUserId
            // 
            comboBoxUserId.FormattingEnabled = true;
            comboBoxUserId.Location = new Point(6, 72);
            comboBoxUserId.Name = "comboBoxUserId";
            comboBoxUserId.Size = new Size(227, 28);
            comboBoxUserId.TabIndex = 5;
            // 
            // buttonSave
            // 
            buttonSave.BackColor = Color.White;
            buttonSave.Image = Properties.Resources.icons8_save_32px;
            buttonSave.ImageAlign = ContentAlignment.MiddleLeft;
            buttonSave.Location = new Point(7, 300);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(227, 41);
            buttonSave.TabIndex = 9;
            buttonSave.Text = "   Сохранять";
            buttonSave.UseVisualStyleBackColor = false;
            buttonSave.Click += buttonSave_Click;
            // 
            // textBoxAddress
            // 
            textBoxAddress.Location = new Point(5, 257);
            textBoxAddress.Name = "textBoxAddress";
            textBoxAddress.Size = new Size(227, 27);
            textBoxAddress.TabIndex = 8;
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(6, 199);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(227, 27);
            textBoxEmail.TabIndex = 7;
            // 
            // textBoxPhone
            // 
            textBoxPhone.Location = new Point(6, 137);
            textBoxPhone.Name = "textBoxPhone";
            textBoxPhone.Size = new Size(227, 27);
            textBoxPhone.TabIndex = 6;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.ForeColor = Color.Black;
            label11.Location = new Point(7, 234);
            label11.Name = "label11";
            label11.Size = new Size(64, 20);
            label11.TabIndex = 0;
            label11.Text = "Жилье :";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.ForeColor = Color.Black;
            label13.Location = new Point(7, 176);
            label13.Name = "label13";
            label13.Size = new Size(153, 20);
            label13.TabIndex = 0;
            label13.Text = "Электронная почта :";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.ForeColor = Color.Black;
            label14.Location = new Point(7, 114);
            label14.Name = "label14";
            label14.Size = new Size(136, 20);
            label14.TabIndex = 0;
            label14.Text = "Номер телефона :";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(flowLayoutPanelRoles);
            groupBox3.ForeColor = Color.Red;
            groupBox3.Location = new Point(10, 369);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(538, 104);
            groupBox3.TabIndex = 1;
            groupBox3.TabStop = false;
            groupBox3.Text = "Круг полномочий";
            // 
            // flowLayoutPanelRoles
            // 
            flowLayoutPanelRoles.AutoScroll = true;
            flowLayoutPanelRoles.Controls.Add(checkBoxAdd);
            flowLayoutPanelRoles.Controls.Add(checkBoxDelete);
            flowLayoutPanelRoles.Controls.Add(checkBoxEdit);
            flowLayoutPanelRoles.Controls.Add(checkBoxExport);
            flowLayoutPanelRoles.Controls.Add(checkBoxPrint);
            flowLayoutPanelRoles.Controls.Add(checkBoxSearch);
            flowLayoutPanelRoles.Controls.Add(checkBoxHomeSearch);
            flowLayoutPanelRoles.Controls.Add(checkBoxHome);
            flowLayoutPanelRoles.Controls.Add(checkBoxSalaryIndex);
            flowLayoutPanelRoles.Controls.Add(checkBoxEmpolyees);
            flowLayoutPanelRoles.Controls.Add(checkBoxUsers);
            flowLayoutPanelRoles.Controls.Add(checkBoxReports);
            flowLayoutPanelRoles.Controls.Add(checkBoxSettings);
            flowLayoutPanelRoles.Controls.Add(checkBoxAbout);
            flowLayoutPanelRoles.Controls.Add(checkBoxHelp);
            flowLayoutPanelRoles.Controls.Add(checkBoxRetirment);
            flowLayoutPanelRoles.Controls.Add(checkBoxSystemRecords);
            flowLayoutPanelRoles.Dock = DockStyle.Fill;
            flowLayoutPanelRoles.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            flowLayoutPanelRoles.Location = new Point(3, 23);
            flowLayoutPanelRoles.Name = "flowLayoutPanelRoles";
            flowLayoutPanelRoles.Size = new Size(532, 78);
            flowLayoutPanelRoles.TabIndex = 0;
            // 
            // checkBoxAdd
            // 
            checkBoxAdd.AutoSize = true;
            checkBoxAdd.Checked = true;
            checkBoxAdd.CheckState = CheckState.Checked;
            checkBoxAdd.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            checkBoxAdd.ForeColor = Color.Black;
            checkBoxAdd.Location = new Point(3, 3);
            checkBoxAdd.Name = "checkBoxAdd";
            checkBoxAdd.Size = new Size(92, 21);
            checkBoxAdd.TabIndex = 3;
            checkBoxAdd.Text = "Добавлять";
            checkBoxAdd.UseVisualStyleBackColor = true;
            // 
            // checkBoxDelete
            // 
            checkBoxDelete.AutoSize = true;
            checkBoxDelete.Checked = true;
            checkBoxDelete.CheckState = CheckState.Checked;
            checkBoxDelete.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            checkBoxDelete.ForeColor = Color.Black;
            checkBoxDelete.Location = new Point(101, 3);
            checkBoxDelete.Name = "checkBoxDelete";
            checkBoxDelete.Size = new Size(74, 21);
            checkBoxDelete.TabIndex = 3;
            checkBoxDelete.Text = "Удалить";
            checkBoxDelete.UseVisualStyleBackColor = true;
            // 
            // checkBoxEdit
            // 
            checkBoxEdit.AutoSize = true;
            checkBoxEdit.Checked = true;
            checkBoxEdit.CheckState = CheckState.Checked;
            checkBoxEdit.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            checkBoxEdit.ForeColor = Color.Black;
            checkBoxEdit.Location = new Point(181, 3);
            checkBoxEdit.Name = "checkBoxEdit";
            checkBoxEdit.Size = new Size(115, 21);
            checkBoxEdit.TabIndex = 3;
            checkBoxEdit.Text = "Редактировать";
            checkBoxEdit.UseVisualStyleBackColor = true;
            // 
            // checkBoxExport
            // 
            checkBoxExport.AutoSize = true;
            checkBoxExport.Checked = true;
            checkBoxExport.CheckState = CheckState.Checked;
            checkBoxExport.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            checkBoxExport.ForeColor = Color.Black;
            checkBoxExport.Location = new Point(302, 3);
            checkBoxExport.Name = "checkBoxExport";
            checkBoxExport.Size = new Size(75, 21);
            checkBoxExport.TabIndex = 3;
            checkBoxExport.Text = "Экспорт";
            checkBoxExport.UseVisualStyleBackColor = true;
            // 
            // checkBoxPrint
            // 
            checkBoxPrint.AutoSize = true;
            checkBoxPrint.Checked = true;
            checkBoxPrint.CheckState = CheckState.Checked;
            checkBoxPrint.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            checkBoxPrint.ForeColor = Color.Black;
            checkBoxPrint.Location = new Point(383, 3);
            checkBoxPrint.Name = "checkBoxPrint";
            checkBoxPrint.Size = new Size(69, 21);
            checkBoxPrint.TabIndex = 3;
            checkBoxPrint.Text = "Печать";
            checkBoxPrint.UseVisualStyleBackColor = true;
            // 
            // checkBoxSearch
            // 
            checkBoxSearch.AutoSize = true;
            checkBoxSearch.Checked = true;
            checkBoxSearch.CheckState = CheckState.Checked;
            checkBoxSearch.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            checkBoxSearch.ForeColor = Color.Black;
            checkBoxSearch.Location = new Point(458, 3);
            checkBoxSearch.Name = "checkBoxSearch";
            checkBoxSearch.Size = new Size(63, 21);
            checkBoxSearch.TabIndex = 3;
            checkBoxSearch.Text = "Поиск";
            checkBoxSearch.UseVisualStyleBackColor = true;
            // 
            // checkBoxHomeSearch
            // 
            checkBoxHomeSearch.AutoSize = true;
            checkBoxHomeSearch.Checked = true;
            checkBoxHomeSearch.CheckState = CheckState.Checked;
            checkBoxHomeSearch.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            checkBoxHomeSearch.ForeColor = Color.Black;
            checkBoxHomeSearch.Location = new Point(3, 30);
            checkBoxHomeSearch.Name = "checkBoxHomeSearch";
            checkBoxHomeSearch.Size = new Size(133, 21);
            checkBoxHomeSearch.TabIndex = 3;
            checkBoxHomeSearch.Text = "Поиск на главной";
            checkBoxHomeSearch.UseVisualStyleBackColor = true;
            // 
            // checkBoxHome
            // 
            checkBoxHome.AutoSize = true;
            checkBoxHome.Checked = true;
            checkBoxHome.CheckState = CheckState.Checked;
            checkBoxHome.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            checkBoxHome.ForeColor = Color.Black;
            checkBoxHome.Location = new Point(142, 30);
            checkBoxHome.Name = "checkBoxHome";
            checkBoxHome.Size = new Size(77, 21);
            checkBoxHome.TabIndex = 3;
            checkBoxHome.Text = "Главный";
            checkBoxHome.UseVisualStyleBackColor = true;
            // 
            // checkBoxSalaryIndex
            // 
            checkBoxSalaryIndex.AutoSize = true;
            checkBoxSalaryIndex.Checked = true;
            checkBoxSalaryIndex.CheckState = CheckState.Checked;
            checkBoxSalaryIndex.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            checkBoxSalaryIndex.ForeColor = Color.Black;
            checkBoxSalaryIndex.Location = new Point(225, 30);
            checkBoxSalaryIndex.Name = "checkBoxSalaryIndex";
            checkBoxSalaryIndex.Size = new Size(84, 21);
            checkBoxSalaryIndex.TabIndex = 3;
            checkBoxSalaryIndex.Text = "Зарплаты";
            checkBoxSalaryIndex.UseVisualStyleBackColor = true;
            // 
            // checkBoxEmpolyees
            // 
            checkBoxEmpolyees.AutoSize = true;
            checkBoxEmpolyees.Checked = true;
            checkBoxEmpolyees.CheckState = CheckState.Checked;
            checkBoxEmpolyees.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            checkBoxEmpolyees.ForeColor = Color.Black;
            checkBoxEmpolyees.Location = new Point(315, 30);
            checkBoxEmpolyees.Name = "checkBoxEmpolyees";
            checkBoxEmpolyees.Size = new Size(96, 21);
            checkBoxEmpolyees.TabIndex = 3;
            checkBoxEmpolyees.Text = "Сотрудники";
            checkBoxEmpolyees.UseVisualStyleBackColor = true;
            // 
            // checkBoxUsers
            // 
            checkBoxUsers.AutoSize = true;
            checkBoxUsers.Checked = true;
            checkBoxUsers.CheckState = CheckState.Checked;
            checkBoxUsers.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            checkBoxUsers.ForeColor = Color.Black;
            checkBoxUsers.Location = new Point(417, 30);
            checkBoxUsers.Name = "checkBoxUsers";
            checkBoxUsers.Size = new Size(112, 21);
            checkBoxUsers.TabIndex = 3;
            checkBoxUsers.Text = "Пользователи";
            checkBoxUsers.UseVisualStyleBackColor = true;
            // 
            // checkBoxReports
            // 
            checkBoxReports.AutoSize = true;
            checkBoxReports.Checked = true;
            checkBoxReports.CheckState = CheckState.Checked;
            checkBoxReports.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            checkBoxReports.ForeColor = Color.Black;
            checkBoxReports.Location = new Point(3, 57);
            checkBoxReports.Name = "checkBoxReports";
            checkBoxReports.Size = new Size(68, 21);
            checkBoxReports.TabIndex = 3;
            checkBoxReports.Text = "Заявки";
            checkBoxReports.UseVisualStyleBackColor = true;
            // 
            // checkBoxSettings
            // 
            checkBoxSettings.AutoSize = true;
            checkBoxSettings.Checked = true;
            checkBoxSettings.CheckState = CheckState.Checked;
            checkBoxSettings.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            checkBoxSettings.ForeColor = Color.Black;
            checkBoxSettings.Location = new Point(77, 57);
            checkBoxSettings.Name = "checkBoxSettings";
            checkBoxSettings.Size = new Size(98, 21);
            checkBoxSettings.TabIndex = 3;
            checkBoxSettings.Text = "Насторойки";
            checkBoxSettings.UseVisualStyleBackColor = true;
            // 
            // checkBoxAbout
            // 
            checkBoxAbout.AutoSize = true;
            checkBoxAbout.Checked = true;
            checkBoxAbout.CheckState = CheckState.Checked;
            checkBoxAbout.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            checkBoxAbout.ForeColor = Color.Black;
            checkBoxAbout.Location = new Point(181, 57);
            checkBoxAbout.Name = "checkBoxAbout";
            checkBoxAbout.Size = new Size(106, 21);
            checkBoxAbout.TabIndex = 3;
            checkBoxAbout.Text = "Информация";
            checkBoxAbout.UseVisualStyleBackColor = true;
            // 
            // checkBoxHelp
            // 
            checkBoxHelp.AutoSize = true;
            checkBoxHelp.Checked = true;
            checkBoxHelp.CheckState = CheckState.Checked;
            checkBoxHelp.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            checkBoxHelp.ForeColor = Color.Black;
            checkBoxHelp.Location = new Point(293, 57);
            checkBoxHelp.Name = "checkBoxHelp";
            checkBoxHelp.Size = new Size(79, 21);
            checkBoxHelp.TabIndex = 3;
            checkBoxHelp.Text = "Помощь";
            checkBoxHelp.UseVisualStyleBackColor = true;
            // 
            // checkBoxRetirment
            // 
            checkBoxRetirment.AutoSize = true;
            checkBoxRetirment.Checked = true;
            checkBoxRetirment.CheckState = CheckState.Checked;
            checkBoxRetirment.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            checkBoxRetirment.ForeColor = Color.Black;
            checkBoxRetirment.Location = new Point(378, 57);
            checkBoxRetirment.Name = "checkBoxRetirment";
            checkBoxRetirment.Size = new Size(102, 21);
            checkBoxRetirment.TabIndex = 3;
            checkBoxRetirment.Text = "Пенсионеры";
            checkBoxRetirment.UseVisualStyleBackColor = true;
            // 
            // checkBoxSystemRecords
            // 
            checkBoxSystemRecords.AutoSize = true;
            checkBoxSystemRecords.Checked = true;
            checkBoxSystemRecords.CheckState = CheckState.Checked;
            checkBoxSystemRecords.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            checkBoxSystemRecords.ForeColor = Color.Black;
            checkBoxSystemRecords.Location = new Point(3, 84);
            checkBoxSystemRecords.Name = "checkBoxSystemRecords";
            checkBoxSystemRecords.Size = new Size(137, 21);
            checkBoxSystemRecords.TabIndex = 3;
            checkBoxSystemRecords.Text = "Системный реестр";
            checkBoxSystemRecords.UseVisualStyleBackColor = true;
            // 
            // AddUserForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(549, 471);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddUserForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Добавлять / редактировать  пользователь";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            flowLayoutPanelRoles.ResumeLayout(false);
            flowLayoutPanelRoles.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label2;
        private Label label1;
        private CheckBox checkBoxSecondaryUser;
        private TextBox textBoxPassword;
        private Label label6;
        private TextBox textBoxUserName;
        private Label label4;
        private Label label5;
        private TextBox textBoxFullName;
        private Label label3;
        private GroupBox groupBox2;
        private TextBox textBoxEmail;
        private TextBox textBoxPhone;
        private Label label11;
        private Label label13;
        private Label label14;
        private GroupBox groupBox3;
        private Button buttonSave;
        private FlowLayoutPanel flowLayoutPanelRoles;
        private CheckBox checkBoxAdd;
        private CheckBox checkBoxDelete;
        private CheckBox checkBoxEdit;
        private CheckBox checkBoxExport;
        private CheckBox checkBoxPrint;
        private CheckBox checkBoxSearch;
        private CheckBox checkBoxHomeSearch;
        private CheckBox checkBoxHome;
        private CheckBox checkBoxSalaryIndex;
        private CheckBox checkBoxEmpolyees;
        private CheckBox checkBoxUsers;
        private CheckBox checkBoxReports;
        private CheckBox checkBoxSettings;
        private CheckBox checkBoxAbout;
        private CheckBox checkBoxHelp;
        private CheckBox checkBoxRetirment;
        private CheckBox checkBoxSystemRecords;
        private ComboBox comboBoxRole;
        private Label label7;
        private ComboBox comboBoxUserId;
        private TextBox textBoxAddress;
        private Label label8;
        private Label label9;
        private Label label10;
    }
}