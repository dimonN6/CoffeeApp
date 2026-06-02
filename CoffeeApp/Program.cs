using System;
using System.Windows.Forms;

namespace CoffeeApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DatabaseHelper.Init(); // создаёт БД и вставляет все данные из кода
            Application.Run(new Form1()); // старт с пазла
        }
    }
}