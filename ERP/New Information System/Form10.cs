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
    public partial class Form10 : Form
    {
        Form7 o = new Form7();
        public Form10()
        {
            InitializeComponent();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            int c = 0;
            o.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("select count(DCID) from DeliveryChallan ", o.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                c = Convert.ToInt32(dr[0]);
                c++;
            }

            textBox87.Text = "DC-0" + c.ToString() + "-" + System.DateTime.Today.Year;
            o.oleDbConnection1.Close();
            //////////////////////////////////////////////////////////
            o.oleDbConnection1.Open();
            OleDbCommand cmd1 = new OleDbCommand("Select SOID from SO where Status = 'OPEN' ", o.oleDbConnection1);
            OleDbDataReader dr1 = cmd1.ExecuteReader();
            while (dr1.Read())
            {
                comboBox5.Items.Add(dr1["SOID"]).ToString();
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

        private void button26_Click(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            o.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Select *from SO where SOID ='" + comboBox5.Text + "' ", o.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                textBox1.Text = dr["CID"].ToString();
                textBox2.Text = dr["CName"].ToString();
             
                textBox4.Text = dr["DDate"].ToString();

            }

            OleDbDataAdapter da = new OleDbDataAdapter("Select  *from SOProducts ", o.oleDbConnection1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView3.DataSource = dt;
            o.oleDbConnection1.Close();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            try
            {
                o.oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("Insert into DeliveryChallan(DCID,SOID,Status,CName,DDate,DCDate,CID) values(@DCID,@SOID,@Status,@CName,@DDate,@DCDate,@CID)", o.oleDbConnection1);
                cmd.Parameters.AddWithValue("@DCID", textBox87.Text);
                cmd.Parameters.AddWithValue("@SOID", comboBox5.Text);
                cmd.Parameters.AddWithValue("@Status", "CLOSE");
                cmd.Parameters.AddWithValue("@CID", textBox1.Text);
                cmd.Parameters.AddWithValue("@CName", textBox2.Text);
                cmd.Parameters.AddWithValue("@DDate", textBox4.Text);
                cmd.Parameters.AddWithValue("@DCDate", dateTimePicker2);

                cmd.ExecuteNonQuery();

                o.oleDbConnection1.Close();
                MessageBox.Show("Delivery Challan Created");
            }
            catch { MessageBox.Show("Delivery Challan Created");}
        }
    }
}