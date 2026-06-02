namespace CoffeeApp
{
    partial class Form5
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.Button btnProducts;
        private System.Windows.Forms.Button btnOrders;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnDetails;   // добавлена здесь
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label lblSearch;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dataGrid = new DataGridView();
            btnProducts = new Button();
            btnOrders = new Button();
            btnLogout = new Button();
            btnDetails = new Button();
            txtSearch = new TextBox();
            btnSearch = new Button();
            topPanel = new Panel();
            lblSearch = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGrid).BeginInit();
            topPanel.SuspendLayout();
            SuspendLayout();
            // 
            // dataGrid
            // 
            dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGrid.Dock = DockStyle.Fill;
            dataGrid.Location = new Point(0, 50);
            dataGrid.Name = "dataGrid";
            dataGrid.ReadOnly = true;
            dataGrid.Size = new Size(825, 450);
            dataGrid.TabIndex = 0;
            // 
            // btnProducts
            // 
            btnProducts.Dock = DockStyle.Right;
            btnProducts.Location = new Point(585, 0);
            btnProducts.Name = "btnProducts";
            btnProducts.Size = new Size(120, 50);
            btnProducts.TabIndex = 3;
            btnProducts.Text = "Товары";
            btnProducts.UseVisualStyleBackColor = false;
            // 
            // btnOrders
            // 
            btnOrders.Dock = DockStyle.Right;
            btnOrders.Location = new Point(705, 0);
            btnOrders.Name = "btnOrders";
            btnOrders.Size = new Size(120, 50);
            btnOrders.TabIndex = 2;
            btnOrders.Text = "Мои заказы";
            btnOrders.UseVisualStyleBackColor = false;
            // 
            // btnLogout
            // 
            btnLogout.Dock = DockStyle.Right;
            btnLogout.Location = new Point(485, 0);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(100, 50);
            btnLogout.TabIndex = 4;
            btnLogout.Text = "Выйти";
            btnLogout.UseVisualStyleBackColor = false;
            // 
            // btnDetails
            // 
            btnDetails.Dock = DockStyle.Right;
            btnDetails.Location = new Point(365, 0);
            btnDetails.Name = "btnDetails";
            btnDetails.Size = new Size(120, 50);
            btnDetails.TabIndex = 5;
            btnDetails.Text = "Детали заказа";
            btnDetails.UseVisualStyleBackColor = false;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(70, 15);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(200, 23);
            txtSearch.TabIndex = 1;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(280, 13);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 27);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Найти";
            // 
            // topPanel
            // 
            topPanel.BackColor = Color.LightSteelBlue;
            topPanel.Controls.Add(btnDetails);
            topPanel.Controls.Add(btnLogout);
            topPanel.Controls.Add(lblSearch);
            topPanel.Controls.Add(txtSearch);
            topPanel.Controls.Add(btnProducts);
            topPanel.Controls.Add(btnSearch);
            topPanel.Controls.Add(btnOrders);
            topPanel.Dock = DockStyle.Top;
            topPanel.Location = new Point(0, 0);
            topPanel.Name = "topPanel";
            topPanel.Size = new Size(825, 50);
            topPanel.TabIndex = 4;
            // 
            // lblSearch
            // 
            lblSearch.Location = new Point(12, 15);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(50, 25);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "Поиск:";
            lblSearch.TextAlign = ContentAlignment.MiddleRight;
            // 
            // Form5
            // 
            ClientSize = new Size(825, 500);
            Controls.Add(dataGrid);
            Controls.Add(topPanel);
            MinimumSize = new Size(700, 400);
            Name = "Form5";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Пользователь";
            ((System.ComponentModel.ISupportInitialize)dataGrid).EndInit();
            topPanel.ResumeLayout(false);
            topPanel.PerformLayout();
            ResumeLayout(false);
        }
    }
}