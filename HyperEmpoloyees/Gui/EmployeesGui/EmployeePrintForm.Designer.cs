namespace HyperEmpoloyees.Gui.EmployeesGui
{
    partial class EmployeePrintForm
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
            printDocumentPrintPage = new System.Drawing.Printing.PrintDocument();
            buttonPreview = new Button();
            groupBox1 = new GroupBox();
            comboBoxColor = new ComboBox();
            dateTimePickerBookThaDate = new DateTimePicker();
            label4 = new Label();
            label3 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // printDocumentPrintPage
            // 
            printDocumentPrintPage.PrintPage += printDocumentPrintPage_PrintPage;
            // 
            // buttonPreview
            // 
            buttonPreview.BackColor = Color.White;
            buttonPreview.ImageAlign = ContentAlignment.MiddleLeft;
            buttonPreview.Location = new Point(28, 106);
            buttonPreview.Name = "buttonPreview";
            buttonPreview.Size = new Size(183, 41);
            buttonPreview.TabIndex = 4;
            buttonPreview.Text = "Печать";
            buttonPreview.UseVisualStyleBackColor = false;
            buttonPreview.Click += buttonPreview_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(comboBoxColor);
            groupBox1.Controls.Add(dateTimePickerBookThaDate);
            groupBox1.Controls.Add(buttonPreview);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.ForeColor = Color.Black;
            groupBox1.Location = new Point(5, 11);
            groupBox1.Margin = new Padding(2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(2);
            groupBox1.Size = new Size(233, 167);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Форма печати";
            // 
            // comboBoxColor
            // 
            comboBoxColor.FormattingEnabled = true;
            comboBoxColor.Items.AddRange(new object[] { "Черно-белая", "Цветная" });
            comboBoxColor.Location = new Point(8, 59);
            comboBoxColor.Name = "comboBoxColor";
            comboBoxColor.Size = new Size(224, 23);
            comboBoxColor.TabIndex = 5;
            // 
            // dateTimePickerBookThaDate
            // 
            dateTimePickerBookThaDate.Anchor = AnchorStyles.Left;
            dateTimePickerBookThaDate.Format = DateTimePickerFormat.Short;
            dateTimePickerBookThaDate.Location = new Point(6, 232);
            dateTimePickerBookThaDate.Name = "dateTimePickerBookThaDate";
            dateTimePickerBookThaDate.Size = new Size(226, 23);
            dateTimePickerBookThaDate.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.Red;
            label4.Location = new Point(82, 40);
            label4.Name = "label4";
            label4.Size = new Size(12, 15);
            label4.TabIndex = 0;
            label4.Text = "*";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.Black;
            label3.Location = new Point(7, 41);
            label3.Name = "label3";
            label3.Size = new Size(80, 15);
            label3.TabIndex = 0;
            label3.Text = "Цвет печати :";
            // 
            // EmployeePrintForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.Disable;
            ClientSize = new Size(249, 189);
            Controls.Add(groupBox1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EmployeePrintForm";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private System.Drawing.Printing.PrintDocument printDocumentPrintPage;
        private Button buttonPreview;
        private GroupBox groupBox1;
        private DateTimePicker dateTimePickerBookThaDate;
        private Label label4;
        private Label label3;
        private ComboBox comboBoxColor;
    }
}