using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace New_Information_System
{
    public partial class Form2 : Form
    {

        Form7 o = new Form7();

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
            
            this.panel9.Visible=false;
            //customer textbox is auto ID generator
           // this.textBox50.Enabled = false;
     
        
            //Customer cb1
            string[] c1 ={ "01", "02", "03", "04", "05", "06", "07", "08", "09", "10","11","12"};
           comboBox1.Items.Clear();
           comboBox1.Items.AddRange(c1);



              //Auto generate customer id  on insertion of customer
        int CID = 0;

            o.oleDbConnection1.Open();
            OleDbCommand cmd1 = new OleDbCommand("select count(CID) from customer", o.oleDbConnection1);
            OleDbDataReader dr1 = cmd1.ExecuteReader();
            while (dr1.Read())
            {
                CID = Convert.ToInt32(dr1[0]);
                CID++;
            }
            o.oleDbConnection1.Close();

            this.textBox50.Text = ""+CID ;


          //  this.textBox50.Text = "COO" + "-" + CID + "-" + System.DateTime.Today.Year;
        }

        



      

        








        private void button1_Click(object sender, EventArgs e)
        {
            //Admin
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {    //back button in customer
            this.panel6.Show();
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

        private void button15_Click(object sender, EventArgs e)
        {
            //search customer


            o.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("select * from Customer where CID='" + comboBox1.Text + "'", o.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                this.textBox38.Text = dr["CID"].ToString();
                this.textBox39.Text = dr["CName"].ToString();
                this.textBox40.Text = dr["CAddress"].ToString();
                this.textBox43.Text = dr["City"].ToString();
                this.textBox37.Text = dr["PH1"].ToString();
                this.textBox36.Text = dr["PH2"].ToString();
                this.textBox5.Text = dr["ContectPerson"].ToString();

                this.textBox6.Text = dr["CPPH"].ToString();
                this.textBox7.Text = dr["CEmail"].ToString();
                this.textBox1.Text = dr["CreditLimit"].ToString();
                this.textBox4.Text = dr["CStatus"].ToString();
                this.textBox3.Text = dr["CGroup"].ToString();
            }
            o.oleDbConnection1.Close();

            this.textBox38.ReadOnly = true;
            this.textBox39.ReadOnly = true;
            this.textBox40.ReadOnly = true;
            this.textBox43.ReadOnly = true;
            this.textBox36.ReadOnly = true;
            this.textBox37.ReadOnly = true;
            this.textBox5.ReadOnly = true;

            this.textBox6.ReadOnly = true;
            this.textBox7.ReadOnly = true;
            this.textBox1.ReadOnly = true;
            this.textBox4.ReadOnly = true;
            this.textBox3.ReadOnly = true;

        }

        private void button10_Click(object sender, EventArgs e)
        {
              //add customer

            o.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Insert into Customer(CID,CName,CAddress,City,PH1,PH2,ContectPerson,CPPH,CEmail,CreditLimit,CStatus,CGroup) values (@CID,@CName,@CAddress,@VCity,@PH1,@PH2,@ContectPerson,@CPPH,@CEmail,@CreditLimit,@CStatus,@CGroup)", o.oleDbConnection1);
            cmd.Parameters.AddWithValue("@CID", textBox50.Text);
            cmd.Parameters.AddWithValue("@CName", textBox51.Text);
            cmd.Parameters.AddWithValue("@CAddress", textBox52.Text);
            cmd.Parameters.AddWithValue("@City", textBox53.Text);
            cmd.Parameters.AddWithValue("@PH1", textBox49.Text);
            cmd.Parameters.AddWithValue("@PH2", textBox48.Text);
            cmd.Parameters.AddWithValue("@ContectPerson", textBox45.Text);
          
            cmd.Parameters.AddWithValue("@CPPH", textBox46.Text);
            cmd.Parameters.AddWithValue("@CEmail", textBox47.Text);
            cmd.Parameters.AddWithValue("@CreditLimit", textBox41.Text);
            cmd.Parameters.AddWithValue("@CStatus", textBox44.Text);
            cmd.Parameters.AddWithValue("@CGroup", textBox42.Text);
         
            cmd.ExecuteNonQuery();
            MessageBox.Show("Customer Added");
            o.oleDbConnection1.Close();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            //Clear Textboxes in Customers


            this.textBox50.Clear();
            this.textBox51.Clear();
            this.textBox52.Clear();
            this.textBox53.Clear();
            this.textBox48.Clear();
            this.textBox49.Clear();
            this.textBox45.Clear();
            this.textBox46.Clear();
            this.textBox47.Clear();
            this.textBox41.Clear();
            this.textBox44.Clear();
            this.textBox42.Clear();
        }

        private void button17_Click(object sender, EventArgs e)
        {//back button in customer
            this.panel9.Visible = false;
           
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //go to add customer
            this.panel9.Visible = true;
        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            //so
            Form9 f9 = new Form9();
            f9.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
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

       


}
}
