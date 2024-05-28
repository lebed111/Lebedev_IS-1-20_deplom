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

namespace Lebedev_IS_1_20_deplom.Add
{
    public partial class Add : Form
    {
        Connectonsql connectonsql = new Connectonsql();
        public BindingSource bSource = new BindingSource();
        public MySqlDataAdapter MyDA = new MySqlDataAdapter();
        public DataTable table = new DataTable();
        int costel = 0;
        int dobav = 0;
        public Add()
        {
            InitializeComponent();
        }

        private void Add_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.FormClosing += MainForm_Closing;
            connectonsql.con();
            connectonsql.conn.Open();
            string sql8 = "SELECT * From login";
            MyDA.SelectCommand = new MySqlCommand(sql8, connectonsql.conn);
            MyDA.Fill(table);
            MyDA.Update(table);
            connectonsql.conn.Close();
            connectonsql.conn.Open();
            MySqlCommand command8 = new MySqlCommand(sql8, connectonsql.conn);
            MySqlDataReader reader = command8.ExecuteReader();
            int a = 0;
            while(reader.Read())
            {
                comboBox1.Items.Add(table.Rows[a][1]);
                a++;
            }
            connectonsql.conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string log = comboBox1.Text;
                for (int id = 0; table.Rows.Count > id; id++)
                {
                    if (log == Convert.ToString(table.Rows[id][1]))
                    {
                        log = Convert.ToString(table.Rows[id][0]);
                    }
                }

                connectonsql.conn.Open();
                string sql = $"INSERT INTO employee (family, name, patronymic, post, telephone, id_login, location) VALUES (\"{textBox1.Text}\",\" {textBox2.Text}\", \"{textBox3.Text}\", \"{textBox4.Text}\", \"{maskedTextBox1.Text}\", \"{log}\", \"{textBox6.Text}\"); ";
                MySqlCommand command = new MySqlCommand(sql, connectonsql.conn);
                command.ExecuteNonQuery();
                connectonsql.conn.Close();
                label8.Text = $"Добавлено записей: {dobav}";
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
