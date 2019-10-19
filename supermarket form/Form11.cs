using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace supermarket_form
{
    public partial class Form11 : Form
    {
        
        public Form11()
        {
            InitializeComponent();
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            string p_name = this.txtName.Text;
            string p_type = this.cboType.SelectedItem.ToString();
            int p_qty = int.Parse(this.txtQty.Text);
            int p_code = Form6.StockId;
            float p_price = float.Parse(this.txtPrice.Text);

            try
            {
                //This is my connection string i have assigned the database file address path  
                string MyConnection2 = "datasource=127.0.0.1;port=3306;username=root;password=;database=supermarket";
                //This is my update query in which i am taking input from the user through windows forms and update the record.  
                string Query = "update stock set name='" + p_name + "',type='" + p_type + "',total_qty='" + p_qty + "' where barcode='" + p_code + "';";
                //This is  MySqlConnection here i have created the object and pass my connection string.  
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();
                MessageBox.Show("Data Updated");
                while (MyReader2.Read())
                {
                }
                MyConn2.Close();//Connection closed here  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.Dispose();

        }

        private void Form11_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Form11_Load(object sender, EventArgs e)
        {
            
        }
    }
}
