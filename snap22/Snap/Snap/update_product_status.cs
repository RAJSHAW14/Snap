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
    public partial class update_product_status : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public update_product_status()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void update_product_status_Load(object sender, EventArgs e)
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }

        public void fill_data()
        {
            MySqlDataAdapter da = new MySqlDataAdapter("select * from product_code_routing_date where id='" + textBox11.Text + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                textBox1.Text = dr["product_code"].ToString();
                textBox2.Text = dr["desinger"].ToString();
                textBox3.Text = dr["color"].ToString();
                textBox4.Text = dr["fabric_req"].ToString();
                maskedTextBox1.Text = dr["actual_fabric"].ToString();
                comboBox1.Text = dr["fab_status"].ToString();
                richTextBox1.Text = dr["fab_remarks"].ToString();
                textBox5.Text = dr["dye_req"].ToString();
                maskedTextBox2.Text = dr["actual_dye"].ToString();
                comboBox2.Text = dr["dye_status"].ToString();
                richTextBox2.Text = dr["dye_remarks"].ToString();
                textBox6.Text = dr["print_req"].ToString();
                maskedTextBox3.Text = dr["actual_print"].ToString();
                comboBox3.Text = dr["print_status"].ToString();
                richTextBox3.Text = dr["print_remakrs"].ToString();
                textBox7.Text = dr["over_dye_req"].ToString();
                maskedTextBox4.Text = dr["over_dye_actual"].ToString();
                comboBox4.Text = dr["over_dye_status"].ToString();
                richTextBox4.Text = dr["over_dye_remaks"].ToString();
                textBox8.Text = dr["cmc_req"].ToString();
                maskedTextBox5.Text = dr["actual_cmc"].ToString();
                comboBox5.Text = dr["cmc_status"].ToString();
                richTextBox5.Text = dr["cmc_remakrs"].ToString();
                textBox9.Text = dr["highlight_req"].ToString();
                maskedTextBox6.Text = dr["actual_highlight"].ToString();
                comboBox6.Text = dr["highlight_status"].ToString();
                richTextBox6.Text = dr["highlight_remakrs"].ToString();
                textBox10.Text = dr["stitiching_req"].ToString();
                maskedTextBox7.Text = dr["stitiching_actual"].ToString();
                comboBox7.Text = dr["stitiching_status"].ToString();
                richTextBox7.Text = dr["stitichign_remarks"].ToString();
                textBox12.Text = dr["style_code"].ToString();
                comboBox8.Text = dr["final_status"].ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update product_code_routing_date set actual_fabric='" + maskedTextBox1.Text + "',fab_remarks='" + richTextBox1.Text + "',fab_status='" + comboBox1.Text + "',actual_dye='" + maskedTextBox2.Text + "',dye_remarks='" + richTextBox2.Text + "',dye_status='" + comboBox2.Text + "',actual_print='" + maskedTextBox3.Text + "',print_remakrs='" + richTextBox3.Text + "',print_status='" + comboBox3.Text + "',over_dye_actual='" + maskedTextBox4.Text + "',over_dye_remaks='" + richTextBox4.Text + "',over_dye_status='" + comboBox4.Text + "',actual_cmc='" + maskedTextBox5.Text + "',cmc_remakrs='" + richTextBox5.Text + "',cmc_status='" + comboBox5.Text + "',actual_highlight='" + maskedTextBox6.Text + "',highlight_remakrs='" + richTextBox6.Text + "',highlight_status='" + comboBox6.Text + "',stitiching_actual='" + maskedTextBox7.Text + "',stitichign_remarks='" + richTextBox7.Text + "',stitiching_status='" + comboBox7.Text + "',final_status='" + comboBox8.Text + "' where id='" + textBox11.Text + "'";
            cmd.ExecuteNonQuery();
            MessageBox.Show("Data Updated");
            product_status_view view = new product_status_view();
            view.dataGridView1.Rows.Clear();
            view.fill_data();            
        }
    }
}
