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
    public partial class final_qc : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public final_qc()
        {
            InitializeComponent();
        }

        private void final_qc_Load(object sender, EventArgs e)
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            maskedTextBox2.Text = DateTime.Today.ToString("dd-MM-yyyy");
        }

        public void fill_data()
        {
            MySqlDataAdapter da = new MySqlDataAdapter("select * from acc_qc_transaction_list where id_number='" + textBox8.Text + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = dr["id"].ToString();
                dataGridView1.Rows[i].Cells[1].Value = dr["check_list"].ToString();
                dataGridView1.Rows[i].Cells[2].Value = dr["parameter"].ToString();
                dataGridView1.Rows[i].Cells[3].Value = dr["d_remakrs"].ToString();
                dataGridView1.Rows[i].Cells[4].Value = dr["parameter"].ToString();
                textBox1.Text = dr["product_code"].ToString();
                richTextBox1.Text = dr["final_qc_remarks"].ToString();
                maskedTextBox1.Text = dr["date"].ToString();
                maskedTextBox2.Text=dr["final_qc_date"].ToString();
                textBox2.Text = dr["style_code"].ToString();
                textBox3.Text = dr["product"].ToString();
                textBox4.Text = dr["size"].ToString();
                textBox5.Text = dr["type"].ToString();
                textBox6.Text = dr["client_store"].ToString();
                textBox7.Text = dr["final_qc_person"].ToString();
                textBox9.Text = dr["color"].ToString();
                textBox10.Text = dr["client"].ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox7.Text=="")
            {
                MessageBox.Show("Enter QC Person Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult result = MessageBox.Show("Are You Sure Want to Approve This Item", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        MySqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "update acc_qc_transaction_list set qc_parameter='" + dataGridView1.Rows[i].Cells[4].Value + "',qc_remarks='" + dataGridView1.Rows[i].Cells[5].Value + "', final_status='APPROVED',d_status='APPROVED',final_qc_person='" + textBox7.Text + "',final_qc_remarks='" + richTextBox1.Text + "',final_qc_date='" + maskedTextBox2.Text + "' WHERE id='" + dataGridView1.Rows[i].Cells[0].Value + "'";
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Item Approved");
                    this.Close();
                }
                else
                {

                }
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are You Sure Want to Reject This Item", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "update acc_qc_transaction_list set qc_parameter='" + dataGridView1.Rows[i].Cells[4].Value + "',qc_remarks='" + dataGridView1.Rows[i].Cells[5].Value + "', final_status='REJECTED',final_qc_person='" + textBox7.Text + "',d_status='REJECTED',final_qc_remarks='" + richTextBox1.Text + "',final_qc_date='"+maskedTextBox2.Text+"' WHERE id='" + dataGridView1.Rows[i].Cells[0].Value + "'";
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Item Rejected");
                this.Close();
            }
            else
            {

            }
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
