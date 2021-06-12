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

namespace Snap
{
    public partial class dpr_order_time_view : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public dpr_order_time_view()
        {
            InitializeComponent();
        }

        private void dpr_order_time_view_Load(object sender, EventArgs e)
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            fill_gride();
            auto_complete();
        }

        public void fill_gride()
        {
            dataGridView1.Columns[3].DefaultCellStyle.Format="h:mm";
            MySqlDataAdapter da = new MySqlDataAdapter("select * from dpr_order_time", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = dr["date"].ToString();
                dataGridView1.Rows[i].Cells[1].Value = dr["order_number"].ToString();
                dataGridView1.Rows[i].Cells[2].Value = dr["unit"].ToString();
                dataGridView1.Rows[i].Cells[3].Value = dr["total_time"].ToString();                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int j = 0;
            MySqlDataAdapter da = new MySqlDataAdapter("select * from dpr_order_time where order_number='"+textBox1.Text+"'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            j = System.Convert.ToInt32(dt.Rows.Count.ToString());
            if(j==0)
            {
                MessageBox.Show("Order number not found");
            }
            else
            {
                dataGridView1.Rows.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = dr["date"].ToString();
                    dataGridView1.Rows[i].Cells[1].Value = dr["order_number"].ToString();
                    dataGridView1.Rows[i].Cells[2].Value = dr["unit"].ToString();
                    dataGridView1.Rows[i].Cells[3].Value = dr["total_time"].ToString();
                }
            }
        }

        public void auto_complete()
        {
            MySqlCommand cmd = new MySqlCommand("select order_number from dpr_order_time", con);
            MySqlDataReader dr = cmd.ExecuteReader();
            AutoCompleteStringCollection autocomplete = new AutoCompleteStringCollection();
            while (dr.Read())
            {
                autocomplete.Add(dr.GetString(0));

            }
            textBox1.AutoCompleteCustomSource = autocomplete;
            dr.Close();
        }
    }
}
