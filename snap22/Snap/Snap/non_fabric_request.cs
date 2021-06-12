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
    public partial class non_fabric_request : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public non_fabric_request()
        {
            InitializeComponent();
        }

        private void non_fabric_request_Load(object sender, EventArgs e)
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            auto_complete();
            auto_complete_department();
            auto_complete_designer();
        }

        public void auto_complete()
        {
            MySqlCommand cmd = new MySqlCommand("select batchcode from batch_code_master", con);
            MySqlDataReader dr = cmd.ExecuteReader();
            AutoCompleteStringCollection autocomplete = new AutoCompleteStringCollection();
            while (dr.Read())
            {
                autocomplete.Add(dr.GetString(0));
            }
            textBox1.AutoCompleteCustomSource = autocomplete;
            dr.Close();
        }

        public AutoCompleteStringCollection AutoComplete_fabric_code()
        {
            MySqlCommand cmd = new MySqlCommand("select item_code from item where item_type='NON-FABRIC'", con);
            MySqlDataReader dr = cmd.ExecuteReader();
            AutoCompleteStringCollection mycoll = new AutoCompleteStringCollection();
            while (dr.Read())
            {
                mycoll.Add(dr["item_code"].ToString());
            }
            dr.Close();
            return mycoll;
        }

        public AutoCompleteStringCollection AutoComplete_component()
        {
            MySqlCommand cmd = new MySqlCommand("select component from component_master", con);
            MySqlDataReader dr = cmd.ExecuteReader();
            AutoCompleteStringCollection mycoll = new AutoCompleteStringCollection();
            while (dr.Read())
            {
                mycoll.Add(dr["component"].ToString());
            }
            dr.Close();
            return mycoll;
        }

        public void auto_complete_department()
        {
            MySqlCommand cmd = new MySqlCommand("select department_name from department", con);
            MySqlDataReader dr = cmd.ExecuteReader();
            AutoCompleteStringCollection autocomplete = new AutoCompleteStringCollection();
            while (dr.Read())
            {
                autocomplete.Add(dr.GetString(0));
            }
            textBox3.AutoCompleteCustomSource = autocomplete;
            dr.Close();
        }

        public void auto_complete_designer()
        {
            MySqlCommand cmd = new MySqlCommand("select desinger_name from designer_master", con);
            MySqlDataReader dr = cmd.ExecuteReader();
            AutoCompleteStringCollection autocomplete = new AutoCompleteStringCollection();
            while (dr.Read())
            {
                autocomplete.Add(dr.GetString(0));
            }
            textBox2.AutoCompleteCustomSource = autocomplete;
            dr.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            int column = dataGridView1.CurrentCell.ColumnIndex;
            string g = dataGridView1.Columns[column].HeaderText;
            if (g.Equals("Item Code"))
            {
                TextBox auto_text = e.Control as TextBox;
                if (auto_text != null)
                {
                    auto_text.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    auto_text.AutoCompleteCustomSource = AutoComplete_fabric_code();
                    auto_text.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }
            }
            else if (g.Equals("Component"))            
            {
                TextBox auto_text = e.Control as TextBox;
                if (auto_text != null)
                {
                    auto_text.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    auto_text.AutoCompleteCustomSource = AutoComplete_component();
                    auto_text.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }
            }

            else
            {
                TextBox auto_text = e.Control as TextBox;
                if (auto_text != null)
                {
                    auto_text.AutoCompleteMode = AutoCompleteMode.None;
                }
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    string newvalue;
                    newvalue = (dataGridView1[e.ColumnIndex, e.RowIndex].Value).ToString();
                    MySqlDataAdapter da = new MySqlDataAdapter("select item_name,uom from item where item_code='" + newvalue + "'", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.Rows[e.RowIndex].Cells[1].Value = dt.Rows[0][0].ToString();
                    dataGridView1.Rows[e.RowIndex].Cells[3].Value = dt.Rows[0][1].ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Choose Correct Item Code");
                dataGridView1.Rows[e.RowIndex].Cells[1].Value = "";
                dataGridView1.Rows[e.RowIndex].Cells[3].Value = "";
            }
        }

        public void clear()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            listBox1.Items.Clear();
            dataGridView1.Rows.Clear();
        }

        int max_request_id, next_request_id;

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            int i = 0;
            MySqlDataAdapter da = new MySqlDataAdapter("select * from batch_code_master where batchcode='" + textBox1.Text + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            i = System.Convert.ToInt32(dt.Rows.Count.ToString());
            if (i == 0)
            {
                MessageBox.Show("Enter the correct Batchcode");
            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    textBox2.Text = dr["designer"].ToString();
                    textBox3.Text = dr["department"].ToString();
                }

                MySqlDataAdapter da1 = new MySqlDataAdapter("select product_code from batchcode_id_product_code where batchcode='" + textBox1.Text+"'",con);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                listBox1.Items.Clear();
                foreach(DataRow dr in dt1.Rows)
                {
                    listBox1.Items.Add(dr["product_code"].ToString());
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to send the Request", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result==DialogResult.Yes)
            {
                MySqlDataAdapter da = new MySqlDataAdapter("select MAX(req_number) AS req_number from non_fabric_request", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    max_request_id = System.Convert.ToInt32(dr["req_number"].ToString());
                }
                next_request_id = max_request_id + 1;

                for(int i=0;i<dataGridView1.Rows.Count-1;i++)
                {
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into non_fabric_request (req_number,batchcode,department,designer,item_code,item_name,qty,unit,pending_qty,req_date,for_vendor,item) Values ('" + next_request_id + "','" + textBox1.Text + "','" + textBox3.Text + "','" + textBox2.Text + "','" + dataGridView1.Rows[i].Cells[0].Value + "','" + dataGridView1.Rows[i].Cells[1].Value + "','" + dataGridView1.Rows[i].Cells[2].Value + "','" + dataGridView1.Rows[i].Cells[3].Value + "','" + dataGridView1.Rows[i].Cells[2].Value + "','" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "','" + textBox4.Text + "','" + dataGridView1.Rows[i].Cells[4].Value + "')";
                    cmd.ExecuteNonQuery();
                }

                for(int j=0; j<listBox1.SelectedItems.Count; j++)
                {
                    MySqlCommand cmd1 = con.CreateCommand();
                    cmd1.CommandType = CommandType.Text;
                    cmd1.CommandText = "insert into non_fabric_p_code_request (req_number,product_code) Values ('"+next_request_id+"','"+listBox1.SelectedItems[j].ToString()+"')";
                    cmd1.ExecuteNonQuery();
                }

                MessageBox.Show("Request Send Sucessfully Your Request Number is "+ next_request_id);
                clear();
            }
        }
    }
}
