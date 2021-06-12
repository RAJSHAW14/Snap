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
    public partial class po_cart : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public po_cart()
        {
            InitializeComponent();
        }

        private void po_cart_Load(object sender, EventArgs e)
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            auto_complete_vendor();
        }

        public void fill_data()
        {
            MySqlDataAdapter da = new MySqlDataAdapter("select * from fabric_po where po_number='"+textBox3.Text+"'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells["fabric_code"].Value = dr["fabric_code"].ToString();
                dataGridView1.Rows[i].Cells["fabric_name"].Value = dr["fabric_name"].ToString();
                dataGridView1.Rows[i].Cells["color"].Value = dr["color"].ToString();
                dataGridView1.Rows[i].Cells["rate"].Value = dr["rate"].ToString();
                dataGridView1.Rows[i].Cells["qty"].Value = dr["order_qty"].ToString();
                dataGridView1.Rows[i].Cells["amount"].Value = dr["amount"].ToString();
                dataGridView1.Rows[i].Cells["gst"].Value = dr["gst"].ToString();
                dataGridView1.Rows[i].Cells["hsn"].Value = dr["hsn"].ToString();
                dataGridView1.Rows[i].Cells["total_amt"].Value = dr["total_amt"].ToString();
                dataGridView1.Rows[i].Cells["lap_dip"].Value = dr["lap_dip"].ToString();
                dataGridView1.Rows[i].Cells["remakrs"].Value = dr["remarks"].ToString();
                dataGridView1.Rows[i].Cells["uom"].Value = dr["uom"].ToString();
                textBox1.Text = dr["po_number"].ToString();
                dateTimePicker1.Value = System.Convert.ToDateTime(dr["po_date"].ToString());
                maskedTextBox2.Text = dr["dod"].ToString();
                textBox2.Text = dr["vendor"].ToString();
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
            if (g.Equals("Fabric Code"))
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
                    MySqlDataAdapter da = new MySqlDataAdapter("select item_name,uom,unit_price,color,gst,hsn from item where item_code='" + newvalue + "'", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.Rows[e.RowIndex].Cells[1].Value = dt.Rows[0][0].ToString();
                    dataGridView1.Rows[e.RowIndex].Cells[2].Value = dt.Rows[0][3].ToString();
                    dataGridView1.Rows[e.RowIndex].Cells[3].Value = dt.Rows[0][2].ToString();
                    dataGridView1.Rows[e.RowIndex].Cells[5].Value = dt.Rows[0][1].ToString();
                    dataGridView1.Rows[e.RowIndex].Cells[7].Value = dt.Rows[0][4].ToString();
                    dataGridView1.Rows[e.RowIndex].Cells[8].Value = dt.Rows[0][5].ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Choose Correct Fabric code");
                dataGridView1.Rows[e.RowIndex].Cells[1].Value = "";
                dataGridView1.Rows[e.RowIndex].Cells[2].Value = "";
                dataGridView1.Rows[e.RowIndex].Cells[3].Value = "";
                dataGridView1.Rows[e.RowIndex].Cells[4].Value = "";
                dataGridView1.Rows[e.RowIndex].Cells[7].Value = "";
                dataGridView1.Rows[e.RowIndex].Cells[8].Value = "";
            }
            amount_calculation();
        }

        public void amount_calculation()
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Cells[dataGridView1.Columns[6].Index].Value = System.Convert.ToDouble(row.Cells[dataGridView1.Columns[3].Index].Value) * (System.Convert.ToDouble(row.Cells[dataGridView1.Columns[4].Index].Value));
                    row.Cells[dataGridView1.Columns[9].Index].Value = System.Convert.ToDouble(row.Cells[dataGridView1.Columns[6].Index].Value) * System.Convert.ToDouble(row.Cells[dataGridView1.Columns[7].Index].Value) / 100 + System.Convert.ToDouble(row.Cells[dataGridView1.Columns[6].Index].Value);
                }
                double sum_of_amt = 0;
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    sum_of_amt += System.Convert.ToDouble(dataGridView1.Rows[i].Cells[9].Value);
                }
                textBox4.Text = System.Convert.ToString(Math.Round(sum_of_amt, 2));
            }
            catch
            {

            }
        }

        private void dataGridView1_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            amount_calculation();
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            amount_calculation();
        }

        int max_number, next_number;
        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox2.Text=="")
            {
                MessageBox.Show("Enter The Vendor Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            else
            {
                MySqlDataAdapter da = new MySqlDataAdapter("select max(po_number) as po_number from fabric_po", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach(DataRow dr in dt.Rows)
                {
                    max_number = System.Convert.ToInt32(dr["po_number"].ToString());
                }
                next_number = max_number + 1;

                for (int j = 0; j < dataGridView1.Rows.Count - 1; j++)
                {
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into fabric_po (po_number,po_date,fabric_name,fabric_code,color,vendor,rate,order_qty,dod,amount,lap_dip,remarks,pending_qty,gst,hsn,total_amt,uom) Values ('" + next_number.ToString() + "','" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "','" + dataGridView1.Rows[j].Cells["fabric_name"].Value + "','" + dataGridView1.Rows[j].Cells["fabric_code"].Value + "','" + dataGridView1.Rows[j].Cells["color"].Value + "','" + textBox2.Text + "','" + dataGridView1.Rows[j].Cells["rate"].Value + "','" + dataGridView1.Rows[j].Cells["qty"].Value + "','" + maskedTextBox2.Text + "','" + dataGridView1.Rows[j].Cells["amount"].Value + "','" + dataGridView1.Rows[j].Cells["lap_dip"].Value + "','" + dataGridView1.Rows[j].Cells["remakrs"].Value + "','" + dataGridView1.Rows[j].Cells["qty"].Value + "','" + dataGridView1.Rows[j].Cells["gst"].Value + "','" + dataGridView1.Rows[j].Cells["hsn"].Value + "','" + dataGridView1.Rows[j].Cells["total_amt"].Value + "','" + dataGridView1.Rows[j].Cells["uom"].Value + "')";
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Purchase order Inserted Sucessfully. Your PO Number is " + next_number, "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("Enter The Vendor Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            else
            {
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from fabric_po where po_number='"+textBox3.Text+"'";
                cmd.ExecuteNonQuery();

                for (int j = 0; j < dataGridView1.Rows.Count - 1; j++)
                {
                    MySqlCommand cmd1 = con.CreateCommand();
                    cmd1.CommandType = CommandType.Text;
                    cmd1.CommandText = "insert into fabric_po (po_number,po_date,fabric_name,fabric_code,color,vendor,rate,order_qty,dod,amount,lap_dip,remarks,pending_qty,gst,hsn,total_amt,uom) Values ('" + textBox1.Text + "','" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "','" + dataGridView1.Rows[j].Cells["fabric_name"].Value + "','" + dataGridView1.Rows[j].Cells["fabric_code"].Value + "','" + dataGridView1.Rows[j].Cells["color"].Value + "','" + textBox2.Text + "','" + dataGridView1.Rows[j].Cells["rate"].Value + "','" + dataGridView1.Rows[j].Cells["qty"].Value + "','" + maskedTextBox2.Text + "','" + dataGridView1.Rows[j].Cells["amount"].Value + "','" + dataGridView1.Rows[j].Cells["lap_dip"].Value + "','" + dataGridView1.Rows[j].Cells["remakrs"].Value + "','" + dataGridView1.Rows[j].Cells["qty"].Value + "','" + dataGridView1.Rows[j].Cells["gst"].Value + "','" + dataGridView1.Rows[j].Cells["hsn"].Value + "','" + dataGridView1.Rows[j].Cells["total_amt"].Value + "','" + dataGridView1.Rows[j].Cells["uom"].Value + "')";
                    cmd1.ExecuteNonQuery();
                }

                MessageBox.Show("Purchase Order Updated Sucessfully", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }

        }

        public void auto_complete_vendor()
        {
            MySqlCommand cmd = new MySqlCommand("select vendor_name from vendor where vendor_type='FABRIC'", con);
            MySqlDataReader dr = cmd.ExecuteReader();
            AutoCompleteStringCollection autocomplete = new AutoCompleteStringCollection();
            while (dr.Read())
            {
                autocomplete.Add(dr.GetString(0));

            }
            textBox2.AutoCompleteCustomSource = autocomplete;
            dr.Close();
        }
    }
}
