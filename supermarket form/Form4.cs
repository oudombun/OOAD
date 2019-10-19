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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            
            this.dataGridView1.DataSource = second_control.dataTable;
            DataGridViewColumn column = this.dataGridView1.Columns[5];
            column.Width = 110;
        }
    }
}
