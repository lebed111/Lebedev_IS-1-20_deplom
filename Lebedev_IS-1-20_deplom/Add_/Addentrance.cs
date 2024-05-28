using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lebedev_IS_1_20_deplom.Add_
{
    public partial class Addentrance : Form
    {
        Connectonsql connectonsql = new Connectonsql();
        public BindingSource bSource = new BindingSource();
        public MySqlDataAdapter MyDA = new MySqlDataAdapter();
        public DataTable tableprovider = new DataTable();
        public DataTable tablepproduct = new DataTable();
        public DataTable tableemployee = new DataTable();
        int dobav = 0;
        int costel = 0;
        public Addentrance()
        {
            InitializeComponent();
        }

        private void Addentrance_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            connectonsql.con();
            //Фамилии Сотрудники
            connectonsql.conn.Open();
            MyDA.SelectCommand = new MySqlCommand("SELECT id, family FROM employee;", connectonsql.conn);
            MyDA.Fill(tableemployee);
            connectonsql.conn.Close();
            connectonsql.conn.Open();
            MySqlCommand command = new MySqlCommand("SELECT id, family FROM employee;", connectonsql.conn);
            MySqlDataReader reader = command.ExecuteReader();
            int a = 0;
            while (reader.Read())
            {
                comboBox3.Items.Add(tableemployee.Rows[a][1]);
                a++;
            }
            connectonsql.conn.Close();
            //Компании
            connectonsql.conn.Open();
            MyDA.SelectCommand = new MySqlCommand("SELECT id, company FROM provider;", connectonsql.conn);
            MyDA.Fill(tableprovider);
            connectonsql.conn.Close();
            connectonsql.conn.Open();
            MySqlCommand command1 = new MySqlCommand("SELECT id, company FROM provider;", connectonsql.conn);
            MySqlDataReader reader1 = command1.ExecuteReader();
            a = 0;
            while (reader1.Read())
            {
                comboBox1.Items.Add(tableprovider.Rows[a][1]);
                a++;
            }
            connectonsql.conn.Close();
            //Продукты
            connectonsql.conn.Open();
            MyDA.SelectCommand = new MySqlCommand("SELECT id, name FROM product;", connectonsql.conn);
            MyDA.Fill(tablepproduct);
            connectonsql.conn.Close();
            connectonsql.conn.Open();
            MySqlCommand command2 = new MySqlCommand("SELECT id, name FROM product;", connectonsql.conn);
            MySqlDataReader reader2 = command2.ExecuteReader();
            a = 0;
            while (reader2.Read())
            {
                comboBox2.Items.Add(tablepproduct.Rows[a][1]);
                a++;
            }
            connectonsql.conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int employee = 0;
            int product = 0;
            int provider = 0;
            for (int id = 0; tablepproduct.Rows.Count > id; id++)
            {
                if (comboBox2.Text == Convert.ToString(tablepproduct.Rows[id][1]))
                {
                    product = Convert.ToInt32(tablepproduct.Rows[id][0]);
                }
            }
            for (int id = 0; tableemployee.Rows.Count > id; id++)
            {
                if (comboBox3.Text == Convert.ToString(tableemployee.Rows[id][1]))
                {
                    employee = Convert.ToInt32(tableemployee.Rows[id][0]);
                }
            }
            for (int id = 0; tableprovider.Rows.Count > id; id++)
            {
                if (comboBox1.Text == Convert.ToString(tableprovider.Rows[id][1]))
                {
                    provider = Convert.ToInt32(tableprovider.Rows[id][0]);
                }
            }
            DateTime dt = DateTime.Parse(dateTimePicker1.Text);
            connectonsql.conn.Open();
            string sql = $"INSERT INTO entrance (id_provider, id_product,date,id_employee,price,quantity) VALUES (\'{provider}\',\'{product}\',\'{dt.ToString("yyyy-MM-dd")}\',\"{employee}\",{textBox1.Text},{textBox2.Text})";
            MySqlCommand command = new MySqlCommand(sql, connectonsql.conn);
            command.ExecuteNonQuery();
            connectonsql.conn.Close();
            dobav++;
            label5.Text = $"Добавлено записей: {dobav}";
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
                if (MessageBox.Show("Вы уверены что хотите закрыть окно?", "Закрыть окно?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //и после этого только завершается работа приложения
                    Application.Exit();
                }
            }
        }
    }
}
