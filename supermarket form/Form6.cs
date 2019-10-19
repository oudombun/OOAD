using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace supermarket_form
{
    public partial class Form6 : Form
    {
        public static int StockId;
        public Form6()
        {
            InitializeComponent();
        }

        private void txtSearch_Click(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUpdate_Click(object sender, EventArgs e)
        {
            StockId = int.Parse(txtStockID.Text.ToString());
            Form11 f11 = new Form11();
            f11.Show();
            this.Hide();
        }
    }
}
