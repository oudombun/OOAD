using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace supermarket_form
{
    public partial class second_control : UserControl
    {
        public static DataTable dTable;
        public second_control()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            
            try
            {
                string MyConnection2 = "datasource=127.0.0.1;port=3306;username=root;password=;database=supermarket";
                //Display query  
                string Query = "select barcode as Barcode,name as Name,price as Unit_Price,type as Type,total_qty as Qty,created_date as Import_Date from stock;";
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                //  MyConn2.Open();  
                //For offline connection we weill use  MySqlDataAdapter class.  
                MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                MyAdapter.SelectCommand = MyCommand2;
                dTable = new DataTable();
                MyAdapter.Fill(dTable);
                this.dataGridView1.DataSource = null;
                this.dataGridView1.Rows.Clear();
                this.dataGridView1.DataSource = dTable; // here i have assign dTable object to the dataGridView1 object to display data.               
                //MyConn2.Close();  
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            using (Form4 f4 = new Form4())
            f4.ShowDialog();
        }

        public static DataTable dataTable => dTable;

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Show();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            f6.Show();
        }

        private void second_control_Load(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Show();
        }
    }
}
