using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SERVICE
{
    public partial class ADMIN : Form
    {
        public ADMIN()
        {
            InitializeComponent();
        }

      
        private void button1_Click(object sender, EventArgs e)
        {
        }
        public void doldur()
        {
            
            {
                SqlConnection con = new SqlConnection(DALC.GetConnectionString());
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM PRODUCT", con);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                con.Close();
            };
        }
        private void button3_Click(object sender, EventArgs e)
        {
            //CREAT PRODUCT //INSERT 

           

            SqlConnection con = new SqlConnection(DALC.GetConnectionString());
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO PRODUCT (STOCKCOUNT,STOCKCODE,SELLERNAME,PRICE,VALUE,STATUS,NAME)"+"VALUES (@STOKSAYI,@STOKKODU,@SATICIADI,@QIYMET,@DEYER,@STATUS,@NAME)", con);
            cmd.Parameters.AddWithValue("@STOKSAYI",textBox1.Text);
            cmd.Parameters.AddWithValue("@STOKKODU", textBox2.Text);
            cmd.Parameters.AddWithValue("@SATICIADI", textBox3.Text);
            cmd.Parameters.AddWithValue("@QIYMET", textBox4.Text);
            cmd.Parameters.AddWithValue("@DEYER", textBox5.Text);
            cmd.Parameters.AddWithValue("@STATUS", textBox6.Text);
            cmd.Parameters.AddWithValue("@NAME", textBox7.Text);

          
            try
            {
                cmd.ExecuteNonQuery();

                MessageBox.Show("Success");
            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.Message);
            }


            doldur();
         
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(DALC.GetConnectionString());
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM PRODUCT", con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(DALC.GetConnectionString());
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand("UPDATE PRODUCT SET STOCKCOUNT=@STOKSAYI,STOCKCODE=@STOKKODU,SELLERNAME=@SATICIADI,PRICE=@QIYMET,VALUE=@DEYER,STATUS=@STATUS,NAME=@NAME WHERE ID=" + textBox8.Text + " ", con);
            cmd.Parameters.AddWithValue("@STOKSAYI", textBox1.Text);
            cmd.Parameters.AddWithValue("@STOKKODU", textBox2.Text);
            cmd.Parameters.AddWithValue("@SATICIADI", textBox3.Text);
            cmd.Parameters.AddWithValue("@QIYMET", textBox4.Text);
            cmd.Parameters.AddWithValue("@DEYER", textBox5.Text);
            cmd.Parameters.AddWithValue("@STATUS", textBox6.Text);
            cmd.Parameters.AddWithValue("@NAME", textBox7.Text);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            
            cmd.ExecuteNonQuery();
            con.Close();
            
            MessageBox.Show("SIFARIS OLUNDU");
            doldur();

        }

        private void ADMIN_Load(object sender, EventArgs e)
        {
            doldur();
        }

        private void button7_Click(object sender, EventArgs e)
        {
           

            SqlConnection con = new SqlConnection(DALC.GetConnectionString());
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand("UPDATE PRODUCT SET STATUS=@STATUS WHERE ID=" + textBox8.Text + " ", con);
            if (textBox6.Height==0)
            {
                cmd.Parameters.AddWithValue("@STATUS", textBox6.Text = "SIFARISH CATDIRILDI");
              
            }
            else
            {
                cmd.Parameters.AddWithValue("@STATUS", textBox6.Text = "SIFARISH LEGV OLUNUB");

            }


            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("UGURLU");


            doldur();
        }

    }
}
