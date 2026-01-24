namespace HyperEmpoloyees
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            flowLayoutPanel1 = new FlowLayoutPanel();
            buttonHome = new Button();
            buttonSalaryCategory = new Button();
            buttonEmployees = new Button();
            buttonRetiremnt = new Button();
            buttonUsers = new Button();
            buttonReports = new Button();
            buttonSystemRecords = new Button();
            buttonSettings = new Button();
            buttonHelp = new Button();
            buttonAbout = new Button();
            panelContainer = new Panel();
            toolTip1 = new ToolTip(components);
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.BackColor = SystemColors.Control;
            flowLayoutPanel1.Controls.Add(buttonHome);
            flowLayoutPanel1.Controls.Add(buttonSalaryCategory);
            flowLayoutPanel1.Controls.Add(buttonEmployees);
            flowLayoutPanel1.Controls.Add(buttonRetiremnt);
            flowLayoutPanel1.Controls.Add(buttonUsers);
            flowLayoutPanel1.Controls.Add(buttonReports);
            flowLayoutPanel1.Controls.Add(buttonSystemRecords);
            flowLayoutPanel1.Controls.Add(buttonSettings);
            flowLayoutPanel1.Controls.Add(buttonHelp);
            flowLayoutPanel1.Controls.Add(buttonAbout);
            flowLayoutPanel1.Dock = DockStyle.Bottom;
            flowLayoutPanel1.Location = new Point(0, 627);
            flowLayoutPanel1.Margin = new Padding(5);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1064, 54);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // buttonHome
            // 
            buttonHome.BackColor = Color.White;
            buttonHome.Image = Properties.Resources.icons8_home_32px;
            buttonHome.ImageAlign = ContentAlignment.MiddleLeft;
            buttonHome.Location = new Point(5, 5);
            buttonHome.Margin = new Padding(5);
            buttonHome.Name = "buttonHome";
            buttonHome.Size = new Size(185, 41);
            buttonHome.TabIndex = 0;
            buttonHome.Text = "   Главный";
            toolTip1.SetToolTip(buttonHome, "   Главный");
            buttonHome.UseVisualStyleBackColor = false;
            buttonHome.Click += buttonHome_Click;
            // 
            // buttonSalaryCategory
            // 
            buttonSalaryCategory.BackColor = Color.White;
            buttonSalaryCategory.Image = Properties.Resources.icons8_teacher_hiring_32px;
            buttonSalaryCategory.ImageAlign = ContentAlignment.MiddleLeft;
            buttonSalaryCategory.Location = new Point(200, 5);
            buttonSalaryCategory.Margin = new Padding(5);
            buttonSalaryCategory.Name = "buttonSalaryCategory";
            buttonSalaryCategory.Size = new Size(185, 41);
            buttonSalaryCategory.TabIndex = 1;
            buttonSalaryCategory.Text = "    Зарплаты";
            toolTip1.SetToolTip(buttonSalaryCategory, "Управление начислением заработной платы");
            buttonSalaryCategory.UseVisualStyleBackColor = false;
            buttonSalaryCategory.Click += buttonSalaryCategory_Click;
            // 
            // buttonEmployees
            // 
            buttonEmployees.BackColor = Color.White;
            buttonEmployees.Image = Properties.Resources.icons8_conference_foreground_selected_32px;
            buttonEmployees.ImageAlign = ContentAlignment.MiddleLeft;
            buttonEmployees.Location = new Point(395, 5);
            buttonEmployees.Margin = new Padding(5);
            buttonEmployees.Name = "buttonEmployees";
            buttonEmployees.Size = new Size(185, 41);
            buttonEmployees.TabIndex = 2;
            buttonEmployees.Text = "      Сотрудники";
            toolTip1.SetToolTip(buttonEmployees, "Управление сотрудниками");
            buttonEmployees.UseVisualStyleBackColor = false;
            buttonEmployees.Click += buttonEmployees_Click;
            // 
            // buttonRetiremnt
            // 
            buttonRetiremnt.BackColor = Color.White;
            buttonRetiremnt.Image = Properties.Resources.icons8_retired_32px;
            buttonRetiremnt.ImageAlign = ContentAlignment.MiddleLeft;
            buttonRetiremnt.Location = new Point(590, 5);
            buttonRetiremnt.Margin = new Padding(5);
            buttonRetiremnt.Name = "buttonRetiremnt";
            buttonRetiremnt.Size = new Size(185, 41);
            buttonRetiremnt.TabIndex = 3;
            buttonRetiremnt.Text = "   Пенсионеры";
            toolTip1.SetToolTip(buttonRetiremnt, "Информация о Пенсионеры");
            buttonRetiremnt.UseVisualStyleBackColor = false;
            buttonRetiremnt.Click += buttonRetiremnt_Click;
            // 
            // buttonUsers
            // 
            buttonUsers.BackColor = Color.White;
            buttonUsers.Image = Properties.Resources.icons8_users_32px;
            buttonUsers.ImageAlign = ContentAlignment.MiddleLeft;
            buttonUsers.Location = new Point(785, 5);
            buttonUsers.Margin = new Padding(5);
            buttonUsers.Name = "buttonUsers";
            buttonUsers.Size = new Size(185, 41);
            buttonUsers.TabIndex = 4;
            buttonUsers.Text = "      Пользователи";
            toolTip1.SetToolTip(buttonUsers, " Управление пользователями");
            buttonUsers.UseVisualStyleBackColor = false;
            buttonUsers.Click += buttonUsers_Click;
            // 
            // buttonReports
            // 
            buttonReports.BackColor = Color.White;
            buttonReports.Image = Properties.Resources.icons8_Business_Report_32px;
            buttonReports.ImageAlign = ContentAlignment.MiddleLeft;
            buttonReports.Location = new Point(5, 56);
            buttonReports.Margin = new Padding(5);
            buttonReports.Name = "buttonReports";
            buttonReports.Size = new Size(185, 41);
            buttonReports.TabIndex = 5;
            buttonReports.Text = "      Заявки";
            toolTip1.SetToolTip(buttonReports, "Создание системных отчетов");
            buttonReports.UseVisualStyleBackColor = false;
            buttonReports.Click += buttonReports_Click;
            // 
            // buttonSystemRecords
            // 
            buttonSystemRecords.BackColor = Color.White;
            buttonSystemRecords.Image = Properties.Resources.icons8_moleskine_32px;
            buttonSystemRecords.ImageAlign = ContentAlignment.MiddleLeft;
            buttonSystemRecords.Location = new Point(200, 56);
            buttonSystemRecords.Margin = new Padding(5);
            buttonSystemRecords.Name = "buttonSystemRecords";
            buttonSystemRecords.Size = new Size(185, 41);
            buttonSystemRecords.TabIndex = 6;
            buttonSystemRecords.Text = "     Системный реестр";
            toolTip1.SetToolTip(buttonSystemRecords, "Информация о системный реестр");
            buttonSystemRecords.UseVisualStyleBackColor = false;
            buttonSystemRecords.Click += buttonSystemRecords_Click;
            // 
            // buttonSettings
            // 
            buttonSettings.BackColor = Color.White;
            buttonSettings.Image = Properties.Resources.icons8_settings_32px;
            buttonSettings.ImageAlign = ContentAlignment.MiddleLeft;
            buttonSettings.Location = new Point(395, 56);
            buttonSettings.Margin = new Padding(5);
            buttonSettings.Name = "buttonSettings";
            buttonSettings.Size = new Size(185, 41);
            buttonSettings.TabIndex = 7;
            buttonSettings.Text = "      Насторойки";
            toolTip1.SetToolTip(buttonSettings, "Настройка общих настроек программы");
            buttonSettings.UseVisualStyleBackColor = false;
            buttonSettings.Click += buttonSettings_Click;
            // 
            // buttonHelp
            // 
            buttonHelp.BackColor = Color.White;
            buttonHelp.Image = Properties.Resources.icons8_help_32px;
            buttonHelp.ImageAlign = ContentAlignment.MiddleLeft;
            buttonHelp.Location = new Point(590, 56);
            buttonHelp.Margin = new Padding(5);
            buttonHelp.Name = "buttonHelp";
            buttonHelp.Size = new Size(185, 41);
            buttonHelp.TabIndex = 8;
            buttonHelp.Text = "      Помощь";
            toolTip1.SetToolTip(buttonHelp, "Учебные пособия");
            buttonHelp.UseVisualStyleBackColor = false;
            buttonHelp.Click += buttonHelp_Click;
            // 
            // buttonAbout
            // 
            buttonAbout.BackColor = Color.White;
            buttonAbout.Image = Properties.Resources.icons8_about_32px;
            buttonAbout.ImageAlign = ContentAlignment.MiddleLeft;
            buttonAbout.Location = new Point(785, 56);
            buttonAbout.Margin = new Padding(5);
            buttonAbout.Name = "buttonAbout";
            buttonAbout.Size = new Size(185, 41);
            buttonAbout.TabIndex = 9;
            buttonAbout.Text = "   Информация";
            toolTip1.SetToolTip(buttonAbout, "Информация о системе и последних обновлениях");
            buttonAbout.UseVisualStyleBackColor = false;
            buttonAbout.Click += buttonAbout_Click;
            // 
            // panelContainer
            // 
            panelContainer.BackColor = Color.White;
            panelContainer.Dock = DockStyle.Fill;
            panelContainer.Location = new Point(0, 0);
            panelContainer.Name = "panelContainer";
            panelContainer.Size = new Size(1064, 627);
            panelContainer.TabIndex = 1;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1064, 681);
            Controls.Add(panelContainer);
            Controls.Add(flowLayoutPanel1);
            Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "Main";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HyperEmpoloyees";
            WindowState = FormWindowState.Maximized;
            FormClosing += Main_FormClosing;
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private Button buttonHome;
        private Button buttonSalaryCategory;
        private Button buttonEmployees;
        private Button buttonRetiremnt;
        private Button buttonUsers;
        private Button buttonReports;
        private Button buttonSystemRecords;
        private Button buttonSettings;
        private Button buttonHelp;
        private Button buttonAbout;
        public Panel panelContainer;
        private ToolTip toolTip1;
    }
}
