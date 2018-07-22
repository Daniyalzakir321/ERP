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
    public partial class Form3 : Form
    {
        Form7 o = new Form7();

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.panel6.Show();
            this.panel6.Visible = true;
            //Vender cb4
            o.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("select VID from Vendor ", o.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox4.Items.Add(dr["VID"]).ToString();

            }
            o.oleDbConnection1.Close();
          
            
         
   


            //Auto generate vender id  on insertion of vender

            int VID = 0;

            o.oleDbConnection1.Open();
            OleDbCommand cmd2 = new OleDbCommand("select count(VID) from vendor", o.oleDbConnection1);
            OleDbDataReader dr11 = cmd2.ExecuteReader();
            while (dr11.Read())
            {
                VID = Convert.ToInt32(dr11[0]);
                VID++;
            }
            o.oleDbConnection1.Close();




            this.textBox62.Text = ""+VID ;
        
//////////////////////////////////////////////////////////////////////////////////////////////////////////////



            this.panel4.Visible = false;
            this.panel11.Visible = false;

            


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

        private void button21_Click(object sender, EventArgs e)
        {
            //search Vendor

          

            this.textBox76.ReadOnly = true;
            this.textBox77.ReadOnly = true;
            this.textBox79.ReadOnly = true;
            this.textBox81.ReadOnly = true;
            this.textBox74.ReadOnly = true;
            this.textBox75.ReadOnly = true;
            this.textBox78.ReadOnly = true;
            this.textBox71.ReadOnly = true;
            this.textBox72.ReadOnly = true;
            this.textBox73.ReadOnly = true;
            this.textBox68.ReadOnly = true;
            this.textBox69.ReadOnly = true;
            this.textBox70.ReadOnly = true;




            o.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("select * from Vendor where VID='" + comboBox4.Text + "'", o.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                this.textBox76.Text = dr["VID"].ToString();
                this.textBox77.Text = dr["VName"].ToString();
                this.textBox79.Text = dr["VCode"].ToString();
                this.textBox81.Text = dr["VCity"].ToString();
                this.textBox75.Text = dr["PH1"].ToString();
                this.textBox74.Text = dr["PH2"].ToString();
                this.textBox78.Text = dr["VAddress"].ToString();
                this.textBox71.Text = dr["CPName"].ToString();
                this.textBox72.Text = dr["CPPH"].ToString();
                this.textBox73.Text = dr["VEmail"].ToString();
                this.textBox68.Text = dr["VFax"].ToString();
                this.textBox69.Text = dr["VGroup"].ToString();
                this.textBox70.Text = dr["VStatus"].ToString();
            }
            
            o.oleDbConnection1.Close();

        }

        private void button20_Click(object sender, EventArgs e)
        {
            this.panel11.Show();
            this.panel11.Visible = true;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            //Insert into Vendor
              o.oleDbConnection1.Open();
              OleDbCommand cmd = new OleDbCommand("Insert into Vendor(VID,VName,VCode,VCity,PH1,PH2,VAddress,CPName,CPPH,VEmail,VFax,VGroup,VStatus) values (@VID,@VName,@VCode,@VCity,@PH1,@PH2,@VAddress,@CPName,@CPPH,@VEmail,@VFax,@VGroup,@VStatus)", o.oleDbConnection1);
             cmd.Parameters.AddWithValue("@VID", textBox62.Text);
            cmd.Parameters.AddWithValue("@VName", textBox63.Text);
            cmd.Parameters.AddWithValue("@VCode", textBox65.Text);
            cmd.Parameters.AddWithValue("@VCity", textBox67.Text);
            cmd.Parameters.AddWithValue("@PH1", textBox61.Text);
            cmd.Parameters.AddWithValue("@PH2", textBox60.Text);
            cmd.Parameters.AddWithValue("@VAddress", textBox64.Text);
            cmd.Parameters.AddWithValue("@CPName", textBox57.Text);
            cmd.Parameters.AddWithValue("@CPPH", textBox58.Text);
            cmd.Parameters.AddWithValue("@VEmail", textBox59.Text);
            cmd.Parameters.AddWithValue("@VFax", textBox54.Text);
            cmd.Parameters.AddWithValue("@VGroup", textBox55.Text);
            cmd.Parameters.AddWithValue("@VStatus", textBox56.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Vendor Added");
            o.oleDbConnection1.Close();

           

        }

        private void button23_Click(object sender, EventArgs e)
        {
            //vendor

            this.textBox62.Clear();
            this.textBox63.Clear();
            this.textBox65.Clear();
            this.textBox67.Clear();
            this.textBox60.Clear();
            this.textBox61.Clear();
            this.textBox64.Clear();
            this.textBox57.Clear();
            this.textBox68.Clear();
            this.textBox59.Clear();
            this.textBox54.Clear();
            this.textBox55.Clear();
            this.textBox56.Clear();
        
        }

        private void button24_Click(object sender, EventArgs e)
        {
            this.panel11.Visible = false;
        }

        private void button27_Click(object sender, EventArgs e)
        {
            
        }

        private void button19_Click(object sender, EventArgs e)
        {
           
        }

        private void button26_Click(object sender, EventArgs e)
        {
          
          



        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           


        }

        private void button25_Click(object sender, EventArgs e)
        {
           
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
        }


        private void button6_Click(object sender, EventArgs e)
        {
            Form8 obj = new Form8();
            obj.Show();
            this.Hide();
        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel14_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            //so
            Form9 f9 = new Form9();
            f9.Show();
            this.Hide();
        }

        private void button5_Click_1(object sender, EventArgs e)
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
