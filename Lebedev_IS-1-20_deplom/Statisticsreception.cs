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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lebedev_IS_1_20_deplom
{
    public partial class Statisticsreception : Form
    {
        Connectonsql connectonsql = new Connectonsql();
        public MySqlDataAdapter MyDA = new MySqlDataAdapter();
        DataSet data = new DataSet();
        public Statisticsreception()
        {
            InitializeComponent();
        }

        private void Statisticsreception_Load(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisX.IsMarginVisible = false;
            connectonsql.con();
            this.TopMost = true;
            for (int i = 1; i < 13; i++)
            {
                double summ = 0;
                connectonsql.conn.Open();
                MySqlCommand command = new MySqlCommand($"SELECT price_all, date FROM reception WHERE MONTH (date) = {i};", connectonsql.conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    summ += reader.GetInt32(0);
                }
                DateTime dateTime = new DateTime(2024, i, 1);
                chart1.Series[0].Points.AddXY($"{dateTime.ToString("MMMM")}",$"{summ}");
                connectonsql.conn.Close();
            }
            chart1.Titles.Add("Продажи");
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
