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
    public partial class Addlogin : Form
    {
        Connectonsql connectonsql = new Connectonsql();
        int costel = 0;
        private void Addlogin_Load(object sender, EventArgs e)
        {
            connectonsql.con();
            this.TopMost = true;
        }
        public Addlogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                connectonsql.conn.Open();
                MySqlCommand command = new MySqlCommand($"INSERT INTO login (login, password) VALUES (\"{textBox1.Text}\",\"{textBox2.Text}\");", connectonsql.conn);
                command.ExecuteNonQuery();
                connectonsql.conn.Close();
                costel = 1;
                this.Close();
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
