using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Lebedev_IS_1_20_deplom.Add_
{
    public partial class Addproduct : Form
    {
        Connectonsql connectonsql = new Connectonsql();
        int costel = 0;
        int dobav = 0;
        public Addproduct()
        {
            InitializeComponent();
        }

        private void Addproduct_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            connectonsql.con();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Добавлена новая строка");
            try
            {
                connectonsql.conn.Open();
                string sql = $"INSERT INTO product (name, Quantity_per_x_1) VALUES (\"{textBox1.Text}\",\'{textBox2.Text}\')";
                MySqlCommand command = new MySqlCommand(sql, connectonsql.conn);
                command.ExecuteNonQuery();
                connectonsql.conn.Close();
                dobav++;
                label4.Text = $"Добавлено записей: {dobav}";
            }
            catch { }
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
