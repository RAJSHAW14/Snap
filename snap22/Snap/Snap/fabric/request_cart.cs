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
    public partial class request_cart : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public request_cart()
        {
            InitializeComponent();
        }

        private void request_cart_Load(object sender, EventArgs e)
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            auto_complete_batch_code();
        }

        public void auto_complete_batch_code()
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
        
        string batch_id;
        private void textBox1_Leave(object sender, EventArgs e)
        {
            int i = 0;
            MySqlDataAdapter da = new MySqlDataAdapter("select * from batch_code_master where batchcode='" + textBox1.Text + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            i = System.Convert.ToInt32(dt.Rows.Count.ToString());
            if (i == 0)
            {
                MessageBox.Show("Batchcode not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    textBox2.Text = dr["department"].ToString();
                    textBox3.Text = dr["designer"].ToString();
                    batch_id = dr["id"].ToString();
                }
                MySqlDataAdapter da1 = new MySqlDataAdapter("select * from product_code_master where batcode_id='" + batch_id.ToString() + "'", con);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                listBox1.Items.Clear();
                foreach (DataRow dr in dt1.Rows)
                {
                    listBox1.Items.Add(dr["product_code"].ToString());
                }
            }
        }

        string prefix, f_y, req_number;
        int last_number,next_number;
        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;            
            i = System.Convert.ToInt32(listBox1.SelectedItems.Count.ToString());
            if(i==0)
            {
                MessageBox.Show("Product Code not Selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(textBox1.Text=="")
            {
                MessageBox.Show("Batchcode not Enter", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MySqlDataAdapter da = new MySqlDataAdapter("select * from no_series WHERE table_for = 'fabric_req'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach(DataRow dr in dt.Rows)
                {
                    prefix = dr["prefix"].ToString();
                    f_y = dr["f.y"].ToString();
                    last_number = System.Convert.ToInt32(dr["last_number"].ToString());
                }
                next_number = last_number + 1;
                req_number = prefix + "/" + next_number + "/" + f_y;
                
                for (int j = 0; j < dataGridView1.Rows.Count - 1; j++)
                {
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into fabric_requisition (req_number,batch_code,department,desinger,date,fabric_code,fabric_name,qty,uom,fab_qty_details,remarks,pending_qty) Values ('" + req_number.ToString() + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "','" + dataGridView1.Rows[j].Cells["item_code"].Value + "','" + dataGridView1.Rows[j].Cells["name"].Value + "','" + dataGridView1.Rows[j].Cells["qty"].Value + "','" + dataGridView1.Rows[j].Cells["UoM"].Value + "','" + dataGridView1.Rows[j].Cells["fab_qty_detail"].Value + "','" + dataGridView1.Rows[j].Cells["remarks"].Value + "','" + dataGridView1.Rows[j].Cells["qty"].Value + "')";
                    cmd.ExecuteNonQuery();
                }

                for (int j = 0; j < listBox1.SelectedItems.Count; j++)
                {
                    MySqlCommand cmd2 = con.CreateCommand();
                    cmd2.CommandType = CommandType.Text;
                    cmd2.CommandText = "insert into fabric_requisition_product (product_code,request_id) Values ('" + listBox1.SelectedItems[j].ToString() + "','" + req_number.ToString() + "')";
                    cmd2.ExecuteNonQuery();
                }

                MySqlCommand cmd3 = con.CreateCommand();
                cmd3.CommandType = CommandType.Text;
                cmd3.CommandText = "update no_series set last_number='" + next_number.ToString() + "' where table_for = 'fabric_req'";
                cmd3.ExecuteNonQuery();

                MessageBox.Show("Request Sent Sucessfully! Your Request number is "+req_number.ToString(), "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }            
        }

        public AutoCompleteStringCollection AutoComplete_item_Code()
        {
            MySqlCommand cmd = new MySqlCommand("select item_code from item where item_type='FABRIC'", con);
            MySqlDataReader dr = cmd.ExecuteReader();
            AutoCompleteStringCollection mycoll = new AutoCompleteStringCollection();
            while (dr.Read())
            {
                mycoll.Add(dr["item_code"].ToString());
            }
            dr.Close();
            return mycoll;
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            int column = dataGridView1.CurrentCell.ColumnIndex;
            string g = dataGridView1.Columns[column].HeaderText;
            if (g.Equals("Fabric code"))
            {
                TextBox auto_text = e.Control as TextBox;
                if (auto_text != null)
                {
                    auto_text.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    auto_text.AutoCompleteCustomSource = AutoComplete_item_Code();
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
                MessageBox.Show("Choose Correct Fabric code");
                dataGridView1.Rows[e.RowIndex].Cells[0].Value = "";
                dataGridView1.Rows[e.RowIndex].Cells[1].Value = "";
                dataGridView1.Rows[e.RowIndex].Cells[3].Value = "";
                
            }
        }
    }
}
