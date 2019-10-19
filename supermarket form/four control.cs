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
using System.IO;

namespace supermarket_form
{
    public partial class four_control : UserControl
    {
        DataTable dTable;
        public four_control()
        {
            InitializeComponent();
            
        }

        private void four_control_Load(object sender, EventArgs e)
        {
            
        }

        private void btnAddmore_Click(object sender, EventArgs e)
        {
            int p_code = int.Parse(txtCode.Text);
            int p_qty = int.Parse(txtQty.Text);
            float p_unitPrice;
            int p_stock_id,p_stock_qty;

            //find stock record by barcode
            try
            {
                //This is my connection string i have assigned the database file address path  
                string MyConnection2 = "datasource=127.0.0.1;port=3306;username=root;password=;database=supermarket";
                //This is my insert query in which i am taking input from the user through windows forms  
                string Query = "Select * from stock where barcode= '" + p_code + "'";
                //This is  MySqlConnection here i have created the object and pass my connection string.  
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                //This is command class which will handle the query and connection object.  
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();     // Here our query will be executed and data saved into the database.  
                while (MyReader2.Read())
                {
                    p_unitPrice = float.Parse(MyReader2.GetString(3));
                    p_stock_id = int.Parse(MyReader2.GetString(0));
                    p_stock_qty= int.Parse(MyReader2.GetString(5));
                    int new_stock_qty = p_stock_qty - p_qty;
                    float amount = p_qty * p_unitPrice;

                    //remove qty from stock
                    try
                    {
                        //This is my connection string i have assigned the database file address path  
                        string MyConnection4 = "datasource=127.0.0.1;port=3306;username=root;password=;database=supermarket";
                        //This is my update query in which i am taking input from the user through windows forms and update the record.  
                        string Query4 = "update stock set total_qty='" + new_stock_qty + "' where barcode='" + p_code + "';";
                        //This is  MySqlConnection here i have created the object and pass my connection string.  
                        MySqlConnection MyConn4 = new MySqlConnection(MyConnection4);
                        MySqlCommand MyCommand4 = new MySqlCommand(Query4, MyConn4);
                        MySqlDataReader MyReader4;
                        MyConn4.Open();
                        MyReader4 = MyCommand4.ExecuteReader();
                        while (MyReader4.Read())
                        {
                        }
                        MyConn4.Close();//Connection closed here  
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }



                    //insert sale record 

                    try
                    {
                        //This is my connection string i have assigned the database file address path  
                        string MyConnection3 = "datasource=127.0.0.1;port=3306;username=root;password=;database=supermarket";
                        //This is my insert query in which i am taking input from the user through windows forms  
                        string Query3 = "insert into `sale` (stock_id,qty,amount) values('" + p_stock_id + "','" + p_qty + "','" + amount + "');";
                        //This is  MySqlConnection here i have created the object and pass my connection string.  
                        MySqlConnection MyConn3 = new MySqlConnection(MyConnection3);
                        //This is command class which will handle the query and connection object.  
                        MySqlCommand MyCommand3 = new MySqlCommand(Query3, MyConn3);
                        MySqlDataReader MyReader3;
                        MyConn3.Open();
                        MyReader3 = MyCommand3.ExecuteReader();     // Here our query will be executed and data saved into the database.  
                        
                        while (MyReader3.Read())
                        {
                           
                        }

                        MyConn3.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                MyConn2.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            updateData();
        }
        private void updateData()
        {
            txtCode.Text="";
            txtQty.Text="";
            this.dataGridView1.Update();
            this.dataGridView1.Refresh();
            try
            {
                string MyConnection2 = "datasource=127.0.0.1;port=3306;username=root;password=;database=supermarket";
                //Display query  
                string Query = "select st.barcode as Barcode,st.name as Name,st.price as Unit_Price,s.qty,s.amount,s.created_date from stock as st inner JOIN sale as s on s.stock_id = st.id where s.recipt_status=0";
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
        }
        private void clearData()
        {
            txtCode.Text = "";
            txtQty.Text = "";
            this.dataGridView1.Update();
            this.dataGridView1.Refresh();
            try
            {
                string MyConnection2 = "datasource=127.0.0.1;port=3306;username=root;password=;database=supermarket";
                //Display query  
                string Query = "select st.barcode as Barcode,st.name as Name,st.price as Unit_Price,s.qty,s.amount,s.created_date from stock as st inner JOIN sale as s on s.stock_id = st.id where s.recipt_status=2";
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
        }

        private void btnorder_Click(object sender, EventArgs e)
        {
            string rand = RandomUtil.GetRandomString();
            try
            {
                //This is my connection string i have assigned the database file address path  
                string MyConnection4 = "datasource=127.0.0.1;port=3306;username=root;password=;database=supermarket";
                //This is my update query in which i am taking input from the user through windows forms and update the record.  
                string Query4 = "update sale set recipt_status =1 where recipt_status=0;";
                //This is  MySqlConnection here i have created the object and pass my connection string.  
                MySqlConnection MyConn4 = new MySqlConnection(MyConnection4);
                MySqlCommand MyCommand4 = new MySqlCommand(Query4, MyConn4);
                MySqlDataReader MyReader4;
                MyConn4.Open();
                MyReader4 = MyCommand4.ExecuteReader();
                while (MyReader4.Read())
                {
                }
                MyConn4.Close();//Connection closed here  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            clearData();
            MessageBox.Show("Thanks you");
        }
    }
    static class RandomUtil
    {
        /// <summary>
        /// Get random string of 11 characters.
        /// </summary>
        /// <returns>Random string.</returns>
        public static string GetRandomString()
        {
            string path = Path.GetRandomFileName();
            path = path.Replace(".", ""); // Remove period.
            return path;
        }
    }
}
