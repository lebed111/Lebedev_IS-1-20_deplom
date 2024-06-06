using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lebedev_IS_1_20_deplom.update
{
    public partial class Updateproduct : Form
    {
        public Updateproduct()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Запись удалена");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Запись изменена");
        }
    }
}
