namespace HyperEmpoloyees.Gui.SalaryRateGui
{
    partial class AddSalaryRateForm
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
            numericUpDownPromtion = new NumericUpDown();
            numericUpDownDegree = new NumericUpDown();
            textBoxBouncYear = new TextBox();
            label6 = new Label();
            textBoxSalary = new TextBox();
            label7 = new Label();
            label4 = new Label();
            label5 = new Label();
            labelSalaryCurrency = new Label();
            labelSBouncCurrency = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            buttonSave = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPromtion).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownDegree).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(numericUpDownPromtion);
            groupBox1.Controls.Add(numericUpDownDegree);
            groupBox1.Controls.Add(textBoxBouncYear);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(textBoxSalary);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(labelSalaryCurrency);
            groupBox1.Controls.Add(labelSBouncCurrency);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.ForeColor = Color.FromArgb(0, 0, 192);
            groupBox1.Location = new Point(8, 8);
            groupBox1.Margin = new Padding(2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(2);
            groupBox1.Size = new Size(239, 308);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Информация о знаке";
            // 
            // numericUpDownPromtion
            // 
            numericUpDownPromtion.Location = new Point(5, 257);
            numericUpDownPromtion.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownPromtion.Name = "numericUpDownPromtion";
            numericUpDownPromtion.Size = new Size(226, 27);
            numericUpDownPromtion.TabIndex = 3;
            numericUpDownPromtion.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numericUpDownDegree
            // 
            numericUpDownDegree.Location = new Point(7, 74);
            numericUpDownDegree.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownDegree.Name = "numericUpDownDegree";
            numericUpDownDegree.Size = new Size(226, 27);
            numericUpDownDegree.TabIndex = 0;
            numericUpDownDegree.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // textBoxBouncYear
            // 
            textBoxBouncYear.Location = new Point(6, 197);
            textBoxBouncYear.Name = "textBoxBouncYear";
            textBoxBouncYear.Size = new Size(227, 27);
            textBoxBouncYear.TabIndex = 2;
            textBoxBouncYear.Text = "0";
            textBoxBouncYear.MouseLeave += textBoxBouncYear_MouseLeave;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = Color.Red;
            label6.Location = new Point(163, 175);
            label6.Name = "label6";
            label6.Size = new Size(16, 20);
            label6.TabIndex = 0;
            label6.Text = "*";
            // 
            // textBoxSalary
            // 
            textBoxSalary.Location = new Point(6, 135);
            textBoxSalary.Name = "textBoxSalary";
            textBoxSalary.Size = new Size(227, 27);
            textBoxSalary.TabIndex = 1;
            textBoxSalary.Text = "0";
            textBoxSalary.MouseLeave += textBoxSalary_MouseLeave;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ForeColor = Color.Black;
            label7.Location = new Point(7, 234);
            label7.Name = "label7";
            label7.Size = new Size(233, 20);
            label7.TabIndex = 0;
            label7.Text = "Годы продвижения по службе :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.Red;
            label4.Location = new Point(85, 113);
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
            label5.Size = new Size(159, 20);
            label5.TabIndex = 0;
            label5.Text = "Ежегодное пособие :";
            // 
            // labelSalaryCurrency
            // 
            labelSalaryCurrency.AutoSize = true;
            labelSalaryCurrency.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            labelSalaryCurrency.ForeColor = Color.LightGray;
            labelSalaryCurrency.Location = new Point(129, 118);
            labelSalaryCurrency.Name = "labelSalaryCurrency";
            labelSalaryCurrency.Size = new Size(28, 13);
            labelSalaryCurrency.TabIndex = 0;
            labelSalaryCurrency.Text = "RUB";
            // 
            // labelSBouncCurrency
            // 
            labelSBouncCurrency.AutoSize = true;
            labelSBouncCurrency.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            labelSBouncCurrency.ForeColor = Color.LightGray;
            labelSBouncCurrency.Location = new Point(198, 180);
            labelSBouncCurrency.Name = "labelSBouncCurrency";
            labelSBouncCurrency.Size = new Size(28, 13);
            labelSBouncCurrency.TabIndex = 0;
            labelSBouncCurrency.Text = "RUB";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.Black;
            label3.Location = new Point(7, 114);
            label3.Name = "label3";
            label3.Size = new Size(81, 20);
            label3.TabIndex = 0;
            label3.Text = "Зарплата :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.Red;
            label2.Location = new Point(198, 50);
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
            label1.Size = new Size(194, 20);
            label1.TabIndex = 0;
            label1.Text = "Функциональная оценка :";
            // 
            // buttonSave
            // 
            buttonSave.BackColor = Color.White;
            buttonSave.Image = Properties.Resources.icons8_save_32px;
            buttonSave.ImageAlign = ContentAlignment.MiddleLeft;
            buttonSave.Location = new Point(8, 321);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(227, 41);
            buttonSave.TabIndex = 4;
            buttonSave.Text = "   Сохранять";
            buttonSave.UseVisualStyleBackColor = false;
            buttonSave.Click += buttonSave_Click;
            // 
            // AddSalaryRateForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(250, 369);
            Controls.Add(groupBox1);
            Controls.Add(buttonSave);
            Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddSalaryRateForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Добавлять / редактировать  пользователь";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPromtion).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownDegree).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label2;
        private Label label1;
        private TextBox textBoxBouncYear;
        private Label label6;
        private TextBox textBoxSalary;
        private Label label4;
        private Label label5;
        private Label label3;
        private Button buttonSave;
        private Label label7;
        private NumericUpDown numericUpDownPromtion;
        private NumericUpDown numericUpDownDegree;
        private Label labelSalaryCurrency;
        private Label labelSBouncCurrency;
    }
}