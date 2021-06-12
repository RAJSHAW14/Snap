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

namespace Snap.fabric
{
    public partial class fabric_stock_summery : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public fabric_stock_summery()
        {
            InitializeComponent();
        }

        private void fabric_stock_summery_Load(object sender, EventArgs e)
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
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM fabric_stock_summery", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells["fabric_code"].Value = dr["fabric_code"].ToString();
                dataGridView1.Rows[i].Cells["receive"].Value = dr["RECEIVE"].ToString();
                dataGridView1.Rows[i].Cells["in_qc"].Value = dr["sent_to_qc"].ToString();
                dataGridView1.Rows[i].Cells["approved"].Value = dr["APPROVE"].ToString();
                dataGridView1.Rows[i].Cells["cutting"].Value = dr["CUTTING"].ToString();
                dataGridView1.Rows[i].Cells["rejected"].Value = dr["REJECT"].ToString();
                dataGridView1.Rows[i].Cells["total"].Value = System.Convert.ToDouble(dataGridView1.Rows[i].Cells["receive"].Value) + System.Convert.ToDouble(dataGridView1.Rows[i].Cells["in_qc"].Value) + System.Convert.ToDouble(dataGridView1.Rows[i].Cells["approved"].Value) + System.Convert.ToDouble(dataGridView1.Rows[i].Cells["cutting"].Value) + System.Convert.ToDouble(dataGridView1.Rows[i].Cells["rejected"].Value);
                dataGridView1.Rows[i].Cells["RETURN"].Value = dr["RETURN"].ToString();
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if(textBox1.Text=="")
            {
                dataGridView1.Rows.Clear();
                fill_data();
            }
            else
            {
                dataGridView1.Rows.Clear();
                MySqlDataAdapter da = new MySqlDataAdapter("select * from fabric_stock_summery where fabric_code like '%" + textBox1.Text + "%'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["fabric_code"].Value = dr["fabric_code"].ToString();
                    dataGridView1.Rows[i].Cells["receive"].Value = dr["RECEIVE"].ToString();
                    dataGridView1.Rows[i].Cells["in_qc"].Value = dr["sent_to_qc"].ToString();
                    dataGridView1.Rows[i].Cells["approved"].Value = dr["APPROVE"].ToString();
                    dataGridView1.Rows[i].Cells["cutting"].Value = dr["CUTTING"].ToString();
                    dataGridView1.Rows[i].Cells["rejected"].Value = dr["REJECT"].ToString();
                    dataGridView1.Rows[i].Cells["total"].Value = System.Convert.ToDouble(dataGridView1.Rows[i].Cells["receive"].Value) + System.Convert.ToDouble(dataGridView1.Rows[i].Cells["in_qc"].Value) + System.Convert.ToDouble(dataGridView1.Rows[i].Cells["approved"].Value) + System.Convert.ToDouble(dataGridView1.Rows[i].Cells["cutting"].Value) + System.Convert.ToDouble(dataGridView1.Rows[i].Cells["rejected"].Value);
                    dataGridView1.Rows[i].Cells["RETURN"].Value = dr["RETURN"].ToString();
                }
            }            
        }
    }
}
