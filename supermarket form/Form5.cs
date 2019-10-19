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
    public partial class Form5 : Form
    {
        
        public Form5()
        {
            InitializeComponent();
        }

        private void txtDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string MyConnection2 = "datasource=127.0.0.1;port=3306;username=root;password=;database=supermarket";
                string deleteType = cboDelete.SelectedItem.ToString();
                string Query = "";
                if (deleteType.Equals("Product Name"))
                {
                    Query = "delete from stock where name='" + this.txtDeleteVal.Text + "';";
                }
                else
                {
                    Query = "delete from stock where barcode='" + this.txtDeleteVal.Text + "';";
                }
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();
                MessageBox.Show("Data Deleted");
                while (MyReader2.Read())
                {
                }
                MyConn2.Close();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
