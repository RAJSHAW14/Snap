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

namespace Snap.CMC
{
    public partial class cmc_production_list : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public cmc_production_list()
        {
            InitializeComponent();
        }

        private void cmc_production_list_Load(object sender, EventArgs e)
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            fill_data();
        }

        public void fill_data()
        {
            MySqlDataAdapter da = new MySqlDataAdapter("select * from cmc_prodcution_time_view order by id desc", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells["id"].Value = dr["id"].ToString();
                dataGridView1.Rows[i].Cells["order_number"].Value = dr["order_number"].ToString();
                dataGridView1.Rows[i].Cells["batch_code"].Value = dr["batchcode"].ToString();
                dataGridView1.Rows[i].Cells["department"].Value = dr["department"].ToString();
                dataGridView1.Rows[i].Cells["designer"].Value = dr["designer"].ToString();
                dataGridView1.Rows[i].Cells["order_receive_date"].Value = System.Convert.ToDateTime(dr["date"].ToString());
                dataGridView1.Rows[i].Cells["design_code"].Value = dr["design_code"].ToString();
                dataGridView1.Rows[i].Cells["design_description"].Value = dr["design_description"].ToString();
                dataGridView1.Rows[i].Cells["design_type"].Value = dr["design_type"].ToString();
                dataGridView1.Rows[i].Cells["machine_type"].Value = dr["machine_type"].ToString();
                dataGridView1.Rows[i].Cells["component"].Value = dr["component"].ToString();
                dataGridView1.Rows[i].Cells["fab_qty_details"].Value = dr["fab_qty_details"].ToString();
                dataGridView1.Rows[i].Cells["fabric"].Value = dr["fabric"].ToString();
                dataGridView1.Rows[i].Cells["color"].Value = dr["color"].ToString();
                dataGridView1.Rows[i].Cells["start_date"].Value = System.Convert.ToDateTime(dr["start_date"].ToString());
                dataGridView1.Rows[i].Cells["start_time"].Value = dr["start_time"].ToString();
                dataGridView1.Rows[i].Cells["end_date"].Value = System.Convert.ToDateTime(dr["end_date"].ToString());
                dataGridView1.Rows[i].Cells["end_time"].Value = dr["end_time"].ToString();
                dataGridView1.Rows[i].Cells["total_time"].Value = dr["total_hour"].ToString();
                dataGridView1.Rows[i].Cells["non_working_time"].Value = dr["non_working_hour"].ToString();
                dataGridView1.Rows[i].Cells["non_w_remarks"].Value = dr["non_working_remarks"].ToString();
                dataGridView1.Rows[i].Cells["actual_time"].Value = dr["effective_time"].ToString();
                dataGridView1.Rows[i].Cells["per_hr_rate"].Value = dr["per_hr_rate"].ToString();
                dataGridView1.Rows[i].Cells["cost"].Value = dr["total_cost"].ToString();                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "ORDER NUMBER")
            {
                dataGridView1.Rows.Clear();
                MySqlDataAdapter da = new MySqlDataAdapter("select * from cmc_prodcution_time_view WHERE order_number LIKE '"+textBox1.Text+"' order by id desc", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["id"].Value = dr["id"].ToString();
                    dataGridView1.Rows[i].Cells["order_number"].Value = dr["order_number"].ToString();
                    dataGridView1.Rows[i].Cells["batch_code"].Value = dr["batchcode"].ToString();
                    dataGridView1.Rows[i].Cells["department"].Value = dr["department"].ToString();
                    dataGridView1.Rows[i].Cells["designer"].Value = dr["designer"].ToString();
                    dataGridView1.Rows[i].Cells["order_receive_date"].Value = System.Convert.ToDateTime(dr["date"].ToString());
                    dataGridView1.Rows[i].Cells["design_code"].Value = dr["design_code"].ToString();
                    dataGridView1.Rows[i].Cells["design_description"].Value = dr["design_description"].ToString();
                    dataGridView1.Rows[i].Cells["design_type"].Value = dr["design_type"].ToString();
                    dataGridView1.Rows[i].Cells["machine_type"].Value = dr["machine_type"].ToString();
                    dataGridView1.Rows[i].Cells["component"].Value = dr["component"].ToString();
                    dataGridView1.Rows[i].Cells["fab_qty_details"].Value = dr["fab_qty_details"].ToString();
                    dataGridView1.Rows[i].Cells["fabric"].Value = dr["fabric"].ToString();
                    dataGridView1.Rows[i].Cells["color"].Value = dr["color"].ToString();
                    dataGridView1.Rows[i].Cells["start_date"].Value = System.Convert.ToDateTime(dr["start_date"].ToString());
                    dataGridView1.Rows[i].Cells["start_time"].Value = dr["start_time"].ToString();
                    dataGridView1.Rows[i].Cells["end_date"].Value = System.Convert.ToDateTime(dr["end_date"].ToString());
                    dataGridView1.Rows[i].Cells["end_time"].Value = dr["end_time"].ToString();
                    dataGridView1.Rows[i].Cells["total_time"].Value = dr["total_hour"].ToString();
                    dataGridView1.Rows[i].Cells["non_working_time"].Value = dr["non_working_hour"].ToString();
                    dataGridView1.Rows[i].Cells["non_w_remarks"].Value = dr["non_working_remarks"].ToString();
                    dataGridView1.Rows[i].Cells["actual_time"].Value = dr["effective_time"].ToString();
                    dataGridView1.Rows[i].Cells["per_hr_rate"].Value = dr["per_hr_rate"].ToString();
                    dataGridView1.Rows[i].Cells["cost"].Value = dr["total_cost"].ToString();
                }
            }
            else if (comboBox1.Text == "DESIGN NUMBER")
            {
                dataGridView1.Rows.Clear();
                MySqlDataAdapter da = new MySqlDataAdapter("select * from cmc_prodcution_time_view WHERE design_code LIKE '" + textBox1.Text + "' order by id desc", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["id"].Value = dr["id"].ToString();
                    dataGridView1.Rows[i].Cells["order_number"].Value = dr["order_number"].ToString();
                    dataGridView1.Rows[i].Cells["batch_code"].Value = dr["batchcode"].ToString();
                    dataGridView1.Rows[i].Cells["department"].Value = dr["department"].ToString();
                    dataGridView1.Rows[i].Cells["designer"].Value = dr["designer"].ToString();
                    dataGridView1.Rows[i].Cells["order_receive_date"].Value = System.Convert.ToDateTime(dr["date"].ToString());
                    dataGridView1.Rows[i].Cells["design_code"].Value = dr["design_code"].ToString();
                    dataGridView1.Rows[i].Cells["design_description"].Value = dr["design_description"].ToString();
                    dataGridView1.Rows[i].Cells["design_type"].Value = dr["design_type"].ToString();
                    dataGridView1.Rows[i].Cells["machine_type"].Value = dr["machine_type"].ToString();
                    dataGridView1.Rows[i].Cells["component"].Value = dr["component"].ToString();
                    dataGridView1.Rows[i].Cells["fab_qty_details"].Value = dr["fab_qty_details"].ToString();
                    dataGridView1.Rows[i].Cells["fabric"].Value = dr["fabric"].ToString();
                    dataGridView1.Rows[i].Cells["color"].Value = dr["color"].ToString();
                    dataGridView1.Rows[i].Cells["start_date"].Value = System.Convert.ToDateTime(dr["start_date"].ToString());
                    dataGridView1.Rows[i].Cells["start_time"].Value = dr["start_time"].ToString();
                    dataGridView1.Rows[i].Cells["end_date"].Value = System.Convert.ToDateTime(dr["end_date"].ToString());
                    dataGridView1.Rows[i].Cells["end_time"].Value = dr["end_time"].ToString();
                    dataGridView1.Rows[i].Cells["total_time"].Value = dr["total_hour"].ToString();
                    dataGridView1.Rows[i].Cells["non_working_time"].Value = dr["non_working_hour"].ToString();
                    dataGridView1.Rows[i].Cells["non_w_remarks"].Value = dr["non_working_remarks"].ToString();
                    dataGridView1.Rows[i].Cells["actual_time"].Value = dr["effective_time"].ToString();
                    dataGridView1.Rows[i].Cells["per_hr_rate"].Value = dr["per_hr_rate"].ToString();
                    dataGridView1.Rows[i].Cells["cost"].Value = dr["total_cost"].ToString();
                }
            }
            else if (comboBox1.Text == "DESIGN DESCRIPTION")
            {
                dataGridView1.Rows.Clear();
                MySqlDataAdapter da = new MySqlDataAdapter("select * from cmc_prodcution_time_view WHERE design_description LIKE '" + textBox1.Text + "' order by id desc", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["id"].Value = dr["id"].ToString();
                    dataGridView1.Rows[i].Cells["order_number"].Value = dr["order_number"].ToString();
                    dataGridView1.Rows[i].Cells["batch_code"].Value = dr["batchcode"].ToString();
                    dataGridView1.Rows[i].Cells["department"].Value = dr["department"].ToString();
                    dataGridView1.Rows[i].Cells["designer"].Value = dr["designer"].ToString();
                    dataGridView1.Rows[i].Cells["order_receive_date"].Value = System.Convert.ToDateTime(dr["date"].ToString());
                    dataGridView1.Rows[i].Cells["design_code"].Value = dr["design_code"].ToString();
                    dataGridView1.Rows[i].Cells["design_description"].Value = dr["design_description"].ToString();
                    dataGridView1.Rows[i].Cells["design_type"].Value = dr["design_type"].ToString();
                    dataGridView1.Rows[i].Cells["machine_type"].Value = dr["machine_type"].ToString();
                    dataGridView1.Rows[i].Cells["component"].Value = dr["component"].ToString();
                    dataGridView1.Rows[i].Cells["fab_qty_details"].Value = dr["fab_qty_details"].ToString();
                    dataGridView1.Rows[i].Cells["fabric"].Value = dr["fabric"].ToString();
                    dataGridView1.Rows[i].Cells["color"].Value = dr["color"].ToString();
                    dataGridView1.Rows[i].Cells["start_date"].Value = System.Convert.ToDateTime(dr["start_date"].ToString());
                    dataGridView1.Rows[i].Cells["start_time"].Value = dr["start_time"].ToString();
                    dataGridView1.Rows[i].Cells["end_date"].Value = System.Convert.ToDateTime(dr["end_date"].ToString());
                    dataGridView1.Rows[i].Cells["end_time"].Value = dr["end_time"].ToString();
                    dataGridView1.Rows[i].Cells["total_time"].Value = dr["total_hour"].ToString();
                    dataGridView1.Rows[i].Cells["non_working_time"].Value = dr["non_working_hour"].ToString();
                    dataGridView1.Rows[i].Cells["non_w_remarks"].Value = dr["non_working_remarks"].ToString();
                    dataGridView1.Rows[i].Cells["actual_time"].Value = dr["effective_time"].ToString();
                    dataGridView1.Rows[i].Cells["per_hr_rate"].Value = dr["per_hr_rate"].ToString();
                    dataGridView1.Rows[i].Cells["cost"].Value = dr["total_cost"].ToString();
                }
            }
            else if (comboBox1.Text == "DESIGN TYPE")
            {
                dataGridView1.Rows.Clear();
                MySqlDataAdapter da = new MySqlDataAdapter("select * from cmc_prodcution_time_view WHERE design_type LIKE '" + textBox1.Text + "' order by id desc", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["id"].Value = dr["id"].ToString();
                    dataGridView1.Rows[i].Cells["order_number"].Value = dr["order_number"].ToString();
                    dataGridView1.Rows[i].Cells["batch_code"].Value = dr["batchcode"].ToString();
                    dataGridView1.Rows[i].Cells["department"].Value = dr["department"].ToString();
                    dataGridView1.Rows[i].Cells["designer"].Value = dr["designer"].ToString();
                    dataGridView1.Rows[i].Cells["order_receive_date"].Value = System.Convert.ToDateTime(dr["date"].ToString());
                    dataGridView1.Rows[i].Cells["design_code"].Value = dr["design_code"].ToString();
                    dataGridView1.Rows[i].Cells["design_description"].Value = dr["design_description"].ToString();
                    dataGridView1.Rows[i].Cells["design_type"].Value = dr["design_type"].ToString();
                    dataGridView1.Rows[i].Cells["machine_type"].Value = dr["machine_type"].ToString();
                    dataGridView1.Rows[i].Cells["component"].Value = dr["component"].ToString();
                    dataGridView1.Rows[i].Cells["fab_qty_details"].Value = dr["fab_qty_details"].ToString();
                    dataGridView1.Rows[i].Cells["fabric"].Value = dr["fabric"].ToString();
                    dataGridView1.Rows[i].Cells["color"].Value = dr["color"].ToString();
                    dataGridView1.Rows[i].Cells["start_date"].Value = System.Convert.ToDateTime(dr["start_date"].ToString());
                    dataGridView1.Rows[i].Cells["start_time"].Value = dr["start_time"].ToString();
                    dataGridView1.Rows[i].Cells["end_date"].Value = System.Convert.ToDateTime(dr["end_date"].ToString());
                    dataGridView1.Rows[i].Cells["end_time"].Value = dr["end_time"].ToString();
                    dataGridView1.Rows[i].Cells["total_time"].Value = dr["total_hour"].ToString();
                    dataGridView1.Rows[i].Cells["non_working_time"].Value = dr["non_working_hour"].ToString();
                    dataGridView1.Rows[i].Cells["non_w_remarks"].Value = dr["non_working_remarks"].ToString();
                    dataGridView1.Rows[i].Cells["actual_time"].Value = dr["effective_time"].ToString();
                    dataGridView1.Rows[i].Cells["per_hr_rate"].Value = dr["per_hr_rate"].ToString();
                    dataGridView1.Rows[i].Cells["cost"].Value = dr["total_cost"].ToString();
                }
            }
            else if (comboBox1.Text == "MACHINE TYPE")
            {
                dataGridView1.Rows.Clear();
                MySqlDataAdapter da = new MySqlDataAdapter("select * from cmc_prodcution_time_view WHERE machine_type LIKE '" + textBox1.Text + "' order by id desc", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["id"].Value = dr["id"].ToString();
                    dataGridView1.Rows[i].Cells["order_number"].Value = dr["order_number"].ToString();
                    dataGridView1.Rows[i].Cells["batch_code"].Value = dr["batchcode"].ToString();
                    dataGridView1.Rows[i].Cells["department"].Value = dr["department"].ToString();
                    dataGridView1.Rows[i].Cells["designer"].Value = dr["designer"].ToString();
                    dataGridView1.Rows[i].Cells["order_receive_date"].Value = System.Convert.ToDateTime(dr["date"].ToString());
                    dataGridView1.Rows[i].Cells["design_code"].Value = dr["design_code"].ToString();
                    dataGridView1.Rows[i].Cells["design_description"].Value = dr["design_description"].ToString();
                    dataGridView1.Rows[i].Cells["design_type"].Value = dr["design_type"].ToString();
                    dataGridView1.Rows[i].Cells["machine_type"].Value = dr["machine_type"].ToString();
                    dataGridView1.Rows[i].Cells["component"].Value = dr["component"].ToString();
                    dataGridView1.Rows[i].Cells["fab_qty_details"].Value = dr["fab_qty_details"].ToString();
                    dataGridView1.Rows[i].Cells["fabric"].Value = dr["fabric"].ToString();
                    dataGridView1.Rows[i].Cells["color"].Value = dr["color"].ToString();
                    dataGridView1.Rows[i].Cells["start_date"].Value = System.Convert.ToDateTime(dr["start_date"].ToString());
                    dataGridView1.Rows[i].Cells["start_time"].Value = dr["start_time"].ToString();
                    dataGridView1.Rows[i].Cells["end_date"].Value = System.Convert.ToDateTime(dr["end_date"].ToString());
                    dataGridView1.Rows[i].Cells["end_time"].Value = dr["end_time"].ToString();
                    dataGridView1.Rows[i].Cells["total_time"].Value = dr["total_hour"].ToString();
                    dataGridView1.Rows[i].Cells["non_working_time"].Value = dr["non_working_hour"].ToString();
                    dataGridView1.Rows[i].Cells["non_w_remarks"].Value = dr["non_working_remarks"].ToString();
                    dataGridView1.Rows[i].Cells["actual_time"].Value = dr["effective_time"].ToString();
                    dataGridView1.Rows[i].Cells["per_hr_rate"].Value = dr["per_hr_rate"].ToString();
                    dataGridView1.Rows[i].Cells["cost"].Value = dr["total_cost"].ToString();
                }
            }
            else if (comboBox1.Text == "BATCHCODE")
            {
                dataGridView1.Rows.Clear();
                MySqlDataAdapter da = new MySqlDataAdapter("select * from cmc_prodcution_time_view WHERE batchcode LIKE '" + textBox1.Text + "' order by id desc", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["id"].Value = dr["id"].ToString();
                    dataGridView1.Rows[i].Cells["order_number"].Value = dr["order_number"].ToString();
                    dataGridView1.Rows[i].Cells["batch_code"].Value = dr["batchcode"].ToString();
                    dataGridView1.Rows[i].Cells["department"].Value = dr["department"].ToString();
                    dataGridView1.Rows[i].Cells["designer"].Value = dr["designer"].ToString();
                    dataGridView1.Rows[i].Cells["order_receive_date"].Value = System.Convert.ToDateTime(dr["date"].ToString());
                    dataGridView1.Rows[i].Cells["design_code"].Value = dr["design_code"].ToString();
                    dataGridView1.Rows[i].Cells["design_description"].Value = dr["design_description"].ToString();
                    dataGridView1.Rows[i].Cells["design_type"].Value = dr["design_type"].ToString();
                    dataGridView1.Rows[i].Cells["machine_type"].Value = dr["machine_type"].ToString();
                    dataGridView1.Rows[i].Cells["component"].Value = dr["component"].ToString();
                    dataGridView1.Rows[i].Cells["fab_qty_details"].Value = dr["fab_qty_details"].ToString();
                    dataGridView1.Rows[i].Cells["fabric"].Value = dr["fabric"].ToString();
                    dataGridView1.Rows[i].Cells["color"].Value = dr["color"].ToString();
                    dataGridView1.Rows[i].Cells["start_date"].Value = System.Convert.ToDateTime(dr["start_date"].ToString());
                    dataGridView1.Rows[i].Cells["start_time"].Value = dr["start_time"].ToString();
                    dataGridView1.Rows[i].Cells["end_date"].Value = System.Convert.ToDateTime(dr["end_date"].ToString());
                    dataGridView1.Rows[i].Cells["end_time"].Value = dr["end_time"].ToString();
                    dataGridView1.Rows[i].Cells["total_time"].Value = dr["total_hour"].ToString();
                    dataGridView1.Rows[i].Cells["non_working_time"].Value = dr["non_working_hour"].ToString();
                    dataGridView1.Rows[i].Cells["non_w_remarks"].Value = dr["non_working_remarks"].ToString();
                    dataGridView1.Rows[i].Cells["actual_time"].Value = dr["effective_time"].ToString();
                    dataGridView1.Rows[i].Cells["per_hr_rate"].Value = dr["per_hr_rate"].ToString();
                    dataGridView1.Rows[i].Cells["cost"].Value = dr["total_cost"].ToString();
                }
            }
            else if (comboBox1.Text == "DEPARTMENT")
            {
                dataGridView1.Rows.Clear();
                MySqlDataAdapter da = new MySqlDataAdapter("select * from cmc_prodcution_time_view WHERE department LIKE '" + textBox1.Text + "' order by id desc", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["id"].Value = dr["id"].ToString();
                    dataGridView1.Rows[i].Cells["order_number"].Value = dr["order_number"].ToString();
                    dataGridView1.Rows[i].Cells["batch_code"].Value = dr["batchcode"].ToString();
                    dataGridView1.Rows[i].Cells["department"].Value = dr["department"].ToString();
                    dataGridView1.Rows[i].Cells["designer"].Value = dr["designer"].ToString();
                    dataGridView1.Rows[i].Cells["order_receive_date"].Value = System.Convert.ToDateTime(dr["date"].ToString());
                    dataGridView1.Rows[i].Cells["design_code"].Value = dr["design_code"].ToString();
                    dataGridView1.Rows[i].Cells["design_description"].Value = dr["design_description"].ToString();
                    dataGridView1.Rows[i].Cells["design_type"].Value = dr["design_type"].ToString();
                    dataGridView1.Rows[i].Cells["machine_type"].Value = dr["machine_type"].ToString();
                    dataGridView1.Rows[i].Cells["component"].Value = dr["component"].ToString();
                    dataGridView1.Rows[i].Cells["fab_qty_details"].Value = dr["fab_qty_details"].ToString();
                    dataGridView1.Rows[i].Cells["fabric"].Value = dr["fabric"].ToString();
                    dataGridView1.Rows[i].Cells["color"].Value = dr["color"].ToString();
                    dataGridView1.Rows[i].Cells["start_date"].Value = System.Convert.ToDateTime(dr["start_date"].ToString());
                    dataGridView1.Rows[i].Cells["start_time"].Value = dr["start_time"].ToString();
                    dataGridView1.Rows[i].Cells["end_date"].Value = System.Convert.ToDateTime(dr["end_date"].ToString());
                    dataGridView1.Rows[i].Cells["end_time"].Value = dr["end_time"].ToString();
                    dataGridView1.Rows[i].Cells["total_time"].Value = dr["total_hour"].ToString();
                    dataGridView1.Rows[i].Cells["non_working_time"].Value = dr["non_working_hour"].ToString();
                    dataGridView1.Rows[i].Cells["non_w_remarks"].Value = dr["non_working_remarks"].ToString();
                    dataGridView1.Rows[i].Cells["actual_time"].Value = dr["effective_time"].ToString();
                    dataGridView1.Rows[i].Cells["per_hr_rate"].Value = dr["per_hr_rate"].ToString();
                    dataGridView1.Rows[i].Cells["cost"].Value = dr["total_cost"].ToString();
                }
            }
            else
            {
                dataGridView1.Rows.Clear();
                fill_data();
            }
        }
    }
}
