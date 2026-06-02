namespace CoffeeApp
{
    partial class Form2
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.GroupBox grpAuth;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            grpAuth = new GroupBox();
            lblLogin = new Label();
            txtLogin = new TextBox();
            lblPass = new Label();
            txtPassword = new TextBox();
            btnLogin = new Button();
            btnRegister = new Button();
            grpAuth.SuspendLayout();
            SuspendLayout();
            // 
            // grpAuth
            // 
            grpAuth.Controls.Add(lblLogin);
            grpAuth.Controls.Add(txtLogin);
            grpAuth.Controls.Add(lblPass);
            grpAuth.Controls.Add(txtPassword);
            grpAuth.Location = new Point(30, 20);
            grpAuth.Name = "grpAuth";
            grpAuth.Size = new Size(240, 130);
            grpAuth.TabIndex = 0;
            grpAuth.TabStop = false;
            // 
            // lblLogin
            // 
            lblLogin.Location = new Point(20, 35);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(60, 25);
            lblLogin.TabIndex = 0;
            lblLogin.Text = "Логин:";
            lblLogin.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtLogin
            // 
            txtLogin.Location = new Point(90, 35);
            txtLogin.Name = "txtLogin";
            txtLogin.Size = new Size(120, 23);
            txtLogin.TabIndex = 0;
            // 
            // lblPass
            // 
            lblPass.Location = new Point(20, 75);
            lblPass.Name = "lblPass";
            lblPass.Size = new Size(60, 25);
            lblPass.TabIndex = 1;
            lblPass.Text = "Пароль:";
            lblPass.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(90, 75);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(120, 23);
            txtPassword.TabIndex = 1;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(40, 170);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(90, 30);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "Войти";
            btnLogin.Click += btnLogin_Click;
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(160, 170);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(90, 30);
            btnRegister.TabIndex = 3;
            btnRegister.Text = "Регистрация";
            btnRegister.Click += btnRegister_Click;
            // 
            // Form2
            // 
            ClientSize = new Size(300, 230);
            Controls.Add(grpAuth);
            Controls.Add(btnLogin);
            Controls.Add(btnRegister);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimumSize = new Size(300, 230);
            Name = "Form2";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Авторизация";
            grpAuth.ResumeLayout(false);
            grpAuth.PerformLayout();
            ResumeLayout(false);
        }
    }
}