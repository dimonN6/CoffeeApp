using System;
using System.Windows.Forms;

namespace CoffeeApp
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string pass = txtPassword.Text;
            if (DatabaseHelper.CheckUser(login, pass, out string role))
            {
                if (role == "admin")
                    new Form4().Show();
                else
                    new Form5(login).Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            new Form3().Show();
            this.Hide();
        }
    }
}