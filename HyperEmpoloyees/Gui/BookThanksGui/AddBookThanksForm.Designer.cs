namespace HyperEmpoloyees.Gui.BookThanksGui
{
    partial class AddBookThanksForm
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
            dateTimePickerBookThaDate = new DateTimePicker();
            richTextBoxNote = new RichTextBox();
            numericUpDownEffect = new NumericUpDown();
            label6 = new Label();
            textBoxRef = new TextBox();
            label7 = new Label();
            label4 = new Label();
            label5 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            buttonSave = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownEffect).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dateTimePickerBookThaDate);
            groupBox1.Controls.Add(richTextBoxNote);
            groupBox1.Controls.Add(numericUpDownEffect);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(textBoxRef);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.ForeColor = Color.FromArgb(0, 0, 192);
            groupBox1.Location = new Point(8, 8);
            groupBox1.Margin = new Padding(2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(2);
            groupBox1.Size = new Size(239, 360);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Информационная книга благодарностей";
            // 
            // dateTimePickerBookThaDate
            // 
            dateTimePickerBookThaDate.Anchor = AnchorStyles.Left;
            dateTimePickerBookThaDate.Format = DateTimePickerFormat.Short;
            dateTimePickerBookThaDate.Location = new Point(7, 199);
            dateTimePickerBookThaDate.Name = "dateTimePickerBookThaDate";
            dateTimePickerBookThaDate.Size = new Size(226, 27);
            dateTimePickerBookThaDate.TabIndex = 4;
            // 
            // richTextBoxNote
            // 
            richTextBoxNote.Location = new Point(6, 257);
            richTextBoxNote.Name = "richTextBoxNote";
            richTextBoxNote.Size = new Size(228, 84);
            richTextBoxNote.TabIndex = 3;
            richTextBoxNote.Text = "";
            // 
            // numericUpDownEffect
            // 
            numericUpDownEffect.Location = new Point(7, 74);
            numericUpDownEffect.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownEffect.Name = "numericUpDownEffect";
            numericUpDownEffect.Size = new Size(226, 27);
            numericUpDownEffect.TabIndex = 0;
            numericUpDownEffect.Value = new decimal(new int[] { 30, 0, 0, 0 });
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = Color.Red;
            label6.Location = new Point(54, 175);
            label6.Name = "label6";
            label6.Size = new Size(16, 20);
            label6.TabIndex = 0;
            label6.Text = "*";
            // 
            // textBoxRef
            // 
            textBoxRef.Location = new Point(6, 135);
            textBoxRef.Name = "textBoxRef";
            textBoxRef.Size = new Size(227, 27);
            textBoxRef.TabIndex = 1;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ForeColor = Color.Black;
            label7.Location = new Point(7, 234);
            label7.Name = "label7";
            label7.Size = new Size(66, 20);
            label7.TabIndex = 0;
            label7.Text = "Деталь :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.Red;
            label4.Location = new Point(64, 113);
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
            label5.Size = new Size(50, 20);
            label5.TabIndex = 0;
            label5.Text = "Дата :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.Black;
            label3.Location = new Point(7, 114);
            label3.Name = "label3";
            label3.Size = new Size(60, 20);
            label3.TabIndex = 0;
            label3.Text = "Число :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.Red;
            label2.Location = new Point(81, 51);
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
            label1.Size = new Size(77, 20);
            label1.TabIndex = 0;
            label1.Text = "Влияние :";
            // 
            // buttonSave
            // 
            buttonSave.BackColor = Color.White;
            buttonSave.Image = Properties.Resources.icons8_save_32px;
            buttonSave.ImageAlign = ContentAlignment.MiddleLeft;
            buttonSave.Location = new Point(8, 373);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(227, 41);
            buttonSave.TabIndex = 4;
            buttonSave.Text = "   Сохранять";
            buttonSave.UseVisualStyleBackColor = false;
            buttonSave.Click += buttonSave_Click;
            // 
            // AddBookThanksForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(250, 426);
            Controls.Add(groupBox1);
            Controls.Add(buttonSave);
            Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddBookThanksForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Добавить книгу благодарностей";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownEffect).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label2;
        private Label label1;
        private Label label6;
        private TextBox textBoxRef;
        private Label label4;
        private Label label5;
        private Label label3;
        private Button buttonSave;
        private Label label7;
        private NumericUpDown numericUpDownEffect;
        private RichTextBox richTextBoxNote;
        private DateTimePicker dateTimePickerBookThaDate;
    }
}