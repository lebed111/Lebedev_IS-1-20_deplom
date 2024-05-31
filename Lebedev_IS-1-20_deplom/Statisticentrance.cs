using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
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
    public partial class Statisticentrance : Form
    {
        Connectonsql connectonsql = new Connectonsql();
        public MySqlDataAdapter MyDA = new MySqlDataAdapter();
        public DataTable dataTable = new DataTable();
        public DataTable provider = new DataTable();
        int i = 5;
        double summ = 0;
        int col = 0;
        DateTime dateTime = new DateTime(2024, 5, 1);
        public Statisticentrance()
        {
            InitializeComponent();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
        void update()
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            provider.Clear();
            connectonsql.conn.Open();
            MyDA.SelectCommand = new MySqlCommand("SELECT id,company FROM provider", connectonsql.conn);
            MyDA.Fill(provider);
            connectonsql.conn.Close();
            for (int j = 0; j < provider.Rows.Count; j++)
            {
                connectonsql.conn.Open();
                MySqlCommand command = new MySqlCommand($"SELECT date, price, quantity, id_provider FROM entrance WHERE MONTH (date) = {i} AND id_provider = \"{provider.Rows[j][0]}\";", connectonsql.conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    summ += reader.GetDouble(1) * Convert.ToDouble(reader.GetInt32(2));
                    col += reader.GetInt32(2);
                }
                chart1.Series[0].Points.AddXY($"{provider.Rows[j][1].ToString()}", $"{summ}");
                chart1.Series[1].Points.AddXY($"oiaeyhbvhiae",$"{col}");
                connectonsql.conn.Close();
            }            
        }

        private void Statisticentrance_Load(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisX.IsMarginVisible = false;
            connectonsql.con();
            this.TopMost = true;
            update();
            chart1.Titles.Add("Май");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            i--;
            dateTime = new DateTime(2024, i, 1);
            update();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            i++;
            dateTime = new DateTime(2024, i, 1);
            update();
        }
    }
}

