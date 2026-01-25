namespace HyperEmpoloyees.Gui.HomeGui
{
    partial class HomeUserControl
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
            labelWelcome = new Label();
            labelCompanyName = new Label();
            pieChart1 = new LiveCharts.WinForms.PieChart();
            cartesianChart1 = new LiveCharts.WinForms.CartesianChart();
            SuspendLayout();
            // 
            // labelWelcome
            // 
            labelWelcome.Anchor = AnchorStyles.None;
            labelWelcome.Location = new Point(350, 80);
            labelWelcome.Name = "labelWelcome";
            labelWelcome.Size = new Size(223, 39);
            labelWelcome.TabIndex = 0;
            // 
            // labelCompanyName
            // 
            labelCompanyName.Anchor = AnchorStyles.None;
            labelCompanyName.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point);
            labelCompanyName.Location = new Point(350, 20);
            labelCompanyName.Name = "labelCompanyName";
            labelCompanyName.Size = new Size(292, 58);
            labelCompanyName.TabIndex = 0;
            // 
            // pieChart1
            // 
            pieChart1.Location = new Point(30, 150);
            pieChart1.Name = "pieChart1";
            pieChart1.Size = new Size(400, 300);
            pieChart1.TabIndex = 2;
            pieChart1.Text = "Статус сотрудников";
            // 
            // cartesianChart1
            // 
            cartesianChart1.Location = new Point(450, 150);
            cartesianChart1.Name = "cartesianChart1";
            cartesianChart1.Size = new Size(580, 300);
            cartesianChart1.TabIndex = 3;
            cartesianChart1.Text = "Зарплата по должностям";
            // 
            // HomeUserControl
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(cartesianChart1);
            Controls.Add(pieChart1);
            Controls.Add(labelCompanyName);
            Controls.Add(labelWelcome);
            Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            Margin = new Padding(4);
            Name = "HomeUserControl";
            Size = new Size(1064, 627);
            Load += HomeUserControl_Load;
            ResumeLayout(false);
        }

        #endregion

        private Label labelWelcome;
        private Label labelCompanyName;
        private LiveCharts.WinForms.PieChart pieChart1;
        private LiveCharts.WinForms.CartesianChart cartesianChart1;
    }
}
