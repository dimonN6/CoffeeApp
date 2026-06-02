namespace CoffeeApp
{
    partial class Form3
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.GroupBox grpReg;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            grpReg = new GroupBox();
            lblLogin = new Label();
            txtLogin = new TextBox();
            lblPass = new Label();
            txtPassword = new TextBox();
            btnRegister = new Button();
            grpReg.SuspendLayout();
            SuspendLayout();
            // 
            // grpReg
            // 
            grpReg.Controls.Add(lblLogin);
            grpReg.Controls.Add(txtLogin);
            grpReg.Controls.Add(lblPass);
            grpReg.Controls.Add(txtPassword);
            grpReg.Location = new Point(30, 20);
            grpReg.Name = "grpReg";
            grpReg.Size = new Size(240, 130);
            grpReg.TabIndex = 0;
            grpReg.TabStop = false;
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
            // btnRegister
            // 
            btnRegister.Location = new Point(80, 170);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(140, 35);
            btnRegister.TabIndex = 2;
            btnRegister.Text = "Зарегистрироваться";
            btnRegister.Click += btnReg_Click;
            // 
            // Form3
            // 
            ClientSize = new Size(300, 230);
            Controls.Add(grpReg);
            Controls.Add(btnRegister);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimumSize = new Size(300, 230);
            Name = "Form3";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Регистрация";
            grpReg.ResumeLayout(false);
            grpReg.PerformLayout();
            ResumeLayout(false);
        }
    }
}