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
    public partial class sixcontrol : UserControl
    {
        public sixcontrol()
        {
            InitializeComponent();
        }
        DataTable dTable;
        private void btnorder_Click(object sender, EventArgs e)
        {
            //string today = DateTime.Now.ToString("M/d/yyyy");
            string checkDate = this.dateTimePicker1.Value.ToString("yyyy-M-d");
            string start = checkDate + " 00:00:00.00";
            string end = checkDate + " 23:59:59.999";
            
            try
            {
                string MyConnection2 = "datasource=127.0.0.1;port=3306;username=root;password=;database=supermarket";
                //Display query  
                string Query = "select created_date as Date, sum(amount) as Profit from sale WHERE created_date BETWEEN '"+start+"' AND '"+end+"'";
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();
                while (MyReader2.Read())
                {
                    if (MyReader2.IsDBNull(MyReader2.GetOrdinal("Profit")))
                    {
                        textBox1.Text = "0$";
                    }
                    else
                    {

                        textBox1.Text = MyReader2.GetString(1)+"$";
                    }
                }
                MyReader2 = null;
                MyConn2.Close();//Connection closed here  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
