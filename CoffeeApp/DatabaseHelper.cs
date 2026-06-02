using System;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace CoffeeApp
{
    public static class DatabaseHelper
    {
        private const string DbFile = "coffee.db";
        private static string ConnStr => $"Data Source={DbFile};Version=3;";

        public static void Init()
        {
            if (!File.Exists(DbFile))
                SQLiteConnection.CreateFile(DbFile);

            using var conn = new SQLiteConnection(ConnStr);
            conn.Open();

            string createTables = @"
                CREATE TABLE IF NOT EXISTS Users (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Login TEXT UNIQUE,
                    Password TEXT,
                    Role TEXT
                );
                CREATE TABLE IF NOT EXISTS Products (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT UNIQUE,
                    Unit TEXT,
                    Price REAL
                );
                CREATE TABLE IF NOT EXISTS Materials (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT UNIQUE,
                    Unit TEXT,
                    Price REAL
                );
                CREATE TABLE IF NOT EXISTS Orders (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Number TEXT,
                    Customer TEXT,
                    Date TEXT,
                    Total REAL
                );
                CREATE TABLE IF NOT EXISTS OrderDetails (
                    OrderId INTEGER,
                    ProductName TEXT,
                    Quantity REAL,
                    Unit TEXT,
                    Price REAL
                );
            ";
            using var cmd = new SQLiteCommand(createTables, conn);
            cmd.ExecuteNonQuery();

            InsertUser("ОООАссоль", "pass123", "user");
            InsertUser("ОООПоставка", "pass123", "user");
            InsertUser("ОООКинотеатрКвант", "pass123", "user");
            InsertUser("ОООНовыйJDTO", "pass123", "user");
            InsertUser("ОООРомашка", "pass123", "user");
            InsertUser("ОООИпподром", "pass123", "user");
            InsertUser("admin", "admin", "admin");

            InsertProduct("Раф \"Имбирный пряник\" 400г.", "шт", 450);
            InsertProduct("Раф \"Черный лес\" 300г.", "шт", 440);
            InsertProduct("Эспрессо 450г.", "шт", 320);
            InsertProduct("Латте \"Ваниль\" 250г.", "шт", 210);

            InsertMaterial("Американо", "шт", 220);
            InsertMaterial("Взбитые сливки", "кг", 210);
            InsertMaterial("Сироп \"Имбирный пряник\"", "кг", 450);

            // Проверяем, есть ли заказы, чтобы не дублировать
            bool hasOrders = false;
            using (var checkCmd = new SQLiteCommand("SELECT COUNT(*) FROM Orders", conn))
                hasOrders = Convert.ToInt32(checkCmd.ExecuteScalar()) > 0;

            if (!hasOrders)
            {
                long orderId = InsertOrder("1", "ОООАссоль", "9 июня 2025", 8670);
                InsertOrderDetail(orderId, "Раф \"Имбирный пряник\" 400г.", 5, "шт", 450);
                InsertOrderDetail(orderId, "Раф \"Черный лес\" 300г.", 4, "шт", 440);
                InsertOrderDetail(orderId, "Эспрессо 450г.", 8, "шт", 320);
                InsertOrderDetail(orderId, "Латте \"Ваниль\" 250г.", 10, "шт", 210);
            }
        }

        private static void InsertUser(string login, string password, string role)
        {
            using var conn = new SQLiteConnection(ConnStr);
            conn.Open();
            using var cmd = new SQLiteCommand("INSERT OR IGNORE INTO Users (Login, Password, Role) VALUES (@l, @p, @r)", conn);
            cmd.Parameters.AddWithValue("@l", login);
            cmd.Parameters.AddWithValue("@p", password);
            cmd.Parameters.AddWithValue("@r", role);
            cmd.ExecuteNonQuery();
        }

        private static void InsertProduct(string name, string unit, double price)
        {
            using var conn = new SQLiteConnection(ConnStr);
            conn.Open();
            using var cmd = new SQLiteCommand("INSERT OR IGNORE INTO Products (Name, Unit, Price) VALUES (@n, @u, @p)", conn);
            cmd.Parameters.AddWithValue("@n", name);
            cmd.Parameters.AddWithValue("@u", unit);
            cmd.Parameters.AddWithValue("@p", price);
            cmd.ExecuteNonQuery();
        }

        private static void InsertMaterial(string name, string unit, double price)
        {
            using var conn = new SQLiteConnection(ConnStr);
            conn.Open();
            using var cmd = new SQLiteCommand("INSERT OR IGNORE INTO Materials (Name, Unit, Price) VALUES (@n, @u, @p)", conn);
            cmd.Parameters.AddWithValue("@n", name);
            cmd.Parameters.AddWithValue("@u", unit);
            cmd.Parameters.AddWithValue("@p", price);
            cmd.ExecuteNonQuery();
        }

        private static long InsertOrder(string number, string customer, string date, double total)
        {
            using var conn = new SQLiteConnection(ConnStr);
            conn.Open();
            using var cmd = new SQLiteCommand("INSERT INTO Orders (Number, Customer, Date, Total) VALUES (@num, @cust, @dat, @tot); SELECT last_insert_rowid();", conn);
            cmd.Parameters.AddWithValue("@num", number);
            cmd.Parameters.AddWithValue("@cust", customer);
            cmd.Parameters.AddWithValue("@dat", date);
            cmd.Parameters.AddWithValue("@tot", total);
            return (long)cmd.ExecuteScalar();
        }

        private static void InsertOrderDetail(long orderId, string product, double qty, string unit, double price)
        {
            using var conn = new SQLiteConnection(ConnStr);
            conn.Open();
            using var cmd = new SQLiteCommand("INSERT INTO OrderDetails (OrderId, ProductName, Quantity, Unit, Price) VALUES (@oid, @p, @q, @u, @pr)", conn);
            cmd.Parameters.AddWithValue("@oid", orderId);
            cmd.Parameters.AddWithValue("@p", product);
            cmd.Parameters.AddWithValue("@q", qty);
            cmd.Parameters.AddWithValue("@u", unit);
            cmd.Parameters.AddWithValue("@pr", price);
            cmd.ExecuteNonQuery();
        }

        public static SQLiteConnection GetConnection() => new SQLiteConnection(ConnStr);

        public static bool CheckUser(string login, string password, out string role)
        {
            role = null;
            using var conn = GetConnection();
            conn.Open();
            using var cmd = new SQLiteCommand("SELECT Role FROM Users WHERE Login=@l AND Password=@p", conn);
            cmd.Parameters.AddWithValue("@l", login);
            cmd.Parameters.AddWithValue("@p", password);
            var res = cmd.ExecuteScalar();
            if (res != null) role = res.ToString();
            return res != null;
        }

        public static bool RegisterUser(string login, string password, string role = "user")
        {
            using var conn = GetConnection();
            conn.Open();
            using var cmd = new SQLiteCommand("INSERT INTO Users (Login, Password, Role) VALUES (@l, @p, @r)", conn);
            cmd.Parameters.AddWithValue("@l", login);
            cmd.Parameters.AddWithValue("@p", password);
            cmd.Parameters.AddWithValue("@r", role);
            try { cmd.ExecuteNonQuery(); return true; }
            catch { return false; }
        }

        // Возвращаем DataTable с русскими заголовками для товаров
        public static DataTable SearchProducts(string searchText)
        {
            using var conn = GetConnection();
            conn.Open();
            string sql = "SELECT Name, Unit, Price FROM Products WHERE Name LIKE @search ORDER BY Name";
            using var cmd = new SQLiteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@search", $"%{searchText}%");
            var da = new SQLiteDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            // Переименовываем колонки
            if (dt.Columns.Contains("Name")) dt.Columns["Name"].ColumnName = "Наименование";
            if (dt.Columns.Contains("Unit")) dt.Columns["Unit"].ColumnName = "Ед. изм.";
            if (dt.Columns.Contains("Price")) dt.Columns["Price"].ColumnName = "Цена, руб.";
            return dt;
        }

        // Возвращаем DataTable с русскими заголовками для материалов
        public static DataTable SearchMaterials(string searchText)
        {
            using var conn = GetConnection();
            conn.Open();
            string sql = "SELECT Name, Unit, Price FROM Materials WHERE Name LIKE @search ORDER BY Name";
            using var cmd = new SQLiteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@search", $"%{searchText}%");
            var da = new SQLiteDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            if (dt.Columns.Contains("Name")) dt.Columns["Name"].ColumnName = "Материал";
            if (dt.Columns.Contains("Unit")) dt.Columns["Unit"].ColumnName = "Ед. изм.";
            if (dt.Columns.Contains("Price")) dt.Columns["Price"].ColumnName = "Цена, руб.";
            return dt;
        }

        // Возвращаем DataTable с русскими заголовками для заказов (все)
        public static DataTable SearchOrders(string searchText)
        {
            using var conn = GetConnection();
            conn.Open();
            string sql = "SELECT Id, Number, Customer, Date, Total FROM Orders WHERE Customer LIKE @search OR Number LIKE @search ORDER BY Date DESC";
            using var cmd = new SQLiteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@search", $"%{searchText}%");
            var da = new SQLiteDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            if (dt.Columns.Contains("Id")) dt.Columns["Id"].ColumnName = "№ заказа";
            if (dt.Columns.Contains("Number")) dt.Columns["Number"].ColumnName = "Номер";
            if (dt.Columns.Contains("Customer")) dt.Columns["Customer"].ColumnName = "Заказчик";
            if (dt.Columns.Contains("Date")) dt.Columns["Date"].ColumnName = "Дата";
            if (dt.Columns.Contains("Total")) dt.Columns["Total"].ColumnName = "Сумма, руб.";
            return dt;
        }

        // Заказы только для конкретного пользователя (с русскими заголовками)
        public static DataTable GetUserOrders(string login)
        {
            using var conn = GetConnection();
            conn.Open();
            string sql = "SELECT Id, Number, Customer, Date, Total FROM Orders WHERE Customer = @login ORDER BY Date DESC";
            using var cmd = new SQLiteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@login", login);
            var da = new SQLiteDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            if (dt.Columns.Contains("Id")) dt.Columns["Id"].ColumnName = "№ заказа";
            if (dt.Columns.Contains("Number")) dt.Columns["Number"].ColumnName = "Номер";
            if (dt.Columns.Contains("Customer")) dt.Columns["Customer"].ColumnName = "Заказчик";
            if (dt.Columns.Contains("Date")) dt.Columns["Date"].ColumnName = "Дата";
            if (dt.Columns.Contains("Total")) dt.Columns["Total"].ColumnName = "Сумма, руб.";
            return dt;
        }

        public static DataTable GetOrderDetails(int orderId)
        {
            using var conn = GetConnection();
            conn.Open();
            string sql = "SELECT ProductName, Quantity, Unit, Price, (Quantity * Price) as Sum FROM OrderDetails WHERE OrderId = @oid";
            using var cmd = new SQLiteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@oid", orderId);
            var da = new SQLiteDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            if (dt.Columns.Contains("ProductName")) dt.Columns["ProductName"].ColumnName = "Продукт";
            if (dt.Columns.Contains("Quantity")) dt.Columns["Quantity"].ColumnName = "Кол-во";
            if (dt.Columns.Contains("Unit")) dt.Columns["Unit"].ColumnName = "Ед. изм.";
            if (dt.Columns.Contains("Price")) dt.Columns["Price"].ColumnName = "Цена, руб.";
            if (dt.Columns.Contains("Sum")) dt.Columns["Sum"].ColumnName = "Сумма, руб.";
            return dt;
        }
    }
}