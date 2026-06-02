using System;
using System.Windows.Forms;

namespace CoffeeApp
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string pass = txtPassword.Text;
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (DatabaseHelper.RegisterUser(login, pass, "user"))
            {
                MessageBox.Show("Регистрация успешна", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                new Form2().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Логин уже существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}