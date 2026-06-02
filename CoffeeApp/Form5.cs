using System;
using System.Data;
using System.Windows.Forms;

namespace CoffeeApp
{
    public partial class Form5 : Form
    {
        private string currentUser;
        private string currentMode = "products";
        private Label lblTotalOrders;

        public Form5(string user)
        {
            currentUser = user;
            InitializeComponent();

            // Панель внизу для общей суммы заказов
            Panel bottomPanel = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 40,
                BackColor = System.Drawing.Color.LightGray
            };
            lblTotalOrders = new Label
            {
                Dock = DockStyle.Fill,
                TextAlign = System.Drawing.ContentAlignment.MiddleRight,
                Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold),
                Padding = new Padding(0, 0, 10, 0)
            };
            bottomPanel.Controls.Add(lblTotalOrders);
            this.Controls.Add(bottomPanel);
            bottomPanel.BringToFront();

            // Подписка на события (кнопки уже есть в дизайнере)
            btnProducts.Click += btnProducts_Click;
            btnOrders.Click += btnOrders_Click;
            btnLogout.Click += btnLogout_Click;
            btnSearch.Click += btnSearch_Click;
            btnDetails.Click += btnDetails_Click;

            LoadProducts();
        }

        private void LoadProducts()
        {
            currentMode = "products";
            dataGrid.DataSource = DatabaseHelper.SearchProducts(txtSearch.Text.Trim());
            lblTotalOrders.Text = "";
        }

        private void LoadOrders()
        {
            currentMode = "orders";
            DataTable dt = DatabaseHelper.GetUserOrders(currentUser);
            dataGrid.DataSource = dt;

            double totalSum = 0;
            foreach (DataRow row in dt.Rows)
                totalSum += Convert.ToDouble(row["Сумма, руб."]);
            lblTotalOrders.Text = $"Общая сумма заказов: {totalSum:F2} руб.";
        }

        private void btnProducts_Click(object sender, EventArgs e) => LoadProducts();
        private void btnOrders_Click(object sender, EventArgs e) => LoadOrders();
        private void btnLogout_Click(object sender, EventArgs e)
        {
            new Form2().Show();
            this.Hide();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (currentMode == "products") LoadProducts();
            else LoadOrders();
        }
        private void btnDetails_Click(object sender, EventArgs e)
        {
            if (currentMode != "orders" || dataGrid.CurrentRow == null)
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