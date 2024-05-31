using Lebedev_IS_1_20_deplom.Add;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lebedev_IS_1_20_deplom
{
    public partial class Main : Form
    {
        Connectonsql connectonsql = new Connectonsql();
        public BindingSource bSource = new BindingSource();
        public MySqlDataAdapter MyDA = new MySqlDataAdapter();
        public DataTable table = new DataTable();
        Timer timer = new Timer();
        int bdindex = 1;

        public Main()
        {
            InitializeComponent();
        }
        public int BD(int a)
        {
            connectonsql.conn.Open();
            dataGridView1.Columns.Clear();
            table.Rows.Clear();
            table.Columns.Clear();
            bSource.DataSource = table;
            dataGridView1.DataSource = bSource;

            switch (a)
            {
                case 1:
                    string sql = "SELECT employee.id, employee.family, employee.name, employee.patronymic, employee.post,employee.telephone, login.login, employee.location FROM employee JOIN login ON login.id = employee.id_login;";
                    MySqlCommand command = new MySqlCommand(sql, connectonsql.conn);
                    MyDA.SelectCommand = new MySqlCommand(sql, connectonsql.conn);
                    MyDA.Fill(table);
                    MyDA.Update(table);
                    dataGridView1.Columns[0].HeaderText = "id";
                    dataGridView1.Columns[1].HeaderText = "фамилия";
                    dataGridView1.Columns[2].HeaderText = "Имя";
                    dataGridView1.Columns[3].HeaderText = "Отчество";
                    dataGridView1.Columns[4].HeaderText = "Должность";
                    dataGridView1.Columns[5].HeaderText = "Телефон";
                    dataGridView1.Columns[6].HeaderText = "Логин";
                    dataGridView1.Columns[7].HeaderText = "Место проживание";

                    dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    bdindex = 1;
                    break;
                case 2:
                    string sql2 = "SELECT * FROM product";
                    MySqlCommand command2 = new MySqlCommand(sql2, connectonsql.conn);
                    MyDA.SelectCommand = new MySqlCommand(sql2, connectonsql.conn);
                    MyDA.Fill(table);
                    MyDA.Update(table);
                    dataGridView1.Columns[0].HeaderText = "id";
                    dataGridView1.Columns[1].HeaderText = "Название";
                    dataGridView1.Columns[2].HeaderText = "Цена за 1шт.";

                    dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    bdindex = 2;
                    break;
                case 3:
                    string sql3 = "SELECT * From client";
                    MySqlCommand command3 = new MySqlCommand(sql3, connectonsql.conn);
                    MyDA.SelectCommand = new MySqlCommand(sql3, connectonsql.conn);
                    MyDA.Fill(table);
                    MyDA.Update(table);
                    dataGridView1.Columns[0].HeaderText = "id";
                    dataGridView1.Columns[1].HeaderText = "ФИО";
                    dataGridView1.Columns[2].HeaderText = "Телефон";
                    dataGridView1.Columns[3].HeaderText = "Адресс";

                    dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    bdindex = 3;
                    break;
                case 4:
                    string sql4 = "SELECT warehouse.id, product.name, provider.company, warehouse.`all` FROM warehouse JOIN product ON product.id = warehouse.id_product JOIN provider ON provider.id = warehouse.id_provider;";
                    MySqlCommand command4 = new MySqlCommand(sql4, connectonsql.conn);
                    MyDA.SelectCommand = new MySqlCommand(sql4, connectonsql.conn);
                    MyDA.Fill(table);
                    MyDA.Update(table);
                    dataGridView1.Columns[0].HeaderText = "id_места";
                    dataGridView1.Columns[1].HeaderText = "Название";
                    dataGridView1.Columns[2].HeaderText = "Компания";
                    dataGridView1.Columns[3].HeaderText = "Количество";

                    dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    bdindex = 4;
                    break;
                case 5:
                    string sql5 = "SELECT * From provider";
                    MySqlCommand command5 = new MySqlCommand(sql5, connectonsql.conn);
                    MyDA.SelectCommand = new MySqlCommand(sql5, connectonsql.conn);
                    MyDA.Fill(table);
                    MyDA.Update(table);
                    dataGridView1.Columns[0].HeaderText = "id";
                    dataGridView1.Columns[1].HeaderText = "Город";
                    dataGridView1.Columns[2].HeaderText = "Телефон";
                    dataGridView1.Columns[3].HeaderText = "Компания";

                    dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    bdindex = 5;
                    break;
                case 6:
                    string sql6 = "SELECT reception.id, product.name, employee.family, reception.quantity, reception.id_price_x1, reception.price_all, client.fio, reception.date FROM reception JOIN product ON product.id = reception.id_product JOIN employee ON employee.id = reception.id_employee JOIN client ON client.id = reception.id_client;";
                    MySqlCommand command6 = new MySqlCommand(sql6, connectonsql.conn);
                    MyDA.SelectCommand = new MySqlCommand(sql6, connectonsql.conn);
                    MyDA.Fill(table);
                    MyDA.Update(table);
                    dataGridView1.Columns[0].HeaderText = "id";
                    dataGridView1.Columns[1].HeaderText = "Название";
                    dataGridView1.Columns[2].HeaderText = "Фамилия сотрудника";
                    dataGridView1.Columns[3].HeaderText = "Количестов";
                    dataGridView1.Columns[4].HeaderText = "Цена за 1шт.";
                    dataGridView1.Columns[5].HeaderText = "Цена зв все";
                    dataGridView1.Columns[6].HeaderText = "Клиент";
                    dataGridView1.Columns[7].HeaderText = "Дата";

                    dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    bdindex = 6;
                    break;
                case 7:
                    string sql7 = "SELECT entrance.id, provider.company, product.name, entrance.date, employee.family, entrance.price, entrance.quantity FROM entrance JOIN provider ON provider.id = entrance.id_provider JOIN  product ON product.id = entrance.id_product JOIN employee ON employee.id = entrance.id_employee;";
                    MySqlCommand command7 = new MySqlCommand(sql7, connectonsql.conn);
                    MyDA.SelectCommand = new MySqlCommand(sql7, connectonsql.conn);
                    MyDA.Fill(table);
                    MyDA.Update(table);
                    dataGridView1.Columns[0].HeaderText = "id";
                    dataGridView1.Columns[1].HeaderText = "Компания";
                    dataGridView1.Columns[2].HeaderText = "Название";
                    dataGridView1.Columns[3].HeaderText = "Дата";
                    dataGridView1.Columns[4].HeaderText = "Фамилия сотрудника";
                    dataGridView1.Columns[5].HeaderText = "Цена закупки";
                    dataGridView1.Columns[6].HeaderText = "Количество";

                    dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    bdindex = 7;
                    break;
                case 8:
                    string sql8 = "SELECT * From login";
                    MySqlCommand command8 = new MySqlCommand(sql8, connectonsql.conn);
                    MyDA.SelectCommand = new MySqlCommand(sql8, connectonsql.conn);
                    MyDA.Fill(table);
                    MyDA.Update(table);
                    dataGridView1.Columns[0].HeaderText = "id";
                    dataGridView1.Columns[1].HeaderText = "Логин";
                    dataGridView1.Columns[2].HeaderText = "Пароль";

                    dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    bdindex = 8;
                    break;

            }
            connectonsql.conn.Close();
            return 1;
            
            
        }

        public void timer1_Tick(object sender, EventArgs e)
        {

            int h = DateTime.Now.Hour;
            int m = DateTime.Now.Minute;
            int s = DateTime.Now.Second;

            string time = "";
            if (h < 10)
            {
                time += "0" + h;
            }
            else
            {
                time += h;
            }

            time += ":";

            if (m < 10)
            {
                time += "0" + m;
            }
            else
            {
                time += m;
            }

            time += ":";

            if (s < 10)
            {
                time += "0" + s;
            }
            else
            {
                time += s;
            }

            string data = "";

            label4.Text = time;
            int day = DateTime.Now.Day;
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;

            if (day < 10)
            {
                data += "0" + day;
            }
            else
            {
                data += day;
            }
            data += ".";
            if (month < 10)
            {
                data += "0" + month;
            }
            else
            {
                data += month;
            }
            data += ".";
            data += year;
            label3.Text = data;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.TopMost = true;           
            Aftorization aftorization = new Aftorization();
            aftorization.ShowDialog();
            label1.Text = Auth.username;
            connectonsql.con();
            BD(1);
            timer.Interval = 1000;
            timer.Tick += new EventHandler(timer1_Tick) ;
            timer.Start();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BD(1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BD(2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BD(3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            BD(4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            BD(5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            BD(6);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            BD(7);
        }
        private void button8_Click(object sender, EventArgs e)
        {
            BD(8);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            switch (bdindex)
            {
                case 1:
                    Add.Add employee = new Add.Add();
                    employee.ShowDialog();
                    break;

                case 2:
                    Add_.Addproduct addproduct = new Add_.Addproduct();
                    addproduct.ShowDialog();
                    break;
                case 3:
                    Add_.Addclient addclient = new Add_.Addclient();
                    addclient.ShowDialog();
                    break;
                case 4:
                    Add_.Addwerehous addwerehous = new Add_.Addwerehous();//Доделать!!!!!
                    addwerehous.ShowDialog();
                    break;
                case 5:
                    Add_.Addprovider addprovider = new Add_.Addprovider();//Додедлать!!!!!!
                    addprovider.ShowDialog();
                    break;
                case 6:
                    Add_.Addreception addreception = new Add_.Addreception();
                    addreception.ShowDialog();
                    //сделать!!!!
                    break;
                case 7:
                    Add_.Addentrance addentrance1 = new Add_.Addentrance();
                    addentrance1.ShowDialog();
                    break;
                case 8:
                    Add_.Addlogin addlogin = new Add_.Addlogin();
                    addlogin.ShowDialog();
                    break;
            }

        }

        private void button11_Click(object sender, EventArgs e)
        {
            Statisticsreception statisticsreception = new Statisticsreception();
            statisticsreception.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Statisticentrance statisticentrance = new Statisticentrance();//доделать
            statisticentrance.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Statisticemployee statisticemployee = new Statisticemployee();
            statisticemployee.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void button14_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                        if (dataGridView1.Rows[i].Cells[j].Value.ToString().Contains(textBox1.Text))
                        {
                            dataGridView1.Rows[i].Selected = true;
                            break;
                        }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            switch (bdindex)
            {
                case 1:
                    update.Updateemployee updateemployee = new update.Updateemployee();
                    updateemployee.ShowDialog();
                    break;

                case 2:
                    update.Updateproduct updateproduct = new update.Updateproduct();
                    updateproduct.ShowDialog();
                    break;
                case 3:
                    update.UpdateClient updateClient = new update.UpdateClient();
                    updateClient.ShowDialog();
                    break;
                case 4:
                    update.Updatewerehous updatewerehous = new update.Updatewerehous();
                    updatewerehous.ShowDialog();
                    break;
                case 5:
                    update.Update_providera update_Providera = new update.Update_providera();
                    update_Providera.ShowDialog();
                    break;
                case 6:
                    update.Updaterecepton updaterecepton = new update.Updaterecepton();
                    updaterecepton.ShowDialog();
                    break;
                case 7:
                    update.Updateentrance updateentrance = new update.Updateentrance();
                    updateentrance.ShowDialog();
                    break;
                case 8:
                    update.Updatelogin updatelogin = new update.Updatelogin();
                    updatelogin.ShowDialog();
                    break;
            }
        }
    }
}
