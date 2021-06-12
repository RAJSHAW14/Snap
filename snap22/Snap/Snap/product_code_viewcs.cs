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
    public partial class product_code_viewcs : Form
    {

        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public product_code_viewcs()
        {
            InitializeComponent();
        }

        private void product_code_viewcs_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            data_gride_load();
        }

        string bachcode, department1, stylecode, stylecolour, generationdate;
        public void data_gride_load()
        {
            //string batch_id;


            //product_code_viewcs product = new product_code_viewcs();
            dataGridView1.Rows.Clear();
            MySqlDataAdapter da1 = new MySqlDataAdapter("select * from  batch_code_master where id='" + textBox1.Text + "'", con);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            foreach (DataRow dr in dt1.Rows)
            {
                bachcode = dr["batchcode"].ToString();
                department1 = dr["department"].ToString();
                stylecode = dr["style_code"].ToString();
                stylecolour = dr["style_colour"].ToString();
                generationdate = dr["generation_date"].ToString();
            }

            MySqlDataAdapter da = new MySqlDataAdapter("select * from  product_code_master where batcode_id='" + textBox1.Text + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr1 in dt.Rows)
            {
                
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = dr1["id"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = bachcode.ToString();
                dataGridView1.Rows[n].Cells[2].Value = dr1["product_code"].ToString();
                dataGridView1.Rows[n].Cells[3].Value = department1.ToString();
                dataGridView1.Rows[n].Cells[4].Value = stylecode.ToString();
                dataGridView1.Rows[n].Cells[5].Value = stylecolour.ToString();
                dataGridView1.Rows[n].Cells[6].Value = generationdate.ToString();



            }

        }
    }
}
