namespace HyperEmpoloyees.Gui.EmpoloyeesGui
{
    partial class EmployeesUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            flowLayoutPanel1 = new FlowLayoutPanel();
            buttonAdd = new Button();
            buttonEdit = new Button();
            buttonDelete = new Button();
            buttonExportAll = new Button();
            buttonExportDataGridView = new Button();
            panel1 = new Panel();
            textBoxSearch = new TextBox();
            buttonSearch = new Button();
            dataGridView1 = new DataGridView();
            labelStateTitle = new Label();
            panelState = new Panel();
            labelStateDescription = new Label();
            buttonRefresh = new Button();
            toolTip1 = new ToolTip(components);
            buttonNext = new Button();
            buttonPrev = new Button();
            panel2 = new Panel();
            labelNoOfItems = new Label();
            comboBoxNoOfPage = new ComboBox();
            flowLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panelState.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.BackColor = SystemColors.Control;
            flowLayoutPanel1.Controls.Add(buttonAdd);
            flowLayoutPanel1.Controls.Add(buttonEdit);
            flowLayoutPanel1.Controls.Add(buttonDelete);
            flowLayoutPanel1.Controls.Add(buttonExportAll);
            flowLayoutPanel1.Controls.Add(buttonExportDataGridView);
            flowLayoutPanel1.Controls.Add(panel1);
            flowLayoutPanel1.Dock = DockStyle.Top;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Margin = new Padding(5);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(5);
            flowLayoutPanel1.Size = new Size(1064, 57);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // buttonAdd
            // 
            buttonAdd.BackColor = Color.White;
            buttonAdd.Image = Properties.Resources.icons8_add_32px;
            buttonAdd.ImageAlign = ContentAlignment.MiddleLeft;
            buttonAdd.Location = new Point(8, 8);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(156, 41);
            buttonAdd.TabIndex = 0;
            buttonAdd.Text = "   Добавлять";
            toolTip1.SetToolTip(buttonAdd, "Добавьте новые данные");
            buttonAdd.UseVisualStyleBackColor = false;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // buttonEdit
            // 
            buttonEdit.BackColor = Color.White;
            buttonEdit.Image = Properties.Resources.icons8_edit_32px;
            buttonEdit.ImageAlign = ContentAlignment.MiddleLeft;
            buttonEdit.Location = new Point(170, 8);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new Size(156, 41);
            buttonEdit.TabIndex = 0;
            buttonEdit.Text = "      Редактировать";
            toolTip1.SetToolTip(buttonEdit, "Измените текущую строку");
            buttonEdit.UseVisualStyleBackColor = false;
            buttonEdit.Click += buttonEdit_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.BackColor = Color.White;
            buttonDelete.Image = Properties.Resources.icons8_Delete_32px;
            buttonDelete.ImageAlign = ContentAlignment.MiddleLeft;
            buttonDelete.Location = new Point(332, 8);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(156, 41);
            buttonDelete.TabIndex = 0;
            buttonDelete.Text = "   Удалить";
            toolTip1.SetToolTip(buttonDelete, "Вы можете удалить сразу несколько строк");
            buttonDelete.UseVisualStyleBackColor = false;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // buttonExportAll
            // 
            buttonExportAll.BackColor = Color.White;
            buttonExportAll.Image = Properties.Resources.icons8_microsoft_excel_2019_32px;
            buttonExportAll.ImageAlign = ContentAlignment.MiddleLeft;
            buttonExportAll.Location = new Point(494, 8);
            buttonExportAll.Name = "buttonExportAll";
            buttonExportAll.Size = new Size(100, 41);
            buttonExportAll.TabIndex = 0;
            buttonExportAll.Text = "   Все";
            toolTip1.SetToolTip(buttonExportAll, "Экспортируйте все данные");
            buttonExportAll.UseVisualStyleBackColor = false;
            buttonExportAll.Click += buttonExportAll_Click;
            // 
            // buttonExportDataGridView
            // 
            buttonExportDataGridView.BackColor = Color.White;
            buttonExportDataGridView.Image = Properties.Resources.icons8_Microsoft_Excel_32px;
            buttonExportDataGridView.ImageAlign = ContentAlignment.MiddleLeft;
            buttonExportDataGridView.Location = new Point(600, 8);
            buttonExportDataGridView.Name = "buttonExportDataGridView";
            buttonExportDataGridView.Size = new Size(100, 41);
            buttonExportDataGridView.TabIndex = 2;
            buttonExportDataGridView.Text = "   Сеть";
            toolTip1.SetToolTip(buttonExportDataGridView, "Экспорт отображения сетевых данных");
            buttonExportDataGridView.UseVisualStyleBackColor = false;
            buttonExportDataGridView.Click += buttonExportDataGridView_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(textBoxSearch);
            panel1.Controls.Add(buttonSearch);
            panel1.Location = new Point(706, 8);
            panel1.Name = "panel1";
            panel1.Size = new Size(323, 41);
            panel1.TabIndex = 1;
            // 
            // textBoxSearch
            // 
            textBoxSearch.Dock = DockStyle.Fill;
            textBoxSearch.Font = new Font("Segoe UI", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            textBoxSearch.Location = new Point(49, 0);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.Size = new Size(274, 39);
            textBoxSearch.TabIndex = 1;
            toolTip1.SetToolTip(textBoxSearch, "Нажмите на значок поиска, чтобы просмотреть все данные");
            textBoxSearch.KeyDown += textBoxSearch_KeyDown;
            // 
            // buttonSearch
            // 
            buttonSearch.BackColor = Color.White;
            buttonSearch.Dock = DockStyle.Left;
            buttonSearch.Image = Properties.Resources.icons8_search_32px;
            buttonSearch.Location = new Point(0, 0);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(49, 41);
            buttonSearch.TabIndex = 0;
            toolTip1.SetToolTip(buttonSearch, "Нажмите на значок поиска, чтобы просмотреть все данные");
            buttonSearch.UseVisualStyleBackColor = false;
            buttonSearch.Click += buttonSearch_Click;
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.BackgroundColor = Color.White;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 57);
            dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle5;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(1064, 570);
            dataGridView1.TabIndex = 2;
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            // 
            // labelStateTitle
            // 
            labelStateTitle.Dock = DockStyle.Top;
            labelStateTitle.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            labelStateTitle.ForeColor = Color.Gray;
            labelStateTitle.Location = new Point(0, 0);
            labelStateTitle.Name = "labelStateTitle";
            labelStateTitle.Size = new Size(464, 30);
            labelStateTitle.TabIndex = 3;
            labelStateTitle.Text = "Нет доступных данных";
            labelStateTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelState
            // 
            panelState.Anchor = AnchorStyles.None;
            panelState.Controls.Add(labelStateDescription);
            panelState.Controls.Add(labelStateTitle);
            panelState.Location = new Point(319, 263);
            panelState.Name = "panelState";
            panelState.Size = new Size(464, 100);
            panelState.TabIndex = 5;
            panelState.Visible = false;
            // 
            // labelStateDescription
            // 
            labelStateDescription.Dock = DockStyle.Top;
            labelStateDescription.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            labelStateDescription.ForeColor = Color.LightGray;
            labelStateDescription.Location = new Point(0, 30);
            labelStateDescription.Name = "labelStateDescription";
            labelStateDescription.Size = new Size(464, 21);
            labelStateDescription.TabIndex = 4;
            labelStateDescription.Text = "Нет доступных данных";
            labelStateDescription.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // buttonRefresh
            // 
            buttonRefresh.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonRefresh.BackColor = Color.White;
            buttonRefresh.Image = Properties.Resources.icons8_sync_32px;
            buttonRefresh.Location = new Point(1014, 578);
            buttonRefresh.Name = "buttonRefresh";
            buttonRefresh.Size = new Size(37, 36);
            buttonRefresh.TabIndex = 6;
            toolTip1.SetToolTip(buttonRefresh, "Перезарядка");
            buttonRefresh.UseVisualStyleBackColor = false;
            buttonRefresh.Click += buttonRefresh_Click;
            // 
            // buttonNext
            // 
            buttonNext.BackColor = Color.White;
            buttonNext.Image = Properties.Resources.icons8_chevron_right_32px;
            buttonNext.Location = new Point(108, 0);
            buttonNext.Name = "buttonNext";
            buttonNext.Size = new Size(37, 32);
            buttonNext.TabIndex = 7;
            toolTip1.SetToolTip(buttonNext, "Нажмите, чтобы перейти вперед");
            buttonNext.UseVisualStyleBackColor = false;
            buttonNext.Click += buttonNext_Click;
            // 
            // buttonPrev
            // 
            buttonPrev.BackColor = Color.White;
            buttonPrev.Image = Properties.Resources.icons8_chevron_left_32px;
            buttonPrev.Location = new Point(0, 0);
            buttonPrev.Name = "buttonPrev";
            buttonPrev.Size = new Size(37, 32);
            buttonPrev.TabIndex = 6;
            toolTip1.SetToolTip(buttonPrev, "Нажмите, чтобы вернуться. ");
            buttonPrev.UseVisualStyleBackColor = false;
            buttonPrev.Click += buttonPrev_Click;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            panel2.BackColor = Color.White;
            panel2.Controls.Add(labelNoOfItems);
            panel2.Controls.Add(comboBoxNoOfPage);
            panel2.Controls.Add(buttonNext);
            panel2.Controls.Add(buttonPrev);
            panel2.Location = new Point(8, 578);
            panel2.Name = "panel2";
            panel2.Size = new Size(200, 32);
            panel2.TabIndex = 3;
            // 
            // labelNoOfItems
            // 
            labelNoOfItems.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            labelNoOfItems.ForeColor = Color.Firebrick;
            labelNoOfItems.Location = new Point(143, 0);
            labelNoOfItems.Name = "labelNoOfItems";
            labelNoOfItems.Size = new Size(57, 31);
            labelNoOfItems.TabIndex = 9;
            labelNoOfItems.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // comboBoxNoOfPage
            // 
            comboBoxNoOfPage.BackColor = Color.White;
            comboBoxNoOfPage.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxNoOfPage.Font = new Font("Segoe UI", 12.75F, FontStyle.Bold, GraphicsUnit.Point);
            comboBoxNoOfPage.FormattingEnabled = true;
            comboBoxNoOfPage.Location = new Point(37, 0);
            comboBoxNoOfPage.Name = "comboBoxNoOfPage";
            comboBoxNoOfPage.Size = new Size(71, 31);
            comboBoxNoOfPage.TabIndex = 8;
            comboBoxNoOfPage.SelectedIndexChanged += comboBoxNoOfPage_SelectedIndexChanged;
            // 
            // EmployeesUserControl
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(panel2);
            Controls.Add(buttonRefresh);
            Controls.Add(panelState);
            Controls.Add(dataGridView1);
            Controls.Add(flowLayoutPanel1);
            Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            Margin = new Padding(4);
            Name = "EmployeesUserControl";
            Size = new Size(1064, 627);
            flowLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panelState.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private Button buttonAdd;
        private Button buttonEdit;
        private Button buttonDelete;
        private Button buttonExportAll;
        private Panel panel1;
        private TextBox textBoxSearch;
        private Button buttonSearch;
        private DataGridView dataGridView1;
        private Label labelStateTitle;
        private Panel panelState;
        private Label labelStateDescription;
        private Button buttonRefresh;
        private ToolTip toolTip1;
        private Button buttonExportDataGridView;
        private Panel panel2;
        private ComboBox comboBoxNoOfPage;
        private Button buttonNext;
        private Button buttonPrev;
        private Label labelNoOfItems;
    }
}
