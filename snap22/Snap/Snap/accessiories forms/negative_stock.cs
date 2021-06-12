using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace Snap.accessiories_forms
{
    public partial class negative_stock : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public negative_stock()
        {
            InitializeComponent();
        }

        private void negative_stock_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            fill_data();
        }

        public void fill_data()
        {
            MySqlDataAdapter da = new MySqlDataAdapter("select * from item where inventory<0 and item_type='ACC'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = dr["ID"].ToString();
                dataGridView1.Rows[i].Cells[1].Value = dr["item_code"].ToString();
                dataGridView1.Rows[i].Cells[2].Value = dr["item_name"].ToString();
                dataGridView1.Rows[i].Cells[3].Value = dr["item_catagory"].ToString();
                dataGridView1.Rows[i].Cells[4].Value = dr["inventory"].ToString();
                dataGridView1.Rows[i].Cells[5].Value = dr["uom"].ToString();
                dataGridView1.Rows[i].Cells[6].Value = dr["unit_price"].ToString();
                dataGridView1.Rows[i].Cells[7].Value = dr["current_valuation"].ToString();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
