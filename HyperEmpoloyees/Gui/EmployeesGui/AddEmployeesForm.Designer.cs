namespace HyperEmpoloyees.Gui.EmpoloyeesGui
{
    partial class AddEmployeesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddEmployeesForm));
            buttonSave = new Button();
            label1 = new Label();
            textBoxFullName = new TextBox();
            groupBox1 = new GroupBox();
            label14 = new Label();
            label4 = new Label();
            label2 = new Label();
            dateTimePickerLastPromotion = new DateTimePicker();
            comboBoxEmpState = new ComboBox();
            comboBoxJopTitle = new ComboBox();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            panel1 = new Panel();
            buttonUpgrade = new Button();
            buttonAutoCol = new Button();
            buttonNew = new Button();
            groupBox4 = new GroupBox();
            richTextBoxNote = new RichTextBox();
            groupBox3 = new GroupBox();
            textBoxNextSalary = new TextBox();
            numericUpDownNextStage = new NumericUpDown();
            numericUpDownNextDegree = new NumericUpDown();
            dateTimePickerNextDate = new DateTimePicker();
            label15 = new Label();
            labelSalaryCurrency = new Label();
            label5 = new Label();
            label12 = new Label();
            label13 = new Label();
            groupBox2 = new GroupBox();
            textBoxCurrentSalary = new TextBox();
            numericUpDownCurrentStage = new NumericUpDown();
            numericUpDownCurrentDegree = new NumericUpDown();
            dateTimePickerCurrentDate = new DateTimePicker();
            labelSBouncCurrency = new Label();
            label11 = new Label();
            label7 = new Label();
            label6 = new Label();
            label3 = new Label();
            tabPage2 = new TabPage();
            tabPage3 = new TabPage();
            tabPage4 = new TabPage();
            tabPage5 = new TabPage();
            groupBox1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            panel1.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownNextStage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownNextDegree).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownCurrentStage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownCurrentDegree).BeginInit();
            SuspendLayout();
            // 
            // buttonSave
            // 
            buttonSave.Anchor = AnchorStyles.Left;
            buttonSave.BackColor = Color.White;
            buttonSave.Image = Properties.Resources.icons8_save_32px;
            buttonSave.ImageAlign = ContentAlignment.MiddleLeft;
            buttonSave.Location = new Point(13, 6);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(175, 67);
            buttonSave.TabIndex = 4;
            buttonSave.Text = "   Сохранять";
            buttonSave.UseVisualStyleBackColor = false;
            buttonSave.Click += buttonSave_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left;
            label1.AutoSize = true;
            label1.ForeColor = Color.Black;
            label1.Location = new Point(8, 33);
            label1.Name = "label1";
            label1.Size = new Size(103, 20);
            label1.TabIndex = 0;
            label1.Text = "Полное имя :";
            // 
            // textBoxFullName
            // 
            textBoxFullName.Anchor = AnchorStyles.Left;
            textBoxFullName.Location = new Point(8, 56);
            textBoxFullName.Name = "textBoxFullName";
            textBoxFullName.Size = new Size(354, 27);
            textBoxFullName.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(label14);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(dateTimePickerLastPromotion);
            groupBox1.Controls.Add(comboBoxEmpState);
            groupBox1.Controls.Add(comboBoxJopTitle);
            groupBox1.Controls.Add(textBoxFullName);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label1);
            groupBox1.ForeColor = Color.FromArgb(0, 0, 192);
            groupBox1.Location = new Point(8, 5);
            groupBox1.Margin = new Padding(2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(2);
            groupBox1.Size = new Size(1004, 105);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Основная информация";
            // 
            // label14
            // 
            label14.Anchor = AnchorStyles.Left;
            label14.AutoSize = true;
            label14.ForeColor = Color.Red;
            label14.Location = new Point(631, 33);
            label14.Name = "label14";
            label14.Size = new Size(16, 20);
            label14.TabIndex = 4;
            label14.Text = "*";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Left;
            label4.AutoSize = true;
            label4.ForeColor = Color.Red;
            label4.Location = new Point(472, 32);
            label4.Name = "label4";
            label4.Size = new Size(16, 20);
            label4.TabIndex = 4;
            label4.Text = "*";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Left;
            label2.AutoSize = true;
            label2.ForeColor = Color.Red;
            label2.Location = new Point(108, 33);
            label2.Name = "label2";
            label2.Size = new Size(16, 20);
            label2.TabIndex = 4;
            label2.Text = "*";
            // 
            // dateTimePickerLastPromotion
            // 
            dateTimePickerLastPromotion.Anchor = AnchorStyles.Left;
            dateTimePickerLastPromotion.Format = DateTimePickerFormat.Short;
            dateTimePickerLastPromotion.Location = new Point(777, 57);
            dateTimePickerLastPromotion.Name = "dateTimePickerLastPromotion";
            dateTimePickerLastPromotion.Size = new Size(200, 27);
            dateTimePickerLastPromotion.TabIndex = 3;
            // 
            // comboBoxEmpState
            // 
            comboBoxEmpState.Anchor = AnchorStyles.Left;
            comboBoxEmpState.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBoxEmpState.AutoCompleteSource = AutoCompleteSource.CustomSource;
            comboBoxEmpState.FormattingEnabled = true;
            comboBoxEmpState.Items.AddRange(new object[] { "Активен", "В отпуске", "Бонусов", "Продвижение", "Участие в розыгрыше бонуса", "Запись об акции", "Остановился", "В стадии обработки" });
            comboBoxEmpState.Location = new Point(573, 56);
            comboBoxEmpState.Name = "comboBoxEmpState";
            comboBoxEmpState.Size = new Size(179, 28);
            comboBoxEmpState.TabIndex = 2;
            // 
            // comboBoxJopTitle
            // 
            comboBoxJopTitle.Anchor = AnchorStyles.Left;
            comboBoxJopTitle.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBoxJopTitle.AutoCompleteSource = AutoCompleteSource.CustomSource;
            comboBoxJopTitle.FormattingEnabled = true;
            comboBoxJopTitle.Location = new Point(379, 55);
            comboBoxJopTitle.Name = "comboBoxJopTitle";
            comboBoxJopTitle.Size = new Size(179, 28);
            comboBoxJopTitle.TabIndex = 2;
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Left;
            label10.AutoSize = true;
            label10.ForeColor = Color.Black;
            label10.Location = new Point(777, 34);
            label10.Name = "label10";
            label10.Size = new Size(195, 20);
            label10.TabIndex = 0;
            label10.Text = "Дата последней подписи :";
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Left;
            label9.AutoSize = true;
            label9.ForeColor = Color.Black;
            label9.Location = new Point(573, 33);
            label9.Name = "label9";
            label9.Size = new Size(61, 20);
            label9.TabIndex = 0;
            label9.Text = "Статус :";
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Left;
            label8.AutoSize = true;
            label8.ForeColor = Color.Black;
            label8.Location = new Point(379, 33);
            label8.Name = "label8";
            label8.Size = new Size(96, 20);
            label8.TabIndex = 0;
            label8.Text = "Должность :";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Controls.Add(tabPage5);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1027, 556);
            tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(panel1);
            tabPage1.Controls.Add(groupBox4);
            tabPage1.Controls.Add(groupBox3);
            tabPage1.Controls.Add(groupBox2);
            tabPage1.Controls.Add(groupBox1);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1019, 523);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Бонусы и продвижение";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(buttonUpgrade);
            panel1.Controls.Add(buttonAutoCol);
            panel1.Controls.Add(buttonNew);
            panel1.Controls.Add(buttonSave);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(3, 444);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(3);
            panel1.Size = new Size(1013, 76);
            panel1.TabIndex = 5;
            // 
            // buttonUpgrade
            // 
            buttonUpgrade.Anchor = AnchorStyles.Right;
            buttonUpgrade.BackColor = Color.White;
            buttonUpgrade.Image = Properties.Resources.icons8_save_32_gold;
            buttonUpgrade.ImageAlign = ContentAlignment.MiddleLeft;
            buttonUpgrade.Location = new Point(616, 6);
            buttonUpgrade.Name = "buttonUpgrade";
            buttonUpgrade.Padding = new Padding(3);
            buttonUpgrade.Size = new Size(389, 67);
            buttonUpgrade.TabIndex = 4;
            buttonUpgrade.Text = "     Процедура получения бонусов и повышения класса обслуживания";
            buttonUpgrade.UseVisualStyleBackColor = false;
            buttonUpgrade.Click += buttonUpgrade_Click;
            // 
            // buttonAutoCol
            // 
            buttonAutoCol.Anchor = AnchorStyles.Left;
            buttonAutoCol.BackColor = Color.White;
            buttonAutoCol.Image = Properties.Resources.icons8_save_32;
            buttonAutoCol.ImageAlign = ContentAlignment.MiddleLeft;
            buttonAutoCol.Location = new Point(375, 6);
            buttonAutoCol.Name = "buttonAutoCol";
            buttonAutoCol.Padding = new Padding(3);
            buttonAutoCol.Size = new Size(175, 67);
            buttonAutoCol.TabIndex = 4;
            buttonAutoCol.Text = "      Автоматический расчет";
            buttonAutoCol.UseVisualStyleBackColor = false;
            buttonAutoCol.Click += buttonAutoCol_Click;
            // 
            // buttonNew
            // 
            buttonNew.Anchor = AnchorStyles.Left;
            buttonNew.BackColor = Color.White;
            buttonNew.Image = Properties.Resources.icons8_save_32_green;
            buttonNew.ImageAlign = ContentAlignment.MiddleLeft;
            buttonNew.Location = new Point(194, 6);
            buttonNew.Name = "buttonNew";
            buttonNew.Padding = new Padding(3);
            buttonNew.Size = new Size(175, 67);
            buttonNew.TabIndex = 4;
            buttonNew.Text = "   Новое";
            buttonNew.UseVisualStyleBackColor = false;
            buttonNew.Click += buttonNew_Click;
            // 
            // groupBox4
            // 
            groupBox4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox4.Controls.Add(richTextBoxNote);
            groupBox4.ForeColor = Color.FromArgb(0, 0, 192);
            groupBox4.Location = new Point(8, 332);
            groupBox4.Margin = new Padding(2);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new Padding(2);
            groupBox4.Size = new Size(1004, 108);
            groupBox4.TabIndex = 0;
            groupBox4.TabStop = false;
            groupBox4.Text = "Примечания :";
            // 
            // richTextBoxNote
            // 
            richTextBoxNote.Dock = DockStyle.Fill;
            richTextBoxNote.Location = new Point(2, 22);
            richTextBoxNote.Name = "richTextBoxNote";
            richTextBoxNote.Size = new Size(1000, 84);
            richTextBoxNote.TabIndex = 0;
            richTextBoxNote.Text = "";
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox3.Controls.Add(textBoxNextSalary);
            groupBox3.Controls.Add(numericUpDownNextStage);
            groupBox3.Controls.Add(numericUpDownNextDegree);
            groupBox3.Controls.Add(dateTimePickerNextDate);
            groupBox3.Controls.Add(label15);
            groupBox3.Controls.Add(labelSalaryCurrency);
            groupBox3.Controls.Add(label5);
            groupBox3.Controls.Add(label12);
            groupBox3.Controls.Add(label13);
            groupBox3.ForeColor = Color.FromArgb(0, 0, 192);
            groupBox3.Location = new Point(7, 223);
            groupBox3.Margin = new Padding(2);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(2);
            groupBox3.Size = new Size(1005, 105);
            groupBox3.TabIndex = 0;
            groupBox3.TabStop = false;
            groupBox3.Text = "Следующий бонус";
            // 
            // textBoxNextSalary
            // 
            textBoxNextSalary.Location = new Point(380, 55);
            textBoxNextSalary.Name = "textBoxNextSalary";
            textBoxNextSalary.Size = new Size(223, 27);
            textBoxNextSalary.TabIndex = 5;
            textBoxNextSalary.Text = "0";
            textBoxNextSalary.TextAlign = HorizontalAlignment.Center;
            textBoxNextSalary.MouseLeave += textBoxNextSalary_MouseLeave;
            // 
            // numericUpDownNextStage
            // 
            numericUpDownNextStage.Anchor = AnchorStyles.Left;
            numericUpDownNextStage.Location = new Point(200, 59);
            numericUpDownNextStage.Name = "numericUpDownNextStage";
            numericUpDownNextStage.Size = new Size(150, 27);
            numericUpDownNextStage.TabIndex = 4;
            numericUpDownNextStage.Value = new decimal(new int[] { 2, 0, 0, 0 });
            numericUpDownNextStage.ValueChanged += numericUpDownNextStage_ValueChanged;
            // 
            // numericUpDownNextDegree
            // 
            numericUpDownNextDegree.Anchor = AnchorStyles.Left;
            numericUpDownNextDegree.Location = new Point(9, 59);
            numericUpDownNextDegree.Name = "numericUpDownNextDegree";
            numericUpDownNextDegree.Size = new Size(150, 27);
            numericUpDownNextDegree.TabIndex = 4;
            numericUpDownNextDegree.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownNextDegree.ValueChanged += numericUpDownNextDegree_ValueChanged;
            // 
            // dateTimePickerNextDate
            // 
            dateTimePickerNextDate.Anchor = AnchorStyles.Left;
            dateTimePickerNextDate.Format = DateTimePickerFormat.Short;
            dateTimePickerNextDate.Location = new Point(655, 53);
            dateTimePickerNextDate.Name = "dateTimePickerNextDate";
            dateTimePickerNextDate.Size = new Size(323, 27);
            dateTimePickerNextDate.TabIndex = 3;
            // 
            // label15
            // 
            label15.Anchor = AnchorStyles.Left;
            label15.AutoSize = true;
            label15.ForeColor = Color.Black;
            label15.Location = new Point(655, 30);
            label15.Name = "label15";
            label15.Size = new Size(50, 20);
            label15.TabIndex = 0;
            label15.Text = "Дата :";
            // 
            // labelSalaryCurrency
            // 
            labelSalaryCurrency.AutoSize = true;
            labelSalaryCurrency.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            labelSalaryCurrency.ForeColor = Color.LightGray;
            labelSalaryCurrency.Location = new Point(565, 34);
            labelSalaryCurrency.Name = "labelSalaryCurrency";
            labelSalaryCurrency.Size = new Size(28, 13);
            labelSalaryCurrency.TabIndex = 0;
            labelSalaryCurrency.Text = "RUB";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Left;
            label5.AutoSize = true;
            label5.ForeColor = Color.Black;
            label5.Location = new Point(377, 32);
            label5.Name = "label5";
            label5.Size = new Size(182, 20);
            label5.TabIndex = 0;
            label5.Text = "Номинальная зарплата :";
            // 
            // label12
            // 
            label12.Anchor = AnchorStyles.Left;
            label12.AutoSize = true;
            label12.ForeColor = Color.Black;
            label12.Location = new Point(9, 36);
            label12.Name = "label12";
            label12.Size = new Size(74, 20);
            label12.TabIndex = 0;
            label12.Text = "Степень :";
            // 
            // label13
            // 
            label13.Anchor = AnchorStyles.Left;
            label13.AutoSize = true;
            label13.ForeColor = Color.Black;
            label13.Location = new Point(200, 36);
            label13.Name = "label13";
            label13.Size = new Size(64, 20);
            label13.TabIndex = 0;
            label13.Text = " Сцена :";
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(textBoxCurrentSalary);
            groupBox2.Controls.Add(numericUpDownCurrentStage);
            groupBox2.Controls.Add(numericUpDownCurrentDegree);
            groupBox2.Controls.Add(dateTimePickerCurrentDate);
            groupBox2.Controls.Add(labelSBouncCurrency);
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(label3);
            groupBox2.ForeColor = Color.FromArgb(0, 0, 192);
            groupBox2.Location = new Point(8, 114);
            groupBox2.Margin = new Padding(2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(2);
            groupBox2.Size = new Size(1004, 105);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "Текущее пособие";
            // 
            // textBoxCurrentSalary
            // 
            textBoxCurrentSalary.Location = new Point(379, 60);
            textBoxCurrentSalary.Name = "textBoxCurrentSalary";
            textBoxCurrentSalary.Size = new Size(223, 27);
            textBoxCurrentSalary.TabIndex = 5;
            textBoxCurrentSalary.Text = "0";
            textBoxCurrentSalary.TextAlign = HorizontalAlignment.Center;
            textBoxCurrentSalary.MouseLeave += textBoxCurrentSalary_MouseLeave;
            // 
            // numericUpDownCurrentStage
            // 
            numericUpDownCurrentStage.Anchor = AnchorStyles.Left;
            numericUpDownCurrentStage.Location = new Point(199, 58);
            numericUpDownCurrentStage.Name = "numericUpDownCurrentStage";
            numericUpDownCurrentStage.Size = new Size(150, 27);
            numericUpDownCurrentStage.TabIndex = 4;
            numericUpDownCurrentStage.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownCurrentStage.ValueChanged += numericUpDownCurrentStage_ValueChanged;
            // 
            // numericUpDownCurrentDegree
            // 
            numericUpDownCurrentDegree.Anchor = AnchorStyles.Left;
            numericUpDownCurrentDegree.Location = new Point(8, 58);
            numericUpDownCurrentDegree.Name = "numericUpDownCurrentDegree";
            numericUpDownCurrentDegree.Size = new Size(150, 27);
            numericUpDownCurrentDegree.TabIndex = 4;
            numericUpDownCurrentDegree.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownCurrentDegree.ValueChanged += numericUpDownCurrentDegree_ValueChanged_1;
            // 
            // dateTimePickerCurrentDate
            // 
            dateTimePickerCurrentDate.Anchor = AnchorStyles.Left;
            dateTimePickerCurrentDate.Format = DateTimePickerFormat.Short;
            dateTimePickerCurrentDate.Location = new Point(654, 60);
            dateTimePickerCurrentDate.Name = "dateTimePickerCurrentDate";
            dateTimePickerCurrentDate.Size = new Size(323, 27);
            dateTimePickerCurrentDate.TabIndex = 3;
            // 
            // labelSBouncCurrency
            // 
            labelSBouncCurrency.AutoSize = true;
            labelSBouncCurrency.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            labelSBouncCurrency.ForeColor = Color.LightGray;
            labelSBouncCurrency.Location = new Point(567, 39);
            labelSBouncCurrency.Name = "labelSBouncCurrency";
            labelSBouncCurrency.Size = new Size(28, 13);
            labelSBouncCurrency.TabIndex = 0;
            labelSBouncCurrency.Text = "RUB";
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.Left;
            label11.AutoSize = true;
            label11.ForeColor = Color.Black;
            label11.Location = new Point(654, 37);
            label11.Name = "label11";
            label11.Size = new Size(50, 20);
            label11.TabIndex = 0;
            label11.Text = "Дата :";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Left;
            label7.AutoSize = true;
            label7.ForeColor = Color.Black;
            label7.Location = new Point(379, 37);
            label7.Name = "label7";
            label7.Size = new Size(182, 20);
            label7.TabIndex = 0;
            label7.Text = "Номинальная зарплата :";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Left;
            label6.AutoSize = true;
            label6.ForeColor = Color.Black;
            label6.Location = new Point(199, 35);
            label6.Name = "label6";
            label6.Size = new Size(64, 20);
            label6.TabIndex = 0;
            label6.Text = " Сцена :";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Left;
            label3.AutoSize = true;
            label3.ForeColor = Color.Black;
            label3.Location = new Point(8, 35);
            label3.Name = "label3";
            label3.Size = new Size(74, 20);
            label3.TabIndex = 0;
            label3.Text = "Степень :";
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1019, 523);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Благодарность ";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            tabPage3.Location = new Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(1019, 523);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Каникулы";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            tabPage4.Location = new Point(4, 29);
            tabPage4.Name = "tabPage4";
            tabPage4.Size = new Size(1019, 523);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Отсутствие";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            tabPage5.Location = new Point(4, 29);
            tabPage5.Name = "tabPage5";
            tabPage5.Size = new Size(1019, 523);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "Послужной список бонус-трека";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // AddEmployeesForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1027, 556);
            Controls.Add(tabControl1);
            Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "AddEmployeesForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Добавлять / редактировать  ";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownNextStage).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownNextDegree).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownCurrentStage).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownCurrentDegree).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button buttonSave;
        private Label label1;
        private TextBox textBoxFullName;
        private GroupBox groupBox1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private TabPage tabPage5;
        private Panel panel1;
        private DateTimePicker dateTimePickerLastPromotion;
        private ComboBox comboBoxEmpState;
        private ComboBox comboBoxJopTitle;
        private GroupBox groupBox3;
        private GroupBox groupBox2;
        private DateTimePicker dateTimePickerCurrentDate;
        private Label label3;
        private NumericUpDown numericUpDownCurrentDegree;
        private NumericUpDown numericUpDownCurrentStage;
        private Label label7;
        private Label label6;
        private Label label8;
        private Label label10;
        private Label label9;
        private Label label11;
        private NumericUpDown numericUpDownNextStage;
        private NumericUpDown numericUpDownNextDegree;
        private DateTimePicker dateTimePickerNextDate;
        private Label labelSBouncCurrency;
        private Label label5;
        private Label label12;
        private Label label13;
        private GroupBox groupBox4;
        private Label label15;
        private RichTextBox richTextBoxNote;
        private Label labelSalaryCurrency;
        private TextBox textBoxNextSalary;
        private TextBox textBoxCurrentSalary;
        private Label label2;
        private Label label14;
        private Label label4;
        private Button buttonUpgrade;
        private Button buttonAutoCol;
        private Button buttonNew;
    }
}