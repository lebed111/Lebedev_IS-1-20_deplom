using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lebedev_IS_1_20_deplom.Add_
{
    public partial class Addreception : Form
    {
        Connectonsql connectonsql = new Connectonsql();
        public BindingSource bSource = new BindingSource();
        public MySqlDataAdapter MyDA = new MySqlDataAdapter();
        public DataTable product = new DataTable();
        public DataTable emploee = new DataTable();
        public DataTable client = new DataTable();
        public Addreception()
        {
            InitializeComponent();
        }

        private void Addreception_Load(object sender, EventArgs e)
        {
            connectonsql.con();
            this.TopMost = true;
            connectonsql.conn.Open();
            MyDA.SelectCommand = new MySqlCommand("SELECT id, name, Quantity_per_x_1 FROM product;", connectonsql.conn);
            MyDA.Fill(product);
            connectonsql.conn.Close();
            connectonsql.conn.Open();
            MySqlCommand command = new MySqlCommand("SELECT id, name, Quantity_per_x_1 FROM product;", connectonsql.conn);
            MySqlDataReader reader = command.ExecuteReader();
            int a = 0;
            while (reader.Read())
            {
                comboBox1.Items.Add(product.Rows[a][1]);
                a++;
            }
            connectonsql.conn.Close();
            connectonsql.conn.Open();
            MyDA.SelectCommand = new MySqlCommand("SELECT id, family FROM employee;",connectonsql.conn);
            MyDA.Fill(emploee);
            connectonsql.conn.Close();
            connectonsql.conn.Open();
            MySqlCommand command1 = new MySqlCommand("SELECT id, family FROM employee;", connectonsql.conn);
            MySqlDataReader reader1 = command1.ExecuteReader();
            a = 0;
            while (reader1.Read())
            {
                comboBox2.Items.Add(emploee.Rows[a][1]);
                a++;
            }
            connectonsql.conn.Close();
            connectonsql.conn.Open();
            MyDA.SelectCommand = new MySqlCommand("SELECT id, fio FROM client;", connectonsql.conn);
            MyDA.Fill(client);
            connectonsql.conn.Close();
            connectonsql.conn.Open();
            MySqlCommand command2 = new MySqlCommand("SELECT id, fio FROM client;", connectonsql.conn);
            MySqlDataReader reader2 = command2.ExecuteReader();
            a = 0;
            while (reader2.Read())
            {
                comboBox4.Items.Add(client.Rows[a][1]);
                a++;
            }
            connectonsql.conn.Close();
        }
    }
}
