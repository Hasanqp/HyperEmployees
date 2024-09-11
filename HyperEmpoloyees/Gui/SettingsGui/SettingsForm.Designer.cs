namespace HyperEmpoloyees.Gui.SettingsGui
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            buttonSaveConnection = new Button();
            radioButtonNetwork = new RadioButton();
            numericUpDownDuration = new NumericUpDown();
            label8 = new Label();
            radioButtonLocal = new RadioButton();
            textBoxPassword = new TextBox();
            textBoxUserName = new TextBox();
            label7 = new Label();
            textBoxDataBase = new TextBox();
            label6 = new Label();
            label5 = new Label();
            textBoxServer = new TextBox();
            label4 = new Label();
            groupBox2 = new GroupBox();
            buttonSaveGeneralSettings = new Button();
            numericUpDownOfItems = new NumericUpDown();
            label3 = new Label();
            textBoxCurrency = new TextBox();
            label2 = new Label();
            textBoxCompanyName = new TextBox();
            label1 = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownDuration).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownOfItems).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(buttonSaveConnection);
            groupBox1.Controls.Add(radioButtonNetwork);
            groupBox1.Controls.Add(numericUpDownDuration);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(radioButtonLocal);
            groupBox1.Controls.Add(textBoxPassword);
            groupBox1.Controls.Add(textBoxUserName);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(textBoxDataBase);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(textBoxServer);
            groupBox1.Controls.Add(label4);
            groupBox1.Location = new Point(329, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(316, 431);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Настройки подключения";
            // 
            // buttonSaveConnection
            // 
            buttonSaveConnection.Anchor = AnchorStyles.Left;
            buttonSaveConnection.BackColor = Color.White;
            buttonSaveConnection.Image = Properties.Resources.icons8_save_32px;
            buttonSaveConnection.ImageAlign = ContentAlignment.MiddleLeft;
            buttonSaveConnection.Location = new Point(6, 375);
            buttonSaveConnection.Name = "buttonSaveConnection";
            buttonSaveConnection.Size = new Size(156, 47);
            buttonSaveConnection.TabIndex = 5;
            buttonSaveConnection.Text = "   Сохранять";
            buttonSaveConnection.UseVisualStyleBackColor = false;
            buttonSaveConnection.Click += buttonSaveConnection_Click;
            // 
            // radioButtonNetwork
            // 
            radioButtonNetwork.AutoSize = true;
            radioButtonNetwork.Location = new Point(164, 37);
            radioButtonNetwork.Name = "radioButtonNetwork";
            radioButtonNetwork.Size = new Size(91, 25);
            radioButtonNetwork.TabIndex = 0;
            radioButtonNetwork.Text = "Сетевой ";
            radioButtonNetwork.UseVisualStyleBackColor = true;
            radioButtonNetwork.CheckedChanged += radioButtonNetwork_CheckedChanged;
            // 
            // numericUpDownDuration
            // 
            numericUpDownDuration.Location = new Point(12, 334);
            numericUpDownDuration.Maximum = new decimal(new int[] { 5000, 0, 0, 0 });
            numericUpDownDuration.Minimum = new decimal(new int[] { 5, 0, 0, 0 });
            numericUpDownDuration.Name = "numericUpDownDuration";
            numericUpDownDuration.Size = new Size(290, 29);
            numericUpDownDuration.TabIndex = 2;
            numericUpDownDuration.Value = new decimal(new int[] { 60, 0, 0, 0 });
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(11, 310);
            label8.Name = "label8";
            label8.Size = new Size(242, 21);
            label8.TabIndex = 0;
            label8.Text = "Период подключения (секунды)";
            // 
            // radioButtonLocal
            // 
            radioButtonLocal.AutoSize = true;
            radioButtonLocal.Checked = true;
            radioButtonLocal.Location = new Point(17, 37);
            radioButtonLocal.Name = "radioButtonLocal";
            radioButtonLocal.Size = new Size(107, 25);
            radioButtonLocal.TabIndex = 0;
            radioButtonLocal.TabStop = true;
            radioButtonLocal.Text = "Локальной";
            radioButtonLocal.UseVisualStyleBackColor = true;
            radioButtonLocal.CheckedChanged += radioButtonLocal_CheckedChanged;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(10, 275);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(290, 29);
            textBoxPassword.TabIndex = 1;
            textBoxPassword.Text = "**";
            textBoxPassword.TextAlign = HorizontalAlignment.Center;
            // 
            // textBoxUserName
            // 
            textBoxUserName.Location = new Point(10, 216);
            textBoxUserName.Name = "textBoxUserName";
            textBoxUserName.Size = new Size(290, 29);
            textBoxUserName.TabIndex = 1;
            textBoxUserName.TextAlign = HorizontalAlignment.Center;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 251);
            label7.Name = "label7";
            label7.Size = new Size(142, 21);
            label7.TabIndex = 0;
            label7.Text = "Имя пользователя";
            // 
            // textBoxDataBase
            // 
            textBoxDataBase.Location = new Point(11, 157);
            textBoxDataBase.Name = "textBoxDataBase";
            textBoxDataBase.Size = new Size(290, 29);
            textBoxDataBase.TabIndex = 1;
            textBoxDataBase.Text = "HyperEmpolyeesDB";
            textBoxDataBase.TextAlign = HorizontalAlignment.Center;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 192);
            label6.Name = "label6";
            label6.Size = new Size(142, 21);
            label6.TabIndex = 0;
            label6.Text = "Имя пользователя";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(10, 133);
            label5.Name = "label5";
            label5.Size = new Size(99, 21);
            label5.TabIndex = 0;
            label5.Text = "База данных";
            // 
            // textBoxServer
            // 
            textBoxServer.Location = new Point(12, 98);
            textBoxServer.Name = "textBoxServer";
            textBoxServer.Size = new Size(290, 29);
            textBoxServer.TabIndex = 1;
            textBoxServer.Text = ".\\SQLEXPRESS";
            textBoxServer.TextAlign = HorizontalAlignment.Center;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(11, 74);
            label4.Name = "label4";
            label4.Size = new Size(62, 21);
            label4.TabIndex = 0;
            label4.Text = "Сервер";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(buttonSaveGeneralSettings);
            groupBox2.Controls.Add(numericUpDownOfItems);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(textBoxCurrency);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(textBoxCompanyName);
            groupBox2.Controls.Add(label1);
            groupBox2.Location = new Point(7, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(316, 363);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "Общие настройки";
            // 
            // buttonSaveGeneralSettings
            // 
            buttonSaveGeneralSettings.Anchor = AnchorStyles.Left;
            buttonSaveGeneralSettings.BackColor = Color.White;
            buttonSaveGeneralSettings.Image = Properties.Resources.icons8_save_32px;
            buttonSaveGeneralSettings.ImageAlign = ContentAlignment.MiddleLeft;
            buttonSaveGeneralSettings.Location = new Point(33, 295);
            buttonSaveGeneralSettings.Name = "buttonSaveGeneralSettings";
            buttonSaveGeneralSettings.Size = new Size(156, 47);
            buttonSaveGeneralSettings.TabIndex = 5;
            buttonSaveGeneralSettings.Text = "   Сохранять";
            buttonSaveGeneralSettings.UseVisualStyleBackColor = false;
            buttonSaveGeneralSettings.Click += buttonSaveGeneralSettings_Click;
            // 
            // numericUpDownOfItems
            // 
            numericUpDownOfItems.Location = new Point(19, 216);
            numericUpDownOfItems.Maximum = new decimal(new int[] { 5000, 0, 0, 0 });
            numericUpDownOfItems.Minimum = new decimal(new int[] { 5, 0, 0, 0 });
            numericUpDownOfItems.Name = "numericUpDownOfItems";
            numericUpDownOfItems.Size = new Size(290, 29);
            numericUpDownOfItems.TabIndex = 2;
            numericUpDownOfItems.Value = new decimal(new int[] { 50, 0, 0, 0 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(18, 192);
            label3.Name = "label3";
            label3.Size = new Size(291, 21);
            label3.TabIndex = 0;
            label3.Text = "Количество отображаемых элементов :";
            // 
            // textBoxCurrency
            // 
            textBoxCurrency.Location = new Point(19, 144);
            textBoxCurrency.Name = "textBoxCurrency";
            textBoxCurrency.Size = new Size(290, 29);
            textBoxCurrency.TabIndex = 1;
            textBoxCurrency.TextAlign = HorizontalAlignment.Center;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 120);
            label2.Name = "label2";
            label2.Size = new Size(63, 21);
            label2.TabIndex = 0;
            label2.Text = "Валюта";
            // 
            // textBoxCompanyName
            // 
            textBoxCompanyName.Location = new Point(19, 81);
            textBoxCompanyName.Name = "textBoxCompanyName";
            textBoxCompanyName.Size = new Size(290, 29);
            textBoxCompanyName.TabIndex = 1;
            textBoxCompanyName.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 57);
            label1.Name = "label1";
            label1.Size = new Size(171, 21);
            label1.TabIndex = 0;
            label1.Text = "Название учреждения";
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(649, 439);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(5, 4, 5, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SettingsForm";
            Padding = new Padding(13, 14, 13, 14);
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Настройки программы";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownDuration).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownOfItems).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private NumericUpDown numericUpDownOfItems;
        private Label label3;
        private TextBox textBoxCurrency;
        private Label label2;
        private TextBox textBoxCompanyName;
        private Label label1;
        private Button buttonSaveGeneralSettings;
        private RadioButton radioButtonNetwork;
        private RadioButton radioButtonLocal;
        private TextBox textBoxDataBase;
        private Label label5;
        private TextBox textBoxServer;
        private Label label4;
        private TextBox textBoxPassword;
        private TextBox textBoxUserName;
        private Label label7;
        private Label label6;
        private NumericUpDown numericUpDownDuration;
        private Label label8;
        private Button buttonSaveConnection;
    }
}
