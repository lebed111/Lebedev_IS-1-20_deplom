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

namespace Lebedev_IS_1_20_deplom
{
    public partial class Statisticemployee : Form
    {
        Connectonsql connectonsql = new Connectonsql();
        public MySqlDataAdapter MyDA = new MySqlDataAdapter();
        public DataTable employe = new DataTable();
        public Statisticemployee()
        {
            InitializeComponent();
        }

        private void Statisticemployee_Load(object sender, EventArgs e)
        {
            double prod = 0;
            double gad = 0;
            double razn = 0;
            connectonsql.con();
            this.TopMost = true;
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            chart1.Series[2].Points.Clear();
            connectonsql.conn.Open();
            MyDA.SelectCommand = new MySqlCommand($"SELECT employee.id, employee.family FROM employee;", connectonsql.conn);
            MyDA.Fill(employe);
            connectonsql.conn.Close();
            connectonsql.conn.Open();
            MySqlCommand command = new MySqlCommand($"SELECT employee.id, employee.family, reception.price_all, reception.date FROM employee JOIN reception ON reception.id_employee = employee.id WHERE MONTH(reception.date) = 5 ;", connectonsql.conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int a = 0;
                
                if (employe.Rows[reader.GetInt32(0)-1][1].ToString() == reader.GetString(1))
                {
                    prod += reader.GetDouble(1);
                }

            }
          //connectonsql.conn.Close();
          //connectonsql.conn.Open();
          //MySqlCommand command = new MySqlCommand($"SELECT employee.family, reception.price_all, reception.date FROM employee JOIN reception ON reception.id_employee = employee.id WHERE MONTH(reception.date) = 5 ;", connectonsql.conn);
          //MySqlDataReader reader = command.ExecuteReader();
          //while (reader.Read())
          //{
          //    summ += reader.GetDouble(1) * Convert.ToDouble(reader.GetInt32(2));
          //    col += reader.GetInt32(2);
          //}
          //connectonsql.conn.Close();

        }
    }
}
