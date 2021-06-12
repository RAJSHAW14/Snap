using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace Snap.costing
{
    public partial class emb_vendor_cart : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public emb_vendor_cart()
        {
            InitializeComponent();
        }

        private void emb_vendor_cart_Load(object sender, EventArgs e)
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }

        public void fill_data()
        {
            MySqlDataAdapter da = new MySqlDataAdapter("select * from emb_master where id='" + textBox9.Text + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                textBox1.Text = dr["emb_code"].ToString();
                textBox2.Text = dr["emb_type"].ToString();
                textBox3.Text = dr["uom"].ToString();
                richTextBox1.Text = dr["emb_name"].ToString();               
            }
        }
    }
}
