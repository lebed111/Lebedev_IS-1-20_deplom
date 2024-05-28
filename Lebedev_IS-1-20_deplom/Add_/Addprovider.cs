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
    public partial class Addprovider : Form
    {
        Connectonsql connectonsql = new Connectonsql();
        public Addprovider()
        {
            this.TopMost = true;
            InitializeComponent();
        }

        private void Addprovider_Load(object sender, EventArgs e)
        {
            connectonsql.con();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connectonsql.conn.Open();
            string sql = $"INSERT INTO client (fio, telephone, address) VALUES (\"{textBox1.Text}\",\"{maskedTextBox1.Text}\",\"{textBox3.Text}\");";
            MySqlCommand command = new MySqlCommand($"INSERT INTO ", connectonsql.conn);
            command.ExecuteNonQuery();
            connectonsql.conn.Close();
        }
    }
}
