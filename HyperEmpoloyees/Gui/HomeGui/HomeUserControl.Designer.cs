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
            SuspendLayout();
            // 
            // labelWelcome
            // 
            labelWelcome.Anchor = AnchorStyles.None;
            labelWelcome.Location = new Point(410, 323);
            labelWelcome.Name = "labelWelcome";
            labelWelcome.Size = new Size(223, 39);
            labelWelcome.TabIndex = 0;
            // 
            // labelCompanyName
            // 
            labelCompanyName.Anchor = AnchorStyles.None;
            labelCompanyName.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point);
            labelCompanyName.Location = new Point(386, 265);
            labelCompanyName.Name = "labelCompanyName";
            labelCompanyName.Size = new Size(292, 58);
            labelCompanyName.TabIndex = 0;
            // 
            // HomeUserControl
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(labelCompanyName);
            Controls.Add(labelWelcome);
            Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            Margin = new Padding(4);
            Name = "HomeUserControl";
            Size = new Size(1064, 627);
            ResumeLayout(false);
        }

        #endregion

        private Label labelWelcome;
        private Label labelCompanyName;
    }
}
