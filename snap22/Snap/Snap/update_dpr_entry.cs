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
    public partial class update_dpr_entry : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public update_dpr_entry()
        {
            InitializeComponent();
        }

        private void update_dpr_entry_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            fill_combobox();
            auto_complete_order_number();
            auto_complete_gate_number();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public void fill_combobox()
        {
            comboBox1.Items.Clear();
            MySqlDataAdapter da = new MySqlDataAdapter("select unit_name from emb_unit where type='IN-HOUSE' ", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                comboBox1.Items.Add(dr["unit_name"].ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text == "")
            {
                MessageBox.Show("Enter Date");
            }
            else
            {
                dataGridView1.Rows.Clear();
                fill_datagride_view();
            }
        }

        public void fill_datagride_view()
        {
            MySqlDataAdapter da = new MySqlDataAdapter("select * from dpr_entry where date='" + maskedTextBox1.Text + "' AND unit='"+comboBox1.Text+"' ", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = dr["gate_number"].ToString();
                dataGridView1.Rows[i].Cells[1].Value = dr["karigar_name"].ToString();
                dataGridView1.Rows[i].Cells[2].Value = dr["order_number"].ToString();
                dataGridView1.Rows[i].Cells[3].Value = dr["component"].ToString();
                dataGridView1.Rows[i].Cells[4].Value = dr["start1"].ToString();
                dataGridView1.Rows[i].Cells[5].Value = dr["end1"].ToString();
                dataGridView1.Rows[i].Cells[6].Value = dr["start2"].ToString();
                dataGridView1.Rows[i].Cells[7].Value = dr["end2"].ToString();
                dataGridView1.Rows[i].Cells[8].Value = dr["start3"].ToString();
                dataGridView1.Rows[i].Cells[9].Value = dr["end3"].ToString();
                dataGridView1.Rows[i].Cells[10].Value = dr["start4"].ToString();
                dataGridView1.Rows[i].Cells[11].Value = dr["end4"].ToString();
                dataGridView1.Rows[i].Cells[12].Value = dr["total_time"].ToString();
                dataGridView1.Rows[i].Cells[13].Value = dr["id"].ToString();
            }
        }

        int id_value = 0;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                id_value = System.Convert.ToInt32(row.Cells["id"].Value.ToString());
                textBox1.Text = row.Cells["order_number"].Value.ToString();
                textBox5.Text = row.Cells["gate_number"].Value.ToString();
                textBox2.Text = row.Cells["Karigar_name"].Value.ToString();
                textBox6.Text = row.Cells["Component"].Value.ToString();
                maskedTextBox2.Text = row.Cells["start1"].Value.ToString();
                maskedTextBox3.Text = row.Cells["end1"].Value.ToString();
                maskedTextBox4.Text = row.Cells["start2"].Value.ToString();
                maskedTextBox5.Text = row.Cells["end2"].Value.ToString();
                maskedTextBox6.Text = row.Cells["start3"].Value.ToString();
                maskedTextBox7.Text = row.Cells["end3"].Value.ToString();
                maskedTextBox8.Text = row.Cells["start4"].Value.ToString();
                maskedTextBox9.Text = row.Cells["end4"].Value.ToString();
            }
        }

        public void auto_complete_order_number()
        {
            MySqlCommand cmd = new MySqlCommand("select order_number from emb_order where order_number like '%" + textBox1.Text + "%'", con);
            MySqlDataReader dr = cmd.ExecuteReader();
            AutoCompleteStringCollection mycollection = new AutoCompleteStringCollection();
            while (dr.Read())
            {
                mycollection.Add(dr.GetString(0));
            }
            textBox1.AutoCompleteCustomSource = mycollection;
            dr.Close();
        }
        public void auto_complete_gate_number()
        {
            MySqlCommand cmd = new MySqlCommand("select gate_number from karigar_master where gate_number like '%" + textBox5.Text + "%' and unit='" + comboBox1.Text + "'", con);
            MySqlDataReader dr = cmd.ExecuteReader();
            AutoCompleteStringCollection mycollection = new AutoCompleteStringCollection();
            while (dr.Read())
            {
                mycollection.Add(dr.GetString(0));
            }
            textBox5.AutoCompleteCustomSource = mycollection;
            dr.Close();
        }

        public void time_calculation()
        {
            TimeSpan start1 = TimeSpan.Parse(maskedTextBox2.Text);
            TimeSpan end1 = TimeSpan.Parse(maskedTextBox3.Text);
            TimeSpan slot1 = end1.Subtract(start1);
            TimeSpan start2 = TimeSpan.Parse(maskedTextBox4.Text);
            TimeSpan end2 = TimeSpan.Parse(maskedTextBox5.Text);
            TimeSpan slot2 = end2.Subtract(start2);
            TimeSpan start3 = TimeSpan.Parse(maskedTextBox6.Text);
            TimeSpan end3 = TimeSpan.Parse(maskedTextBox7.Text);
            TimeSpan slot3 = end3.Subtract(start3);
            TimeSpan start4 = TimeSpan.Parse(maskedTextBox8.Text);
            TimeSpan end4 = TimeSpan.Parse(maskedTextBox9.Text);
            TimeSpan slot4 = end4.Subtract(start4);
            TimeSpan final_time = slot1 + slot2 + slot3 + slot4;
            string diff = final_time.Hours.ToString("00") + ":" + final_time.Minutes.ToString("00");
            textBox3.Text = diff.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            time_calculation();
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update dpr_entry set order_number='" + textBox1.Text + "',date='" + maskedTextBox1.Text + "',gate_number='" + textBox5.Text + "',karigar_name='" + textBox2.Text + "',unit='" + comboBox1.Text + "',component='" + textBox6.Text + "',start1='" + maskedTextBox2.Text + "',end1='" + maskedTextBox3.Text + "',start2='" + maskedTextBox4.Text + "',end2='" + maskedTextBox5.Text + "',start3='" + maskedTextBox6.Text + "',end3='" + maskedTextBox7.Text + "',start4='" + maskedTextBox8.Text + "',end4='" + maskedTextBox9.Text + "',total_time='" + textBox3.Text + "' where id='" + id_value + "'";
            cmd.ExecuteNonQuery();


            dataGridView1.Rows.Clear();
            fill_datagride_view();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (id_value == 0)
            {
                MessageBox.Show("Select the row to delete");
            }
            else
            {
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from dpr_entry where id='" + id_value + "'";
                cmd.ExecuteNonQuery();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox5.Clear();
                textBox6.Clear();
                maskedTextBox2.Clear();
                maskedTextBox3.Clear();
                maskedTextBox4.Clear();
                maskedTextBox5.Clear();
                maskedTextBox6.Clear();
                maskedTextBox7.Clear();
                maskedTextBox8.Clear();
                maskedTextBox9.Clear();
                dataGridView1.Rows.Clear();
                fill_datagride_view();
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            MySqlDataAdapter da = new MySqlDataAdapter("select name from karigar_master where gate_number='" + textBox5.Text + "' and unit='" + comboBox1.Text + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                textBox2.Text = dr["name"].ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for(int i=0;i<dataGridView1.Rows.Count;i++)
            {
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update dpr_entry set date='" + maskedTextBox10.Text + "' where id='" + dataGridView1.Rows[i].Cells[13].Value + "'";
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Date Updateed");
            dataGridView1.Rows.Clear();
            maskedTextBox1.Text = maskedTextBox10.Text;
            fill_datagride_view();
        }
    }
}
