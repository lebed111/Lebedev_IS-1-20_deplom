using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;
using static Mysqlx.Expect.Open.Types.Condition.Types;
using System.Diagnostics;

namespace Lebedev_IS_1_20_deplom
{
    public partial class Aftorization : Form
    {
        Connectonsql connectonsql = new Connectonsql();
        public BindingSource bSource = new BindingSource();
        public MySqlDataAdapter MyDA = new MySqlDataAdapter();
        public DataTable table = new DataTable();
        int costel = 0;
        public Aftorization()
        {
            InitializeComponent();
        }

        private void Aftorization_Load(object sender, EventArgs e)
        {
            connectonsql.con();
            this.FormClosing += MainForm_Closing;
        }

        private void buttton1_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text;
            string password = textBox2.Text;
            int id = 0;
            try
            {
                connectonsql.conn.Open();
                string sql = $"select * from login where login = '{login}' and password = {password}";
                MySqlCommand command = new MySqlCommand(sql, connectonsql.conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    id = Convert.ToInt32(reader[0].ToString());
                }
                connectonsql.conn.Close();
                connectonsql.conn.Open();
                sql = $"select family,name,patronymic,id_login from employee where id_login = {id}";
                command = new MySqlCommand(sql, connectonsql.conn);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Auth.username = $"{reader[0].ToString()} {reader[1].ToString()[0]}. {reader[2].ToString()[0]}.";
                }
                connectonsql.conn.Close();
                costel = 1;
                this.Close();
            }
            catch
            {
                MessageBox.Show("Неверный пароль или логин");
            }
            finally
            {
                connectonsql.conn.Close();
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Alt | Keys.F4))
            {
                // Ignore Alt+F4
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (costel == 0)
            {
                //устанавливает флаг отмены события в истину
                e.Cancel = true;
                //спрашивает стоит ли завершится
                if (MessageBox.Show("Вы уверены что хотите закрыть программу?", "Выйти?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //и после этого только завершается работа приложения
                    Application.Exit();
                    Process.GetCurrentProcess().Kill();
                }
            }
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            costel = 1;
            this.Close();
        }
    }
}
