using Google.Protobuf.WellKnownTypes;
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
using System.Windows.Forms.DataVisualization.Charting;

namespace Lebedev_IS_1_20_deplom
{
    public partial class Statisticemployee : Form
    {
        Connectonsql connectonsql = new Connectonsql();
        public MySqlDataAdapter MyDA = new MySqlDataAdapter();
        public DataTable employe = new DataTable();
        int date = 5;
        public Statisticemployee()
        {
            InitializeComponent();
        }
        void update ()
        {
            double prod = 0;
            double gad = 0;
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
            connectonsql.conn.Open();
            MyDA.SelectCommand = new MySqlCommand($"SELECT employee.id, employee.family FROM employee;", connectonsql.conn);
            MyDA.Fill(employe);
            connectonsql.conn.Close();
            for (int i = 0; i < employe.Rows.Count; i++)
            {
                connectonsql.conn.Open();
                MySqlCommand command = new MySqlCommand($"SELECT employee.id, employee.family, reception.price_all, reception.date FROM employee JOIN reception ON reception.id_employee = employee.id WHERE MONTH(reception.date) = {date} AND employee.id = {employe.Rows[i][0]};", connectonsql.conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    prod += reader.GetDouble(2);
                }
                connectonsql.conn.Close();
                connectonsql.conn.Open();
                command = new MySqlCommand($"SELECT employee.id, entrance.price, entrance.quantity, entrance.date FROM employee JOIN entrance ON entrance.id_employee = employee.id WHERE MONTH(entrance.date) = {date} AND employee.id = {employe.Rows[i][0]};", connectonsql.conn);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    gad += reader.GetDouble(2) * reader.GetDouble(1);
                }
                connectonsql.conn.Close();
                chart1.Series[0].Points.AddXY($"{employe.Rows[i][1]}",yValue: prod);
                chart1.Series[1].Points.AddXY("",yValue:gad);
                chart1.Series[2].Points.AddXY("",yValue: prod - gad);
                prod = 0;
                gad = 0;
            }
            chart1.Titles.Clear();
            DateTime dateTime = new DateTime(2024, date, 1);
            chart1.Titles.Add($"{dateTime.ToString("MMMM")}");

        }
        private void Statisticemployee_Load(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisX.IsMarginVisible = false;
            chart1.Titles.Add("Май");
            connectonsql.con();
            this.TopMost = true;
            update();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            date--;
            update();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            date++;
            update();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
