namespace HyperEmpoloyees.Gui.UsersGui
{
    partial class LoginForm
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
            textBoxPassword = new TextBox();
            label6 = new Label();
            textBoxUserName = new TextBox();
            label4 = new Label();
            label5 = new Label();
            label3 = new Label();
            panel1 = new Panel();
            pictureBoxLoading = new PictureBox();
            pictureBox2 = new PictureBox();
            buttonLogin = new Button();
            panel2 = new Panel();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            label7 = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLoading).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(12, 264);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.PasswordChar = '*';
            textBoxPassword.Size = new Size(227, 27);
            textBoxPassword.TabIndex = 1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = Color.Red;
            label6.Location = new Point(78, 242);
            label6.Name = "label6";
            label6.Size = new Size(16, 20);
            label6.TabIndex = 0;
            label6.Text = "*";
            // 
            // textBoxUserName
            // 
            textBoxUserName.Location = new Point(12, 202);
            textBoxUserName.Name = "textBoxUserName";
            textBoxUserName.Size = new Size(227, 27);
            textBoxUserName.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.Red;
            label4.Location = new Point(156, 180);
            label4.Name = "label4";
            label4.Size = new Size(16, 20);
            label4.TabIndex = 0;
            label4.Text = "*";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.Black;
            label5.Location = new Point(13, 243);
            label5.Name = "label5";
            label5.Size = new Size(70, 20);
            label5.TabIndex = 0;
            label5.Text = "Пароль :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.Black;
            label3.Location = new Point(13, 181);
            label3.Name = "label3";
            label3.Size = new Size(148, 20);
            label3.TabIndex = 0;
            label3.Text = "Имя пользователя :";
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(pictureBoxLoading);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(buttonLogin);
            panel1.Controls.Add(textBoxPassword);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(textBoxUserName);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label5);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(247, 346);
            panel1.TabIndex = 1;
            // 
            // pictureBoxLoading
            // 
            pictureBoxLoading.Image = Properties.Resources.Loading;
            pictureBoxLoading.Location = new Point(164, 297);
            pictureBoxLoading.Name = "pictureBoxLoading";
            pictureBoxLoading.Size = new Size(43, 40);
            pictureBoxLoading.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxLoading.TabIndex = 2;
            pictureBoxLoading.TabStop = false;
            pictureBoxLoading.Visible = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.logingif;
            pictureBox2.Location = new Point(31, 19);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(176, 127);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // buttonLogin
            // 
            buttonLogin.BackColor = Color.White;
            buttonLogin.Image = Properties.Resources.icons8_import_32px;
            buttonLogin.ImageAlign = ContentAlignment.MiddleLeft;
            buttonLogin.Location = new Point(12, 297);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new Size(137, 40);
            buttonLogin.TabIndex = 2;
            buttonLogin.Text = "   Войти";
            buttonLogin.UseVisualStyleBackColor = false;
            buttonLogin.Click += buttonLogin_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(255, 192, 128);
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(247, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(302, 346);
            panel2.TabIndex = 2;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.icons8_user_200px;
            pictureBox1.Location = new Point(43, 123);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(218, 156);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Black", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.FromArgb(192, 64, 0);
            label2.Location = new Point(-1, 19);
            label2.Name = "label2";
            label2.Size = new Size(300, 30);
            label2.TabIndex = 0;
            label2.Text = "Добро пожаловать снова !";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = Color.FromArgb(192, 64, 0);
            label7.Location = new Point(24, 73);
            label7.Name = "label7";
            label7.Size = new Size(226, 25);
            label7.TabIndex = 0;
            label7.Text = "завершить свою работу";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(192, 64, 0);
            label1.Location = new Point(20, 52);
            label1.Name = "label1";
            label1.Size = new Size(241, 25);
            label1.TabIndex = 0;
            label1.Text = "Войдите в систему, чтобы";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(549, 346);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoginForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Регистрироваться";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLoading).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private TextBox textBoxPassword;
        private Label label6;
        private TextBox textBoxUserName;
        private Label label4;
        private Label label5;
        private Label label3;
        private Panel panel1;
        private Panel panel2;
        private Label label1;
        private Button buttonLogin;
        private Label label2;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Label label7;
        private PictureBox pictureBoxLoading;
    }
}