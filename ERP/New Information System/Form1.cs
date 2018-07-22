using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
////////////////////                            REAL 

namespace New_Information_System
{
    public partial class Form1 : Form
    {
        Form7 o = new Form7();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            this.AcceptButton = this.button5;
            this.CancelButton = this.button6;
            this.button2.Enabled = false;
            this.button3.Enabled = false;
            this.button4.Enabled = false;
            this.button9.Enabled = false;
            this.button7.Enabled = false;
            this.button8.Enabled = false;
            this.button10.Enabled = false;
            this.button11.Enabled = false;
            this.button12.Enabled = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            //Admin
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            //customer
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            //vendor
            Form3 f3 = new Form3();
            f3.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //purchase order
            Form4 f4 = new Form4();
            f4.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //GRN
            Form5 f5 = new Form5();
            f5.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //Invoice
            Form6 f6 = new Form6();
            f6.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //Exit
            Application.Exit();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            if(Username.Text == "" || textBox2.Text == "")
            {
                this.button2.Enabled = true;
                this.button3.Enabled = true;
                this.button4.Enabled = true;
                this.button9.Enabled = true;

                this.button7.Enabled = true;
                this.button8.Enabled = true;
                this.button5.Enabled = false;
            }
            else
            { MessageBox.Show("Invalid Password");}
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click_2(object sender, EventArgs e)
        {
            if (Username.Text == "" || textBox2.Text == "")
            {
                this.button2.Enabled = true;
                this.button3.Enabled = true;
                this.button4.Enabled = true;
                this.button9.Enabled = true;

                this.button7.Enabled = true;
                this.button8.Enabled = true;
                this.button5.Enabled = false;
                this.button10.Enabled = true;
                this.button11.Enabled = true;
                this.button12.Enabled = true;
            }
            else
            { MessageBox.Show("Invalid Password"); }
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //Admin
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void button6_Click_2(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button10_Click(object sender, EventArgs e)
        {//so
            Form9 f9 = new Form9();
            f9.Show();
            this.Hide();
            
           
        }

      
        private void button11_Click(object sender, EventArgs e)
        {
            //delivery challan
            Form10 f16 = new Form10();
            f16.Show();
            this.Hide();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //so  invoice reveivable
            Form11 f696 = new Form11();
            f696.Show();
            this.Hide();
        }

        private void button8_Click_2(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            //Invoice
            Form6 f6 = new Form6();
            f6.Show();
            this.Hide();
        }

       

      

       
    }
}
