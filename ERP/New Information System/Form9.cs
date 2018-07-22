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
    public partial class Form9 : Form
    {
        string[] pid = new string[50];
        int[] qtty = new int[50];
        int[] ptprice = new int[50];//ptprice= product total price
        int counter = 0;


        Form7 o = new Form7();
        public Form9()
        {
            InitializeComponent();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //so
            Form9 f9 = new Form9();
            f9.Show();
            this.Hide();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            o.oleDbConnection1.Open();
            OleDbCommand cc = new OleDbCommand("Select Deptname from Dept ", o.oleDbConnection1);
            OleDbDataReader d = cc.ExecuteReader();
            while (d.Read())
            {
                comboBox2.Items.Add(d["Deptname"]).ToString();
            }

//////////////////////////////////////////////////////////////////////////////////////////////////
            OleDbCommand cm = new OleDbCommand("Select CID from Customer where CStatus = 'ACTIVE' ", o.oleDbConnection1);
            OleDbDataReader dr = cm.ExecuteReader();

            while (dr.Read())
            {
                comboBox1.Items.Add(dr["CID"]).ToString();
            }
////////////////////////////////////////////////////////////////////////////////////////////////

            OleDbCommand cd = new OleDbCommand("Select PID from soProducts ", o.oleDbConnection1);
            OleDbDataReader dnr = cd.ExecuteReader();
            while (dnr.Read())
            {

                comboBox3.Items.Add(dnr["PID"]).ToString();
            }

            o.oleDbConnection1.Close();
///////////////////////////////////////////////////////////////////////////////////////////////////
          
            
            
            int c = 0;
            o.oleDbConnection1.Open();
            
            OleDbCommand cmdd = new OleDbCommand("select count(SOID) from SO where CDept= '" + comboBox2.Text + "'", o.oleDbConnection1);
            OleDbDataReader drr = cmdd.ExecuteReader();
            if (drr.Read())
            {
                c = Convert.ToInt32(drr[0]);
                c++;
            }

            textBox87.Text = comboBox2.Text + "-" + c.ToString() + "-" + System.DateTime.Today.Year;

            o.oleDbConnection1.Close();


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

        private void button1_Click(object sender, EventArgs e)
        {
            //Admin
            Form1 f1 = new Form1();
            f1.Show();
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            o.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Select *from Customer where CID = '" + comboBox1.Text + "'", o.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                textBox1.Text = dr["Cname"].ToString();
                textBox9.Text = dr["PH1"].ToString();
                textBox7.Text = dr["CGroup"].ToString();
                textBox4.Text = dr["CPPH"].ToString();

            }

            o.oleDbConnection1.Close();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            o.oleDbConnection1.Open();
            OleDbCommand cd = new OleDbCommand("Select *from SOProducts where Pid = '" + comboBox3.Text + "'", o.oleDbConnection1);
            OleDbDataReader dnr = cd.ExecuteReader();

            if (dnr.Read())
            {

                textBox2.Text = dnr["PModel"].ToString();
                textBox6.Text = dnr["PName"].ToString();
                textBox5.Text = dnr["TPPRICE"].ToString();


            }

            o.oleDbConnection1.Close();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            try
            {
                //CREATE SO
                int s = 0;
                foreach (int p in ptprice)
                {
                    s += p + s;

                }

                o.oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("insert into SO(SOID,SODate,CDept,CName,CID,CCPPH,TotalAmount,PRICE) values(@SOID,@SODate,@CDept,@CName,@CID,@CCPPH,@TotalAmount,@PRICE)", o.oleDbConnection1);

                cmd.Parameters.AddWithValue("@SOID", textBox87.Text);
                cmd.Parameters.AddWithValue("@SODate", dateTimePicker1);
                cmd.Parameters.AddWithValue("@CDept", textBox7.Text);
                cmd.Parameters.AddWithValue("@CName", textBox1.Text);
                cmd.Parameters.AddWithValue("@CID", comboBox1.Text);
                cmd.Parameters.AddWithValue("@CCPPH", textBox4.Text);
                cmd.Parameters.AddWithValue("@TotalAmount", textBox10.Text);
                cmd.Parameters.AddWithValue("@PRICE", s);
                cmd.ExecuteNonQuery();

                for (int i = 0; i < counter; i++)
                {
                    OleDbCommand cmd1 = new OleDbCommand("insert into SOProducts(SOID,Pid,PQty,TPPRICE,PNAME,PMODEL) values(@SOID,@Pid,@PQty,@TPPRICE,@PNAME,@PMODEL)", o.oleDbConnection1);

                    cmd1.Parameters.AddWithValue("@SOID", textBox87.Text);
                    cmd1.Parameters.AddWithValue("@Pid", pid[i]);
                    cmd1.Parameters.AddWithValue("@PQty", qtty[i]);
                    cmd1.Parameters.AddWithValue("@TPPRICE", ptprice[i]);
                    cmd1.Parameters.AddWithValue("@PNAME", textBox6.Text);
                    cmd1.Parameters.AddWithValue("@PMODEL", textBox2.Text);
                    cmd1.ExecuteNonQuery();

                }

                o.oleDbConnection1.Close();
                MessageBox.Show("Sales Order Created");
            }

            catch { MessageBox.Show("Please Enter All Fields"); }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                int tprice;
                int pprice = Convert.ToInt32(textBox5.Text);
                int qty = Convert.ToInt32(textBox3.Text.ToString());

                tprice = qty * pprice;
                textBox10.Text = tprice.ToString();

                textBox8.Text += label9.Text + " : " + comboBox3.Text + Environment.NewLine;
                textBox8.Text += label2.Text + " : " + textBox2.Text + Environment.NewLine;
                textBox8.Text += label6.Text + " : " + textBox6.Text + Environment.NewLine;
                textBox8.Text += label5.Text + " : " + textBox5.Text + Environment.NewLine;
                textBox8.Text += label3.Text + " : " + textBox3.Text + Environment.NewLine;
                textBox8.Text += label16.Text + " : " + textBox10.Text + Environment.NewLine;

                pid[counter] = comboBox3.Text;
                qtty[counter] = Convert.ToInt32(textBox3.Text);
                ptprice[counter] = Convert.ToInt32(textBox10.Text);
                counter++;
            }
            catch { MessageBox.Show("Please Enter All Fields"); }
        }
    }
}
