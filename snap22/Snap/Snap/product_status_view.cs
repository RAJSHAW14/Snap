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
    public partial class product_status_view : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public product_status_view()
        {
            InitializeComponent();
        }

        private void product_status_view_Load(object sender, EventArgs e)
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
            MySqlDataAdapter da = new MySqlDataAdapter("select * from product_code_routing_date where final_status='OPEN' order by id DESC", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = dr["id"].ToString();
                dataGridView1.Rows[i].Cells[1].Value = dr["product_code"].ToString();
                dataGridView1.Rows[i].Cells[2].Value = dr["component"].ToString();
                dataGridView1.Rows[i].Cells[3].Value = dr["desinger"].ToString();
                dataGridView1.Rows[i].Cells[4].Value = dr["stating_date"].ToString();
                dataGridView1.Rows[i].Cells[5].Value = dr["fabric_req"].ToString();
                dataGridView1.Rows[i].Cells[6].Value = dr["actual_fabric"].ToString();
                dataGridView1.Rows[i].Cells[7].Value = dr["fab_remarks"].ToString();
                dataGridView1.Rows[i].Cells[8].Value = dr["fab_status"].ToString();
                dataGridView1.Rows[i].Cells[9].Value = dr["dye_req"].ToString();
                dataGridView1.Rows[i].Cells[10].Value = dr["actual_dye"].ToString();
                dataGridView1.Rows[i].Cells[11].Value = dr["dye_remarks"].ToString();
                dataGridView1.Rows[i].Cells[12].Value = dr["dye_status"].ToString();
                dataGridView1.Rows[i].Cells[13].Value = dr["print_req"].ToString();
                dataGridView1.Rows[i].Cells[14].Value = dr["actual_print"].ToString();
                dataGridView1.Rows[i].Cells[15].Value = dr["print_remakrs"].ToString();
                dataGridView1.Rows[i].Cells[16].Value = dr["print_status"].ToString();
                dataGridView1.Rows[i].Cells[17].Value = dr["over_dye_req"].ToString();
                dataGridView1.Rows[i].Cells[18].Value = dr["over_dye_actual"].ToString();
                dataGridView1.Rows[i].Cells[19].Value = dr["over_dye_remaks"].ToString();
                dataGridView1.Rows[i].Cells[20].Value = dr["over_dye_status"].ToString();
                dataGridView1.Rows[i].Cells[21].Value = dr["cmc_req"].ToString();
                dataGridView1.Rows[i].Cells[22].Value = dr["actual_cmc"].ToString();
                dataGridView1.Rows[i].Cells[23].Value = dr["cmc_remakrs"].ToString();
                dataGridView1.Rows[i].Cells[24].Value = dr["cmc_status"].ToString();
                dataGridView1.Rows[i].Cells[25].Value = dr["highlight_req"].ToString();
                dataGridView1.Rows[i].Cells[26].Value = dr["actual_highlight"].ToString();
                dataGridView1.Rows[i].Cells[27].Value = dr["highlight_remakrs"].ToString();
                dataGridView1.Rows[i].Cells[28].Value = dr["highlight_status"].ToString();
                dataGridView1.Rows[i].Cells[29].Value = dr["stitiching_req"].ToString();
                dataGridView1.Rows[i].Cells[30].Value = dr["stitiching_actual"].ToString();
                dataGridView1.Rows[i].Cells[31].Value = dr["stitichign_remarks"].ToString();
                dataGridView1.Rows[i].Cells[32].Value = dr["stitiching_status"].ToString();
            }

        }

        int id_value = 0;
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                id_value = System.Convert.ToInt32(row.Cells["id"].Value.ToString());
            }
            update_product_status status1 = new update_product_status();
            status1.textBox11.Text = id_value.ToString();
            status1.fill_data();
            status1.Show();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                fill_data();
            }
            else
            {
                dataGridView1.Rows.Clear();
                MySqlDataAdapter da = new MySqlDataAdapter("select * from product_code_routing_date where product_code like '%" + textBox1.Text + "%' AND final_status='OPEN' order by id DESC", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = dr["id"].ToString();
                    dataGridView1.Rows[i].Cells[1].Value = dr["product_code"].ToString();
                    dataGridView1.Rows[i].Cells[2].Value = dr["component"].ToString();
                    dataGridView1.Rows[i].Cells[3].Value = dr["desinger"].ToString();
                    dataGridView1.Rows[i].Cells[4].Value = dr["stating_date"].ToString();
                    dataGridView1.Rows[i].Cells[5].Value = dr["fabric_req"].ToString();
                    dataGridView1.Rows[i].Cells[6].Value = dr["actual_fabric"].ToString();
                    dataGridView1.Rows[i].Cells[7].Value = dr["fab_remarks"].ToString();
                    dataGridView1.Rows[i].Cells[8].Value = dr["fab_status"].ToString();
                    dataGridView1.Rows[i].Cells[9].Value = dr["dye_req"].ToString();
                    dataGridView1.Rows[i].Cells[10].Value = dr["actual_dye"].ToString();
                    dataGridView1.Rows[i].Cells[11].Value = dr["dye_remarks"].ToString();
                    dataGridView1.Rows[i].Cells[12].Value = dr["dye_status"].ToString();
                    dataGridView1.Rows[i].Cells[13].Value = dr["print_req"].ToString();
                    dataGridView1.Rows[i].Cells[14].Value = dr["actual_print"].ToString();
                    dataGridView1.Rows[i].Cells[15].Value = dr["print_remakrs"].ToString();
                    dataGridView1.Rows[i].Cells[16].Value = dr["print_status"].ToString();
                    dataGridView1.Rows[i].Cells[17].Value = dr["over_dye_req"].ToString();
                    dataGridView1.Rows[i].Cells[18].Value = dr["over_dye_actual"].ToString();
                    dataGridView1.Rows[i].Cells[19].Value = dr["over_dye_remaks"].ToString();
                    dataGridView1.Rows[i].Cells[20].Value = dr["over_dye_status"].ToString();
                    dataGridView1.Rows[i].Cells[21].Value = dr["cmc_req"].ToString();
                    dataGridView1.Rows[i].Cells[22].Value = dr["actual_cmc"].ToString();
                    dataGridView1.Rows[i].Cells[23].Value = dr["cmc_remakrs"].ToString();
                    dataGridView1.Rows[i].Cells[24].Value = dr["cmc_status"].ToString();
                    dataGridView1.Rows[i].Cells[25].Value = dr["highlight_req"].ToString();
                    dataGridView1.Rows[i].Cells[26].Value = dr["actual_highlight"].ToString();
                    dataGridView1.Rows[i].Cells[27].Value = dr["highlight_remakrs"].ToString();
                    dataGridView1.Rows[i].Cells[28].Value = dr["highlight_status"].ToString();
                    dataGridView1.Rows[i].Cells[29].Value = dr["stitiching_req"].ToString();
                    dataGridView1.Rows[i].Cells[30].Value = dr["stitiching_actual"].ToString();
                    dataGridView1.Rows[i].Cells[31].Value = dr["stitichign_remarks"].ToString();
                    dataGridView1.Rows[i].Cells[32].Value = dr["stitiching_status"].ToString();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            fill_data();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "FABRIC")
            {
                dataGridView1.Rows.Clear();
                MySqlDataAdapter da = new MySqlDataAdapter("select * from product_code_routing_date where fabric_req='" + maskedTextBox1.Text + "' and final_status='OPEN'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = dr["id"].ToString();
                    dataGridView1.Rows[i].Cells[1].Value = dr["product_code"].ToString();
                    dataGridView1.Rows[i].Cells[2].Value = dr["component"].ToString();
                    dataGridView1.Rows[i].Cells[3].Value = dr["desinger"].ToString();
                    dataGridView1.Rows[i].Cells[4].Value = dr["stating_date"].ToString();
                    dataGridView1.Rows[i].Cells[5].Value = dr["fabric_req"].ToString();
                    dataGridView1.Rows[i].Cells[6].Value = dr["actual_fabric"].ToString();
                    dataGridView1.Rows[i].Cells[7].Value = dr["fab_remarks"].ToString();
                    dataGridView1.Rows[i].Cells[8].Value = dr["fab_status"].ToString();
                    dataGridView1.Rows[i].Cells[9].Value = dr["dye_req"].ToString();
                    dataGridView1.Rows[i].Cells[10].Value = dr["actual_dye"].ToString();
                    dataGridView1.Rows[i].Cells[11].Value = dr["dye_remarks"].ToString();
                    dataGridView1.Rows[i].Cells[12].Value = dr["dye_status"].ToString();
                    dataGridView1.Rows[i].Cells[13].Value = dr["print_req"].ToString();
                    dataGridView1.Rows[i].Cells[14].Value = dr["actual_print"].ToString();
                    dataGridView1.Rows[i].Cells[15].Value = dr["print_remakrs"].ToString();
                    dataGridView1.Rows[i].Cells[16].Value = dr["print_status"].ToString();
                    dataGridView1.Rows[i].Cells[17].Value = dr["over_dye_req"].ToString();
                    dataGridView1.Rows[i].Cells[18].Value = dr["over_dye_actual"].ToString();
                    dataGridView1.Rows[i].Cells[19].Value = dr["over_dye_remaks"].ToString();
                    dataGridView1.Rows[i].Cells[20].Value = dr["over_dye_status"].ToString();
                    dataGridView1.Rows[i].Cells[21].Value = dr["cmc_req"].ToString();
                    dataGridView1.Rows[i].Cells[22].Value = dr["actual_cmc"].ToString();
                    dataGridView1.Rows[i].Cells[23].Value = dr["cmc_remakrs"].ToString();
                    dataGridView1.Rows[i].Cells[24].Value = dr["cmc_status"].ToString();
                    dataGridView1.Rows[i].Cells[25].Value = dr["highlight_req"].ToString();
                    dataGridView1.Rows[i].Cells[26].Value = dr["actual_highlight"].ToString();
                    dataGridView1.Rows[i].Cells[27].Value = dr["highlight_remakrs"].ToString();
                    dataGridView1.Rows[i].Cells[28].Value = dr["highlight_status"].ToString();
                    dataGridView1.Rows[i].Cells[29].Value = dr["stitiching_req"].ToString();
                    dataGridView1.Rows[i].Cells[30].Value = dr["stitiching_actual"].ToString();
                    dataGridView1.Rows[i].Cells[31].Value = dr["stitichign_remarks"].ToString();
                    dataGridView1.Rows[i].Cells[32].Value = dr["stitiching_status"].ToString();
                }
            }
            else if (comboBox1.Text == "DYE")
            {
                dataGridView1.Rows.Clear();
                MySqlDataAdapter da = new MySqlDataAdapter("select * from product_code_routing_date where dye_req='" + maskedTextBox1.Text + "' and final_status='OPEN'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = dr["id"].ToString();
                    dataGridView1.Rows[i].Cells[1].Value = dr["product_code"].ToString();
                    dataGridView1.Rows[i].Cells[2].Value = dr["component"].ToString();
                    dataGridView1.Rows[i].Cells[3].Value = dr["desinger"].ToString();
                    dataGridView1.Rows[i].Cells[4].Value = dr["stating_date"].ToString();
                    dataGridView1.Rows[i].Cells[5].Value = dr["fabric_req"].ToString();
                    dataGridView1.Rows[i].Cells[6].Value = dr["actual_fabric"].ToString();
                    dataGridView1.Rows[i].Cells[7].Value = dr["fab_remarks"].ToString();
                    dataGridView1.Rows[i].Cells[8].Value = dr["fab_status"].ToString();
                    dataGridView1.Rows[i].Cells[9].Value = dr["dye_req"].ToString();
                    dataGridView1.Rows[i].Cells[10].Value = dr["actual_dye"].ToString();
                    dataGridView1.Rows[i].Cells[11].Value = dr["dye_remarks"].ToString();
                    dataGridView1.Rows[i].Cells[12].Value = dr["dye_status"].ToString();
                    dataGridView1.Rows[i].Cells[13].Value = dr["print_req"].ToString();
                    dataGridView1.Rows[i].Cells[14].Value = dr["actual_print"].ToString();
                    dataGridView1.Rows[i].Cells[15].Value = dr["print_remakrs"].ToString();
                    dataGridView1.Rows[i].Cells[16].Value = dr["print_status"].ToString();
                    dataGridView1.Rows[i].Cells[17].Value = dr["over_dye_req"].ToString();
                    dataGridView1.Rows[i].Cells[18].Value = dr["over_dye_actual"].ToString();
                    dataGridView1.Rows[i].Cells[19].Value = dr["over_dye_remaks"].ToString();
                    dataGridView1.Rows[i].Cells[20].Value = dr["over_dye_status"].ToString();
                    dataGridView1.Rows[i].Cells[21].Value = dr["cmc_req"].ToString();
                    dataGridView1.Rows[i].Cells[22].Value = dr["actual_cmc"].ToString();
                    dataGridView1.Rows[i].Cells[23].Value = dr["cmc_remakrs"].ToString();
                    dataGridView1.Rows[i].Cells[24].Value = dr["cmc_status"].ToString();
                    dataGridView1.Rows[i].Cells[25].Value = dr["highlight_req"].ToString();
                    dataGridView1.Rows[i].Cells[26].Value = dr["actual_highlight"].ToString();
                    dataGridView1.Rows[i].Cells[27].Value = dr["highlight_remakrs"].ToString();
                    dataGridView1.Rows[i].Cells[28].Value = dr["highlight_status"].ToString();
                    dataGridView1.Rows[i].Cells[29].Value = dr["stitiching_req"].ToString();
                    dataGridView1.Rows[i].Cells[30].Value = dr["stitiching_actual"].ToString();
                    dataGridView1.Rows[i].Cells[31].Value = dr["stitichign_remarks"].ToString();
                    dataGridView1.Rows[i].Cells[32].Value = dr["stitiching_status"].ToString();
                }
            }

            else if (comboBox1.Text == "PRINT")
            {
                dataGridView1.Rows.Clear();
                MySqlDataAdapter da = new MySqlDataAdapter("select * from product_code_routing_date where print_req='" + maskedTextBox1.Text + "' and final_status='OPEN'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = dr["id"].ToString();
                    dataGridView1.Rows[i].Cells[1].Value = dr["product_code"].ToString();
                    dataGridView1.Rows[i].Cells[2].Value = dr["component"].ToString();
                    dataGridView1.Rows[i].Cells[3].Value = dr["desinger"].ToString();
                    dataGridView1.Rows[i].Cells[4].Value = dr["stating_date"].ToString();
                    dataGridView1.Rows[i].Cells[5].Value = dr["fabric_req"].ToString();
                    dataGridView1.Rows[i].Cells[6].Value = dr["actual_fabric"].ToString();
                    dataGridView1.Rows[i].Cells[7].Value = dr["fab_remarks"].ToString();
                    dataGridView1.Rows[i].Cells[8].Value = dr["fab_status"].ToString();
                    dataGridView1.Rows[i].Cells[9].Value = dr["dye_req"].ToString();
                    dataGridView1.Rows[i].Cells[10].Value = dr["actual_dye"].ToString();
                    dataGridView1.Rows[i].Cells[11].Value = dr["dye_remarks"].ToString();
                    dataGridView1.Rows[i].Cells[12].Value = dr["dye_status"].ToString();
                    dataGridView1.Rows[i].Cells[13].Value = dr["print_req"].ToString();
                    dataGridView1.Rows[i].Cells[14].Value = dr["actual_print"].ToString();
                    dataGridView1.Rows[i].Cells[15].Value = dr["print_remakrs"].ToString();
                    dataGridView1.Rows[i].Cells[16].Value = dr["print_status"].ToString();
                    dataGridView1.Rows[i].Cells[17].Value = dr["over_dye_req"].ToString();
                    dataGridView1.Rows[i].Cells[18].Value = dr["over_dye_actual"].ToString();
                    dataGridView1.Rows[i].Cells[19].Value = dr["over_dye_remaks"].ToString();
                    dataGridView1.Rows[i].Cells[20].Value = dr["over_dye_status"].ToString();
                    dataGridView1.Rows[i].Cells[21].Value = dr["cmc_req"].ToString();
                    dataGridView1.Rows[i].Cells[22].Value = dr["actual_cmc"].ToString();
                    dataGridView1.Rows[i].Cells[23].Value = dr["cmc_remakrs"].ToString();
                    dataGridView1.Rows[i].Cells[24].Value = dr["cmc_status"].ToString();
                    dataGridView1.Rows[i].Cells[25].Value = dr["highlight_req"].ToString();
                    dataGridView1.Rows[i].Cells[26].Value = dr["actual_highlight"].ToString();
                    dataGridView1.Rows[i].Cells[27].Value = dr["highlight_remakrs"].ToString();
                    dataGridView1.Rows[i].Cells[28].Value = dr["highlight_status"].ToString();
                    dataGridView1.Rows[i].Cells[29].Value = dr["stitiching_req"].ToString();
                    dataGridView1.Rows[i].Cells[30].Value = dr["stitiching_actual"].ToString();
                    dataGridView1.Rows[i].Cells[31].Value = dr["stitichign_remarks"].ToString();
                    dataGridView1.Rows[i].Cells[32].Value = dr["stitiching_status"].ToString();
                }
            }

            else if (comboBox1.Text == "OVER DYE")
            {
                dataGridView1.Rows.Clear();
                MySqlDataAdapter da = new MySqlDataAdapter("select * from product_code_routing_date where over_dye_req='" + maskedTextBox1.Text + "' and final_status='OPEN'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = dr["id"].ToString();
                    dataGridView1.Rows[i].Cells[1].Value = dr["product_code"].ToString();
                    dataGridView1.Rows[i].Cells[2].Value = dr["component"].ToString();
                    dataGridView1.Rows[i].Cells[3].Value = dr["desinger"].ToString();
                    dataGridView1.Rows[i].Cells[4].Value = dr["stating_date"].ToString();
                    dataGridView1.Rows[i].Cells[5].Value = dr["fabric_req"].ToString();
                    dataGridView1.Rows[i].Cells[6].Value = dr["actual_fabric"].ToString();
                    dataGridView1.Rows[i].Cells[7].Value = dr["fab_remarks"].ToString();
                    dataGridView1.Rows[i].Cells[8].Value = dr["fab_status"].ToString();
                    dataGridView1.Rows[i].Cells[9].Value = dr["dye_req"].ToString();
                    dataGridView1.Rows[i].Cells[10].Value = dr["actual_dye"].ToString();
                    dataGridView1.Rows[i].Cells[11].Value = dr["dye_remarks"].ToString();
                    dataGridView1.Rows[i].Cells[12].Value = dr["dye_status"].ToString();
                    dataGridView1.Rows[i].Cells[13].Value = dr["print_req"].ToString();
                    dataGridView1.Rows[i].Cells[14].Value = dr["actual_print"].ToString();
                    dataGridView1.Rows[i].Cells[15].Value = dr["print_remakrs"].ToString();
                    dataGridView1.Rows[i].Cells[16].Value = dr["print_status"].ToString();
                    dataGridView1.Rows[i].Cells[17].Value = dr["over_dye_req"].ToString();
                    dataGridView1.Rows[i].Cells[18].Value = dr["over_dye_actual"].ToString();
                    dataGridView1.Rows[i].Cells[19].Value = dr["over_dye_remaks"].ToString();
                    dataGridView1.Rows[i].Cells[20].Value = dr["over_dye_status"].ToString();
                    dataGridView1.Rows[i].Cells[21].Value = dr["cmc_req"].ToString();
                    dataGridView1.Rows[i].Cells[22].Value = dr["actual_cmc"].ToString();
                    dataGridView1.Rows[i].Cells[23].Value = dr["cmc_remakrs"].ToString();
                    dataGridView1.Rows[i].Cells[24].Value = dr["cmc_status"].ToString();
                    dataGridView1.Rows[i].Cells[25].Value = dr["highlight_req"].ToString();
                    dataGridView1.Rows[i].Cells[26].Value = dr["actual_highlight"].ToString();
                    dataGridView1.Rows[i].Cells[27].Value = dr["highlight_remakrs"].ToString();
                    dataGridView1.Rows[i].Cells[28].Value = dr["highlight_status"].ToString();
                    dataGridView1.Rows[i].Cells[29].Value = dr["stitiching_req"].ToString();
                    dataGridView1.Rows[i].Cells[30].Value = dr["stitiching_actual"].ToString();
                    dataGridView1.Rows[i].Cells[31].Value = dr["stitichign_remarks"].ToString();
                    dataGridView1.Rows[i].Cells[32].Value = dr["stitiching_status"].ToString();
                }
            }

            else if (comboBox1.Text == "CMC")
            {
                dataGridView1.Rows.Clear();
                MySqlDataAdapter da = new MySqlDataAdapter("select * from product_code_routing_date where cmc_req='" + maskedTextBox1.Text + "' and final_status='OPEN'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = dr["id"].ToString();
                    dataGridView1.Rows[i].Cells[1].Value = dr["product_code"].ToString();
                    dataGridView1.Rows[i].Cells[2].Value = dr["component"].ToString();
                    dataGridView1.Rows[i].Cells[3].Value = dr["desinger"].ToString();
                    dataGridView1.Rows[i].Cells[4].Value = dr["stating_date"].ToString();
                    dataGridView1.Rows[i].Cells[5].Value = dr["fabric_req"].ToString();
                    dataGridView1.Rows[i].Cells[6].Value = dr["actual_fabric"].ToString();
                    dataGridView1.Rows[i].Cells[7].Value = dr["fab_remarks"].ToString();
                    dataGridView1.Rows[i].Cells[8].Value = dr["fab_status"].ToString();
                    dataGridView1.Rows[i].Cells[9].Value = dr["dye_req"].ToString();
                    dataGridView1.Rows[i].Cells[10].Value = dr["actual_dye"].ToString();
                    dataGridView1.Rows[i].Cells[11].Value = dr["dye_remarks"].ToString();
                    dataGridView1.Rows[i].Cells[12].Value = dr["dye_status"].ToString();
                    dataGridView1.Rows[i].Cells[13].Value = dr["print_req"].ToString();
                    dataGridView1.Rows[i].Cells[14].Value = dr["actual_print"].ToString();
                    dataGridView1.Rows[i].Cells[15].Value = dr["print_remakrs"].ToString();
                    dataGridView1.Rows[i].Cells[16].Value = dr["print_status"].ToString();
                    dataGridView1.Rows[i].Cells[17].Value = dr["over_dye_req"].ToString();
                    dataGridView1.Rows[i].Cells[18].Value = dr["over_dye_actual"].ToString();
                    dataGridView1.Rows[i].Cells[19].Value = dr["over_dye_remaks"].ToString();
                    dataGridView1.Rows[i].Cells[20].Value = dr["over_dye_status"].ToString();
                    dataGridView1.Rows[i].Cells[21].Value = dr["cmc_req"].ToString();
                    dataGridView1.Rows[i].Cells[22].Value = dr["actual_cmc"].ToString();
                    dataGridView1.Rows[i].Cells[23].Value = dr["cmc_remakrs"].ToString();
                    dataGridView1.Rows[i].Cells[24].Value = dr["cmc_status"].ToString();
                    dataGridView1.Rows[i].Cells[25].Value = dr["highlight_req"].ToString();
                    dataGridView1.Rows[i].Cells[26].Value = dr["actual_highlight"].ToString();
                    dataGridView1.Rows[i].Cells[27].Value = dr["highlight_remakrs"].ToString();
                    dataGridView1.Rows[i].Cells[28].Value = dr["highlight_status"].ToString();
                    dataGridView1.Rows[i].Cells[29].Value = dr["stitiching_req"].ToString();
                    dataGridView1.Rows[i].Cells[30].Value = dr["stitiching_actual"].ToString();
                    dataGridView1.Rows[i].Cells[31].Value = dr["stitichign_remarks"].ToString();
                    dataGridView1.Rows[i].Cells[32].Value = dr["stitiching_status"].ToString();
                }
            }

            else if (comboBox1.Text == "HIGHLIGHT")
            {
                dataGridView1.Rows.Clear();
                MySqlDataAdapter da = new MySqlDataAdapter("select * from product_code_routing_date where highlight_req='" + maskedTextBox1.Text + "' and final_status='OPEN'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = dr["id"].ToString();
                    dataGridView1.Rows[i].Cells[1].Value = dr["product_code"].ToString();
                    dataGridView1.Rows[i].Cells[2].Value = dr["component"].ToString();
                    dataGridView1.Rows[i].Cells[3].Value = dr["desinger"].ToString();
                    dataGridView1.Rows[i].Cells[4].Value = dr["stating_date"].ToString();
                    dataGridView1.Rows[i].Cells[5].Value = dr["fabric_req"].ToString();
                    dataGridView1.Rows[i].Cells[6].Value = dr["actual_fabric"].ToString();
                    dataGridView1.Rows[i].Cells[7].Value = dr["fab_remarks"].ToString();
                    dataGridView1.Rows[i].Cells[8].Value = dr["fab_status"].ToString();
                    dataGridView1.Rows[i].Cells[9].Value = dr["dye_req"].ToString();
                    dataGridView1.Rows[i].Cells[10].Value = dr["actual_dye"].ToString();
                    dataGridView1.Rows[i].Cells[11].Value = dr["dye_remarks"].ToString();
                    dataGridView1.Rows[i].Cells[12].Value = dr["dye_status"].ToString();
                    dataGridView1.Rows[i].Cells[13].Value = dr["print_req"].ToString();
                    dataGridView1.Rows[i].Cells[14].Value = dr["actual_print"].ToString();
                    dataGridView1.Rows[i].Cells[15].Value = dr["print_remakrs"].ToString();
                    dataGridView1.Rows[i].Cells[16].Value = dr["print_status"].ToString();
                    dataGridView1.Rows[i].Cells[17].Value = dr["over_dye_req"].ToString();
                    dataGridView1.Rows[i].Cells[18].Value = dr["over_dye_actual"].ToString();
                    dataGridView1.Rows[i].Cells[19].Value = dr["over_dye_remaks"].ToString();
                    dataGridView1.Rows[i].Cells[20].Value = dr["over_dye_status"].ToString();
                    dataGridView1.Rows[i].Cells[21].Value = dr["cmc_req"].ToString();
                    dataGridView1.Rows[i].Cells[22].Value = dr["actual_cmc"].ToString();
                    dataGridView1.Rows[i].Cells[23].Value = dr["cmc_remakrs"].ToString();
                    dataGridView1.Rows[i].Cells[24].Value = dr["cmc_status"].ToString();
                    dataGridView1.Rows[i].Cells[25].Value = dr["highlight_req"].ToString();
                    dataGridView1.Rows[i].Cells[26].Value = dr["actual_highlight"].ToString();
                    dataGridView1.Rows[i].Cells[27].Value = dr["highlight_remakrs"].ToString();
                    dataGridView1.Rows[i].Cells[28].Value = dr["highlight_status"].ToString();
                    dataGridView1.Rows[i].Cells[29].Value = dr["stitiching_req"].ToString();
                    dataGridView1.Rows[i].Cells[30].Value = dr["stitiching_actual"].ToString();
                    dataGridView1.Rows[i].Cells[31].Value = dr["stitichign_remarks"].ToString();
                    dataGridView1.Rows[i].Cells[32].Value = dr["stitiching_status"].ToString();
                }
            }

            else if (comboBox1.Text == "STITICHING")
            {
                dataGridView1.Rows.Clear();
                MySqlDataAdapter da = new MySqlDataAdapter("select * from product_code_routing_date where stitiching_req='" + maskedTextBox1.Text + "' and final_status='OPEN'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = dr["id"].ToString();
                    dataGridView1.Rows[i].Cells[1].Value = dr["product_code"].ToString();
                    dataGridView1.Rows[i].Cells[2].Value = dr["component"].ToString();
                    dataGridView1.Rows[i].Cells[3].Value = dr["desinger"].ToString();
                    dataGridView1.Rows[i].Cells[4].Value = dr["stating_date"].ToString();
                    dataGridView1.Rows[i].Cells[5].Value = dr["fabric_req"].ToString();
                    dataGridView1.Rows[i].Cells[6].Value = dr["actual_fabric"].ToString();
                    dataGridView1.Rows[i].Cells[7].Value = dr["fab_remarks"].ToString();
                    dataGridView1.Rows[i].Cells[8].Value = dr["fab_status"].ToString();
                    dataGridView1.Rows[i].Cells[9].Value = dr["dye_req"].ToString();
                    dataGridView1.Rows[i].Cells[10].Value = dr["actual_dye"].ToString();
                    dataGridView1.Rows[i].Cells[11].Value = dr["dye_remarks"].ToString();
                    dataGridView1.Rows[i].Cells[12].Value = dr["dye_status"].ToString();
                    dataGridView1.Rows[i].Cells[13].Value = dr["print_req"].ToString();
                    dataGridView1.Rows[i].Cells[14].Value = dr["actual_print"].ToString();
                    dataGridView1.Rows[i].Cells[15].Value = dr["print_remakrs"].ToString();
                    dataGridView1.Rows[i].Cells[16].Value = dr["print_status"].ToString();
                    dataGridView1.Rows[i].Cells[17].Value = dr["over_dye_req"].ToString();
                    dataGridView1.Rows[i].Cells[18].Value = dr["over_dye_actual"].ToString();
                    dataGridView1.Rows[i].Cells[19].Value = dr["over_dye_remaks"].ToString();
                    dataGridView1.Rows[i].Cells[20].Value = dr["over_dye_status"].ToString();
                    dataGridView1.Rows[i].Cells[21].Value = dr["cmc_req"].ToString();
                    dataGridView1.Rows[i].Cells[22].Value = dr["actual_cmc"].ToString();
                    dataGridView1.Rows[i].Cells[23].Value = dr["cmc_remakrs"].ToString();
                    dataGridView1.Rows[i].Cells[24].Value = dr["cmc_status"].ToString();
                    dataGridView1.Rows[i].Cells[25].Value = dr["highlight_req"].ToString();
                    dataGridView1.Rows[i].Cells[26].Value = dr["actual_highlight"].ToString();
                    dataGridView1.Rows[i].Cells[27].Value = dr["highlight_remakrs"].ToString();
                    dataGridView1.Rows[i].Cells[28].Value = dr["highlight_status"].ToString();
                    dataGridView1.Rows[i].Cells[29].Value = dr["stitiching_req"].ToString();
                    dataGridView1.Rows[i].Cells[30].Value = dr["stitiching_actual"].ToString();
                    dataGridView1.Rows[i].Cells[31].Value = dr["stitichign_remarks"].ToString();
                    dataGridView1.Rows[i].Cells[32].Value = dr["stitiching_status"].ToString();
                }
            }
            else
            {
                fill_data();
            }
        }
    }
}
