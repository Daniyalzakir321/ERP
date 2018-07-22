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
    public partial class Form5 : Form
    {
        Form7 o = new Form7();
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            //auto generate grnid
            int c = 0;
            o.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("select count(GRNID) from GRN ", o.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                c = Convert.ToInt32(dr[0]);
                c++;
            }

            textBox87.Text = "GRN-0" + c.ToString();




            //poid open ones will shown



            OleDbCommand cmd1 = new OleDbCommand("Select POID from PO where Status = 'OPEN' ", o.oleDbConnection1);
            OleDbDataReader dr1 = cmd1.ExecuteReader();
            while (dr1.Read())
            {
                comboBox5.Items.Add(dr1["POID"]).ToString();
            }

            o.oleDbConnection1.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //Invoice
            Form6 f6 = new Form6();
            f6.Show();
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

        private void button8_Click(object sender, EventArgs e)
        {
            //Exit
            Application.Exit();
        

        }

        private void button30_Click(object sender, EventArgs e)
        {
            //Create GRN
            o.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Insert into GRN(GRNID,POID,VName,GRDate,DDate) values(@GRNID,@POID,@VName,@GRDate,@DDate)", o.oleDbConnection1);
            cmd.Parameters.AddWithValue("@GRNID", textBox87.Text);
            cmd.Parameters.AddWithValue("@POID", comboBox5.Text);
            
            cmd.Parameters.AddWithValue("@VName", textBox2.Text);
            cmd.Parameters.AddWithValue("@GRDate", dateTimePicker2);
            cmd.Parameters.AddWithValue("@DDate", dateTimePicker1);
         
            cmd.ExecuteNonQuery();
            OleDbCommand cnd = new OleDbCommand("Update PO set Status='CLOSE' where POID = @PID");
            o.oleDbConnection1.Close();
            MessageBox.Show("GRN Created");
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void panel16_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            o.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Select *from PO where POID = '" + comboBox5.Text + "'", o.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                textBox1.Text = dr["VID"].ToString();
                textBox2.Text = dr["VName"].ToString();
                dateTimePicker1.Text = dr["DDate"].ToString();
                

            }


            OleDbDataAdapter da = new OleDbDataAdapter("Select  *from POProducts  ", o.oleDbConnection1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView3.DataSource = dt;



            o.oleDbConnection1.Close();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
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

       

       

       
      
       

      





        }
}
