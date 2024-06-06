using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Lebedev_IS_1_20_deplom.Add;

namespace Lebedev_IS_1_20_deplom
{
    public class Connectonsql
    {
        public MySqlConnection conn;
        public void con()
        {
            string connStr = "server=147.45.239.24;port=3306;user=lebedev;database=LebedevDB;password=1%8e286uTuQ)MU;";
            conn = new MySqlConnection(connStr);
            if (conn == null)
            {
                string connStr1 = "server=127.0.1.1;port=3306;user=admin;database=diplom;password=1234;";            
                conn = new MySqlConnection(connStr1);
            }
        }
    }
    public static class Auth
    {
        public static string username;
    }
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
    }
}
