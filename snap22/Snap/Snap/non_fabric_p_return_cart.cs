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
    public partial class non_fabric_p_return_cart : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public non_fabric_p_return_cart()
        {
            InitializeComponent();
        }

        private void non_fabric_p_return_cart_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            maskedTextBox1.Text = DateTime.Now.ToString("dd/MM/yyyy");
            auto_complete();
        }

        public void delete_grn()
        {
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                MySqlCommand cmd2 = con.CreateCommand();
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "update item set inventory=inventory-'" + dataGridView1.Rows[i].Cells[5].Value + "' where item_code='" + dataGridView1.Rows[i].Cells[0].Value + "'";
                cmd2.ExecuteNonQuery();
            }
        }

        public void auto_complete()
        {
            MySqlCommand cmd = new MySqlCommand("select vendor_name from vendor", con);
            MySqlDataReader dr = cmd.ExecuteReader();
            AutoCompleteStringCollection autocomplete = new AutoCompleteStringCollection();
            while (dr.Read())
            {
                autocomplete.Add(dr.GetString(0));
            }
            textBox1.AutoCompleteCustomSource = autocomplete;
            dr.Close();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {

            }
            else
            {
                int i = 0;
                MySqlDataAdapter da = new MySqlDataAdapter("select * from vendor", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                i = System.Convert.ToInt32(dt.Rows.Count.ToString());
                if (i == 0)
                {
                    MessageBox.Show("Enter Correct Vendor Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                }
            }
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

        int max_request_id, next_request_id;
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Enter Vendor name");
            }
            else if (maskedTextBox1.Text == "")
            {
                MessageBox.Show("Enter RETURN Date");
            }
            else
            {
                MySqlDataAdapter da = new MySqlDataAdapter("select MAX(return_number) AS return_number from non_fabric_p_return_header", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    max_request_id = System.Convert.ToInt32(dr["return_number"].ToString());
                }
                next_request_id = max_request_id + 1;

                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into non_fabric_p_return_header (return_number,return_date,vendor,against_grn,against_bill_number,amount,remarks) Values ('" + next_request_id + "','" + maskedTextBox1.Text + "','" + textBox1.Text + "','" + textBox8.Text + "','" + textBox7.Text + "','" + textBox5.Text + "','" + richTextBox1.Text + "')";
                cmd.ExecuteNonQuery();

                for (int j = 0; j < dataGridView1.Rows.Count - 1; j++)
                {
                    MySqlCommand cmd1 = con.CreateCommand();
                    cmd1.CommandType = CommandType.Text;
                    cmd1.CommandText = "insert into non_fabric_p_return_line (return_number,item_code,name,sub_categories,unit,qty,rate,gst,hsn,total,amount) Values ('" + next_request_id + "','" + dataGridView1.Rows[j].Cells[0].Value + "','" + dataGridView1.Rows[j].Cells[1].Value + "','" + dataGridView1.Rows[j].Cells[2].Value + "','" + dataGridView1.Rows[j].Cells[3].Value + "','" + dataGridView1.Rows[j].Cells[5].Value + "','" + dataGridView1.Rows[j].Cells[4].Value + "','" + dataGridView1.Rows[j].Cells[7].Value + "','" + dataGridView1.Rows[j].Cells[8].Value + "','" + dataGridView1.Rows[j].Cells[9].Value + "','" + dataGridView1.Rows[j].Cells[6].Value + "')";
                    cmd1.ExecuteNonQuery();
                }

                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    MySqlCommand cmd2 = con.CreateCommand();
                    cmd2.CommandType = CommandType.Text;
                    cmd2.CommandText = "update item set inventory=inventory-'" + dataGridView1.Rows[i].Cells[5].Value + "' where item_code='" + dataGridView1.Rows[i].Cells[0].Value + "'";
                    cmd2.ExecuteNonQuery();
                }

                MessageBox.Show("PURCHASE RETURN SAVED YOUR NUMBER IS " + next_request_id, "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlDataAdapter da = new MySqlDataAdapter("select * from non_fabric_p_return_line where return_number='" + textBox6.Text + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                int i = dataGridView2.Rows.Add();
                dataGridView2.Rows[i].Cells[0].Value = dr["item_code"].ToString();
                dataGridView2.Rows[i].Cells[1].Value = dr["qty"].ToString();
            }

            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update non_fabric_p_return_header set vendor='" + textBox1.Text + "',return_date='" + maskedTextBox1.Text + "',against_grn='" + textBox8.Text + "',against_bill_number='" + textBox7.Text + "',amount='" + textBox5.Text + "',remarks='" + richTextBox1.Text + "' where return_number='" + textBox2.Text + "'";
            cmd.ExecuteNonQuery();

            for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
            {
                MySqlCommand cmd2 = con.CreateCommand();
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "update item set inventory=inventory+'" + dataGridView2.Rows[i].Cells[1].Value + "' where item_code='" + dataGridView2.Rows[i].Cells[0].Value + "'";
                cmd2.ExecuteNonQuery();
            }

            MySqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "delete from non_fabric_p_return_header where return_number='" + textBox2.Text + "'";
            cmd1.ExecuteNonQuery();

            for (int j = 0; j < dataGridView1.Rows.Count - 1; j++)
            {
                MySqlCommand cmd3 = con.CreateCommand();
                cmd3.CommandType = CommandType.Text;
                cmd3.CommandText = "insert into non_fabric_p_return_line (return_number,item_code,name,sub_categories,unit,qty,rate,gst,hsn,total,amount) Values ('" + textBox2.Text + "','" + dataGridView1.Rows[j].Cells[0].Value + "','" + dataGridView1.Rows[j].Cells[1].Value + "','" + dataGridView1.Rows[j].Cells[2].Value + "','" + dataGridView1.Rows[j].Cells[3].Value + "','" + dataGridView1.Rows[j].Cells[5].Value + "','" + dataGridView1.Rows[j].Cells[4].Value + "','" + dataGridView1.Rows[j].Cells[7].Value + "','" + dataGridView1.Rows[j].Cells[8].Value + "','" + dataGridView1.Rows[j].Cells[9].Value + "','" + dataGridView1.Rows[j].Cells[6].Value + "')";
                cmd3.ExecuteNonQuery();
            }

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                MySqlCommand cmd2 = con.CreateCommand();
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "update item set inventory=inventory+'" + dataGridView1.Rows[i].Cells[5].Value + "' where item_code='" + dataGridView1.Rows[i].Cells[0].Value + "'";
                cmd2.ExecuteNonQuery();
            }

            MessageBox.Show("Purchase Return Updated Sucessfully");
            this.Close();
        }

        public void datagride_fill_line()
        {
            MySqlDataAdapter da = new MySqlDataAdapter("select * from non_fabric_p_return_line where return_number='" + textBox6.Text + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = row["item_code"].ToString();
                dataGridView1.Rows[i].Cells[1].Value = row["name"].ToString();
                dataGridView1.Rows[i].Cells[2].Value = row["sub_categories"].ToString();
                dataGridView1.Rows[i].Cells[3].Value = row["unit"].ToString();
                dataGridView1.Rows[i].Cells[4].Value = row["rate"].ToString();
                dataGridView1.Rows[i].Cells[5].Value = row["qty"].ToString();
                dataGridView1.Rows[i].Cells[6].Value = row["amount"].ToString();
                dataGridView1.Rows[i].Cells[7].Value = row["gst"].ToString();
                dataGridView1.Rows[i].Cells[8].Value = row["hsn"].ToString();
                dataGridView1.Rows[i].Cells[9].Value = row["total"].ToString();               
            }
        }

        public void datagride_fill_header()
        {
            MySqlDataAdapter da = new MySqlDataAdapter("select * from non_fabric_p_return_header where return_number='" + textBox6.Text + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                textBox2.Text = dr["return_number"].ToString();
                maskedTextBox1.Text = dr["return_date"].ToString();
                textBox8.Text = dr["against_grn"].ToString();
                textBox1.Text = dr["vendor"].ToString();
                textBox7.Text = dr["against_bill_number"].ToString();
                richTextBox1.Text = dr["remarks"].ToString();
                textBox5.Text = dr["amount"].ToString();
            }
        }

        private void dataGridView1_EditingControlShowing_1(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            int column = dataGridView1.CurrentCell.ColumnIndex;
            string g = dataGridView1.Columns[column].HeaderText;
            if (g.Equals("Non-Fabric Code"))
            {
                TextBox auto_text = e.Control as TextBox;
                if (auto_text != null)
                {
                    auto_text.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    auto_text.AutoCompleteCustomSource = AutoComplete_fabric_code();
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

        private void dataGridView1_UserDeletedRow_1(object sender, DataGridViewRowEventArgs e)
        {
            double sum_of_qty = 0, sum_of_amount = 0, sum_of_total = 0;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                sum_of_qty += System.Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value);
                sum_of_amount += System.Convert.ToDouble(dataGridView1.Rows[i].Cells[6].Value);
                sum_of_total += System.Convert.ToDouble(dataGridView1.Rows[i].Cells[9].Value);
            }
            textBox5.Text = System.Convert.ToString(Math.Round(sum_of_total, 2));
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            double sum_of_qty = 0, sum_of_amount = 0, sum_of_total = 0;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                sum_of_qty += System.Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value);
                sum_of_amount += System.Convert.ToDouble(dataGridView1.Rows[i].Cells[6].Value);
                sum_of_total += System.Convert.ToDouble(dataGridView1.Rows[i].Cells[9].Value);
            }
            textBox5.Text = System.Convert.ToString(Math.Round(sum_of_total, 2));
        }

       // string header_id;
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    string newvalue;
                    newvalue = (dataGridView1[e.ColumnIndex, e.RowIndex].Value).ToString();
                    MySqlDataAdapter da = new MySqlDataAdapter("select item_name,item_catagory,uom,gst,hsn,unit_price from item where item_code='" + newvalue + "'", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.Rows[e.RowIndex].Cells[1].Value = dt.Rows[0][0].ToString();
                    dataGridView1.Rows[e.RowIndex].Cells[2].Value = dt.Rows[0][1].ToString();
                    dataGridView1.Rows[e.RowIndex].Cells[3].Value = dt.Rows[0][2].ToString();
                    dataGridView1.Rows[e.RowIndex].Cells[7].Value = dt.Rows[0][3].ToString();
                    dataGridView1.Rows[e.RowIndex].Cells[8].Value = dt.Rows[0][4].ToString();
                    dataGridView1.Rows[e.RowIndex].Cells[4].Value = dt.Rows[0][5].ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Choose Correct Non-Fabric code");
                dataGridView1.Rows[e.RowIndex].Cells[1].Value = "";
                dataGridView1.Rows[e.RowIndex].Cells[2].Value = "";
                dataGridView1.Rows[e.RowIndex].Cells[3].Value = "";
                dataGridView1.Rows[e.RowIndex].Cells[4].Value = "";
                dataGridView1.Rows[e.RowIndex].Cells[5].Value = "";
                dataGridView1.Rows[e.RowIndex].Cells[6].Value = "";
                dataGridView1.Rows[e.RowIndex].Cells[7].Value = "";
            }

            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Cells[dataGridView1.Columns[6].Index].Value = System.Convert.ToDouble(row.Cells[dataGridView1.Columns[4].Index].Value) * System.Convert.ToDouble(row.Cells[dataGridView1.Columns[5].Index].Value);
                    row.Cells[dataGridView1.Columns[9].Index].Value = System.Convert.ToDouble(row.Cells[dataGridView1.Columns[6].Index].Value) * (System.Convert.ToDouble(row.Cells[dataGridView1.Columns[7].Index].Value) / 100) + System.Convert.ToDouble(row.Cells[dataGridView1.Columns[6].Index].Value);
                }

                double sum_of_qty = 0, sum_of_amount = 0, sum_of_total = 0;
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    sum_of_qty += System.Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value);
                    sum_of_amount += System.Convert.ToDouble(dataGridView1.Rows[i].Cells[6].Value);
                    sum_of_total += System.Convert.ToDouble(dataGridView1.Rows[i].Cells[9].Value);
                }

                textBox5.Text = System.Convert.ToString(Math.Round(sum_of_total, 2));
            }
            catch
            {

            }
        }
    }
}
