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
    public partial class Form6 : Form
    {
        Form7 o = new Form7();
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
         /*   
            o.oleDbConnection1.Open();
            OleDbCommand cmd2 = new OleDbCommand("Select *from GRNProducts where GRNID = '" + comboBox9.Text + "'", o.oleDbConnection1);
            OleDbDataReader dr111 = cmd2.ExecuteReader();

            if (dr111.Read())
            {

                textBox4.Text = dr111["PModel"].ToString();
                textBox5.Text = dr111["PQty"].ToString();
           

            }
            o.oleDbConnection1.Close();*/
            /////////////////////////////////////////////////////////////
         




          
            this.textBox3.ReadOnly = true;

            int c = 0;

            o.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("select count(InvoiceID) from Invoice ", o.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                c = Convert.ToInt32(dr[0]);
                c++;
            }

            textBox97.Text = "0" + c.ToString();



            OleDbCommand cmdd = new OleDbCommand("Select GRNID from GRN where Status ='Close' ", o.oleDbConnection1);
            OleDbDataReader drr = cmdd.ExecuteReader();

            while (drr.Read())
            {
                comboBox9.Items.Add(drr["GRNID"]).ToString();
            }



            o.oleDbConnection1.Close();


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

        private void button32_Click(object sender, EventArgs e)
        {//Create invoice   
            
            
            o.oleDbConnection1.Open();

            OleDbCommand cmd = new OleDbCommand("insert into Invoice(InvoiceID,VendorID,VendorName,GRNDate,CDate,AmountPayable,GRNID) values(@InvoiceID,@VendorID,@VendorName,@GRNDate,@CDate,@AmountPayable,@GRNID)", o.oleDbConnection1);

            cmd.Parameters.AddWithValue("@InvoiceID", textBox97.Text);
            cmd.Parameters.AddWithValue("@VendorID", textBox93.Text);
            cmd.Parameters.AddWithValue("@VendorName", textBox95.Text);
            cmd.Parameters.AddWithValue("@GRNDate", textBox94.Text);
            cmd.Parameters.AddWithValue("@CDate", dateTimePicker1);
            cmd.Parameters.AddWithValue("@AmountPayable", textBox3.Text);
            cmd.Parameters.AddWithValue("@GRNID", comboBox9.Text);


            cmd.ExecuteNonQuery();

            o.oleDbConnection1.Close();
     
            MessageBox.Show("Invoice Created");
            
        }

        private void panel20_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label116_Click(object sender, EventArgs e)
        {

        }

        private void label117_Click(object sender, EventArgs e)
        {

        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            o.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Select *from GRN where GRNID = '" + comboBox9.Text + "'", o.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {

                textBox94.Text = dr["GRDate"].ToString();
                textBox1.Text = dr["POID"].ToString();
                textBox93.Text = dr["sno"].ToString();
                textBox95.Text = dr["VName"].ToString();

            }
            o.oleDbConnection1.Close();


            //////////////////////////////////////////////////////////////////////////////////////////
/*
            o.oleDbConnection1.Open();
            OleDbCommand cmd2 = new OleDbCommand("Select *from GRNProducts where GRNID = '" + comboBox9.Text + "'", o.oleDbConnection1);
            OleDbDataReader dr111 = cmd2.ExecuteReader();

            if (dr111.Read())
            {

                textBox4.Text = dr111["PModel"].ToString();
                textBox5.Text = dr111["PQty"].ToString();
           

            }
            o.oleDbConnection1.Close();*/


            ///////////////////////////////////////////////////////////////////////////////////////


            
            o.oleDbConnection1.Open();
            OleDbCommand cmd1 = new OleDbCommand("Select * from PO where VName = @VName", o.oleDbConnection1);
            cmd1.Parameters.AddWithValue("VName", textBox5.Text);
            OleDbDataReader dr1 = cmd1.ExecuteReader();
            if (dr1.Read())
            {
                textBox96.Text = dr1["TotalAmount"].ToString();
           

            }
            o.oleDbConnection1.Close();

          
        
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {//discount
                int price = Convert.ToInt32(textBox96.Text);
                int disc = Convert.ToInt32(textBox2.Text);
                int discount = (price * disc) / 100;
                int d = price - discount;
                textBox3.Text = d.ToString();
            }
            catch { MessageBox.Show("Please First Enter Price & Then Enter Discount You Want To Give");}
        }

        private void groupBox18_Enter(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {/*
            ////////////////////////////////////////////////////////////////////////
            o.oleDbConnection1.Open();
            OleDbCommand cmdd = new OleDbCommand("Select *from POproducts where poID ='" + textBox1.Text + "'", o.oleDbConnection1);
            OleDbDataReader dr = cmdd.ExecuteReader();

            if (dr.Read())
            {

                textBox4.Text = dr["ProductType"].ToString();
                textBox5.Text = dr["pqty"].ToString();


            }

            o.oleDbConnection1.Close();
            /////////////////////////////////////////////////////////////
          */


        }

    }
}
