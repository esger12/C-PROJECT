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
    public partial class CUSTOMER : Form
    {
        public CUSTOMER()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ADMIN cs = new ADMIN();            
            SqlConnection con = new SqlConnection(DALC.GetConnectionString());
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM PRODUCT WHERE ID=" + textBox1.Text + "", con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("MEHSUL ALINDI");
            

        }

        private void CUSTOMER_Load(object sender, EventArgs e)
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
    }
}
