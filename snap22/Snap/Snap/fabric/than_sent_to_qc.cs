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
    public partial class than_sent_to_qc : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public than_sent_to_qc()
        {
            InitializeComponent();
        }

        private void than_sent_to_qc_Load(object sender, EventArgs e)
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }

        string id_value = "";
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                id_value = row.Cells["id"].Value.ToString();
            }
        }

        public void fill_data()
        {
            MySqlDataAdapter da = new MySqlDataAdapter("select * from fabric_than_details_view Where status='RECEIVE'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells["id"].Value = dr["id"].ToString();
                dataGridView1.Rows[i].Cells["fabric_code"].Value = dr["fabric_code"].ToString();
                dataGridView1.Rows[i].Cells["than_number"].Value = dr["than_number"].ToString();
                dataGridView1.Rows[i].Cells["than_qty"].Value = dr["than_qty"].ToString();
                dataGridView1.Rows[i].Cells["vendor"].Value = dr["vendor"].ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(id_value=="")
            {
                MessageBox.Show("Please select the cell to sent to qc", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update fabric_than_details set status='SENT TO QC' where id='" + id_value.ToString() + "'";
                cmd.ExecuteNonQuery();

                MessageBox.Show("Item Sent to QC", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.Rows.Clear();
                fill_data();
            }
        }
    }
}
