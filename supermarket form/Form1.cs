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
    public partial class Form1 : Form
    {
        int panelwidth;
        bool iscollapsed;
        public Form1()
        {
            InitializeComponent();
            timerTime.Start();
            sidepanel.Height = btnHome.Height;
            first_control1.BringToFront();
            panelwidth = panelleft.Width;
            iscollapsed = false;

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            sidepanel.Height = btnHome.Height;
            sidepanel.Top = btnHome.Top;
            first_control1.BringToFront();
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            sidepanel.Height = btnStock.Height;
            sidepanel.Top = btnStock.Top;
            second_control1.BringToFront();

        }

        private void btnDelivery_Click(object sender, EventArgs e)
        {
            sidepanel.Height = btnDelivery.Height;
            sidepanel.Top = btnDelivery.Top;
            
            four_control1.BringToFront();
            

        }
        

        private void second_control1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            sidepanel.Height = btnabout.Height;
            sidepanel.Top = btnabout.Top;
            fivecontrol1.BringToFront();
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timerTime_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            labelTime.Text = dt.ToString("HH:MM:ss");


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
                 if (iscollapsed)
            {
                panelleft.Width = panelleft.Width + 10; 
                if (panelleft.Width >= panelwidth)

                {
                timer1.Stop();
                iscollapsed = false;
                this.Refresh();

                }
            }
                else 
            {
                panelleft.Width = panelleft.Width - 10;
                if (panelleft.Width <= 47)
                {
                    timer1.Stop();
                    iscollapsed = true;
                    this.Refresh();

                }

           }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
                     timer1.Start();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnSolditem_Click(object sender, EventArgs e)
        {
            sidepanel.Height = btnSolditem.Height;
            sidepanel.Top = btnSolditem.Top;
            sixcontrol1.BringToFront();
        }

        private void sixcontrol1_Load(object sender, EventArgs e)
        {
           
        }
    }
}
