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

namespace Snap.costing
{
    public partial class emb_mat_consumption : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["$safeprojectname$.Properties.Settings.erpConnectionString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(constring);
        public emb_mat_consumption()
        {
            InitializeComponent();
        }

        private void emb_mat_consumption_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }

        public AutoCompleteStringCollection AutoComplete_item_Code()
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

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            int column = dataGridView1.CurrentCell.ColumnIndex;
            string g = dataGridView1.Columns[column].HeaderText;
            if (g.Equals("ITEM CODE"))
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
                    MySqlDataAdapter da = new MySqlDataAdapter("select item_name,item_catagory,uom,last_purchase_price from item where item_code='" + newvalue + "'", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.Rows[e.RowIndex].Cells[1].Value = dt.Rows[0][0].ToString();
                    dataGridView1.Rows[e.RowIndex].Cells[2].Value = dt.Rows[0][1].ToString();
                    dataGridView1.Rows[e.RowIndex].Cells[3].Value = dt.Rows[0][3].ToString();
                    dataGridView1.Rows[e.RowIndex].Cells[4].Value = dt.Rows[0][2].ToString();
                }

                
                
            }
            catch (Exception)
            {
                MessageBox.Show("Choose Correct Item code");
                dataGridView1.Rows[e.RowIndex].Cells[1].Value = "";
                dataGridView1.Rows[e.RowIndex].Cells[2].Value = "";
                dataGridView1.Rows[e.RowIndex].Cells[3].Value = "0.00";
                dataGridView1.Rows[e.RowIndex].Cells[4].Value = "";                
            }

            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Cells[dataGridView1.Columns[7].Index].Value = System.Convert.ToDouble(row.Cells[dataGridView1.Columns[5].Index].Value) * (System.Convert.ToDouble(row.Cells[dataGridView1.Columns[6].Index].Value) / 100) + System.Convert.ToDouble(row.Cells[dataGridView1.Columns[5].Index].Value);
                    row.Cells[dataGridView1.Columns[8].Index].Value = System.Convert.ToDouble(row.Cells[dataGridView1.Columns[3].Index].Value) * System.Convert.ToDouble(row.Cells[dataGridView1.Columns[7].Index].Value);
                }
                double sum_of_cost = 0;
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    sum_of_cost += System.Convert.ToDouble(dataGridView1.Rows[i].Cells[8].Value);
                }
                textBox7.Text = System.Convert.ToString(Math.Round(sum_of_cost, 2));
                
            }
            catch
            {

            }
            

        }

        private void dataGridView1_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            double sum_of_cost = 0;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                sum_of_cost += System.Convert.ToDouble(dataGridView1.Rows[i].Cells[8].Value);
            }
            textBox7.Text = System.Convert.ToString(Math.Round(sum_of_cost, 2));
            
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            double sum_of_cost = 0;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                sum_of_cost += System.Convert.ToDouble(dataGridView1.Rows[i].Cells[8].Value);
            }
            textBox7.Text = System.Convert.ToString(Math.Round(sum_of_cost, 2));
            
        }

        

        public void fill_emb_master()
        {
            MySqlDataAdapter da = new MySqlDataAdapter("select * from emb_master where id='" + textBox9.Text + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                textBox1.Text = dr["emb_code"].ToString();
                textBox2.Text = dr["emb_type"].ToString();
                textBox3.Text = dr["uom"].ToString();
                richTextBox1.Text = dr["emb_name"].ToString();
            }
        }


        public void fill_data()
        {
            MySqlDataAdapter da = new MySqlDataAdapter("select * from emb_consumption where emb_id='" + textBox9.Text + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                textBox1.Text = dr["emb_code"].ToString();
                textBox2.Text = dr["emb_type"].ToString();
                textBox3.Text = dr["uom"].ToString();                               
                textBox7.Text = dr["mat_cost"].ToString();                
                richTextBox1.Text = dr["emb_name"].ToString();
                richTextBox2.Text = dr["remarks"].ToString();
            }

            MySqlDataAdapter da1 = new MySqlDataAdapter("select * from emb_consumption_line where emb_id='" + textBox9.Text + "'", con);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            foreach(DataRow dr1 in dt1.Rows)
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = dr1["item_code"].ToString();
                dataGridView1.Rows[i].Cells[1].Value = dr1["name"].ToString();
                dataGridView1.Rows[i].Cells[2].Value = dr1["cat"].ToString();
                dataGridView1.Rows[i].Cells[3].Value = dr1["rate"].ToString();
                dataGridView1.Rows[i].Cells[4].Value = dr1["unit"].ToString();
                dataGridView1.Rows[i].Cells[5].Value = dr1["qty"].ToString();
                dataGridView1.Rows[i].Cells[6].Value = dr1["wastage"].ToString();
                dataGridView1.Rows[i].Cells[7].Value = dr1["final_qty"].ToString();
                dataGridView1.Rows[i].Cells[8].Value = dr1["amt"].ToString();
                dataGridView1.Rows[i].Cells[9].Value = dr1["remarks"].ToString();
            }


        }

        private void textBox5_Layout(object sender, LayoutEventArgs e)
        {

        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox7.Text=="")
            {
                MessageBox.Show("Enter Consumption");
            }
            else
            {
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into emb_consumption_header (emb_id,remarks,mat_cost) Values ('" + textBox9.Text + "','" + richTextBox2.Text + "','" + textBox7.Text + "')";
                cmd.ExecuteNonQuery();

                for (int j = 0; j < dataGridView1.Rows.Count - 1; j++)
                {
                    MySqlCommand cmd1 = con.CreateCommand();
                    cmd1.CommandType = CommandType.Text;
                    cmd1.CommandText = "insert into emb_consumption_line (emb_id,item_code,name,cat,rate,unit,qty,wastage,final_qty,amt,remarks) Values ('" + textBox9.Text + "','" + dataGridView1.Rows[j].Cells[0].Value + "','" + dataGridView1.Rows[j].Cells[1].Value + "','" + dataGridView1.Rows[j].Cells[2].Value + "','" + dataGridView1.Rows[j].Cells[3].Value + "','" + dataGridView1.Rows[j].Cells[4].Value + "','" + dataGridView1.Rows[j].Cells[5].Value + "','" + dataGridView1.Rows[j].Cells[6].Value + "','" + dataGridView1.Rows[j].Cells[7].Value + "','" + dataGridView1.Rows[j].Cells[8].Value + "','" + dataGridView1.Rows[j].Cells[9].Value + "')";
                    cmd1.ExecuteNonQuery();
                }

                MySqlCommand cmd2 = con.CreateCommand();
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "update emb_master set mat_rate='" + textBox7.Text + "' where id='" + textBox9.Text + "'";
                cmd2.ExecuteNonQuery();

                MessageBox.Show("Consumption Entered");
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox7.Text == "")
            {
                MessageBox.Show("Enter Consumption");
            }

            else
            {
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from emb_consumption_header where emb_id='"+textBox9.Text+"'";
                cmd.ExecuteNonQuery();

                MySqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "insert into emb_consumption_header (emb_id,remarks,mat_cost) Values ('" + textBox9.Text + "','" + richTextBox2.Text + "','" + textBox7.Text + "')";
                cmd1.ExecuteNonQuery();

                MySqlCommand cmd2 = con.CreateCommand();
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "delete from emb_consumption_line where emb_id='" + textBox9.Text + "'";
                cmd2.ExecuteNonQuery();

                for (int j = 0; j < dataGridView1.Rows.Count - 1; j++)
                {
                    MySqlCommand cmd3 = con.CreateCommand();
                    cmd3.CommandType = CommandType.Text;
                    cmd3.CommandText = "insert into emb_consumption_line (emb_id,item_code,name,cat,rate,unit,qty,wastage,final_qty,amt,remarks) Values ('" + textBox9.Text + "','" + dataGridView1.Rows[j].Cells[0].Value + "','" + dataGridView1.Rows[j].Cells[1].Value + "','" + dataGridView1.Rows[j].Cells[2].Value + "','" + dataGridView1.Rows[j].Cells[3].Value + "','" + dataGridView1.Rows[j].Cells[4].Value + "','" + dataGridView1.Rows[j].Cells[5].Value + "','" + dataGridView1.Rows[j].Cells[6].Value + "','" + dataGridView1.Rows[j].Cells[7].Value + "','" + dataGridView1.Rows[j].Cells[8].Value + "','" + dataGridView1.Rows[j].Cells[9].Value + "')";
                    cmd3.ExecuteNonQuery();
                }

                MySqlCommand cmd4 = con.CreateCommand();
                cmd4.CommandType = CommandType.Text;
                cmd4.CommandText = "update emb_master set mat_rate='" + textBox7.Text + "' where id='" + textBox9.Text + "'";
                cmd4.ExecuteNonQuery();

                MessageBox.Show("Consumption Updated");
                this.Close();
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
