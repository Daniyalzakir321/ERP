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
    public partial class Form8 : Form
    {
        Form7 o = new Form7();
        public Form8()

        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            this.panel14.Visible = true;
            //APP.DIS,EDIt
            //to populate CBox2 for approval and dissaproval
            o.oleDbConnection1.Open();
            OleDbCommand cmd1 = new OleDbCommand("select VID from Vendor ", o.oleDbConnection1);
            OleDbDataReader dr1 = cmd1.ExecuteReader();
            while (dr1.Read())
            {
                comboBox2.Items.Add(dr1["VID"]).ToString();

            }
            o.oleDbConnection1.Close();
        }
       

        private void button26_Click(object sender, EventArgs e)
        {
            //      vendor approve

            o.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Update Vendor set VName=@VName,PH1=@PH1,CPName=@CPName,VStatus=@VStatus where VID=@VID", o.oleDbConnection1);
            cmd.Parameters.AddWithValue("@VID", this.comboBox2.Text);
            cmd.Parameters.AddWithValue("@VName", this.textBox82.Text);
            cmd.Parameters.AddWithValue("@PH1", this.textBox80.Text);
            cmd.Parameters.AddWithValue("@CPName", this.textBox83.Text);
            cmd.Parameters.AddWithValue("@VStatus", this.textBox66.Text);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Record Approved");
            o.oleDbConnection1.Close();
            this.textBox66.Text = "Approved";

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Vender approval and edit combobox2 back coding for app,disapp,edit

            o.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Select *from Vendor where VID = '" + comboBox2.Text + "'", o.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                textBox82.Text = dr["VName"].ToString();
                textBox80.Text = dr["PH1"].ToString();
                textBox83.Text = dr["CPName"].ToString();
                textBox66.Text = dr["VStatus"].ToString();

            }
            o.oleDbConnection1.Close();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            //      vendor disapprove

            o.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Update Vendor set VName=@VName,PH1=@PH1,CPName=@CPName,VStatus=@VStatus where VID=@VID", o.oleDbConnection1);
            cmd.Parameters.AddWithValue("@VID", this.comboBox2.Text);
            cmd.Parameters.AddWithValue("@VName", this.textBox82.Text);
            cmd.Parameters.AddWithValue("@PH1", this.textBox80.Text);
            cmd.Parameters.AddWithValue("@CPName", this.textBox83.Text);
            cmd.Parameters.AddWithValue("@VStatus", this.textBox66.Text);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Record  Disapproved");
            o.oleDbConnection1.Close();
            this.textBox66.Text = "Disapproved";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //   Edit Vendor panel

            o.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Update Vendor set VName=@VName,PH1=@PH1,CPName=@CPName,VStatus=@VStatus where VID=@VID", o.oleDbConnection1);
            cmd.Parameters.AddWithValue("@VID", this.comboBox2.Text);
            cmd.Parameters.AddWithValue("@VName", this.textBox82.Text);
            cmd.Parameters.AddWithValue("@PH1", this.textBox80.Text);
            cmd.Parameters.AddWithValue("@CPName", this.textBox83.Text);
            cmd.Parameters.AddWithValue("@VStatus", this.textBox66.Text);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Record Edited");
            o.oleDbConnection1.Close();
        }

        private void button27_Click(object sender, EventArgs e)
        {

            Form3 obj = new Form3();
            obj.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //Admin
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //customer
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            //purchase order
            Form4 f4 = new Form4();
            f4.Show();
            this.Hide();
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
             //GRN
            Form5 f5 = new Form5();
            f5.Show();
            this.Hide();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {

            //Invoice
            Form6 f6 = new Form6();
            f6.Show();
            this.Hide();
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            //Exit
            Application.Exit();
        }

       

        private void button4_Click_1(object sender, EventArgs e)
        {
            //vendor
            Form3 f3 = new Form3();
            f3.Show();
            this.Hide();
        }

        private void panel14_Paint(object sender, PaintEventArgs e)
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
    }
}
