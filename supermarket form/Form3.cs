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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Qty_Click(object sender, EventArgs e)
        {

        }

        private void txtQty_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDate_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtProductID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtProductName_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            string p_name = txtProductName.Text;
            string p_type = cboType.SelectedItem.ToString();
            int p_qty = int.Parse(txtQty.Text);
            int p_code = int.Parse(txtProductCode.Text);
            float p_price = float.Parse(txtPrice.Text);
           
              try  {  
                    //This is my connection string i have assigned the database file address path  
                    string MyConnection2 = "datasource=127.0.0.1;port=3306;username=root;password=;database=supermarket";
                    //This is my insert query in which i am taking input from the user through windows forms  
                    string Query = "insert into stock(name,barcode,price,type,total_qty) values('" + p_name + "','" + p_code + "','" + p_price + "','" + p_type + "','" + p_qty + "');";
                    //This is  MySqlConnection here i have created the object and pass my connection string.  
                    MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);  
                    //This is command class which will handle the query and connection object.  
                    MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);  
                    MySqlDataReader MyReader2;  
                    MyConn2.Open();  
                    MyReader2 = MyCommand2.ExecuteReader();     // Here our query will be executed and data saved into the database.  
                    MessageBox.Show("Save Data");  
                    while (MyReader2.Read()){                     
                    }  
                    MyConn2.Close();
                this.Hide();
            }  
                catch (Exception ex)  {   
                    MessageBox.Show(ex.Message);  
                }  
        }
    }
}
