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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lebedev_IS_1_20_deplom.Add_
{
    public partial class Addwerehous : Form
    {
        Connectonsql connectonsql = new Connectonsql();
        public BindingSource bSource = new BindingSource();
        public MySqlDataAdapter MyDA = new MySqlDataAdapter();
        public DataTable product = new DataTable();
        public DataTable provider = new DataTable();
        public DataTable table = new DataTable();
        public Addwerehous()
        {
            InitializeComponent();
        }

        private void Addwerehous_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            connectonsql.con();
            connectonsql.conn.Open();
            MyDA.SelectCommand = new MySqlCommand("SELECT id, name FROM product;", connectonsql.conn);
            MyDA.Fill(product);
            connectonsql.conn.Close();
            connectonsql.conn.Open();
            MySqlCommand command = new MySqlCommand("SELECT id, name FROM product;", connectonsql.conn);
            MySqlDataReader reader = command.ExecuteReader();
            int a = 0;
            while (reader.Read())
            {
                comboBox1.Items.Add(product.Rows[a][1]);
                a++;
            }
            connectonsql.conn.Close();
            connectonsql.conn.Open();
            MyDA.SelectCommand = new MySqlCommand("SELECT id, company FROM provider;", connectonsql.conn);
            MyDA.Fill(provider);
            connectonsql.conn.Close();
            connectonsql.conn.Open();
            MySqlCommand command1 = new MySqlCommand("SELECT id, company FROM provider;", connectonsql.conn);
            MySqlDataReader reader1 = command1.ExecuteReader();
            a = 0;
            while (reader1.Read())
            {
                comboBox2.Items.Add(provider.Rows[a][1]);
                a++;
            }
            connectonsql.conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool cr  = false;
            connectonsql.conn.Open();
            MyDA.SelectCommand = new MySqlCommand("SELECT warehouse.id_product, warehouse.id_provider, provider.company, product.name FROM warehouse JOIN provider ON provider.id = warehouse.id JOIN product ON product.id = warehouse.id;", connectonsql.conn);
            MyDA.Fill(table);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                for (int j = 0; j < product.Rows.Count; j++)
                {
                    if(table.Rows[i][3].ToString() == product.Rows[j][1].ToString())
                    {
                        for(int k = 0;k < provider.Rows.Count;k++)
                        {
                            if(table.Rows[i][2].ToString() == provider.Rows[i][1].ToString())
                            {
                                cr = true;
                                break;
                            }
                        }
                    }
                }
            }
            connectonsql.conn.Close();
            if (cr == false)
            {
                int produc = 0;
                int provide = 0;
                for (int i = 0; i < product.Rows.Count; i++)
                {
                    if (comboBox1.Text == Convert.ToString(product.Rows[i][1].ToString()))
                    {
                        produc = Convert.ToInt32(product.Rows[i][0]);
                    }
                }
                for (int i = 0; i < provider.Rows.Count; i++)
                {
                    if (comboBox1.Text == Convert.ToString(provider.Rows[i][1].ToString()))
                    {
                        produc = Convert.ToInt32(provider.Rows[i][0]);
                    }
                }
                connectonsql.conn.Open();
                MySqlCommand command = new MySqlCommand($"INSERT INTO warehouse (id_product, id_provider, all) VALUES (\'{produc}\',\'{provide}\',\'{Convert.ToInt32(textBox1.Text)}\';)", connectonsql.conn);
                command.ExecuteNonQuery();
                connectonsql.conn.Close();
            }

        }
    }
}
