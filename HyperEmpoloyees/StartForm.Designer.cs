namespace HyperEmpoloyees
{
    partial class StartForm
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
            components = new System.ComponentModel.Container();
            progressBar1 = new ProgressBar();
            labelState = new Label();
            pictureBox1 = new PictureBox();
            panelSettings = new Panel();
            linkLabelExit = new LinkLabel();
            linkLabelSetServer = new LinkLabel();
            timerStart = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panelSettings.SuspendLayout();
            SuspendLayout();
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(13, 301);
            progressBar1.Margin = new Padding(4);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(488, 32);
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.TabIndex = 0;
            // 
            // labelState
            // 
            labelState.AutoSize = true;
            labelState.Location = new Point(15, 278);
            labelState.Name = "labelState";
            labelState.Size = new Size(225, 21);
            labelState.TabIndex = 1;
            labelState.Text = "Подключение к базе данных...";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.images;
            pictureBox1.Location = new Point(120, 45);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(279, 212);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // panelSettings
            // 
            panelSettings.Controls.Add(linkLabelExit);
            panelSettings.Controls.Add(linkLabelSetServer);
            panelSettings.Location = new Point(13, 340);
            panelSettings.Name = "panelSettings";
            panelSettings.Size = new Size(488, 23);
            panelSettings.TabIndex = 3;
            // 
            // linkLabelExit
            // 
            linkLabelExit.AutoSize = true;
            linkLabelExit.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            linkLabelExit.Location = new Point(252, 3);
            linkLabelExit.Name = "linkLabelExit";
            linkLabelExit.Size = new Size(134, 17);
            linkLabelExit.TabIndex = 0;
            linkLabelExit.TabStop = true;
            linkLabelExit.Text = "Закройте программу";
            linkLabelExit.LinkClicked += linkLabelExit_LinkClicked;
            // 
            // linkLabelSetServer
            // 
            linkLabelSetServer.AutoSize = true;
            linkLabelSetServer.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            linkLabelSetServer.Location = new Point(4, 3);
            linkLabelSetServer.Name = "linkLabelSetServer";
            linkLabelSetServer.Size = new Size(216, 17);
            linkLabelSetServer.TabIndex = 0;
            linkLabelSetServer.TabStop = true;
            linkLabelSetServer.Text = "Измените настройки подключения";
            linkLabelSetServer.LinkClicked += linkLabelSetServer_LinkClicked;
            // 
            // timerStart
            // 
            timerStart.Enabled = true;
            timerStart.Interval = 5000;
            timerStart.Tick += timerStart_Tick;
            // 
            // StartForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(513, 370);
            Controls.Add(panelSettings);
            Controls.Add(pictureBox1);
            Controls.Add(labelState);
            Controls.Add(progressBar1);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(5, 4, 5, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "StartForm";
            Padding = new Padding(13, 14, 13, 14);
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "StartForm";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panelSettings.ResumeLayout(false);
            panelSettings.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ProgressBar progressBar1;
        private Label labelState;
        private PictureBox pictureBox1;
        private Panel panelSettings;
        private LinkLabel linkLabelSetServer;
        private LinkLabel linkLabelExit;
        private System.Windows.Forms.Timer timerStart;
    }
}
