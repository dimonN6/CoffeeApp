using System;
using System.Data;
using System.Windows.Forms;

namespace CoffeeApp
{
    public partial class Form4 : Form
    {
        private string currentTable = "Products";

        public Form4()
        {
            InitializeComponent();
            btnMaterials.Click += btnMaterials_Click;
            btnOrders.Click += btnOrders_Click;
            btnShowDetails.Click += btnShowDetails_Click;
            btnSearch.Click += btnSearch_Click;
            btnLogout.Click += btnLogout_Click;
            LoadProducts();
        }

        private void LoadProducts()
        {
            currentTable = "Products";
            dataGrid.DataSource = DatabaseHelper.SearchProducts(txtSearch.Text.Trim());
        }

        private void LoadMaterials()
        {
            currentTable = "Materials";
            dataGrid.DataSource = DatabaseHelper.SearchMaterials(txtSearch.Text.Trim());
        }

        private void LoadOrders()
        {
            currentTable = "Orders";
            dataGrid.DataSource = DatabaseHelper.SearchOrders(txtSearch.Text.Trim());
        }

        private void btnMaterials_Click(object sender, EventArgs e) => LoadMaterials();
        private void btnOrders_Click(object sender, EventArgs e) => LoadOrders();
        private void btnLogout_Click(object sender, EventArgs e)
        {
            new Form2().Show();
            this.Hide();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (currentTable == "Products") LoadProducts();
            else if (currentTable == "Materials") LoadMaterials();
            else if (currentTable == "Orders") LoadOrders();
        }
        private void btnShowDetails_Click(object sender, EventArgs e)
        {
            if (currentTable != "Orders" || dataGrid.CurrentRow == null)
            {
                MessageBox.Show("Выберите заказ в таблице заказов.", "Подсказка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int orderId = Convert.ToInt32(dataGrid.CurrentRow.Cells["№ заказа"].Value);
            DataTable details = DatabaseHelper.GetOrderDetails(orderId);
            if (details.Rows.Count == 0)
            {
                MessageBox.Show("Нет деталей для этого заказа.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Form frmDetails = new Form();
            DataGridView dgv = new DataGridView
            {
                Dock = DockStyle.Fill,
                DataSource = details,
                ReadOnly = true,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            frmDetails.Controls.Add(dgv);
            frmDetails.Size = new System.Drawing.Size(600, 400);
            frmDetails.Text = $"Детали заказа №{orderId}";
            frmDetails.StartPosition = FormStartPosition.CenterParent;
            frmDetails.ShowDialog();
        }
    }
}