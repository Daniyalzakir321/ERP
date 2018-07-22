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
    public partial class Form11 : Form
    {
        Form7 o = new Form7();
        public Form11()
        {
            InitializeComponent();
        }

        private void Form11_Load(object sender, EventArgs e)
        {
            int c = 0;

            o.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("select count(InvoiceID) from soInvoice ", o.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                c = Convert.ToInt32(dr[0]);
                c++;
            }

            textBox97.Text = "0" + c.ToString() + "-" + System.DateTime.Today.Year;
            /////////////////////////////////////////////////////////////////////
            OleDbCommand cmdd = new OleDbCommand("Select DCID from DeliveryChallan where Status ='CLOSE' ", o.oleDbConnection1);
            OleDbDataReader drr = cmdd.ExecuteReader();

            while (drr.Read())
            {
                comboBox9.Items.Add(drr["DCID"]).ToString();
            }



            o.oleDbConnection1.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //vendor
            Form3 f3 = new Form3();
            f3.Show();
            this.Hide();
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

        private void button10_Click(object sender, EventArgs e)
        {
            //so
            Form9 f9 = new Form9();
            f9.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
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

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button32_Click(object sender, EventArgs e)
        {
            try
            {
                o.oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("insert into soInvoice(InvoiceID,CustID,CustName,DCDate,InvoiceDate,AmountRecievable,DelCID) values(@InvoiceID,@CustID,@CustName,@DCDate,@InvoiceDate,@AmountRecievable,@DelCID)", o.oleDbConnection1);

                cmd.Parameters.AddWithValue("@InvoiceID", textBox97.Text);
                cmd.Parameters.AddWithValue("@CustID", textBox4.Text);
                cmd.Parameters.AddWithValue("@CustName", textBox5.Text);
                cmd.Parameters.AddWithValue("@DCDate", textBox94.Text);
                cmd.Parameters.AddWithValue("@InvoiceDate", dateTimePicker1);
                cmd.Parameters.AddWithValue("@AmountRecievable", textBox96.Text);
                cmd.Parameters.AddWithValue("@DelCID", comboBox9.Text);


                cmd.ExecuteNonQuery();

                o.oleDbConnection1.Close();
                MessageBox.Show("Invoice Created");
            }
            catch { MessageBox.Show("Please Enter All Fields"); }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int price = Convert.ToInt32(textBox96.Text);
                int disc = Convert.ToInt32(textBox2.Text);
                int discount = (price * disc) / 100;
                int d = price - discount;
                textBox3.Text = d.ToString();
            }
            catch { MessageBox.Show("Please Enter All Fields"); }
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            o.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Select *from DeliveryChallan where DCID = '" + comboBox9.Text + "'", o.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {

                textBox94.Text = dr["DCDate"].ToString();
                textBox1.Text = dr["SOID"].ToString();
                textBox95.Text = dr["CName"].ToString();
                textBox93.Text = dr["CID"].ToString();


            }
           
            OleDbCommand cmd1 = new OleDbCommand("Select * from SO where CName = @CName", o.oleDbConnection1);
            cmd1.Parameters.AddWithValue("CName", textBox95.Text);
            OleDbDataReader dr1 = cmd1.ExecuteReader();
            if (dr1.Read())
            {
                textBox96.Text = dr1["TotalAmount"].ToString();
            

            }
            o.oleDbConnection1.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {/*
            ////////////////////////////////////////////////////////////////////////
            o.oleDbConnection1.Open();
            OleDbCommand cmdd = new OleDbCommand("Select *from soproducts where soid ='" + textBox1.Text + "'", o.oleDbConnection1);
            OleDbDataReader dr = cmdd.ExecuteReader();

            if (dr.Read())
            {

                textBox4.Text = dr["pmodel"].ToString();
                textBox5.Text = dr["pqty"].ToString();


            }

            o.oleDbConnection1.Close();
            ////////////////////////////////////////////////////////////////////

            */





        }
    }
}
