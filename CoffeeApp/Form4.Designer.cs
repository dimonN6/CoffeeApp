namespace CoffeeApp
{
    partial class Form4
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Button btnMaterials;
        private System.Windows.Forms.Button btnOrders;
        private System.Windows.Forms.Button btnShowDetails;
        private System.Windows.Forms.Button btnLogout;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dataGrid = new DataGridView();
            txtSearch = new TextBox();
            btnSearch = new Button();
            topPanel = new Panel();
            lblSearch = new Label();
            btnMaterials = new Button();
            btnOrders = new Button();
            btnShowDetails = new Button();
            btnLogout = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGrid).BeginInit();
            topPanel.SuspendLayout();
            SuspendLayout();

            // dataGrid
            dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGrid.Dock = DockStyle.Fill;
            dataGrid.ReadOnly = true;
            dataGrid.Location = new Point(0, 50);
            dataGrid.Name = "dataGrid";
            dataGrid.Size = new Size(836, 450);
            dataGrid.TabIndex = 0;

            // topPanel
            topPanel.BackColor = Color.LightSteelBlue;
            topPanel.Controls.Add(btnShowDetails);
            topPanel.Controls.Add(btnOrders);
            topPanel.Controls.Add(btnMaterials);
            topPanel.Controls.Add(btnLogout);
            topPanel.Controls.Add(lblSearch);
            topPanel.Controls.Add(txtSearch);
            topPanel.Controls.Add(btnSearch);
            topPanel.Dock = DockStyle.Top;
            topPanel.Location = new Point(0, 0);
            topPanel.Name = "topPanel";
            topPanel.Size = new Size(836, 50);
            topPanel.TabIndex = 6;

            // lblSearch
            lblSearch.Location = new Point(12, 15);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(50, 25);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "Поиск:";
            lblSearch.TextAlign = ContentAlignment.MiddleRight;

            // txtSearch
            txtSearch.Location = new Point(70, 15);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(200, 23);
            txtSearch.TabIndex = 1;

            // btnSearch
            btnSearch.Location = new Point(280, 13);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 27);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Найти";

            // btnMaterials
            btnMaterials.Dock = DockStyle.Right;
            btnMaterials.Location = new Point(726, 0);
            btnMaterials.Name = "btnMaterials";
            btnMaterials.Size = new Size(110, 50);
            btnMaterials.TabIndex = 5;
            btnMaterials.Text = "Материалы";

            // btnOrders
            btnOrders.Dock = DockStyle.Right;
            btnOrders.Location = new Point(616, 0);
            btnOrders.Name = "btnOrders";
            btnOrders.Size = new Size(110, 50);
            btnOrders.TabIndex = 4;
            btnOrders.Text = "Заказы";

            // btnShowDetails
            btnShowDetails.Dock = DockStyle.Right;
            btnShowDetails.Location = new Point(506, 0);
            btnShowDetails.Name = "btnShowDetails";
            btnShowDetails.Size = new Size(110, 50);
            btnShowDetails.TabIndex = 3;
            btnShowDetails.Text = "Детали заказа";

            // btnLogout
            btnLogout.Dock = DockStyle.Right;
            btnLogout.Location = new Point(396, 0);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(110, 50);
            btnLogout.TabIndex = 2;
            btnLogout.Text = "Выйти";

            // Form4
            ClientSize = new Size(836, 500);
            Controls.Add(dataGrid);
            Controls.Add(topPanel);
            MinimumSize = new Size(700, 400);
            Name = "Form4";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Администратор";

            ((System.ComponentModel.ISupportInitialize)dataGrid).EndInit();
            topPanel.ResumeLayout(false);
            topPanel.PerformLayout();
            ResumeLayout(false);
        }
    }
}