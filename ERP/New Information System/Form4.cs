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
    public partial class Form4 : Form

    {
        string[] pid = new string[100];
        int[] qty = new int[100];
        int[] pprice = new int[100];



        int counter = 0;

        Form7 o = new Form7();

        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

            o.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Select Deptname from Dept ", o.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Items.Add(dr["Deptname"]).ToString();
            }
            o.oleDbConnection1.Close();


            //vendor details
            o.oleDbConnection1.Open();
            OleDbCommand cmdd = new OleDbCommand("Select VID from PO where Approve = 'APPROVED' ", o.oleDbConnection1);
            OleDbDataReader drr = cmdd.ExecuteReader();

            while (drr.Read())
            {
                comboBox1.Items.Add(drr["VID"]).ToString();
            }
            o.oleDbConnection1.Close();

            //Product details
            o.oleDbConnection1.Open();
            OleDbCommand cd = new OleDbCommand("Select Pid from Products ", o.oleDbConnection1);
            OleDbDataReader dnr = cd.ExecuteReader();
            while (dnr.Read())
            {

                comboBox3.Items.Add(dnr["Pid"]).ToString();
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


        private void button30_Click(object sender, EventArgs e)
        {
          






            //CREATE PO
            int s = 0;
            foreach (int p in pprice)
            {
                s += p + s;

            }

            o.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("insert into PO(POID,PODate,VDept,VName,VID,VCPPH,TotalAmount) values(@POID,@PODate,@VDept,@VName,@VID,@VCPPH,@TotalAmount)", o.oleDbConnection1);

            cmd.Parameters.AddWithValue("@POID", textBox87.Text);
            cmd.Parameters.AddWithValue("@PODate", dateTimePicker1);
            cmd.Parameters.AddWithValue("@VDept", textBox4.Text);
            cmd.Parameters.AddWithValue("@VName", textBox1.Text);
            cmd.Parameters.AddWithValue("@VID", comboBox1.Text);
            cmd.Parameters.AddWithValue("@VCPPH", textBox7.Text);
            cmd.Parameters.AddWithValue("@TotalAmount", s);

           


            for (int i = 0; i < counter; i++)
            {
                OleDbCommand cmd1 = new OleDbCommand("insert into POProducts(POID,Pid,PQty,TPPRICE,PNAME,ProductType) values(@POID,@Pid,@PQty,@TPPRICE,@PNAME,@ProductType)", o.oleDbConnection1);

                cmd1.Parameters.AddWithValue("@POID", textBox87.Text);
                cmd1.Parameters.AddWithValue("@Pid", pid[i]);
                cmd1.Parameters.AddWithValue("@PQty", qty[i]);
                cmd1.Parameters.AddWithValue("@TPPRICE", pprice[i]);
                cmd1.Parameters.AddWithValue("@PNAME", textBox6.Text);
                cmd1.Parameters.AddWithValue("@ProductType", textBox2.Text);
                cmd1.ExecuteNonQuery();
              
            }

            o.oleDbConnection1.Close();
            MessageBox.Show("PLEASE TAKE YOUR PURCHASE ORDER SLIP");



        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
           

            //vendor details
            o.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Select *from PO where VID = '" + comboBox1.Text + "'", o.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                
                textBox1.Text = dr["Vname"].ToString();
                textBox4.Text = dr["VDept"].ToString();
                textBox7.Text = dr["VCPPH"].ToString();

            }

            o.oleDbConnection1.Close();

            

        }

        private void panel16_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox14_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int c = 0;
            o.oleDbConnection1.Open();

            OleDbCommand cmdd = new OleDbCommand("select count(POID) from PO where VDept= '" + comboBox2.Text + "'", o.oleDbConnection1);
            OleDbDataReader drr = cmdd.ExecuteReader();
            if (drr.Read())
            {
                c = Convert.ToInt32(drr[0]);
                c++;
            }

            textBox87.Text = comboBox2.Text + "-" + c.ToString() + "-" + System.DateTime.Today.Year;

            o.oleDbConnection1.Close();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            //product info
            o.oleDbConnection1.Open();
            OleDbCommand cd = new OleDbCommand("Select *from Products where Pid = '" + comboBox3.Text + "'", o.oleDbConnection1);
            OleDbDataReader dnr = cd.ExecuteReader();

            if (dnr.Read())
            {
                textBox2.Text = dnr["ProductType"].ToString();
                textBox6.Text = dnr["PName"].ToString();
                textBox5.Text = dnr["BasePrice"].ToString();


            }

            o.oleDbConnection1.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                textBox8.Text += label9.Text + " : " + comboBox3.Text + Environment.NewLine;
                textBox8.Text += label2.Text + " : " + textBox2.Text + Environment.NewLine;
                textBox8.Text += label6.Text + " : " + textBox6.Text + Environment.NewLine;
                textBox8.Text += label5.Text + " : " + textBox5.Text + Environment.NewLine;
                textBox8.Text += label3.Text + " : " + textBox3.Text + Environment.NewLine;

                pid[counter] = comboBox3.Text;

                qty[counter] = Convert.ToInt32(textBox3.Text);
                pprice[counter] = Convert.ToInt32(textBox5.Text);
                counter++;
            }
            catch { MessageBox.Show("Please Enter Quantity"); }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

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

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void panel17_Paint(object sender, PaintEventArgs e)
        {

        }

       
    }
}
