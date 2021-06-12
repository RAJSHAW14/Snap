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
    public partial class emb_inhouse_List : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public emb_inhouse_List()
        {
            InitializeComponent();
        }

        private void emb_inhouse_List_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            fill_datagrid();
        }
        public void fill_datagrid()
        {
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from emb_tracker where order_type='IN-HOUSE'";
            cmd.ExecuteNonQuery();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = dr["id"].ToString();
                dataGridView1.Rows[i].Cells[1].Value = dr["order_number"].ToString();
                dataGridView1.Rows[i].Cells[2].Value = dr["date"].ToString();
                dataGridView1.Rows[i].Cells[3].Value = dr["batchcode"].ToString();
                dataGridView1.Rows[i].Cells[4].Value = dr["v_emb_code"].ToString();
                dataGridView1.Rows[i].Cells[5].Value = dr["karigar_name"].ToString();
                dataGridView1.Rows[i].Cells[6].Value = dr["designer"].ToString();
                dataGridView1.Rows[i].Cells[7].Value = dr["design_code"].ToString();
                dataGridView1.Rows[i].Cells[8].Value = dr["design_description"].ToString();
                dataGridView1.Rows[i].Cells[9].Value = dr["emb_unit"].ToString();
                dataGridView1.Rows[i].Cells[10].Value = dr["no_of_p_code"].ToString();
                dataGridView1.Rows[i].Cells[11].Value = dr["item"].ToString();
                dataGridView1.Rows[i].Cells[12].Value = dr["fabric"].ToString();
                dataGridView1.Rows[i].Cells[13].Value = dr["fab_qty_detail"].ToString();
                dataGridView1.Rows[i].Cells[14].Value = dr["meter"].ToString();
                dataGridView1.Rows[i].Cells[15].Value = dr["pieces"].ToString();
                dataGridView1.Rows[i].Cells[16].Value = dr["set"].ToString();
                dataGridView1.Rows[i].Cells[17].Value = dr["line_1"].ToString();
                dataGridView1.Rows[i].Cells[18].Value = dr["inch_1"].ToString();
                dataGridView1.Rows[i].Cells[19].Value = dr["inch_2"].ToString();
                dataGridView1.Rows[i].Cells[20].Value = dr["inch_3"].ToString();
                dataGridView1.Rows[i].Cells[21].Value = dr["item_qty"].ToString();
                dataGridView1.Rows[i].Cells[22].Value = dr["total_job_issue"].ToString();
                dataGridView1.Rows[i].Cells[23].Value = dr["item_pending_qty"].ToString();
                dataGridView1.Rows[i].Cells[24].Value = dr["pending_job_issue"].ToString();
                dataGridView1.Rows[i].Cells[25].Value = dr["status"].ToString();
                dataGridView1.Rows[i].Cells[26].Value = dr["rate"].ToString();
                dataGridView1.Rows[i].Cells[27].Value = dr["rate_type"].ToString();
                dataGridView1.Rows[i].Cells[28].Value = dr["amount"].ToString();
                dataGridView1.Rows[i].Cells[29].Value = dr["lead_time"].ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            inhouse_order_cart inhouse = new inhouse_order_cart();
            inhouse.button3.Enabled = false;
            inhouse.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (id_value == 0)
            {
                MessageBox.Show("Please select the Order number");
            }
            else
            {
                int i = 0;
                MySqlDataAdapter da = new MySqlDataAdapter("select * from emb_receive where order_id='" + id_value + "'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                i = System.Convert.ToInt32(dt.Rows.Count.ToString());
                if (i == 0)
                {
                    inhouse_order_cart cart = new inhouse_order_cart();
                    cart.button2.Enabled = false;
                    cart.textBox19.Text = id_value.ToString();
                    cart.fetch_all_details();
                    cart.Show();
                }
                else
                {
                    MessageBox.Show("You Already Receive against Order Edit Not Allow");
                }
            }
        }

        int id_value = 0;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                id_value = System.Convert.ToInt32(row.Cells["id"].Value.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.Text = "Please Wait....";
            button4.Enabled = false;
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            app.Visible = true;
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            worksheet.Name = "Exported from gridview";
            for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                }
            }
            button4.Text = "EXPORT";
            button4.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(comboBox1.Text=="")
            {
                MessageBox.Show("Enter Filter Type");
            }
            else if(comboBox1.Text== "ORDER NUMBER")
            {
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from emb_tracker where order_number like '%"+textBox1.Text+"%' and order_type='IN-HOUSE'";
                cmd.ExecuteNonQuery();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = dr["id"].ToString();
                    dataGridView1.Rows[i].Cells[1].Value = dr["order_number"].ToString();
                    dataGridView1.Rows[i].Cells[2].Value = dr["date"].ToString();
                    dataGridView1.Rows[i].Cells[3].Value = dr["batchcode"].ToString();
                    dataGridView1.Rows[i].Cells[4].Value = dr["v_emb_code"].ToString();
                    dataGridView1.Rows[i].Cells[5].Value = dr["karigar_name"].ToString();
                    dataGridView1.Rows[i].Cells[6].Value = dr["designer"].ToString();
                    dataGridView1.Rows[i].Cells[7].Value = dr["design_code"].ToString();
                    dataGridView1.Rows[i].Cells[8].Value = dr["design_description"].ToString();
                    dataGridView1.Rows[i].Cells[9].Value = dr["emb_unit"].ToString();
                    dataGridView1.Rows[i].Cells[10].Value = dr["no_of_p_code"].ToString();
                    dataGridView1.Rows[i].Cells[11].Value = dr["item"].ToString();
                    dataGridView1.Rows[i].Cells[12].Value = dr["fabric"].ToString();
                    dataGridView1.Rows[i].Cells[13].Value = dr["fab_qty_detail"].ToString();
                    dataGridView1.Rows[i].Cells[14].Value = dr["meter"].ToString();
                    dataGridView1.Rows[i].Cells[15].Value = dr["pieces"].ToString();
                    dataGridView1.Rows[i].Cells[16].Value = dr["set"].ToString();
                    dataGridView1.Rows[i].Cells[17].Value = dr["line_1"].ToString();
                    dataGridView1.Rows[i].Cells[18].Value = dr["inch_1"].ToString();
                    dataGridView1.Rows[i].Cells[19].Value = dr["inch_2"].ToString();
                    dataGridView1.Rows[i].Cells[20].Value = dr["inch_3"].ToString();
                    dataGridView1.Rows[i].Cells[21].Value = dr["item_qty"].ToString();
                    dataGridView1.Rows[i].Cells[22].Value = dr["total_job_issue"].ToString();
                    dataGridView1.Rows[i].Cells[23].Value = dr["item_pending_qty"].ToString();
                    dataGridView1.Rows[i].Cells[24].Value = dr["pending_job_issue"].ToString();
                    dataGridView1.Rows[i].Cells[25].Value = dr["status"].ToString();
                    dataGridView1.Rows[i].Cells[26].Value = dr["rate"].ToString();
                    dataGridView1.Rows[i].Cells[27].Value = dr["rate_type"].ToString();
                    dataGridView1.Rows[i].Cells[28].Value = dr["amount"].ToString();
                    dataGridView1.Rows[i].Cells[29].Value = dr["lead_time"].ToString();
                }
            }
            else if (comboBox1.Text == "DATE")
            {
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from emb_tracker where date like '%" + textBox1.Text + "%' and order_type='IN-HOUSE'";
                cmd.ExecuteNonQuery();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = dr["id"].ToString();
                    dataGridView1.Rows[i].Cells[1].Value = dr["order_number"].ToString();
                    dataGridView1.Rows[i].Cells[2].Value = dr["date"].ToString();
                    dataGridView1.Rows[i].Cells[3].Value = dr["batchcode"].ToString();
                    dataGridView1.Rows[i].Cells[4].Value = dr["v_emb_code"].ToString();
                    dataGridView1.Rows[i].Cells[5].Value = dr["karigar_name"].ToString();
                    dataGridView1.Rows[i].Cells[6].Value = dr["designer"].ToString();
                    dataGridView1.Rows[i].Cells[7].Value = dr["design_code"].ToString();
                    dataGridView1.Rows[i].Cells[8].Value = dr["design_description"].ToString();
                    dataGridView1.Rows[i].Cells[9].Value = dr["emb_unit"].ToString();
                    dataGridView1.Rows[i].Cells[10].Value = dr["no_of_p_code"].ToString();
                    dataGridView1.Rows[i].Cells[11].Value = dr["item"].ToString();
                    dataGridView1.Rows[i].Cells[12].Value = dr["fabric"].ToString();
                    dataGridView1.Rows[i].Cells[13].Value = dr["fab_qty_detail"].ToString();
                    dataGridView1.Rows[i].Cells[14].Value = dr["meter"].ToString();
                    dataGridView1.Rows[i].Cells[15].Value = dr["pieces"].ToString();
                    dataGridView1.Rows[i].Cells[16].Value = dr["set"].ToString();
                    dataGridView1.Rows[i].Cells[17].Value = dr["line_1"].ToString();
                    dataGridView1.Rows[i].Cells[18].Value = dr["inch_1"].ToString();
                    dataGridView1.Rows[i].Cells[19].Value = dr["inch_2"].ToString();
                    dataGridView1.Rows[i].Cells[20].Value = dr["inch_3"].ToString();
                    dataGridView1.Rows[i].Cells[21].Value = dr["item_qty"].ToString();
                    dataGridView1.Rows[i].Cells[22].Value = dr["total_job_issue"].ToString();
                    dataGridView1.Rows[i].Cells[23].Value = dr["item_pending_qty"].ToString();
                    dataGridView1.Rows[i].Cells[24].Value = dr["pending_job_issue"].ToString();
                    dataGridView1.Rows[i].Cells[25].Value = dr["status"].ToString();
                    dataGridView1.Rows[i].Cells[26].Value = dr["rate"].ToString();
                    dataGridView1.Rows[i].Cells[27].Value = dr["rate_type"].ToString();
                    dataGridView1.Rows[i].Cells[28].Value = dr["amount"].ToString();
                    dataGridView1.Rows[i].Cells[29].Value = dr["lead_time"].ToString();
                }
            }

            else if (comboBox1.Text == "BATCHCODE")
            {
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from emb_tracker where batchcode like '%" + textBox1.Text + "%' and order_type='IN-HOUSE'";
                cmd.ExecuteNonQuery();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = dr["id"].ToString();
                    dataGridView1.Rows[i].Cells[1].Value = dr["order_number"].ToString();
                    dataGridView1.Rows[i].Cells[2].Value = dr["date"].ToString();
                    dataGridView1.Rows[i].Cells[3].Value = dr["batchcode"].ToString();
                    dataGridView1.Rows[i].Cells[4].Value = dr["v_emb_code"].ToString();
                    dataGridView1.Rows[i].Cells[5].Value = dr["karigar_name"].ToString();
                    dataGridView1.Rows[i].Cells[6].Value = dr["designer"].ToString();
                    dataGridView1.Rows[i].Cells[7].Value = dr["design_code"].ToString();
                    dataGridView1.Rows[i].Cells[8].Value = dr["design_description"].ToString();
                    dataGridView1.Rows[i].Cells[9].Value = dr["emb_unit"].ToString();
                    dataGridView1.Rows[i].Cells[10].Value = dr["no_of_p_code"].ToString();
                    dataGridView1.Rows[i].Cells[11].Value = dr["item"].ToString();
                    dataGridView1.Rows[i].Cells[12].Value = dr["fabric"].ToString();
                    dataGridView1.Rows[i].Cells[13].Value = dr["fab_qty_detail"].ToString();
                    dataGridView1.Rows[i].Cells[14].Value = dr["meter"].ToString();
                    dataGridView1.Rows[i].Cells[15].Value = dr["pieces"].ToString();
                    dataGridView1.Rows[i].Cells[16].Value = dr["set"].ToString();
                    dataGridView1.Rows[i].Cells[17].Value = dr["line_1"].ToString();
                    dataGridView1.Rows[i].Cells[18].Value = dr["inch_1"].ToString();
                    dataGridView1.Rows[i].Cells[19].Value = dr["inch_2"].ToString();
                    dataGridView1.Rows[i].Cells[20].Value = dr["inch_3"].ToString();
                    dataGridView1.Rows[i].Cells[21].Value = dr["item_qty"].ToString();
                    dataGridView1.Rows[i].Cells[22].Value = dr["total_job_issue"].ToString();
                    dataGridView1.Rows[i].Cells[23].Value = dr["item_pending_qty"].ToString();
                    dataGridView1.Rows[i].Cells[24].Value = dr["pending_job_issue"].ToString();
                    dataGridView1.Rows[i].Cells[25].Value = dr["status"].ToString();
                    dataGridView1.Rows[i].Cells[26].Value = dr["rate"].ToString();
                    dataGridView1.Rows[i].Cells[27].Value = dr["rate_type"].ToString();
                    dataGridView1.Rows[i].Cells[28].Value = dr["amount"].ToString();
                    dataGridView1.Rows[i].Cells[29].Value = dr["lead_time"].ToString();
                }
            }
            else if (comboBox1.Text == "KARIGAR NAME")
            {
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from emb_tracker where karigar_name like '%" + textBox1.Text + "%' and order_type='IN-HOUSE'";
                cmd.ExecuteNonQuery();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = dr["id"].ToString();
                    dataGridView1.Rows[i].Cells[1].Value = dr["order_number"].ToString();
                    dataGridView1.Rows[i].Cells[2].Value = dr["date"].ToString();
                    dataGridView1.Rows[i].Cells[3].Value = dr["batchcode"].ToString();
                    dataGridView1.Rows[i].Cells[4].Value = dr["v_emb_code"].ToString();
                    dataGridView1.Rows[i].Cells[5].Value = dr["karigar_name"].ToString();
                    dataGridView1.Rows[i].Cells[6].Value = dr["designer"].ToString();
                    dataGridView1.Rows[i].Cells[7].Value = dr["design_code"].ToString();
                    dataGridView1.Rows[i].Cells[8].Value = dr["design_description"].ToString();
                    dataGridView1.Rows[i].Cells[9].Value = dr["emb_unit"].ToString();
                    dataGridView1.Rows[i].Cells[10].Value = dr["no_of_p_code"].ToString();
                    dataGridView1.Rows[i].Cells[11].Value = dr["item"].ToString();
                    dataGridView1.Rows[i].Cells[12].Value = dr["fabric"].ToString();
                    dataGridView1.Rows[i].Cells[13].Value = dr["fab_qty_detail"].ToString();
                    dataGridView1.Rows[i].Cells[14].Value = dr["meter"].ToString();
                    dataGridView1.Rows[i].Cells[15].Value = dr["pieces"].ToString();
                    dataGridView1.Rows[i].Cells[16].Value = dr["set"].ToString();
                    dataGridView1.Rows[i].Cells[17].Value = dr["line_1"].ToString();
                    dataGridView1.Rows[i].Cells[18].Value = dr["inch_1"].ToString();
                    dataGridView1.Rows[i].Cells[19].Value = dr["inch_2"].ToString();
                    dataGridView1.Rows[i].Cells[20].Value = dr["inch_3"].ToString();
                    dataGridView1.Rows[i].Cells[21].Value = dr["item_qty"].ToString();
                    dataGridView1.Rows[i].Cells[22].Value = dr["total_job_issue"].ToString();
                    dataGridView1.Rows[i].Cells[23].Value = dr["item_pending_qty"].ToString();
                    dataGridView1.Rows[i].Cells[24].Value = dr["pending_job_issue"].ToString();
                    dataGridView1.Rows[i].Cells[25].Value = dr["status"].ToString();
                    dataGridView1.Rows[i].Cells[26].Value = dr["rate"].ToString();
                    dataGridView1.Rows[i].Cells[27].Value = dr["rate_type"].ToString();
                    dataGridView1.Rows[i].Cells[28].Value = dr["amount"].ToString();
                    dataGridView1.Rows[i].Cells[29].Value = dr["lead_time"].ToString();
                }
            }
            else if (comboBox1.Text == "DESIGN DESCRIPTION")
            {
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from emb_tracker where design_description like '%" + textBox1.Text + "%' and order_type='IN-HOUSE'";
                cmd.ExecuteNonQuery();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = dr["id"].ToString();
                    dataGridView1.Rows[i].Cells[1].Value = dr["order_number"].ToString();
                    dataGridView1.Rows[i].Cells[2].Value = dr["date"].ToString();
                    dataGridView1.Rows[i].Cells[3].Value = dr["batchcode"].ToString();
                    dataGridView1.Rows[i].Cells[4].Value = dr["v_emb_code"].ToString();
                    dataGridView1.Rows[i].Cells[5].Value = dr["karigar_name"].ToString();
                    dataGridView1.Rows[i].Cells[6].Value = dr["designer"].ToString();
                    dataGridView1.Rows[i].Cells[7].Value = dr["design_code"].ToString();
                    dataGridView1.Rows[i].Cells[8].Value = dr["design_description"].ToString();
                    dataGridView1.Rows[i].Cells[9].Value = dr["emb_unit"].ToString();
                    dataGridView1.Rows[i].Cells[10].Value = dr["no_of_p_code"].ToString();
                    dataGridView1.Rows[i].Cells[11].Value = dr["item"].ToString();
                    dataGridView1.Rows[i].Cells[12].Value = dr["fabric"].ToString();
                    dataGridView1.Rows[i].Cells[13].Value = dr["fab_qty_detail"].ToString();
                    dataGridView1.Rows[i].Cells[14].Value = dr["meter"].ToString();
                    dataGridView1.Rows[i].Cells[15].Value = dr["pieces"].ToString();
                    dataGridView1.Rows[i].Cells[16].Value = dr["set"].ToString();
                    dataGridView1.Rows[i].Cells[17].Value = dr["line_1"].ToString();
                    dataGridView1.Rows[i].Cells[18].Value = dr["inch_1"].ToString();
                    dataGridView1.Rows[i].Cells[19].Value = dr["inch_2"].ToString();
                    dataGridView1.Rows[i].Cells[20].Value = dr["inch_3"].ToString();
                    dataGridView1.Rows[i].Cells[21].Value = dr["item_qty"].ToString();
                    dataGridView1.Rows[i].Cells[22].Value = dr["total_job_issue"].ToString();
                    dataGridView1.Rows[i].Cells[23].Value = dr["item_pending_qty"].ToString();
                    dataGridView1.Rows[i].Cells[24].Value = dr["pending_job_issue"].ToString();
                    dataGridView1.Rows[i].Cells[25].Value = dr["status"].ToString();
                    dataGridView1.Rows[i].Cells[26].Value = dr["rate"].ToString();
                    dataGridView1.Rows[i].Cells[27].Value = dr["rate_type"].ToString();
                    dataGridView1.Rows[i].Cells[28].Value = dr["amount"].ToString();
                    dataGridView1.Rows[i].Cells[29].Value = dr["lead_time"].ToString();
                }
            }

            else
            {
                fill_datagrid();
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            
        }

        public void reload()
        {
            dataGridView1.Rows.Clear();
            fill_datagrid();
        }
    }
}
