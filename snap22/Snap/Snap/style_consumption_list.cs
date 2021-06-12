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
    public partial class style_consumption_list : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public style_consumption_list()
        {
            InitializeComponent();
        }

        private void style_consumption_list_Load(object sender, EventArgs e)
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }

        public void load_datagride()
        {
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from style_master";
            cmd.ExecuteNonQuery();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = dr["id"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = dr["style_code"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = dr["style_colour"].ToString();
                dataGridView1.Rows[n].Cells[3].Value = dr["description"].ToString();
                dataGridView1.Rows[n].Cells[4].Value = dr["catagory"].ToString();
                dataGridView1.Rows[n].Cells[5].Value = dr["fabric_status"].ToString();
                dataGridView1.Rows[n].Cells[6].Value = dr["emb_status"].ToString();
                dataGridView1.Rows[n].Cells[7].Value = dr["mat_status"].ToString();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
